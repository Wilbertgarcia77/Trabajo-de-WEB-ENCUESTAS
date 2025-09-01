using System;

namespace encuestasgym.Models
{
    public class RespuestaNutricion
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string PlanAlimenticio { get; set; }
        public string RestriccionAlimentaria { get; set; }
        public int ComidasPorDia { get; set; }
        public DateTime Fecha { get; set; }
    }
}
