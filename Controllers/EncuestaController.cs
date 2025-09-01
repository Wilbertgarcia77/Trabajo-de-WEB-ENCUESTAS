using Microsoft.AspNetCore.Mvc;

namespace encuestasgym.Controllers
{
    public class EncuestaController : Controller
    {
        private readonly IConfiguration _configuration;
        public EncuestaController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public IActionResult Nutricion()
        {
            return View();
        }

    [HttpPost]
    public async Task<IActionResult> Nutricion(string planAlimenticio, string restriccionAlimentaria, int comidasPorDia, string suplementos, double aguaDia, string alergias)
        {
            int usuarioId = HttpContext.Session.GetInt32("UsuarioId") ?? 0;
            if (usuarioId <= 0)
            {
                TempData["ErrorEncuesta"] = "No se pudo identificar el usuario. Por favor inicia sesión antes de responder la encuesta.";
                return RedirectToAction("Nutricion");
            }
            // Validar que el usuario existe en la tabla usuarios
            string? connStr = _configuration.GetConnectionString("DefaultConnection");
            using (var conn = new MySql.Data.MySqlClient.MySqlConnection(connStr))
            {
                conn.Open();
                string userCheck = "SELECT COUNT(*) FROM usuarios WHERE id = @usuario_id";
                using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(userCheck, conn))
                {
                    cmd.Parameters.AddWithValue("@usuario_id", usuarioId);
                    var exists = Convert.ToInt32(cmd.ExecuteScalar());
                    if (exists == 0)
                    {
                        TempData["ErrorEncuesta"] = "El usuario no existe. Por favor regístrate antes de responder la encuesta.";
                        return RedirectToAction("Nutricion");
                    }
                }
            }

            _ = _configuration.GetConnectionString("DefaultConnection");
            if (string.IsNullOrEmpty(connStr))
            {
                TempData["ErrorEncuesta"] = "No se encontró la cadena de conexión a la base de datos. Contacta al administrador.";
                return RedirectToAction("Nutricion");
            }
            using (var conn = new MySql.Data.MySqlClient.MySqlConnection(connStr))
            {
                conn.Open();
                string query = "INSERT INTO respuestas_nutricion (usuario_id, plan_alimenticio, restriccion_alimentaria, comidas_por_dia, suplementos, agua_dia, alergias) VALUES (@usuario_id, @plan, @restriccion, @comidas, @suplementos, @agua, @alergias)";
                using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@usuario_id", usuarioId);
                    cmd.Parameters.AddWithValue("@plan", planAlimenticio);
                    cmd.Parameters.AddWithValue("@restriccion", restriccionAlimentaria);
                    cmd.Parameters.AddWithValue("@comidas", comidasPorDia);
                    cmd.Parameters.AddWithValue("@suplementos", suplementos ?? "");
                    cmd.Parameters.AddWithValue("@agua", aguaDia);
                    cmd.Parameters.AddWithValue("@alergias", alergias ?? "");
                    cmd.ExecuteNonQuery();
                }

                // Guardar en reportes
                string datosJson = $"{{'planAlimenticio':'{planAlimenticio}','restriccionAlimentaria':'{restriccionAlimentaria}','comidasPorDia':{comidasPorDia},'suplementos':'{suplementos}','aguaDia':{aguaDia},'alergias':'{alergias}'}}".Replace('"', '\"');
                string reporteQuery = "INSERT INTO reportes (usuario_id, tipo_encuesta, datos) VALUES (@usuario_id, @tipo, @datos)";
                using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(reporteQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@usuario_id", usuarioId);
                    cmd.Parameters.AddWithValue("@tipo", "Nutricion");
                    cmd.Parameters.AddWithValue("@datos", datosJson);
                    cmd.ExecuteNonQuery();
                }
            }
            // Llamar a OpenAI para recomendación nutricional
            string prompt = $"Soy un nutricionista. Dame una recomendación personalizada para este usuario: Plan alimenticio: {planAlimenticio}, Restricción: {restriccionAlimentaria}, Comidas por día: {comidasPorDia}, Suplementos: {suplementos}, Agua al día: {aguaDia}, Alergias: {alergias}";
            string recomendacion = await Helpers.OpenAIHelper.ObtenerRecomendacion(prompt);
            TempData["EncuestaGuardada"] = true;
            TempData["ResultadoOpenAI"] = recomendacion;
            return RedirectToAction("Nutricion");
        }
        public IActionResult Ejercicio()
        {
            return View();
        }
            [HttpPost]
            public async Task<IActionResult> Ejercicio(int diasEjercicio, string tipoEjercicio, string condicionFisica, string objetivo, int tiempoSesion, string preferenciaGrupo)
            {
                int usuarioId = HttpContext.Session.GetInt32("UsuarioId") ?? 0;
                string? connStr = _configuration.GetConnectionString("DefaultConnection");
                if (string.IsNullOrEmpty(connStr))
                {
                    TempData["ErrorEncuesta"] = "No se encontró la cadena de conexión a la base de datos. Contacta al administrador.";
                    return RedirectToAction("Ejercicio");
                }
                // Validar que el usuario existe en la tabla usuarios
                using (var conn = new MySql.Data.MySqlClient.MySqlConnection(connStr))
                {
                    conn.Open();
                    string userCheck = "SELECT COUNT(*) FROM usuarios WHERE id = @usuario_id";
                    using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(userCheck, conn))
                    {
                        cmd.Parameters.AddWithValue("@usuario_id", usuarioId);
                        var exists = Convert.ToInt32(cmd.ExecuteScalar());
                        if (exists == 0)
                        {
                            TempData["ErrorEncuesta"] = "El usuario no existe. Por favor regístrate antes de responder la encuesta.";
                            return RedirectToAction("Ejercicio");
                        }
                    }
                }
                using (var conn = new MySql.Data.MySqlClient.MySqlConnection(connStr))
                {
                    conn.Open();
                    string query = "INSERT INTO respuestas_ejercicio (usuario_id, dias_ejercicio, tipo_ejercicio, condicion_fisica, objetivo, tiempo_sesion, preferencia_grupo) VALUES (@usuario_id, @dias, @tipo, @condicion, @objetivo, @tiempo, @grupo)";
                    using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@usuario_id", usuarioId);
                        cmd.Parameters.AddWithValue("@dias", diasEjercicio);
                        cmd.Parameters.AddWithValue("@tipo", tipoEjercicio);
                        cmd.Parameters.AddWithValue("@condicion", condicionFisica);
                        cmd.Parameters.AddWithValue("@objetivo", objetivo ?? "");
                        cmd.Parameters.AddWithValue("@tiempo", tiempoSesion);
                        cmd.Parameters.AddWithValue("@grupo", preferenciaGrupo ?? "");
                        cmd.ExecuteNonQuery();
                    }

                    // Guardar en reportes
                    string datosJson = $"{{'diasEjercicio':{diasEjercicio},'tipoEjercicio':'{tipoEjercicio}','condicionFisica':'{condicionFisica}','objetivo':'{objetivo}','tiempoSesion':{tiempoSesion},'preferenciaGrupo':'{preferenciaGrupo}'}}".Replace('"', '\"');
                    string reporteQuery = "INSERT INTO reportes (usuario_id, tipo_encuesta, datos) VALUES (@usuario_id, @tipo, @datos)";
                    using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(reporteQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@usuario_id", usuarioId);
                        cmd.Parameters.AddWithValue("@tipo", "Ejercicio");
                        cmd.Parameters.AddWithValue("@datos", datosJson);
                        cmd.ExecuteNonQuery();
                    }
                }
                // Llamar a OpenAI para recomendación de ejercicio
                string prompt = $"Soy entrenador personal. Dame una recomendación personalizada para este usuario: Días de ejercicio: {diasEjercicio}, Tipo: {tipoEjercicio}, Condición física: {condicionFisica}, Objetivo: {objetivo}, Tiempo por sesión: {tiempoSesion}, Preferencia grupo: {preferenciaGrupo}";
                string recomendacion = await Helpers.OpenAIHelper.ObtenerRecomendacion(prompt);
                TempData["EncuestaGuardada"] = true;
                TempData["ResultadoOpenAI"] = recomendacion;
                return RedirectToAction("Ejercicio");
            }
        public IActionResult Personales()
        {
            return View();
        }
            [HttpPost]
            public async Task<IActionResult> Personales(int edad, string enfermedadCronica, string recomendadoMedico, string ocupacion, int horasSueno, string habitos)
            {
                int usuarioId = HttpContext.Session.GetInt32("UsuarioId") ?? 0;
                string? connStr = _configuration.GetConnectionString("DefaultConnection");
                if (string.IsNullOrEmpty(connStr))
                {
                    TempData["ErrorEncuesta"] = "No se encontró la cadena de conexión a la base de datos. Contacta al administrador.";
                    return RedirectToAction("Personales");
                }
                // Validar que el usuario existe en la tabla usuarios
                using (var conn = new MySql.Data.MySqlClient.MySqlConnection(connStr))
                {
                    conn.Open();
                    string userCheck = "SELECT COUNT(*) FROM usuarios WHERE id = @usuario_id";
                    using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(userCheck, conn))
                    {
                        cmd.Parameters.AddWithValue("@usuario_id", usuarioId);
                        var exists = Convert.ToInt32(cmd.ExecuteScalar());
                        if (exists == 0)
                        {
                            TempData["ErrorEncuesta"] = "El usuario no existe. Por favor regístrate antes de responder la encuesta.";
                            return RedirectToAction("Personales");
                        }
                    }
                }
                using (var conn = new MySql.Data.MySqlClient.MySqlConnection(connStr))
                {
                    conn.Open();
                    string query = "INSERT INTO respuestas_personales (usuario_id, edad, enfermedad_cronica, recomendado_medico, ocupacion, horas_sueno, habitos) VALUES (@usuario_id, @edad, @enfermedad, @recomendado, @ocupacion, @horas, @habitos)";
                    using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@usuario_id", usuarioId);
                        cmd.Parameters.AddWithValue("@edad", edad);
                        cmd.Parameters.AddWithValue("@enfermedad", enfermedadCronica);
                        cmd.Parameters.AddWithValue("@recomendado", recomendadoMedico);
                        cmd.Parameters.AddWithValue("@ocupacion", ocupacion ?? "");
                        cmd.Parameters.AddWithValue("@horas", horasSueno);
                        cmd.Parameters.AddWithValue("@habitos", habitos ?? "");
                        cmd.ExecuteNonQuery();
                    }

                    // Guardar en reportes
                    string datosJson = $"{{'edad':{edad},'enfermedadCronica':'{enfermedadCronica}','recomendadoMedico':'{recomendadoMedico}','ocupacion':'{ocupacion}','horasSueno':{horasSueno},'habitos':'{habitos}'}}".Replace('"', '\"');
                    string reporteQuery = "INSERT INTO reportes (usuario_id, tipo_encuesta, datos) VALUES (@usuario_id, @tipo, @datos)";
                    using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(reporteQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@usuario_id", usuarioId);
                        cmd.Parameters.AddWithValue("@tipo", "Personales");
                        cmd.Parameters.AddWithValue("@datos", datosJson);
                        cmd.ExecuteNonQuery();
                    }
                }
                // Lógica especial: aptitud y recomendación
                string prompt = $"Eres un entrenador de gimnasio. Evalúa si este usuario es apto para el gym y recomiendale con que puede empezar y cuantas horas deberia de hacer. Edad: {edad}, Enfermedad crónica: {enfermedadCronica}, Recomendado por médico: {recomendadoMedico}, Ocupación: {ocupacion}, Horas de sueño: {horasSueno}, Hábitos: {habitos}";
                string resultado = await Helpers.OpenAIHelper.ObtenerRecomendacion(prompt);
                TempData["EncuestaGuardada"] = true;
                TempData["ResultadoOpenAI"] = resultado;
                return RedirectToAction("Personales");
            }
    }
}
