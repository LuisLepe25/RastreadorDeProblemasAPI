namespace RastreadorDeProblemasAPI.Models.DTO
{
    public class ProblemaDTO
    {
        public int IdProblema { get; set; }
        public string Descripcion { get; set; }
        public int IdProblemaEstatus { get; set; }
        public string ProblemaEstatusNombre { get; set; }
        public string ColorEstatusProblema { get; set; }
        public int IdUsuarioAsignado { get; set; }
        public string UsuarioNombre { get; set; }
        public long IdentificadorAlumno { get; set; }
    }
}
