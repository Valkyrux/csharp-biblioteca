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
        public string Titolo { get => this.titolo;}
        protected string autore;
        protected int anno;
        public enum Categoria { storia, matematica, informatica, arte, musica, scienze }
        public enum Stato { in_presito, disponibile, in_consegna, in_riparazione }
        
        public Documento(string titolo, string autore, int anno)
        {
            this.titolo = titolo;
            this.autore = autore;
            this.anno = anno;
        }

        public virtual string Write()
        {
            return String.Format("TITOLO: {0}\nAUTORE: {1}\nANNO: {2}\n", this.titolo, this.autore, this.anno);
        }
    }
}
