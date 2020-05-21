using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace KitapEvi.Library
{
    public class Menu
    {
        public static void BaslangicMenusu()
        {
            char ch;
            int hatadurumu = 0;
            do
            {
                try
                {
                    hatadurumu = 0;
                    Console.WriteLine("Merhabalar Kitabevi Sistemine Hoşgeldiniz \nUygulamayı " + DateTime.Now + " tarihinde çalıştırdınız.\nKitap listesi şu dizinde bulunmaktadır : " + KitaplikLib.path);
                    Console.Write("\n \n \n \n" +
                    "-----------------------------------------\n" +
                    "1.Kitapevine kitap eklemek \n2.Kitaplığı görüntülemek.\nİşlem Yapmak İçin Rakam Giriniz : => ");
                    ch = Convert.ToChar(Console.ReadLine());
                    Console.WriteLine("-----------------------------------------");
                    switch (ch)
                    {
                        case '1':
                            KitaplikLib.KitapEkleme();
                            hatadurumu = 0;
                            break;
                        case '2':
                            KitaplikLib.KitaplariGoruntule();
                            hatadurumu = 0;
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("HATA :Menüde sadece 2 seçenek bulunmaktadır , 1 veya 2 seçeneğini kullanınız.\n");
                            hatadurumu = 1;
                            break;
                    }
                }
                catch (FormatException hata)
                {
                    Console.Clear();
                    Console.WriteLine("HATA : Girdiğiniz değer 1 karakteri aşıyor Lütfen sadece 1 karakter kullanın. Tekrar Giriniz.\n\n\n");
                    hatadurumu = 1;
                }
                catch (Exception hata)
                {
                    Console.Clear();
                    Console.WriteLine("HATA : Lütfen örnekte ki gibi bir kullanım gerçekleştiriniz.'1' - '2'");
                    hatadurumu = 1;
                }
            } while (hatadurumu == 1);

        }
        public static char TekrarMenusu()
        {
            char cevap = 'h';
            int hatadurumu = 0;
            do
            {

                try
                {
                    Console.WriteLine("---------------------------------------\nSistem : Başka işlem yapmak istiyor musunuz ? (e-h)");
                    cevap = Convert.ToChar(Console.ReadLine());
                    switch (cevap)
                    {
                        case 'e':
                            cevap = 'e';
                            hatadurumu = 0;
                            break;
                        case 'h':
                            cevap = 'h';
                            hatadurumu = 0;
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("HATA :Menüde sadece 3 seçenek bulunmaktadır , 1,2 veya 3 seçeneğini kullanınız.\n");
                            hatadurumu = 1;
                            break;
                    }
                }
                catch (FormatException hata)
                {
                    Console.WriteLine("\nHATA : Girdiğiniz değer 1 karakteri aşıyor Lütfen sadece 1 karakter kullanın. Tekrar Giriniz.");
                    hatadurumu = 1;
                }
                catch (Exception hata)
                {
                    Console.WriteLine("\nHATA : Bilinmeyen bir hatayla karşılaşıldı. Lütfen tekrar deneyin.");
                    hatadurumu = 1;
                }
            } while (hatadurumu == 1);

            return cevap;

        }
    }
}
