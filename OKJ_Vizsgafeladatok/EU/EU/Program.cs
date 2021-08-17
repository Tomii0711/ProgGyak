using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

//1. feladat
namespace EU
{
    class Orszag
    {
        public string nev;
        public DateTime csatl;

        public Orszag(string [] sor)
        {
            nev = sor[0];
            csatl = Convert.ToDateTime(sor[1]);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //segédváltozók
            List<Orszag> orszagok = new List<Orszag>();
            int ketezerHet = 0;
            DateTime MO = DateTime.Now;
            string majusi = "nem volt";
            DateTime legutolso = new DateTime(1900,1,1);
            string legutolsoOrsz = "";
            HashSet<int> csatlEvek = new HashSet<int>();

            //2. feladat
            StreamReader be = new StreamReader("EUcsatlakozas.txt");
            while (!be.EndOfStream)
            {
                Orszag akt = new Orszag(be.ReadLine().Split(';'));
                orszagok.Add(akt);

                //4. feladathoz
                if (akt.csatl.Year == 2007)
                {
                    ketezerHet++;
                }
                //5. feladathoz
                if (akt.nev == "Magyarország")
                {
                    MO = akt.csatl;
                }
                //6. feladathoz
                if (akt.csatl.Month == 5)
                {
                    majusi = "volt";
                }
                //7. feladathoz
                if (akt.csatl > legutolso)
                {
                    legutolso = akt.csatl;
                    legutolsoOrsz = akt.nev;
                }
                //8. feladathoz
                csatlEvek.Add(akt.csatl.Year);
            }
            be.Close();

            //8. feladathoz
            List<int> evek = csatlEvek.ToList<int>();
            int[] evekDB = new int[evek.Count]; 

            //3. feladat
            Console.WriteLine($"3. feladat: EU tagállamainak száma: {orszagok.Count} db");

            //4. feladat
            Console.WriteLine($"4. feladat: 2007-ben {ketezerHet} ország csatlakozott.");

            //5. feladat
            Console.WriteLine($"5. feladat: Magyarország csatlakozásának dátuma: {MO.Year}.{MO.Month.ToString("00")}.{MO.Day.ToString("00")}");

            //6. feladat
            Console.WriteLine($"6. feladat: Májusban {majusi} csatlakozás!");

            //7. feladat
            Console.WriteLine($"7. feladat: Legutoljára csatlakozott ország: {legutolsoOrsz}");

            //8. feladat
            Console.WriteLine("8. feladat: Statisztika");
            for (int i = 0; i < orszagok.Count; i++)
            {
                for (int j = 0; j < evek.Count; j++)
                {
                    if (orszagok[i].csatl.Year == evek[j])
                    {
                        evekDB[j]++;
                        break;
                    }
                }
            }
            for (int i = 0; i < evek.Count; i++)
            {
                if (evekDB[i] > 0)
                {
                    Console.WriteLine($"\t{evek[i]} - {evekDB[i]} ország");
                }
            }
        }
    }
}
