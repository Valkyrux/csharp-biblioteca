using System;

namespace csharp_biblioteca
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Biblioteca miaBiblioteca = new Biblioteca("Biblioteca Digitale");
            miaBiblioteca.AddUtente("Giuseppe", "Savoia", "email@email.com", "12345", "3285754639");
            miaBiblioteca.AddUtente("Giuseppe", "savoia", "email@email.com", "12345", "3285754639");
            miaBiblioteca.AddLibro("ciao", "Paolo", 2022, "cuufaigi", 2, 0);
            Console.WriteLine(miaBiblioteca.Documenti[0].Write());
        }
    }
}