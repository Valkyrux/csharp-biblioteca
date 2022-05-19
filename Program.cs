using System;
using System.IO;

namespace csharp_biblioteca
{
    internal class Program
    {
        static void showMenu()
        {
            Console.WriteLine("**********************************");
            Console.WriteLine("*      1 : Aggiungi Utente       *");
            Console.WriteLine("*        2 : Cerca Utente        *");
            Console.WriteLine("*      3 : Cerca Documento       *");
            Console.WriteLine("*      4 : Aggiungi Prestito     *");
            Console.WriteLine("*       help : Mostra menu       *");
            Console.WriteLine("*      Premi Invio per Uscire    *");
            Console.WriteLine("**********************************");
            Console.WriteLine("\n@--------------------------------@");
            Console.WriteLine("|         Cosa vuoi fare?        |");
            Console.WriteLine("@--------------------------------@\n");
        }

        static void callToAction()
        {
            Console.WriteLine("\n@------------------------------------------------------------------------@");
            Console.WriteLine("|  Cosa vuoi Fare? (digita help per mostrare il MENU, INVIO per USCIRE)  |");
            Console.WriteLine("@------------------------------------------------------------------------@\n");
        }

        static void GestoreOperazioni(Biblioteca miaBiblioteca, string? sOperazione)
        {
            switch (sOperazione)
            {
                case "1":
                    Console.WriteLine("\n****** AGGIUNGI UTENTE ******\n");
                    Console.WriteLine("-> Inserisci Nome");
                    string nome = Console.ReadLine();
                    Console.WriteLine("-> Inserisci Cognome");
                    string cognome = Console.ReadLine();
                    Console.WriteLine("-> Inserisci e mail");
                    string eMail = Console.ReadLine();
                    Console.WriteLine("-> Inserisci Password");
                    string password = Console.ReadLine();
                    Console.WriteLine("-> Inserisci Numero di telefono");
                    string numeroTelefono = Console.ReadLine();
                    Console.WriteLine("_____________________________________");
                    if (miaBiblioteca.AddUtente(nome, cognome, eMail, password, numeroTelefono))
                    {
                        Console.WriteLine("!!!  Utente Aggiunto con successo  !!!");
                    };
                    callToAction();
                    break;
                case "2":
                    Console.WriteLine("\n****** CERCA UTENTE ******\n");
                    Console.WriteLine("-> Inserisci Nome");
                    nome = Console.ReadLine();
                    Console.WriteLine("-> Inserisci Cognome");
                    cognome = Console.ReadLine();
                    Console.WriteLine("-> Inserisci e mail");
                    eMail = Console.ReadLine();
                    Console.WriteLine("_____________________________________");
                    Console.WriteLine(miaBiblioteca.WriteUtente(miaBiblioteca.KeyGenerator(nome, cognome, eMail)));
                    callToAction();
                    break;
                case "3":
                    Console.WriteLine("\n****** CERCA DOCUMENTO ******\n");
                    Console.WriteLine("  -  Digita 1: Cerca per Titolo\n  -  Digita 2: Cerca per Codice\n  -  Qualsiasi altro input per uscire");
                    string searchChooice = Console.ReadLine();
                    switch (searchChooice)
                    {
                        case "1":
                            Console.WriteLine("-> Inserisci Titolo");
                            string? titolo = Console.ReadLine();
                            List<Documento>risultatoFiltro = miaBiblioteca.FiltraPerTitolo(titolo);
                            Console.WriteLine("Risutati trovati: {0}", risultatoFiltro.Count());
                            risultatoFiltro.ForEach(p => Console.WriteLine("{0}", p.Write()));
                            
                            break;
                        case "2":
                            Console.WriteLine("-> Inserisci Codice");
                            string? codice = Console.ReadLine();
                            risultatoFiltro = miaBiblioteca.FiltraPerCodice(codice);
                            Console.WriteLine("Risutati trovati: {0}", risultatoFiltro.Count());
                            risultatoFiltro.ForEach(p => Console.WriteLine("{0}", p.Write()));
                            break;
                        default:
                            Console.WriteLine("USCITA");
                            break;
                    }
                    callToAction();
                    break;
                case "help":
                    showMenu();
                    break;
                case "":
                    Console.WriteLine("USCITA");
                    break;
                default: 
                    Console.WriteLine("Operazione NON valida (premi h per visualizzare la lista di operazioni)");
                    break;
            }
        }
        static void Main(string[] args)
        {
            Biblioteca miaBiblioteca = new Biblioteca("Biblioteca Digitale");

            string fileName = "lista_utenti.txt";
            if (File.Exists(fileName))
            {
                string[] ListaUtentiDaFile = File.ReadAllLines(fileName);

                Console.WriteLine(ListaUtentiDaFile.Length);

  
                for (int i = 0; i < ListaUtentiDaFile.Length; i += 5)
                {
                    miaBiblioteca.AddUtente(ListaUtentiDaFile[i], ListaUtentiDaFile[i + 1], ListaUtentiDaFile[i + 2], ListaUtentiDaFile[i + 3], ListaUtentiDaFile[i + 4]);
                }
            }
            else
            {
                miaBiblioteca.AddUtente("Giuseppe", "Savoia", "email@email.com", "12345", "3285754639");
            }

            miaBiblioteca.AddLibro("ciao", new List<Persona> { new Persona("ciao" ,"pippo"), new Persona("ciao", "ciro") }, 2022, "cuufaigi", 0, 1000, 0);
            miaBiblioteca.AddLibro("ciao", new List<Persona> { new Persona("Leggistringhe", "Intero"), new Persona("Piero", "Sortpagine") }, 2022, "cuufaigi", 0, 1000, 0);
            miaBiblioteca.AddLibro("ciao", new List<Persona> { new Persona("Piero", "Sortpagine") }, 2022, "cuufaigi", 0, 1000, 0);

            Console.WriteLine("Benvenuto in '{0}'\n", miaBiblioteca.Nome.ToUpper());
            showMenu();

            string? sChooice;
            bool checkValue = true;
            while (checkValue) {
                sChooice = Console.ReadLine();
                GestoreOperazioni(miaBiblioteca, sChooice);
                if(sChooice == "")
                {
                    try
                    {
                        StreamWriter streamWriter = File.CreateText(fileName);
                        foreach (string? elemento in miaBiblioteca.DatiUtentiDaSalvare())
                        {
                            streamWriter.WriteLine(elemento);
                        }
                        streamWriter.Close();
                        checkValue = false;
                    }
                    catch
                    {
                        Console.WriteLine("Impossibile al momento salvare le modifiche.\n-> digita exit per uscire\n-> qualisiasi altra cosa per tornare al menu");
                        string? errorExitHandler = Console.ReadLine();
                        if(errorExitHandler == "exit")
                        {
                            checkValue = false;
                        }
                        else
                        {
                            showMenu();
                        }
                    }
                }
            }
        }
    }
}