using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace KitapEvi.Uygulamasi
{
    public class Kitaplik
    {
        private static string kitapadi;
        private static string yazar;
        private static DateTime basimtarihi;
        private static string tur;

        public static string Kitapadi { get => kitapadi; set => kitapadi = value; }
        public static string Yazar { get => yazar; set => yazar = value; }
        public static DateTime Basimtarihi { get => basimtarihi; set => basimtarihi = value; }
        public static string Tur { get => tur; set => tur = value; }

        private static int kitapsayi;//Kullanıcının eklemek istediği sayıyı tanımlıcağımız değişken.
        private static int tarih; // Basım tarihi tanımlanması sırasında ki aksaklıkları engellemek için kullanıldı.


        public Kitaplik(string kitapadi, string yazar, DateTime basimtarihi, string tur)
        {
            Kitapadi = kitapadi;
            Yazar = yazar;
            Basimtarihi = basimtarihi;
            Tur = tur;
        }        
        

        public static void KitabiYazdir(Kitaplik[] kitapdizisi,int i)
        {
            FileStream fs = new FileStream("D:/kitapkayitlari.txt", FileMode.Append, FileAccess.Write, FileShare.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(kitapdizisi[i].KitapDizisi());
            fs.Flush();
            sw.Close();
            fs.Close();
        }


        public static void KitaplariGoruntule()
        {
            string line;
            StreamReader file = new StreamReader(@"D:/kitapkayitlari.txt");
            while ((line = file.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
            file.Close();
        }
        public static void KitapEkleme()
        {
            Console.WriteLine("Kaç kitap eklemek istiyorsunuz ?");
            kitapsayi = Convert.ToInt16(Console.ReadLine());
            Kitaplik[] kitapdizisi = new Kitaplik[kitapsayi];

            for (int i = 0; i < kitapsayi; i++)
            {
                Console.WriteLine("Kitap Adını Giriniz : \n");
                Kitapadi = Console.ReadLine();
                Console.WriteLine("Kitap Yazarını Giriniz : \n");
                Yazar = Console.ReadLine();
                Console.WriteLine("Kitap Basım Yılını Giriniz : \n");
                do
                {
                    tarih = int.Parse(Console.ReadLine());
                    if (tarih > 2020)
                    {
                        Console.WriteLine("Basım Yılını 2020'den Küçük Girmelisiniz.\n Tekrar Giriniz : ");
                    }
                } while (tarih > 2020);
                Basimtarihi = new DateTime(tarih, 1, 1);
                Console.WriteLine("Kitap Tur Giriniz : ");
                Tur = Console.ReadLine();
                Kitaplik kitap = new Kitaplik(Kitapadi, Yazar, Basimtarihi, Tur);
                kitapdizisi[i] = kitap;
                KitabiYazdir(kitapdizisi,i);
            }
        }
        public string KitapDizisi() => $"Kitap Adı:{Kitapadi} | Yazar:{Yazar} | Basım Tarihi:{Basimtarihi.Year} | Tur:{Tur}";
    }
}
