using System;

namespace encuestasgym.Models
{
    public class RespuestaPersonal
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int Edad { get; set; }
        public string EnfermedadCronica { get; set; }
        public string RecomendadoMedico { get; set; }
        public DateTime Fecha { get; set; }
    }
}
