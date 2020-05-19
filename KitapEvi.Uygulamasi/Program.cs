using System;
using System.IO;
using KitapEvi.Library;

namespace KitapEvi.Uygulamasi
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string cevap = "";
                Console.WriteLine("Merhabalar Kitabevi Sistemine Hoşgeldiniz \nUygulamayı " + DateTime.Now + " tarihinde çalıştırdın.");
                do {
                Console.WriteLine("\n \n \n \n" + "-----------------------------------------\n" + "1.Kitapevine kitap eklemek \n2.Kitaplığı görüntülemek.");
                Console.WriteLine("\nİşlem Yapmak İçin Rakam Giriniz :");
                char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            KitaplikLib.KitapEkleme();
                            break;
                        case '2':
                            KitaplikLib.KitaplariGoruntule();
                            break;
                        default:
                            Console.WriteLine("Menüde sadece 2 seçenek bulunmaktadır , 1 veya 2 seçeneğini kullanınız.");
                            break;
                    }
                    Console.WriteLine("---------------------------------------\nBaşka işlem yapmak istiyor musunuz ? (e-h)");
                    cevap = Console.ReadLine();
                    Console.Clear();
                } while (cevap == "e");
            }
            catch (Exception hata)
            {
                Console.WriteLine("Lütfen örnekte ki gibi bir kullanım gerçekleştiriniz.'1' - '2'");
            }
        }
    }
}