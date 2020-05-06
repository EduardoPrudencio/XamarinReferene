using System;
namespace Octus.Models
{
    public class Usuario
    {
        public Usuario()
        {
        }

        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
    }
}
