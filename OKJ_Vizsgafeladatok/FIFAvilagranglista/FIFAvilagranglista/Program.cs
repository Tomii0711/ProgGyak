using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

//1. feladat
namespace FIFAvilagranglista
{
    //Adat osztály
    class Adat
    {
        public string nev;
        public int helyezes;
        public int valtozas;
        public int pontszam;

        public Adat(string [] sor)
        {
            nev = sor[0];
            helyezes = Convert.ToInt32(sor[1]);
            valtozas = Convert.ToInt32(sor[2]);
            pontszam = Convert.ToInt32(sor[3]);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Segédváltozók
            List<Adat> adatok = new List<Adat>();
            double pontSzum = 0;
            string vanMagyar = "nincs";
            HashSet<int> segedH = new HashSet<int>();

            //2. feladat
            StreamReader be = new StreamReader("fifa.txt");
            be.ReadLine();
            while (!be.EndOfStream)
            {
                Adat akt = new Adat(be.ReadLine().Split(';'));
                adatok.Add(akt);

                //4. fealdathoz
                pontSzum += akt.pontszam;
                //6. feladathoz
                if (akt.nev == "Magyarország")
                {
                    vanMagyar = "van";
                }
                //7. feladathoz
                segedH.Add(akt.valtozas);
            }
            be.Close();

            //7. feladathoz
            List<int> valtozasok = segedH.ToList();
            int[] valtozasDB = new int[valtozasok.Count];

            //3. feladat
            Console.WriteLine($"3. feladat: A világranglistán {adatok.Count} csapat szerepel");

            //4. feladat
            Console.WriteLine($"4. feladat: A csapatok átlagos pontszáma: {Math.Round(pontSzum/adatok.Count,2)} pont");

            //5. feladat
            int maxValt = adatok[0].valtozas, maxValtIndex = 0;
            for (int i = 0; i < adatok.Count; i++)
            {
                if (adatok[i].valtozas > maxValt)
                {
                    maxValt = adatok[i].valtozas;
                    maxValtIndex = i;
                }

                //7. feladathoz
                for (int j = 0; j < valtozasok.Count; j++)
                {
                    if (adatok[i].valtozas == valtozasok[j])
                    {
                        valtozasDB[j]++;
                        break;
                    }
                }
            }
            Console.WriteLine("5. feladat: A legtöbbet javító csapat:");
            Console.WriteLine($"\tHelyezés: {adatok[maxValtIndex].helyezes}");
            Console.WriteLine($"\tCsapat: {adatok[maxValtIndex].nev}");
            Console.WriteLine($"\tPontszám: {adatok[maxValtIndex].pontszam}");

            //6. feladat
            Console.WriteLine($"6. feladat: A csapatok között {vanMagyar} Magyarország");

            //7. feladat
            Console.WriteLine("7. feladat: Statisztika");
            for (int i = 0; i < valtozasok.Count; i++)
            {
                if (valtozasDB[i] > 1)
                {
                    Console.WriteLine($"\t{valtozasok[i]} helyet változott: {valtozasDB[i]} csapat");
                }
            }
        }
    }
}
