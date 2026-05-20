using Microsoft.AspNetCore.Identity;

namespace GastosPersonales.Entities
{
    public class Usuario : IdentityUser
    {
        public DateTime FechaNacimiento { get; set; }
    }
}
