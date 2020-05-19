using System;
using System.IO;

namespace KitapEvi.Library
{
    public class KitaplikLib
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
        private static string path = "D:/kitapkayitlari.txt";


        public KitaplikLib(string kitapadi, string yazar, DateTime basimtarihi, string tur)//default constructer metod (varsayılan yapıcı metod)
        {
            //Class içinde bulunan fieldlarımıza varsayılan değerlerini atama işlemi yapar
            Kitapadi = kitapadi;
            Yazar = yazar;
            Basimtarihi = basimtarihi;
            Tur = tur;
        }


        public static void KitabiYazdir(KitaplikLib[] kitapdizisi, int i)
        {
            try
            {
            FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write, FileShare.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(kitapdizisi[i].KitapDetay());
            fs.Flush();
            sw.Close();
            fs.Close();
            }
            catch (IOException e)
            {
                // Dosya konumunun bulunamadığı hatalarda dizini kontrol etme mesajını gönderir.
                Console.WriteLine("Dosya dizini bulunamadı. Lütfen dizini kontrol ediniz :" + "\n" + path);
            }
            // text dosyası yoksa oluşturup KitapEkleme() methodu ile dizi elemanlarını kaydeden methodumuz.

        }


        public static void KitaplariGoruntule()
        {
            string path = "D:/kitapkayitlari.txt";
            try
            {   //Stream reader ile text dosyasını açıyor.
                StreamReader sr = new StreamReader(path);
                //ReadToEnd() methoduyla txt dosyasının sonuna kadar satır satır okuyor ve yazdırıyor.
                string line = sr.ReadToEnd();
                Console.WriteLine(line);
            }
            catch (IOException e)
            {
                // Dosya konumunun bulunamadığı hatalarda dizini kontrol etme mesajını gönderir.
                Console.WriteLine("Dosya dizini bulunamadı. Lütfen dizini kontrol ediniz :" +"\n"+path);
            }
        }
        public static void KitapEkleme()
        {
            Console.WriteLine("Kaç kitap eklemek istiyorsunuz ?");
            kitapsayi = Convert.ToInt16(Console.ReadLine());
            KitaplikLib[] kitapdizisi = new KitaplikLib[kitapsayi];

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
                KitaplikLib kitap = new KitaplikLib(Kitapadi, Yazar, Basimtarihi, Tur);
                kitapdizisi[i] = kitap;
                KitabiYazdir(kitapdizisi, i);
            }
        }

        //KitaplıkLib classından türeyen kitap nesnesinin özelliklerini yazdırmamızı sağlar.
        public string KitapDetay() => $"Kitap Adı:{Kitapadi} | Yazar:{Yazar} | Basım Tarihi:{Basimtarihi.Year} | Tur:{Tur}";

    }
}
