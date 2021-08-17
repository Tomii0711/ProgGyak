using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Hianyzasok
{
    class Osztaly
    {
        public string osztaly;
        public int hianyzasok;

        public Osztaly(string beOsztaly, int beHianyzas)
        {
            osztaly = beOsztaly;
            hianyzasok = beHianyzas;
        }

        public string KiIr()
        {
            return ($"{osztaly};{hianyzasok}");
        }
    }

    class Adat
    {
        public string nev;
        public string osztaly;
        public int elso;
        public int utso;
        public int orak;

        public Adat(string [] sor)
        {
            nev = sor[0];
            osztaly = sor[1];
            elso = Convert.ToInt32(sor[2]);
            utso = Convert.ToInt32(sor[3]);
            orak = Convert.ToInt32(sor[4]);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //segédváltozók
            List<Adat> adatok = new List<Adat>();
            int orakSum = 0;
            HashSet<string> segedOsztalyNevek = new HashSet<string>();

            //1. feladat
            StreamReader be = new StreamReader("szeptember.csv", System.Text.Encoding.UTF8, true);
            be.ReadLine();
            while (!be.EndOfStream)
            {
                Adat akt = new Adat(be.ReadLine().Split(';'));
                adatok.Add(akt);

                //2. feladathoz
                orakSum += akt.orak;
                //6. feladathoz
                segedOsztalyNevek.Add(akt.osztaly);
            }
            be.Close();
            //6. feladathoz
            List<string> osztalyok = segedOsztalyNevek.ToList<string>();
            int[] osztalyDB = new int[osztalyok.Count];

            //2. feladat
            Console.WriteLine($"2. feladat\n\tÖsszes mulasztott órák száma: {orakSum} óra.");

            //3. feladat
            Console.Write("3. feladat\n\tKérem adjon meg egy napot: ");
            int beNap = Convert.ToInt32(Console.ReadLine());
            Console.Write("\tTanuló neve: ");
            string beNev = Console.ReadLine();

            //4. feladat
            string hianyzottE = "nem ";
            for (int i = 0; i < adatok.Count; i++)
            {
                if (adatok[i].nev == beNev)
                {
                    hianyzottE = "";
                    break;
                }
            }
            Console.WriteLine($"4. feladat\n\tA tanuló {hianyzottE}hiányzott szeptemberben");

            //5. feladat
            Console.WriteLine($"5. feladat: Hiányzók 2017.09.{beNap}-n:");
            string hianyzok = "";
            for (int i = 0; i < adatok.Count; i++)
            {
                if (adatok[i].elso <= beNap && adatok[i].utso >= beNap)
                {
                    hianyzok += ($"\t{adatok[i].nev} ({adatok[i].osztaly})\n");
                }

                //6. feladathoz
                for (int j = 0; j < osztalyok.Count; j++)
                {
                    if (adatok[i].osztaly == osztalyok[j])
                    {
                        osztalyDB[j] += adatok[i].orak;
                        break;
                    }
                }
            }
            if (hianyzok.Length == 0)
            {
                Console.WriteLine("\tNem volt hiányzó");
            }
            else
            {
                Console.WriteLine(hianyzok);
            }

            //6. feladat
            List<Osztaly> osztalyokOssz = new List<Osztaly>(); 
            StreamWriter ki = new StreamWriter("osszesites.csv");
            for (int i = 0; i < osztalyok.Count; i++)
            {
                Osztaly akt = new Osztaly(osztalyok[i], osztalyDB[i]);
                osztalyokOssz.Add(akt);
            }
            List<Osztaly> rendezve = osztalyokOssz.OrderBy(o => o.osztaly).ToList();
            for (int i = 0; i < osztalyokOssz.Count; i++)
            {
                ki.WriteLine(rendezve[i].KiIr());
            }
            ki.Close();
        }
    }
}
