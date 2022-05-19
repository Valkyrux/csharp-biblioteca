using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca
{
    internal class Documento
    {
        protected string titolo;
        public string Titolo { get => this.titolo; }
        protected List<Persona> autori;
        public List<Persona> Autori { get => this.autori; }
        protected int anno;
        public int Anno { get => this.anno; }
        public enum Categoria { storia, matematica, informatica, arte, musica, scienze }
        public enum Stato { in_prestito, disponibile, in_consegna, in_riparazione }
        
        public Documento(string titolo, List<Persona> autori, int anno)
        {
            this.titolo = titolo;
            this.autori = autori;
            this.anno = anno;
        }

        public virtual string Write()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (Persona persona in this.autori)
            {
                stringBuilder.Append(persona.ToString());
                stringBuilder.Append(", ");
            }
            return String.Format("TITOLO: {0}\nAUTORE: {1}\nANNO: {2}\n", this.titolo, stringBuilder.ToString(), this.anno);
        }
        public virtual string getCodice()
        {
            return "NULL";
        }

        public virtual string getType()
        {
            return "DOCUMENTO";
        }
    }
}
