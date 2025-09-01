namespace encuestasgym.Models
{
    public class Recomendacion
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string TipoEncuesta { get; set; } = "";
        public string RecomendacionTexto { get; set; } = "";
        public DateTime Fecha { get; set; }
    }
}
