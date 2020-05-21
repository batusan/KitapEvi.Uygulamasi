using ConsoleTables;
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
        public static string path = "D:/kitapkayitlari.txt";

        public KitaplikLib() { }//Constructor

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

        public static int KitapSayisiniHesapla()
        {
            string line;
            int sayac = 0;
            StreamReader sr = new StreamReader(path);
            while ((line = sr.ReadLine()) != null)
            {
                sayac++;
            }
            return sayac;
        }

        public static void KitaplariGoruntule()
        {
            try
            {
                string line;
                StreamReader sr = new StreamReader(path);
                string[,] goruntulemedizisi = new string[KitapSayisiniHesapla(), 4];

                for (int i = 0; i < KitapSayisiniHesapla();)
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        for (int j = 0; j < 4;)
                        {
                            string[] kelimeler = line.Split('|');
                            foreach (string kelime in kelimeler)
                            {
                                goruntulemedizisi[i, j] = kelime;
                                j++;
                            }
                        }
                        i++;
                    }
                }
                /*for (int i = 0; i < KitapSayisiniHesapla(); i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        Console.WriteLine(kitapdizi2[i, j]);
                        //kitapdizi2[i, j] = kelime;
                    }
                }*/               
                TabloÇiz(goruntulemedizisi);
                Console.WriteLine(KitapSayisiniHesapla() + " kitap listelendi.");
                sr.Close();
            }
            catch (IOException e)
            {
                // Dosya konumunun bulunamadığı hatalarda dizini kontrol etme mesajını gönderir.
                Console.WriteLine("Dosya dizini bulunamadı. Lütfen dizini kontrol ediniz :" + "\n" + path);
            }
            // text dosyası yoksa oluşturup KitapEkleme() methodu ile dizi elemanlarını kaydeden methodumuz.
        }

        public static void KitapEkleme()
        {
            Console.Write("Kaç kitap eklemek istiyorsunuz ? => ");
            kitapsayi = Convert.ToInt16(Console.ReadLine());
            KitaplikLib[] kitapdizisi = new KitaplikLib[kitapsayi];

            for (int i = 0; i < kitapsayi; i++)
            {
                Console.Write("Kitap Adını Giriniz : => ");
                Kitapadi = Console.ReadLine();
                Console.Write("Kitap Yazarını Giriniz : => ");
                Yazar = Console.ReadLine();
                Console.Write("Kitap Basım Yılını Giriniz : => ");
                do
                {
                    tarih = int.Parse(Console.ReadLine());
                    if (tarih > 2020)
                    {
                        Console.Write("Basım Yılını 2020'den Küçük Girmelisiniz.Tekrar Giriniz : => ");
                    }
                } while (tarih > 2020);
                Basimtarihi = new DateTime(tarih, 1, 1);
                Console.Write("Kitap Türü Giriniz : => ");
                Tur = Console.ReadLine();
                KitaplikLib kitap = new KitaplikLib(Kitapadi, Yazar, Basimtarihi, Tur);
                kitapdizisi[i] = kitap;
                KitabiYazdir(kitapdizisi, i);
            }
        }

        //KitaplıkLib classından türeyen kitap nesnesinin özelliklerini yazdırmamızı sağlar.
        public string KitapDetay() => $"{Kitapadi}|{Yazar}|{Basimtarihi.Year}|{Tur}";

        //ConsoleTables adlı proje classından tablo yapmamızı sağlayan bir kütüphane eklendi daha düzgün görüntülenmesi için.
        public static void TabloÇiz(string[,] dizi)
        {
            Console.Clear();
            Console.WriteLine("-----------------------------Kitap Listesi------------------------------");
            var table = new ConsoleTable("Kitap Adı", "Yazar", "Basım tarihi", "Tür");
            for (int i = 0; i < KitapSayisiniHesapla(); i++)
            {
                table.AddRow(dizi[i, 0], dizi[i, 1], dizi[i, 2], dizi[i, 3]);
            }
            table.Write();
        }
    }
}
