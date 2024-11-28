namespace api_prueba_efecty.Models
{
    public class DataPersona
    {

        public int id { get; set; }
        public string? nombre{ get; set; }
        public string? apellidos { get; set; }
        public int tipoDocumento { get; set; }
        public string?  fechaNacimiento { get; set; }
        public decimal valorGana { get; set; }
        public int estadoCivil { get; set; }

    }
}
