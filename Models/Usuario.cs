using Microsoft.AspNetCore.Identity;

namespace TrabalhoASPNet.Models
{
    public class Usuario : IdentityUser
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
    }
}