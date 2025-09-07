using Microsoft.AspNetCore.Mvc;
using encuestasgym.Helpers;
using System.Text.Json;
using MySql.Data.MySqlClient;

namespace encuestasgym.Controllers
{
    public class ResultadosController : Controller
    {
        private readonly IConfiguration _configuration;

        public ResultadosController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // Página principal de resultados
        public async Task<IActionResult> Index()
        {
            int? usuarioId = HttpContext.Session.GetInt32("UsuarioId");
            if (usuarioId == null || usuarioId <= 0)
            {
                ViewBag.Respuestas = "No se pudo identificar el usuario. Por favor inicia sesión.";
                ViewBag.Recomendacion = "";
                ViewBag.Encuestas = new List<object>();
                return View();
            }

            string? connStr = _configuration.GetConnectionString("DefaultConnection");
            if (string.IsNullOrEmpty(connStr))
            {
                ViewBag.Respuestas = "No se encontró la cadena de conexión a la base de datos.";
                ViewBag.Recomendacion = "";
                ViewBag.Encuestas = new List<object>();
                return View();
            }

            string rol = "cliente";
            using (var conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string rolQuery = "SELECT rol FROM usuarios WHERE id = @usuario_id LIMIT 1";
                using (var cmd = new MySqlCommand(rolQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@usuario_id", usuarioId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            rol = reader["rol"]?.ToString() ?? "cliente";
                        }
                    }
                }
            }

            var encuestas = new List<object>();
            using (var conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string query;
                if (rol == "administrador")
                {
                    // El administrador ve todas las encuestas de todos los usuarios
                    query = "SELECT reportes.tipo_encuesta, reportes.datos, usuarios.nombre AS nombre_usuario FROM reportes JOIN usuarios ON reportes.usuario_id = usuarios.id ORDER BY reportes.fecha DESC";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                encuestas.Add(new {
                                    tipo = reader["tipo_encuesta"]?.ToString() ?? "",
                                    datos = reader["datos"]?.ToString() ?? "",
                                    usuario = reader["nombre_usuario"]?.ToString() ?? ""
                                });
                            }
                        }
                    }
                }
                else
                {
                    // El cliente solo ve sus propias encuestas
                    query = "SELECT tipo_encuesta, datos FROM reportes WHERE usuario_id = @usuario_id ORDER BY fecha DESC";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@usuario_id", usuarioId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                encuestas.Add(new {
                                    tipo = reader["tipo_encuesta"]?.ToString() ?? "",
                                    datos = reader["datos"]?.ToString() ?? ""
                                });
                            }
                        }
                    }
                }
            }

            ViewBag.Encuestas = encuestas;
            ViewBag.Recomendacion = "";
            ViewBag.Rol = rol;
            return View();
        }

        // Botón para obtener recomendación
        [HttpPost]
        public async Task<IActionResult> ObtenerRecomendacion(string tipoEncuesta)
        {
            int? usuarioId = HttpContext.Session.GetInt32("UsuarioId");
            if (usuarioId == null || usuarioId <= 0)
            {
                ViewBag.Respuestas = "";
                ViewBag.Recomendacion = "No se pudo identificar el usuario. Por favor inicia sesión.";
                ViewBag.Encuestas = new List<object>();
                return View("Index");
            }

            string? connStr = _configuration.GetConnectionString("DefaultConnection");
            if (string.IsNullOrEmpty(connStr))
            {
                ViewBag.Respuestas = "No se encontró la cadena de conexión a la base de datos.";
                ViewBag.Recomendacion = "";
                ViewBag.Encuestas = new List<object>();
                return View("Index");
            }

            if (string.IsNullOrEmpty(tipoEncuesta))
            {
                ViewBag.Respuestas = "";
                ViewBag.Recomendacion = "Debes seleccionar una encuesta antes de obtener la recomendación.";

                // Volver a cargar encuestas
                var encuestas = new List<object>();
                using (var conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string query = "SELECT tipo_encuesta, datos FROM reportes WHERE usuario_id = @usuario_id ORDER BY fecha DESC";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@usuario_id", usuarioId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                encuestas.Add(new { tipo = reader["tipo_encuesta"]?.ToString() ?? "", datos = reader["datos"]?.ToString() ?? "" });
                            }
                        }
                    }
                }

                ViewBag.Encuestas = encuestas;
                return View("Index");
            }

            // Obtener datos de la encuesta seleccionada
            string datosEncuesta = "";
            using (var conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT datos FROM reportes WHERE usuario_id = @usuario_id AND tipo_encuesta = @tipo LIMIT 1";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@usuario_id", usuarioId);
                    cmd.Parameters.AddWithValue("@tipo", tipoEncuesta);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            datosEncuesta = reader["datos"]?.ToString() ?? "";
                        }
                    }
                }
            }

            // Generar recomendación con OpenAI
            string prompt = $"Soy un entrenador de gimnasio y nutricionista. Dame recomendaciones personalizadas para el siguiente usuario según sus respuestas:\n{datosEncuesta}";
            string recomendacion = await OpenAIHelper.ObtenerRecomendacion(prompt);

            // Guardar recomendación en la base de datos
            using (var conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string insert = "INSERT INTO recomendaciones (usuario_id, tipo_encuesta, recomendacion_texto, fecha) VALUES (@usuario_id, @tipo, @reco, NOW())";
                using (var cmd = new MySqlCommand(insert, conn))
                {
                    cmd.Parameters.AddWithValue("@usuario_id", usuarioId);
                    cmd.Parameters.AddWithValue("@tipo", tipoEncuesta);
                    cmd.Parameters.AddWithValue("@reco", recomendacion);
                    cmd.ExecuteNonQuery();
                }
            }

            // Volver a cargar encuestas
            var encuestas2 = new List<object>();
            using (var conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT tipo_encuesta, datos FROM reportes WHERE usuario_id = @usuario_id ORDER BY fecha DESC";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@usuario_id", usuarioId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            encuestas2.Add(new { tipo = reader["tipo_encuesta"]?.ToString() ?? "", datos = reader["datos"]?.ToString() ?? "" });
                        }
                    }
                }
            }

            ViewBag.Encuestas = encuestas2;
            ViewBag.Recomendacion = recomendacion;
            ViewBag.Respuestas = datosEncuesta;
            return View("Index");
        }
        // Acción para eliminar una encuesta
        [HttpPost]
        public IActionResult EliminarEncuesta(string tipoEncuesta)
        {
            int? usuarioId = HttpContext.Session.GetInt32("UsuarioId");
            if (usuarioId == null || usuarioId <= 0)
            {
                return RedirectToAction("Index");
            }

            string? connStr = _configuration.GetConnectionString("DefaultConnection");
            if (string.IsNullOrEmpty(connStr))
            {
                return RedirectToAction("Index");
            }

            using (var conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string delete = "DELETE FROM reportes WHERE usuario_id = @usuario_id AND tipo_encuesta = @tipo";
                using (var cmd = new MySqlCommand(delete, conn))
                {
                    cmd.Parameters.AddWithValue("@usuario_id", usuarioId);
                    cmd.Parameters.AddWithValue("@tipo", tipoEncuesta);
                    cmd.ExecuteNonQuery();
                }
            }

            return RedirectToAction("Index");
        }
    }
}
