using System;

namespace encuestasgym.Models
{
    public class RespuestaEjercicio
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int DiasEjercicio { get; set; }
        public string TipoEjercicio { get; set; }
        public string CondicionFisica { get; set; }
        public DateTime Fecha { get; set; }
    }
}
