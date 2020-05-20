﻿using ConsoleTables;
using System;
using System.IO;
using System.Runtime.InteropServices.ComTypes;

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

        public static void TxtDosyasiniKaldirma()
        {
            Console.WriteLine("Kitap listesini temizlemek istediğinizden emin misiniz ? (evet - hayır)");
            string txtcevap = Console.ReadLine();
            if (txtcevap == "evet")
            {
                Console.Clear();
                File.Delete(path);
                Console.WriteLine("Kitaplık başarıyla kaldırıldı.");
            }
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
                string[,] kitapdizi2 = new string[KitapSayisiniHesapla(), 4];

                for (int i = 0; i < KitapSayisiniHesapla();)
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        for (int j = 0; j < 4;)
                        {
                            string[] kelimeler = line.Split('|');
                            foreach (string kelime in kelimeler)
                            {
                                kitapdizi2[i, j] = kelime;
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
                TabloÇiz(kitapdizi2);
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
        public string KitapDetay() => $"{Kitapadi}|{Yazar}|{Basimtarihi.Year}|{Tur}";

        //------------------------------------------------------------------------------------
        public static void TabloÇiz(string[,] dizi)
        {
            int kitapsayi = KitapSayisiniHesapla();
            var table = new ConsoleTable("Kitap Adı", "Yazar", "Basım tarihi", "Tür");
            for (int i = 0; i < KitapSayisiniHesapla(); i++)
            {
                table.AddRow(dizi[i, 0], dizi[i, 1], dizi[i, 2], dizi[i, 3]);
            }
            Console.WriteLine("\nKitaplar:" + kitapsayi + "\n");
            table.Write();
        }
    }
}
