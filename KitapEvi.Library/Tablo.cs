using System;
using System.Linq;
using System.Text;

namespace KitapEvi.Library
{
    public class Tablo
    {
        static int maks = 0, maks0 = 0, maks1 = 0, maks2 = 0, maks3 = 0;
        private static void SatirlariHesapla(string[,] goruntulemedizisi, int satir)
        {
            for (int i = 0; i < satir; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    string data = goruntulemedizisi[i, j];
                    maks = data.Length;
                    if (j == 0)
                    {
                        if (maks > maks0)
                        {
                            maks0 = maks;
                        }
                    }
                    if (j == 1)
                    {
                        if (maks > maks1)
                        {
                            maks1 = maks;
                        }
                    }
                    if (j == 2)
                    {
                        if (maks > maks2)
                        {
                            maks2 = maks;
                        }
                    }
                    if (j == 3)
                    {
                        if (maks > maks3)
                        {
                            maks3 = maks;
                        }
                    }
                }
            }
        }


        public static void Cizdir(string[,] dizi, int satirsayi, string para1, string para2, string para3, string para4)
        {
            // Tabloyu hatlarını çizen ve yerleştirmeyi yapan metodumuz.
            SatirlariHesapla(dizi, satirsayi);
            Console.Clear();
            int satir = maks0 + maks1 + maks2 + maks3+8;
            StringBuilder sb = new StringBuilder();
            var cizgi = " " + string.Join("", Enumerable.Repeat("-",satir));
            for (int i = 0; i < satirsayi; i++)
            {
                sb.AppendLine(cizgi);
                SatirYazdir(dizi, sb, i);
            }
            sb.AppendLine(cizgi);
            Console.Write(sb.ToString());
        }

        private static void SatirYazdir(string[,] dizi, StringBuilder sb, int i)
        {
            sb.AppendLine(" " + "|" + dizi[i, 0] + string.Join("", Enumerable.Repeat(" ", (Math.Abs(maks0 - dizi[i, 0].Length))))
        + " " + "|" + dizi[i, 1] + string.Join("", Enumerable.Repeat(" ", (Math.Abs(maks1 - dizi[i, 1].Length))))
        + " " + "|" + dizi[i, 2] + string.Join("", Enumerable.Repeat(" ", (Math.Abs(maks2 - dizi[i, 2].Length))))
        + " " + "|" + dizi[i, 3] + string.Join("", Enumerable.Repeat(" ", (Math.Abs(maks3 - dizi[i, 3].Length)))) + "|");
        }

    }
}
