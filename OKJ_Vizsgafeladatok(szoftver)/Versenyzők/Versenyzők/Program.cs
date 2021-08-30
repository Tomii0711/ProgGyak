using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

//1. feladat
namespace Versenyzők
{
    //2. feladathoz
    class Pilota
    {
        public string nev;
        public DateTime szuletes;
        public string nemzetiseg;
        public string rajtszam;

        public Pilota(string[] sor)
        {
            nev = sor[0];
            string[] datumTomb = sor[1].Split('.');
            szuletes = new DateTime(Convert.ToInt32(datumTomb[0]), Convert.ToInt32(datumTomb[1]), Convert.ToInt32(datumTomb[2]));
            nemzetiseg = sor[2];
            rajtszam = sor[3];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //segédváltozók
            List<Pilota> adatok = new List<Pilota>();
            int minRajtszam = 1000;
            string minNemzetiseg = "";
            List<string> rajtszamok = new List<string>();
            List<string> ismetlodo = new List<string>();

            //2. feladat
            StreamReader be = new StreamReader("pilotak.csv");
            be.ReadLine();
            while (!be.EndOfStream)
            {
                Pilota akt = new Pilota(be.ReadLine().Split(';'));
                adatok.Add(akt);

                if (akt.rajtszam != "")
                {
                    //6. feladathoz
                    if (Convert.ToInt32(akt.rajtszam) < minRajtszam)
                    {
                        minRajtszam = Convert.ToInt32(akt.rajtszam);
                        minNemzetiseg = akt.nemzetiseg;
                    }
                    //7. feladathoz
                    if (rajtszamok.Contains(akt.rajtszam))
                    {
                        ismetlodo.Add(akt.rajtszam);
                    }
                    else
                    {
                        rajtszamok.Add(akt.rajtszam);
                    }
                }
            }
            be.Close();

            //3. feladat
            Console.WriteLine("3. feladat: " + adatok.Count);

            //4. feladat
            Console.WriteLine("4. feladat: " + adatok[adatok.Count - 1].nev);

            //5. feladat
            Console.WriteLine("5. feladat:");
            for (int i = 0; i < adatok.Count; i++)
            {
                if (adatok[i].szuletes.Year < 1901)
                {
                    Console.WriteLine($"\t{adatok[i].nev} ({adatok[i].szuletes.ToString("d")})");
                }
            }

            //6. fealdat
            Console.WriteLine("6. feladat: " + minNemzetiseg);

            //7. feladat
            Console.WriteLine("7. feladat: " + string.Join(", ", ismetlodo));
        }
    }
}
