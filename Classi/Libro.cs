using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca
{
    internal class Libro : Documento
    {
        protected string ISBN;
        public Categoria settore;
        public Stato statoLibro;

        public Libro(string titolo, string autore, int anno, string ISBN, int categoria, int stato) : base(titolo, autore, anno)
        {
            this.ISBN = ISBN;
            settore = (Categoria)categoria;
            statoLibro = (Stato)stato;
        }

        public override string Write()
        {
            return String.Format("*********LIBRO********\n{0}ISBN: {1}\nSETTORE: {2}\nSTATO: {3}\n", base.Write(), this.ISBN, this.settore, this.statoLibro);
        }
    }
}
