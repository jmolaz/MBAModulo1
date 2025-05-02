using Microsoft.AspNetCore.Identity;

namespace MBAModulo1.Core.Models
{
    public class Vendedor : IdentityUser
    {
        public string? NomeCompleto { get; set; }
    }
}