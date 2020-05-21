using System;
using System.IO;
using KitapEvi.Library;

namespace KitapEvi.Uygulamasi
{
    class Program
    {
        static void Main(string[] args)
        {
            char cevap = 'e';
            do
            {
                Console.Clear();
                Menu.BaslangicMenusu();
                cevap = Menu.TekrarMenusu();
            } while (cevap == 'e');
        }
    }
}