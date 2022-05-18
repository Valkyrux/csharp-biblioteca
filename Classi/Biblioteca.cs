using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca
{
    internal class Biblioteca
    {
        private string nome;
        public List<Documento> Documenti;
        /*
        public List<Prestito> Prestito;
        */

        private Dictionary<string, Utente> Utenti;

        public Biblioteca(string nome)
        {
            this.nome = nome;
            this.Utenti = new Dictionary<string, Utente>();
            this.Documenti = new List<Documento>();
        }

        public void AddUtente(string nome, string cognome, string email, string password, string telefono)
        {
            try
            {
                Utente nuovoUtente = new Utente(nome, cognome, email, password, telefono);
                this.Utenti.Add(nuovoUtente.KeyGenerator(), nuovoUtente);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void AddLibro(string titolo, string autore, int anno, string ISBN, int categoria, int stato)
        {
            try
            {
                Libro nuovoLibro = new Libro(titolo, autore, anno, ISBN, categoria, stato);
                Documenti.Add(nuovoLibro);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
