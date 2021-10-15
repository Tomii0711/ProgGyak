using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

//1. feladat
namespace balkezesek
{
    class Adat
    {
        public string nev;
        public DateTime elso;
        public DateTime utolso;
        public int suly;
        public int magassag;

        public double magassagCenti;

        public Adat(string[] sor)
        {
            nev = sor[0];
            string[] seged = sor[1].Split('-');
            elso = new DateTime(Convert.ToInt32(seged[0]), Convert.ToInt32(seged[1]), Convert.ToInt32(seged[2]));
            seged = sor[2].Split('-');
            utolso = new DateTime(Convert.ToInt32(seged[0]), Convert.ToInt32(seged[1]), Convert.ToInt32(seged[2]));
            suly = Convert.ToInt32(sor[3]);
            magassag = Convert.ToInt32(sor[4]);
            magassagCenti = magassag * 2.54;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //segéd változók
            List<Adat> adatok = new List<Adat>();

            //2. feladat
            StreamReader be = new StreamReader("balkezesek.csv");
            be.ReadLine();
            while (!be.EndOfStream)
            {
                Adat akt = new Adat(be.ReadLine().Split(';'));
                adatok.Add(akt);
            }
            be.Close();

            //3. feladat
            Console.WriteLine($"3. feladat: {adatok.Count}");

            //4. feladat
            Console.WriteLine("4. feladat:");
            for (int i = 0; i < adatok.Count; i++)
            {
                if (adatok[i].utolso.Year == 1999 && adatok[i].utolso.Month == 10)
                {
                    Console.WriteLine($"\t{adatok[i].nev}, {adatok[i].magassagCenti.ToString("0.0")} cm");
                }
            }

            //5. feladat
            Console.WriteLine("5. feladat:");
            int beEv = 0;
            do
            {
                Console.Write("Kérek egy 1990 és 1999 közötti évszámot!: ");
                beEv = Convert.ToInt32(Console.ReadLine());
                if (beEv < 1990 || beEv > 1999)
                {
                    Console.Write("Hibás adat!");
                }
                else
                {
                    break;
                }
            } while (true);
            Console.WriteLine(beEv);

            //6. feladat
            double sulySzumm = 0;
            double sulyDB = 0;
            for (int i = 0; i < adatok.Count; i++)
            {
                if (adatok[i].elso.Year <= beEv && adatok[i].utolso.Year >= beEv)
                {
                    sulySzumm += adatok[i].suly;
                    sulyDB++;
                }
            }
            Console.WriteLine($"6. feladat: {Math.Round(sulySzumm/sulyDB, 2)} font");
        }
    }
}
