using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using encuestasgym.Models;
using System.Collections.Generic;

namespace encuestasgym.Controllers
{
    public class AdminController : Controller
    {
        private readonly IConfiguration _configuration;
        public AdminController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // Página principal de administración de clientes
        public IActionResult Clientes()
        {
            string? connStr = _configuration.GetConnectionString("DefaultConnection");
            var clientes = new List<Usuario>();
            if (!string.IsNullOrEmpty(connStr))
            {
                using (var conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string query = "SELECT id, nombre, email, rol FROM usuarios WHERE rol = 'cliente'";
                    using (var cmd = new MySqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            clientes.Add(new Usuario
                            {
                                Id = reader.GetInt32("id"),
                                Nombre = reader.GetString("nombre"),
                                Email = reader.GetString("email"),
                                Rol = reader.GetString("rol"),
                                Password = "" // No mostrar la contraseña
                            });
                        }
                    }
                }
            }
            ViewBag.Clientes = clientes;
            return View();
        }

        // Ver encuestas y recomendaciones de un cliente
        public IActionResult DetalleCliente(int id)
        {
            string? connStr = _configuration.GetConnectionString("DefaultConnection");
            Usuario? cliente = null;
            var encuestas = new List<object>();
            var recomendaciones = new List<object>();
            if (!string.IsNullOrEmpty(connStr))
            {
                using (var conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    // Obtener datos del cliente
                    string queryCliente = "SELECT id, nombre, email, rol FROM usuarios WHERE id = @id";
                    using (var cmd = new MySqlCommand(queryCliente, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                cliente = new Usuario
                                {
                                    Id = reader.GetInt32("id"),
                                    Nombre = reader.GetString("nombre"),
                                    Email = reader.GetString("email"),
                                    Rol = reader.GetString("rol"),
                                    Password = ""
                                };
                            }
                        }
                    }
                    // Obtener encuestas
                    string queryEncuestas = "SELECT tipo_encuesta, datos FROM reportes WHERE usuario_id = @id ORDER BY fecha DESC";
                    using (var cmd = new MySqlCommand(queryEncuestas, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
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
                    // Obtener recomendaciones
                    string queryReco = "SELECT recomendacion_texto, fecha, tipo_encuesta FROM recomendaciones WHERE usuario_id = @id ORDER BY fecha DESC";
                    using (var cmd = new MySqlCommand(queryReco, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                recomendaciones.Add(new {
                                    texto = reader["recomendacion_texto"]?.ToString() ?? "",
                                    fecha = reader["fecha"]?.ToString() ?? "",
                                    tipo = reader["tipo_encuesta"]?.ToString() ?? ""
                                });
                            }
                        }
                    }
                }
            }
            ViewBag.Cliente = cliente;
            ViewBag.Encuestas = encuestas;
            ViewBag.Recomendaciones = recomendaciones;
            return View();
        }

        // Eliminar cliente
    [HttpPost]
    public IActionResult EliminarCliente(int id)
        {
            string? connStr = _configuration.GetConnectionString("DefaultConnection");
            if (!string.IsNullOrEmpty(connStr))
            {
                using (var conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    // Eliminar recomendaciones del usuario
                    string deleteReco = "DELETE FROM recomendaciones WHERE usuario_id = @id";
                    using (var cmd = new MySqlCommand(deleteReco, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                    // Eliminar reportes/encuestas del usuario
                    string deleteReportes = "DELETE FROM reportes WHERE usuario_id = @id";
                    using (var cmd = new MySqlCommand(deleteReportes, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                    // Eliminar respuestas de nutrición
                    string deleteNutricion = "DELETE FROM respuestas_nutricion WHERE usuario_id = @id";
                    using (var cmd = new MySqlCommand(deleteNutricion, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                    // Eliminar respuestas de ejercicio
                    string deleteEjercicio = "DELETE FROM respuestas_ejercicio WHERE usuario_id = @id";
                    using (var cmd = new MySqlCommand(deleteEjercicio, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                    // Eliminar respuestas personales
                    string deletePersonales = "DELETE FROM respuestas_personales WHERE usuario_id = @id";
                    using (var cmd = new MySqlCommand(deletePersonales, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                    // Eliminar usuario
                    string deleteUsuario = "DELETE FROM usuarios WHERE id = @id";
                    using (var cmd = new MySqlCommand(deleteUsuario, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            return RedirectToAction("Clientes");
        }

        // Editar cliente (solo nombre y email)
        [HttpPost]
        public IActionResult EditarCliente(int id, string nombre, string email)
        {
            string? connStr = _configuration.GetConnectionString("DefaultConnection");
            if (!string.IsNullOrEmpty(connStr))
            {
                using (var conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string update = "UPDATE usuarios SET nombre = @nombre, email = @email WHERE id = @id";
                    using (var cmd = new MySqlCommand(update, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            return RedirectToAction("Clientes");
        }
    }
}
