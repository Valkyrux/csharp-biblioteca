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

        private Dictionary<Tuple<string, string, string>, Utente> Utenti;
        public List<string?> DatiUtentiDaSalvare() 
        {
            List<string?> utentiPresenti = new List<string?>();
     
            foreach (var elementoDizionario in this.Utenti)
            {
                utentiPresenti.Add(elementoDizionario.Value.nome);
                utentiPresenti.Add(elementoDizionario.Value.cognome);
                utentiPresenti.Add(elementoDizionario.Value.email);
                utentiPresenti.Add(elementoDizionario.Value.password);
                utentiPresenti.Add(elementoDizionario.Value.telefono);
            }
            Console.WriteLine(String.Format(" ", utentiPresenti));
            return utentiPresenti;         
        }

        public Biblioteca(string nome)
        {
            this.nome = nome;
            this.Utenti = new Dictionary<Tuple<string, string, string>, Utente>();
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
        public Tuple<string, string, string> KeyGenerator(Utente utente)
        {
            return new Tuple<string, string, string>(utente.nome.ToLower(), utente.cognome.ToLower(), utente.email.ToLower());
        }

        public Tuple<string, string, string> KeyGenerator(string nome, string cognome, string email)
        {
            return new Tuple<string, string, string>(nome.ToLower(),cognome.ToLower(), email.ToLower());
        }

        public string WriteUtente(Tuple<string, string, string> key)
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

        public List<Documento> FiltraPerCodice(string codice)
        {
            List<Documento> list = new List<Documento>();

            list = this.Documenti.Where(p => p.getCodice().Contains(codice)).ToList();
            return list;
        }

        public void AddLibro(string titolo, List<Persona> autore, int anno, string ISBN, int categoria, int numeroDiPagine, int stato)
        {
            try
            {
                Libro nuovoLibro = new Libro(titolo, autore, anno, ISBN, categoria, numeroDiPagine, stato);
                Documenti.Add(nuovoLibro);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
