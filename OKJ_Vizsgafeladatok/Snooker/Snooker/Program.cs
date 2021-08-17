using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

//1. feladat
namespace Snooker
{
    class Versenyzo
    {
        public int helyezes;
        public string nev;
        public string orszag;
        public int nyeremeny;

        public Versenyzo(string [] sor)
        {
            helyezes = Convert.ToInt32(sor[0]);
            nev = sor[1];
            orszag = sor[2];
            nyeremeny = Convert.ToInt32(sor[3]);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //segéd változók
            List<Versenyzo> versenyzok = new List<Versenyzo>();
            double nyeremenySzum = 0;
            string vanNorveg = "nincs";
            HashSet<string> nevekO = new HashSet<string>();

            //2. feladat
            StreamReader be = new StreamReader("snooker.txt");
            be.ReadLine();
            while (!be.EndOfStream)
            {
                Versenyzo akt = new Versenyzo(be.ReadLine().Split(';'));
                versenyzok.Add(akt);

                //4. feladathoz
                nyeremenySzum += akt.nyeremeny;
                //6. feladathoz
                if (akt.orszag == "Norvégia")
                {
                    vanNorveg = "van";
                }
                //7. fealdathoz
                nevekO.Add(akt.orszag);
            }
            be.Close();

            //7. feladathoz
            List<string> orszagNevek = nevekO.ToList<string>();
            int[] orszDB = new int[orszagNevek.Count];

            //3. feladat
            Console.WriteLine($"3. feladat: A világranglistán {versenyzok.Count} versenyző szerepel");

            //4. feladat
            Console.WriteLine($"4. feladat: A versenyzők átlagosan {Math.Round(nyeremenySzum/versenyzok.Count,2)} fontot kerestek");

            //5. feladat
            int maxKinaiNyeremeny = 0, maxKIndex = 0;
            for (int i = 0; i < versenyzok.Count; i++)
            {
                if (versenyzok[i].orszag == "Kína" && versenyzok[i].nyeremeny > maxKinaiNyeremeny)
                {
                    maxKinaiNyeremeny = versenyzok[i].nyeremeny;
                    maxKIndex = i;
                }

                //7. feladaathoz
                for (int j = 0; j < orszagNevek.Count; j++)
                {
                    if (versenyzok[i].orszag == orszagNevek[j])
                    {
                        orszDB[j]++;
                        break;
                    }
                }
            }
            Console.WriteLine("5. feladat: A legjobban kereső kínai versenyző:");
            Console.WriteLine($"\tHelyezés: {versenyzok[maxKIndex].helyezes}");
            Console.WriteLine($"\tNév: {versenyzok[maxKIndex].nev}");
            Console.WriteLine($"\tOrszág: {versenyzok[maxKIndex].orszag}");
            Console.WriteLine($"\tNyeremény: {(versenyzok[maxKIndex].nyeremeny * 380).ToString("N0")} FT");

            //6. feladat
            Console.WriteLine($"6. feladat: A versenyzők között {vanNorveg} norvég versenyző.");

            //7. feladat
            Console.WriteLine("7. feladat: Statisztika");
            for (int i = 0; i < orszagNevek.Count; i++)
            {
                if (orszDB[i] > 4)
                {
                    Console.WriteLine($"\t{orszagNevek[i]} - {orszDB[i]} fő");
                }
            }
        }
    }
}
