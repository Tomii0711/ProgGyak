using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

//1. feladat
namespace Bérek2020
{
    //Dolgozó osztály
    class Dolgozo
    {
        public string nev;
        public string nem;
        public string reszleg;
        public int belepes;
        public int ber;

        public Dolgozo(string [] beSor)
        {
            nev = beSor[0];
            nem = beSor[1];
            reszleg = beSor[2];
            belepes = Convert.ToInt32(beSor[3]);
            ber = Convert.ToInt32(beSor[4]);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //segédváltozók
            int[] dolgozoSzamok;
            List<string> reszlegek;
            List<Dolgozo> adatok = new List<Dolgozo>();
            double sum = 0;
            HashSet<string> reszlegekH = new HashSet<string>();
            
            //2. feladat
            StreamReader be = new StreamReader("berek2020.txt");
            be.ReadLine();
            while (!be.EndOfStream)
            {
                var akt = new Dolgozo(be.ReadLine().Split(';'));
                adatok.Add(akt);

                //4. feladathoz
                sum += akt.ber;
                //7. feladathoz
                reszlegekH.Add(akt.reszleg);
            }
            be.Close();

            reszlegek = reszlegekH.ToList<string>();
            dolgozoSzamok = new int[reszlegek.Count];

            //3. feladat
            Console.WriteLine($"3. feladat: Dolgozók száma: {adatok.Count} fő");

            //4. feladat
            Console.WriteLine($"4. feladat: Bérek átlaga: {Math.Round(sum/adatok.Count/1000,1)} eFt");

            //5. feladat
            Console.Write("5. feladat: Kérem egy részleg nevét: ");
            string beReszleg = Console.ReadLine();

            //6. feladat
            int maxBer = -1, maxBerIndex = 0;
            for (int i = 0; i < adatok.Count; i++)
            {
                if (adatok[i].reszleg == beReszleg)
                {
                    if (adatok[i].ber > maxBer)
                    {
                        maxBer = adatok[i].ber;
                        maxBerIndex = i;
                    }
                }

                //7. feladathoz
                for (int j = 0; j < reszlegek.Count; j++)
                {
                    if (adatok[i].reszleg == reszlegek[j])
                    {
                        dolgozoSzamok[j]++;
                        break;
                    }
                }
            }
            if (maxBer == -1)
            {
                Console.WriteLine("6. feladat: A megadott részleg nem létezik a cégnél!");
            }
            else
            {
                Console.WriteLine("6. feladat: a legtöbbet kereső dolgozó a megadott részlegen");
                Console.WriteLine($"\tNév: {adatok[maxBerIndex].nev}");
                Console.WriteLine($"\tNeme: {adatok[maxBerIndex].nem}");
                Console.WriteLine($"\tBelépés: {adatok[maxBerIndex].belepes}");
                Console.WriteLine($"\tBér: {adatok[maxBerIndex].ber.ToString("N000")} Forint");
            }

            //7. feladat
            Console.WriteLine("7. feladat: Statisztika");
            for (int i = 0; i < reszlegek.Count; i++)
            {
                Console.WriteLine($"\t{reszlegek[i]} - {dolgozoSzamok[i]} fő");
            }
        }
    }
}
