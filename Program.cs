﻿using System;

namespace csharp_biblioteca
{
    internal class Program
    {
        static void showMenu()
        {
            Console.WriteLine("*********************************");
            Console.WriteLine("*     1 : Aggiungi Utente       *");
            Console.WriteLine("*       2 : Cerca Utente        *");
            Console.WriteLine("*     3 : Cerca Documento       *");
            Console.WriteLine("*     4 : Aggiungi Prestito     *");
            Console.WriteLine("*         h : Mostra menu       *");
            Console.WriteLine("*     Premi Invio per Uscire    *");
            Console.WriteLine("*********************************");
            Console.WriteLine("\n@-------------------------------@");
            Console.WriteLine("|        Cosa vuoi fare?        |");
            Console.WriteLine("@-------------------------------@\n");
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
                    Console.WriteLine("\nCosa vuoi Fare? (premi h per mostrare il MENU, INVIO per USCIRE)");
                    break;
                case "2":
                    Console.WriteLine("\n****** CERCA UTENTE ******\n");
                    Console.WriteLine("Inserisci Nome");
                    nome = Console.ReadLine();
                    Console.WriteLine("Inserisci Cognome");
                    cognome = Console.ReadLine();
                    Console.WriteLine("Inserisci e mail");
                    eMail = Console.ReadLine();
                    Console.WriteLine(miaBiblioteca.WriteUtente(miaBiblioteca.KeyGenerator(nome, cognome, eMail)));
                    Console.WriteLine("\nCosa vuoi Fare? (premi h per mostrare il MENU, INVIO per USCIRE)");
                    break;
                case "3":
                    Console.WriteLine("\n****** CERCA DOCUMENTO ******\n");
                    Console.WriteLine("Inserisci Titolo");
                    string? titolo = Console.ReadLine();
                    List<Documento>risultatoFiltro = miaBiblioteca.FiltraPerTitolo(titolo);
                    Console.WriteLine("Risutati trovati: {0}", risultatoFiltro.Count());
                    risultatoFiltro.ForEach(p => Console.WriteLine("{0}", p.Write()));
                    Console.WriteLine("\nCosa vuoi Fare? (premi h per mostrare il MENU, INVIO per USCIRE)");
                    break;
                case "h":
                    showMenu();
                    break;
                default: 
                    Console.WriteLine("Operazione NON valida (premi h per visualizzare la lista di operazioni)");
                    break;
            }
        }
        static void Main(string[] args)
        {
            Biblioteca miaBiblioteca = new Biblioteca("Biblioteca Digitale");
            miaBiblioteca.AddUtente("Giuseppe", "Savoia", "email@email.com", "12345", "3285754639");
            miaBiblioteca.AddUtente("Giuseppe", "savoia", "email@email.com", "12345", "3285754639");
            miaBiblioteca.AddLibro("ciao", "Paolo", 2022, "cuufaigi", 2, 0);
            miaBiblioteca.AddLibro("ciao", "Salvo", 2022, "cuufaigi", 2, 0);
            miaBiblioteca.AddLibro("ciao", "Enrico", 2022, "cuufaigi", 2, 0);
            Console.WriteLine(miaBiblioteca.Documenti[0].Write());

            Console.WriteLine("Benvenuto in '{0}'\n", miaBiblioteca.Nome.ToUpper());
            showMenu();
            
            string? sChooice = Console.ReadLine();

            while (sChooice != "") {
                GestoreOperazioni(miaBiblioteca, sChooice);
                sChooice = Console.ReadLine();
            }
        }
    }
}