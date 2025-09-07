using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using encuestasgym.Models;
using MySql.Data.MySqlClient;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace encuestasgym.Controllers
{
    public class AccountController : Controller
    {
        private readonly IConfiguration _configuration;
        public AccountController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            string? connStr = _configuration.GetConnectionString("DefaultConnection");
            if (string.IsNullOrEmpty(connStr))
            {
                ViewBag.Error = "No se encontró la cadena de conexión a la base de datos. Contacta al administrador.";
                return View();
            }
            using (var conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT * FROM usuarios WHERE email = @email AND password = @password";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@password", password);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Autenticación exitosa
                            TempData["UsuarioId"] = reader["id"];
                            TempData["NombreUsuario"] = reader["nombre"];
                            HttpContext.Session.SetInt32("UsuarioId", Convert.ToInt32(reader["id"]));
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            ViewBag.Error = "Usuario o contraseña incorrectos, o el usuario no existe. Si no tienes una cuenta, <a href='/Account/Register' style='color:#007bff;font-weight:bold;'>regístrate aquí</a>.";
                            return View();
                        }
                    }
                }
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Usuario usuario)
        {
            if (!ModelState.IsValid)
                return View(usuario);

            string? connStr = _configuration.GetConnectionString("DefaultConnection");
            if (string.IsNullOrEmpty(connStr))
            {
                ViewBag.Error = "No se encontró la cadena de conexión a la base de datos. Contacta al administrador.";
                return View();
            }
            using (var conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string query = "INSERT INTO usuarios (nombre, email, password, rol) VALUES (@nombre, @email, @password, @rol)";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nombre", usuario.Nombre);
                    cmd.Parameters.AddWithValue("@email", usuario.Email);
                    cmd.Parameters.AddWithValue("@password", usuario.Password);
                    cmd.Parameters.AddWithValue("@rol", usuario.Rol);
                    cmd.ExecuteNonQuery();
                }
            }
            return RedirectToAction("Login");
        }
        [HttpPost]
        public IActionResult Logout()
        {
            TempData.Clear();
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
