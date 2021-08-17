using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

//1. feladat
namespace vb2018
{
    class Adat
    {
        public string varos;
        public string nev1;
        public string nev2;
        public int ferohely;

        public Adat(string[] sor)
        {
            varos = sor[0];
            nev1 = sor[1];
            nev2 = sor[2];
            ferohely = Convert.ToInt32(sor[3]);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //segédváltozók
            List<Adat> adatok = new List<Adat>();
            double ferohelySum = 0;
            int vanAlternativ = 0;
            HashSet<string> varosok = new HashSet<string>();

            //2. feladat
            StreamReader be = new StreamReader("vb2018.txt");
            be.ReadLine();
            while (!be.EndOfStream)
            {
                Adat akt = new Adat(be.ReadLine().Split(';'));
                adatok.Add(akt);

                //5. feladathoz
                ferohelySum += akt.ferohely;
                //6. feladathoz
                if (akt.nev2 != "n.a.")
                {
                    vanAlternativ++;
                }
                //9. feladathoz
                varosok.Add(akt.varos);
            }
            be.Close();

            //3. feladat
            Console.WriteLine($"3. feladat: Stadionok száma: {adatok.Count}");

            //4. feladat
            int minFerohely = adatok[0].ferohely, minInd = 0;
            for (int i = 0; i < adatok.Count; i++)
            {
                if (adatok[i].ferohely < minFerohely)
                {
                    minFerohely = adatok[i].ferohely;
                    minInd = i;
                }
            }
            Console.WriteLine($"4. feladat: A legkevesebb férőhely:\n\tVáros: {adatok[minInd].varos}\n\tStadion neve: {adatok[minInd].nev1}\n\tFérőhely: {adatok[minInd].ferohely}");

            //5. feladat
            Console.WriteLine($"5. feladat: Átlagos férőhelyszám: {Math.Round(ferohelySum / adatok.Count, 1)}");

            //6. feladat
            Console.WriteLine($"6. feladat: Két néven is ismert stadionok száma: {vanAlternativ}");

            //7. feladat
            string beNev = "";
            do
            {
                Console.Write("7. feladat: Kérem a város nevét: ");
                beNev = Console.ReadLine();
            } while (beNev.Length < 3);

            //8. feladat
            string helyszinE = "nem ";
            for (int i = 0; i < adatok.Count; i++)
            {
                if (adatok[i].varos.ToLower() == beNev.ToLower())
                {
                    helyszinE = "";
                    break;
                }
            }
            Console.WriteLine($"8. fealdat: A megadott város {helyszinE}VB helyszín.");

            //9. feladat
            Console.WriteLine($"9. feladat: {varosok.Count} különböző városban voltak mérkőzések.");
        }
    }
}
