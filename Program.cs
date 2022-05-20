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
            Console.WriteLine("*     3 : Aggiungi Documento     *");
            Console.WriteLine("*      4 : Cerca Documento       *");
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
                    Console.WriteLine("\n****** AGGIUNGI DOCUMENTO ******\n");
                    Console.WriteLine("  -  Digita 1: aggiungi Libro\n  -  Digita 2: Aggiungi DVD\n  -  Qualsiasi altro input per tornare al menu principale");
                    string? addChoice = Console.ReadLine();
                    switch (addChoice)
                    {
                        case "1":
                            Console.WriteLine("-> Inserisci Titolo");
                            string? titolo = Console.ReadLine();
                            
                            List<Persona> Autori = new List<Persona>();
                            string? autoreNome;
                            string? autoreCognome;
                            bool Continue = true;
                            Console.WriteLine("-> Inserisci Autori");
                            while (Continue)
                            {
                                Console.WriteLine("  -> Inserisci il nome dell'autore");
                                autoreNome = Console.ReadLine();
                                Console.WriteLine("  -> Inserisci il cognome dell'autore");
                                autoreCognome = Console.ReadLine();
                                if (autoreNome != "" && autoreCognome != "" && autoreNome != null && autoreCognome != null)
                                {
                                    Autori.Add(new Persona(autoreNome, autoreCognome));
                                    Console.WriteLine(" autore inserito con successo\n");
                                }
                                else
                                {
                                    Console.WriteLine(" autore non valido\n");
                                }
                                Console.WriteLine("Inserire un altro autore? digita 'SI' per continuare, qualsiasi altro input per passare alla voce successiva");
                                string? inputToContinue = Console.ReadLine();
                                if(inputToContinue != "SI")
                                {
                                   Continue = false;
                                }

                                Console.WriteLine("-> Inserisci Anno");
                                int anno;
                                int.TryParse(Console.ReadLine(), out anno);

                                Console.WriteLine("-> Inserisci ISBN");
                                string? ISBN = Console.ReadLine();

                                Console.WriteLine("-> Inserisci Categoria");
                                string[] categoryArray = Enum.GetNames<Documento.Categoria>();
                                for (int i = 0; i<categoryArray.Length; i++)
                                {
                                    Console.WriteLine(" {0} per {1}", i, categoryArray[i]);
                                }
                                int categoria;
                                int.TryParse(Console.ReadLine(), out categoria);

                                Console.WriteLine("-> Inserisci Numero di Pagine");
                                int numPagine;
                                int.TryParse(Console.ReadLine(), out numPagine);

                                Console.WriteLine("-> Inserisci stato");
                                string[] stateArray = Enum.GetNames<Documento.Stato>();
                                for (int i = 0; i < stateArray.Length; i++)
                                {
                                    Console.WriteLine(" {0} per {1}", i, stateArray[i]);
                                }
                                int stato;
                                int.TryParse(Console.ReadLine(), out stato);
                                try
                                {
                                    miaBiblioteca.AddLibro(titolo, Autori, anno, ISBN, categoria, numPagine, stato);
                                    Console.WriteLine("Libro inserito con successo");
                                }catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                callToAction();

                            }

                            break;
                        case "2":
                            Console.WriteLine("Operazione non implementata, ritorno al menu principale");
                            break;
                        default:
                            Console.WriteLine("Operazione annullata");
                            break;
                    }
                    break;
                case "4":
                    Console.WriteLine("\n****** CERCA DOCUMENTO ******\n");
                    Console.WriteLine("  -  Digita 1: Cerca per Titolo\n  -  Digita 2: Cerca per Codice\n  -  Qualsiasi altro input per tornare al menu principale");
                    string? searchChooice = Console.ReadLine();
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
                        
                    }
                    callToAction();
                    break;
                case "help":
                    showMenu();
                    break;
                case "":
                    Console.WriteLine("A presto!");
                    break;
                default: 
                    Console.WriteLine("Operazione NON valida (digita help per visualizzare la lista di operazioni disponibili)");
                    break;
            }
        }
        static void Main(string[] args)
        {
            Biblioteca miaBiblioteca = new Biblioteca("Biblioteca Digitale");

            string? evPublic = Environment.GetEnvironmentVariable("Public");

            string fileNameUtenti = "lista_utenti.txt";
            string fileNameDocumenti = "lista_documenti.txt";
            string folderName = "\\bool-experis-biblioteca";
            
            string pathToDirectory = evPublic + folderName;
            
            if (!File.Exists(pathToDirectory + "\\config.txt"))
            {
                if (!Directory.Exists(pathToDirectory))
                {
                    Directory.CreateDirectory(pathToDirectory);
                }

                StreamWriter config = new StreamWriter(pathToDirectory + "\\config.txt");
                Console.WriteLine("File di configurazione non presente:\n-> Premi invio per istanziare una configurazione locale\n-> Digita il path per la cartella remota");
                string? pathRemoto = Console.ReadLine();
                if(pathRemoto != "")
                {
                    config.WriteLine("section:config_remota");
                    config.WriteLine(pathRemoto);
                    pathToDirectory = pathRemoto;
                }
                else
                {
                    config.WriteLine("section:config_locale");
                }
                config.Close();
            } else 
            {
                StreamReader readConfig = new StreamReader(pathToDirectory + "\\config.txt");
                if (readConfig.ReadLine() == "section:config_remota")
                {
                    pathToDirectory = readConfig.ReadLine();
                    readConfig.Close();
                }

            }
            fileNameUtenti = pathToDirectory + @"\" + fileNameUtenti;
            fileNameDocumenti = pathToDirectory + @"\" + fileNameDocumenti;
            
        
           
            
            
            if (File.Exists(fileNameUtenti))
            {
                string[] ListaUtentiDaFile = File.ReadAllLines(fileNameUtenti);
  
                for (int i = 0; i < ListaUtentiDaFile.Length; i += 5)
                {
                    miaBiblioteca.AddUtente(ListaUtentiDaFile[i], ListaUtentiDaFile[i + 1], ListaUtentiDaFile[i + 2], ListaUtentiDaFile[i + 3], ListaUtentiDaFile[i + 4]);
                }
            }
            else
            {
                miaBiblioteca.AddUtente("Giuseppe", "Savoia", "email@email.com", "12345", "3285754639");
            }

            if (File.Exists(fileNameDocumenti))
            {
                string[] ListaDocumentiDaFile = File.ReadAllLines(fileNameDocumenti);

                for (int i = 0; i < ListaDocumentiDaFile.Length; i ++)
                {
                    string[] documentoInArray = ListaDocumentiDaFile[i].Split('|');

                    if(documentoInArray[0] == "LIBRO")
                    {
                        List<Persona> autori = new List<Persona>();
                        if (documentoInArray.Length == 8)
                        {
                            string[] autorArray = documentoInArray[7].Split(':');
                            for (int j = 0; j < autorArray.Length; j += 2)
                            {
                                autori.Add(new Persona(autorArray[j], autorArray[j + 1]));
                            }

                        }

                        int anno;
                        int categoria;
                        switch(documentoInArray[4])
                        {
                            case "storia":
                                categoria = 0;
                                break;
                            case "matematica":
                                categoria = 1;
                                break;
                            case "informatica":
                                categoria = 2;
                                break;
                            case "arte":
                                categoria = 3;
                                break;
                            case "musica":
                                categoria = 4;
                                break;
                            case "scienze":
                                categoria = 5;
                                break;
                            default:
                                categoria = 7;
                                break;
                        }
                        
                        int numPagine;
                        
                        int stato;
                        switch (documentoInArray[6])
                        {
                            case "in_prestito":
                                stato = 0;
                                break;
                            case "disponibile":
                                stato = 1;
                                break;
                            case "in_consegna":
                                stato = 2;
                                break;
                            case "in_riparazione":
                                stato = 3;
                                break;
                            default:
                                stato = 4;
                                break;
                        }
                        if (int.TryParse(documentoInArray[2], out anno) && int.TryParse(documentoInArray[5], out numPagine))
                        {
                            miaBiblioteca.AddLibro(documentoInArray[1], autori, anno, documentoInArray[3], categoria, numPagine, stato);
                        }
                    }
                }
            }
            else
            {
                miaBiblioteca.AddLibro("ciao", new List<Persona> { new Persona("ciao" ,"pippo"), new Persona("ciao", "ciro") }, 2022, "cuufaigi", 0, 1000, 0);
                miaBiblioteca.AddLibro("ciao", new List<Persona> { new Persona("Leggistringhe", "Intero"), new Persona("Piero", "Sortpagine") }, 2022, "cuufaigi", 0, 1000, 0);
                miaBiblioteca.AddLibro("ciao", new List<Persona> { new Persona("Piero", "Sortpagine") }, 2022, "cuufaigi", 0, 1000, 0);               
            }

            Console.WriteLine("Benvenuto in '{0}'", miaBiblioteca.Nome.ToUpper());
            Console.WriteLine("{0} utenti registati, {1} documenti totali\n", miaBiblioteca.DatiUtentiDaSalvare().Count()/5, miaBiblioteca.Documenti.Count());
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
                        StreamWriter streamWriterUtenti = File.CreateText(fileNameUtenti);
                        StreamWriter streamWriterDocumenti = File.CreateText(fileNameDocumenti);

                        foreach (string? elemento in miaBiblioteca.DatiUtentiDaSalvare())
                        {
                            streamWriterUtenti.WriteLine(elemento);
                        }

                        foreach (string? documento in miaBiblioteca.DatiDocumentiDaSalvare())
                        {
                            streamWriterDocumenti.WriteLine(documento);
                        }
                        streamWriterUtenti.Close();
                        streamWriterDocumenti.Close();
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