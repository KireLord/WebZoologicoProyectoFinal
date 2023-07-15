namespace WebZoologico.Models
{
    public class AnimalesZoologico
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Especie { get; set; }
        public string Descripcion { get; set; }
        public string FotoPath { get; set; }

        // Otros campos relacionados con los animales del zoológico

        // Constructor por defecto
        public AnimalesZoologico()
        {
        }

        // Constructor con parámetros para facilitar la creación de instancias
        public AnimalesZoologico(string nombre, string especie, string descripcion, string fotoPath)
        {
            Nombre = nombre;
            Especie = especie;
            Descripcion = descripcion;
            FotoPath = fotoPath;
        }
    }
}
