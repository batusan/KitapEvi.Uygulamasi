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
                char cevap = 'a';
                do
                {
                    Console.WriteLine("Merhabalar Kitabevi Sistemine Hoşgeldiniz \nUygulamayı " + DateTime.Now + " tarihinde çalıştırdın.");

                    Console.WriteLine("\n \n \n \n" + "-----------------------------------------\n" + "1.Kitapevine kitap eklemek \n2.Kitaplığı görüntülemek.\n3.Kitaplığı Temizlemek.");
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
                        case '3':
                            KitaplikLib.TxtDosyasiniKaldirma();
                            break;
                        default:
                            Console.WriteLine("Menüde sadece 2 seçenek bulunmaktadır , 1 veya 2 seçeneğini kullanınız.");
                            break;
                    }
                    Console.WriteLine("---------------------------------------\nBaşka işlem yapmak istiyor musunuz ? (e-h)");
                    try
                    {
                        cevap = Convert.ToChar(Console.ReadLine());
                        Console.Clear();
                    }
                    catch (Exception hata)
                    {
                        Console.WriteLine("");
                    }

                } while (cevap == 'e');
            }
            catch (Exception hata)
            {
                Console.WriteLine("Lütfen örnekte ki gibi bir kullanım gerçekleştiriniz.'1' - '2'");
            }
        }
    }
}