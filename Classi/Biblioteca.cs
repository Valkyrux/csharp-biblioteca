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

        public string Nome { get => this.nome; }

        public bool AddUtente(string nome, string cognome, string email, string password, string telefono)
        {
            try
            {
                Utente nuovoUtente = new Utente(nome, cognome, email, password, telefono);
                this.Utenti.Add(KeyGenerator(nuovoUtente), nuovoUtente);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public string KeyGenerator(Utente utente)
        {
            return string.Format("{0};{1};{2}", utente.nome.ToLower(), utente.cognome.ToLower(), utente.email.ToLower());
        }

        public string KeyGenerator(string nome, string cognome, string email)
        {
            return string.Format("{0};{1};{2}", nome.ToLower(),cognome.ToLower(), email.ToLower());
        }

        public string WriteUtente(string key)
        {
            try
            {
                return string.Format("\nNOME: {0}\nCOGNOME: {1}\nEMAIL: {2}\nTELEFONO: {3}\n", this.Utenti[key].nome, this.Utenti[key].cognome, this.Utenti[key].email, this.Utenti[key].telefono);
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        public List<Documento> FiltraPerTitolo(string titolo)
        {
            List<Documento> list = new List<Documento>();
            list = this.Documenti.Where(p => p.Titolo.Contains(titolo)).ToList();
            return list;
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
