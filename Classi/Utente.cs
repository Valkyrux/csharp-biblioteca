using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca
{
    internal class Utente : Persona
    {
        public string email;
        private string password;
        public string? telefono;

        public Utente(string nome, string cognome, string email, string password, string telefono) : base(nome, cognome)
        {
            this.email = email;
            this.password = password;
            this.telefono = telefono;
        }

        public string KeyGenerator()
        {
            return string.Format("{0};{1};{2}", base.nome.ToLower(), base.cognome.ToLower(), this.email.ToLower());
        }
    }
}
