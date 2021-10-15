using System;
using System.IO;
using System.Collections.Generic;

//1. feladat
namespace Rostok
{
    class Adat
    {
        public string Nev;
        public string Kategoria;
        public string Mennyiseg;
        public double Tartalom;

        public Adat(string [] sor)
        {
            Nev = sor[0];
            Kategoria = sor[1];
            Mennyiseg = sor[2];
            Tartalom = Convert.ToDouble(sor[3]);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //segédváltozók
            List<Adat> adatok = new List<Adat>();
            int nemSzazas = 0, tartalomDB = 0;
            double tartalomSum = 0;
            HashSet<string> kategoriak = new HashSet<string>();
            StreamWriter ki = new StreamWriter("Rostok100g.txt");
            ki.WriteLine("Megnevezés;Kategória;Rost"); //fejléc

            //2. feladat
            StreamReader be = new StreamReader("rostok.txt");
            be.ReadLine(); //fejléc
            while (!be.EndOfStream)
            {
                Adat akt = new Adat(be.ReadLine().Split(';'));
                adatok.Add(akt);

                //4. feladathoz
                if (akt.Mennyiseg != "100g")
                {
                    nemSzazas++;
                }
                //5. feladathoz
                else
                {
                    if (akt.Kategoria == "Friss gyümölcsök")
                    {
                        tartalomSum += akt.Tartalom;
                        tartalomDB++;
                    }
                    //9. feladathoz
                    ki.WriteLine($"{akt.Nev};{akt.Kategoria};{akt.Tartalom}");
                }

                //7. feladathoz
                kategoriak.Add(akt.Kategoria);
            }
            be.Close();
            ki.Close();

            //3. feladat
            Console.WriteLine($"3. feladat: Élelmiszerek száma: {adatok.Count}");

            //4. feladat
            Console.WriteLine($"4. feladat: Nem 100g-os egység: {nemSzazas}");

            //5. feladat
            Console.WriteLine($"5. feladat: Friss gyümölcsök átlagos rosttartalma: {Math.Round(tartalomSum / tartalomDB, 14)}g");

            //6. feladat
            Console.Write("6. feladat: Kérek egy karakterláncot: ");
            string beKar = Console.ReadLine().ToLower();
            List<string> vannak = new List<string>();
            for (int i = 0; i < adatok.Count; i++)
            {
                if (adatok[i].Nev.ToLower().Contains(beKar))
                {
                    vannak.Add("\t" + adatok[i].Nev + " @ " + adatok[i].Kategoria + " @ " + adatok[i].Mennyiseg + " @ " + adatok[i].Tartalom);
                }
            }
            if (vannak.Count != 0)
            {
                for (int i = 0; i < vannak.Count; i++)
                {
                    Console.WriteLine(vannak[i]);
                }
            }
            else
            {
                Console.WriteLine("\tA keresés eredménytelen!");
            }

            //7. feladat
            Console.WriteLine($"7. feladat: Kategóriák száma: {kategoriak.Count}");

            //8. feladat
            Console.WriteLine("8. feladat: Statisztika");
            int[] katDB = new int[kategoriak.Count];
            for (int i = 0; i < adatok.Count; i++)
            {
                int j = 0;
                foreach (var item in kategoriak)
                {
                    if (adatok[i].Kategoria == item)
                    {
                        katDB[j]++;
                        break;
                    }
                    j++;
                }
            }
            int katInd = 0;
            foreach (var item in kategoriak)
            {
                Console.WriteLine($"\t{item} - {katDB[katInd]}");
                katInd++;
            }

            //9. feladat
            Console.WriteLine("9. feladat: Rostok100g.txt");
        }
    }
}
