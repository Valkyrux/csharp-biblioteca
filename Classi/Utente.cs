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
        public string password;
        public string? telefono;

        public Utente(string nome, string cognome, string email, string password, string telefono) : base(nome, cognome)
        {
            this.email = email;
            this.password = password;
            this.telefono = telefono;
        }
    }
}
