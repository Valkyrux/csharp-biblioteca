using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca
{
    internal class Persona
    {
        public string nome { get; set; }
        public string cognome { get; set; }

        public Persona(string nome, string cognome)
        {
            this.nome = nome;
            this.cognome = cognome;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", this.nome, this.cognome);
        }
    }
}
