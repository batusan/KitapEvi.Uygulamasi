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
            try
            {           
                do
                {
                    Console.Clear();
                    Menu.BaslangicMenusu();
                    cevap = Menu.TekrarMenusu();
                } while (cevap == 'e');
            }
            catch (Exception hata)
            {
                Console.WriteLine("Lütfen örnekte ki gibi bir kullanım gerçekleştiriniz.'1' - '2'");
            }
        }
    }
}