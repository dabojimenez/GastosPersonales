namespace GastosPersonales.Entities
{
    public class Category
    {
        public Guid Id { get; set; }
        public required Guid UsuarioId { get; set; }
        public required string Nombre { get; set; }
        public string? Descripción { get; set; }
        public TypeCategory TypeCategory { get; set; }
    }

    public enum TypeCategory
    {
        Ingreso,
        Gasto
    }
}
