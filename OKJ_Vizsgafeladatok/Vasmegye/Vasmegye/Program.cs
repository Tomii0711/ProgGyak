using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

//1. feladat
namespace Vasmegye
{
    class Adat
    {
        public string azon;
        public string eredeti;
        public char m;
        public DateTime datum;
        public string nem;
        public int kul;
        public int k;

        public Adat(string sor)
        {
            azon = sor;
            eredeti = azon;
            m = azon[0];
            string evElo = "";
            switch (m)
            {
                case '1':
                    evElo = "19";
                    nem = "férfi";
                    break;
                case '2':
                    evElo = "19";
                    nem = "nő";
                    break;
                case '3':
                    evElo = "20";
                    nem = "férfi";
                    break;
                case '4':
                    evElo = "20";
                    nem = "nő";
                    break;
            }
            datum = new DateTime(Convert.ToInt32(evElo + sor.Substring(2, 2)), Convert.ToInt32(sor.Substring(4, 2)), Convert.ToInt32(sor.Substring(6, 2)));
            kul = Convert.ToInt32(sor.Substring(9, 3));
            k = Convert.ToInt32(Char.GetNumericValue(sor[sor.Length - 1]));
            azon = azon.Replace("-", "");
        }

        //3. feladat
        public bool CdvEll()
        {
            int ell = 0;
            for (int i = 0; i < 10; i++)
            {
                int szam = Convert.ToInt32(Char.GetNumericValue(azon[i]));
                ell += szam * (10 - i);
            }
            return (k == ell % 11) ? true : false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //segédváltozók
            List<Adat> adatok = new List<Adat>();
            HashSet<int> segedEvek = new HashSet<int>();

            //2. feladat
            Console.WriteLine("2. feladat: Adatok beolvasása, tárolása");
            StreamReader be = new StreamReader("vas.txt");
            while (!be.EndOfStream)
            {
                Adat akt = new Adat(be.ReadLine());
                adatok.Add(akt);
            }
            be.Close();

            //4. feladat
            Console.WriteLine("4. feladat: Ellenőrzés");
            for (int i = 0; i < adatok.Count; i++)
            {
                if (!adatok[i].CdvEll())
                {
                    Console.WriteLine($"\tHibás a {adatok[i].eredeti} személyi azonosító!");
                    adatok.RemoveAt(i);
                }
            }

            //5. feladat
            Console.WriteLine($"5. feladat: Vas megyében a vizsgált évek alatt {adatok.Count} csecsemő született.");

            //6. feladat
            int fiuDB = 0;
            for (int i = 0; i < adatok.Count; i++)
            {
                if (adatok[i].nem == "férfi")
                {
                    fiuDB++;
                }
                //9. feladathoz
                segedEvek.Add(adatok[i].datum.Year);
            }
            Console.WriteLine($"6. feladat: Fiúk száma: {fiuDB}");

            //9. feladathoz
            List<int> evek = segedEvek.ToList<int>();
            int[] evekDB = new int[evek.Count];

            //7. feladat
            Console.WriteLine($"7. feladat: Vizsgált időszak: {evek.Min()} - {evek.Max()}");

            //8. feladat
            string szuletettE = "nem ";
            for (int i = 0; i < adatok.Count; i++)
            {
                if (adatok[i].datum.Year % 4 == 0 && adatok[i].datum.Month == 2 && adatok[i].datum.Day == 24)
                {
                    szuletettE = "";
                    break;
                }
            }
            Console.WriteLine($"8. feladat: Szökőnapon {szuletettE}született baba!");

            //9. feladat
            for (int i = 0; i < adatok.Count; i++)
            {
                for (int j = 0; j < evek.Count; j++)
                {
                    if (adatok[i].datum.Year == evek[j])
                    {
                        evekDB[j]++;
                        break;
                    }
                }
            }
            Console.WriteLine("9. feladat: Statisztika");
            for (int i = 0; i < evek.Count; i++)
            {
                Console.WriteLine($"\t{evek[i]} - {evekDB[i]} fő");
            }
        }
    }
}
