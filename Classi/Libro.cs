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
        protected int numeroDiPagine;
        public Categoria settore;
        public Stato statoLibro;

        public Libro(string titolo, List<Persona> autori, int anno, string ISBN, int categoria, int numeroDiPagine, int stato) : base(titolo, autori, anno)
        {
            this.ISBN = ISBN;
            this.numeroDiPagine = numeroDiPagine;
            settore = (Categoria)categoria;
            statoLibro = (Stato)stato;
        }

        public override string Write()
        {
            return String.Format("_____ LIBRO _____\n{0}ISBN: {1}\nSETTORE: {2}\nPAGINE: {3}\nSTATO: {4}\n", base.Write(), this.ISBN, this.settore, this.numeroDiPagine, this.statoLibro);
        }
        public override string getCodice()
        {
            return this.ISBN;
        }
    }
}
