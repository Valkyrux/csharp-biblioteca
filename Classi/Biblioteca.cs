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
        /*
        public List<Documento> Documenti;
        public List<Prestito> Prestito;
        */

        private Dictionary<string, Utente> Utenti;

        public Biblioteca(string nome)
        {
            this.nome = nome;
            this.Utenti = new Dictionary<string, Utente>();
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
    }
}
