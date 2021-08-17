using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

//1. feladat
namespace Lift
{
    class Utazas
    {
        public string idoPont;
        public int kartya;
        public int start;
        public int cel;

        public Utazas(string [] sor)
        {
            idoPont = sor[0];
            kartya = Convert.ToInt32(sor[1]);
            start = Convert.ToInt32(sor[2]);
            cel = Convert.ToInt32(sor[3]);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //segédváltozók
            List<Utazas> adatok = new List<Utazas>();
            int celMax = 0;
            HashSet<string> segedNapok = new HashSet<string>();

            //2. feladat
            StreamReader be = new StreamReader("lift.txt");
            while (!be.EndOfStream)
            {
                Utazas akt = new Utazas(be.ReadLine().Split(' '));
                adatok.Add(akt);

                //5. feladathoz
                if (akt.cel > celMax)
                {
                    celMax = akt.cel;
                }
                //8. feladathoz
                segedNapok.Add(akt.idoPont);
            }
            be.Close();

            //8. feladathoz
            List<string> napok = segedNapok.ToList<string>();
            int[] napokDB = new int[napok.Count];

            //3. feladat
            Console.WriteLine($"3. feladat: Összes lifthasználat: {adatok.Count}");

            //4. feladat
            Console.WriteLine($"4. feladat: Időszak: {adatok.First().idoPont} - {adatok.Last().idoPont}");

            //5. feladat
            Console.WriteLine($"5. feladat: Célszint max: {celMax}");

            //6. feladat
            string beSzamS, beSzintS;
            Console.Write("6. feladat:\n\tKártya száma: ");
            beSzamS = Console.ReadLine();
            Console.Write("\tCélszint száma: ");
            beSzintS = Console.ReadLine();
            int beSzam, beSzint;
            try
            {
                beSzam = Convert.ToInt32(beSzamS);
                beSzint = Convert.ToInt32(beSzintS);
            }
            catch (Exception)
            {
                beSzam = 5;
                beSzint = 5;
            }

            //7. feladat
            string utaztakE = "nem ";
            for (int i = 0; i < adatok.Count; i++)
            {
                if (adatok[i].kartya == beSzam && adatok[i].cel == beSzint)
                {
                    utaztakE = "";
                    break;
                }
            }
            Console.WriteLine($"7. feladat: A(z) {beSzam}. kártyával {utaztakE}utaztak a(z) {beSzint}. emeletre!");

            //8. feladat
            for (int i = 0; i < adatok.Count; i++)
            {
                for (int j = 0; j < napok.Count; j++)
                {
                    if (adatok[i].idoPont == napok[j])
                    {
                        napokDB[j]++;
                        break;
                    }
                }
            }
            Console.WriteLine("8. feladat: Statisztika");
            for (int i = 0; i < napok.Count; i++)
            {
                Console.WriteLine($"\t{napok[i]} - {napokDB[i]}x");
            }
        }
    }
}
