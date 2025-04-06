using Microsoft.AspNetCore.Identity;

namespace MBAMODULO1.Models
{
    public class Vendedor : IdentityUser
    {
        public string? NomeCompleto { get; set; }
    }
}