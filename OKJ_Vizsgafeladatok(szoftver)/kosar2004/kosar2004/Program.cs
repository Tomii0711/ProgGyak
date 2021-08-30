using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

//1. feladat
namespace kosar2004
{
    //2. feladathoz
    class Adat
    {
        public string hazai;
        public string idegen;
        public int hazai_pont;
        public int idegen_pont;
        public string helyszin;
        public string idopont;

        public Adat(string [] sor)
        {
            hazai = sor[0];
            idegen = sor[1];
            hazai_pont = Convert.ToInt32(sor[2]);
            idegen_pont = Convert.ToInt32(sor[3]);
            helyszin = sor[4];
            idopont = sor[5];
        }

        public string kiIr()
        {
            return ($"{hazai}-{idegen} ({hazai_pont}:{idegen_pont})");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //segédváltozók
            List<Adat> adatok = new List<Adat>();
            int madridHazai = 0, madridIdegen = 0;
            string voltEDontetlen = "nem";
            string barcelonaNev = "";
            List<Adat> ketezernegyNov21 = new List<Adat>();
            HashSet<string> stadionok = new HashSet<string>();

            //2. feladat
            StreamReader be = new StreamReader("eredmenyek.csv");
            be.ReadLine();
            while (!be.EndOfStream)
            {
                Adat akt = new Adat(be.ReadLine().Split(';'));
                adatok.Add(akt);

                //3. feladathoz
                madridHazai = (akt.hazai == "Real Madrid") ? madridHazai + 1 : madridHazai;
                madridIdegen = (akt.idegen == "Real Madrid") ? madridIdegen + 1 : madridIdegen;
                //4. feladathoz
                voltEDontetlen = (akt.hazai_pont == akt.idegen_pont) ? "igen" : voltEDontetlen;
                //5. feladathoz
                List<string> nevSzavak = akt.hazai.Split(' ').ToList<string>();
                if (nevSzavak.Contains("Barcelona") || nevSzavak.Contains("barcelona"))
                {
                    barcelonaNev = akt.hazai;
                }
                //6. feladathoz
                if (akt.idopont == "2004-11-21")
                {
                    ketezernegyNov21.Add(akt);
                }
                //7. feladathoz
                stadionok.Add(akt.helyszin);
            }
            be.Close();

            //3. feladat
            Console.WriteLine($"3. feladat: Real Madrid: Hazai: {madridHazai}, Idegen: {madridIdegen}");

            //4. feladat
            Console.WriteLine($"4. feladat: Volt döntetlen? {voltEDontetlen}");

            //5. feladat
            Console.WriteLine($"5. feladat: barcelonai csapat neve: {barcelonaNev}");

            //6. feladat
            Console.WriteLine("6. feladat");
            for (int i = 0; i < ketezernegyNov21.Count; i++)
            {
                Console.WriteLine($"\t{ketezernegyNov21[i].kiIr()}");
            }

            //7. feladat
            List<string> stadionokLista = stadionok.ToList<string>();
            int[] stadiondb = new int[stadionokLista.Count];

            for (int i = 0; i < adatok.Count; i++)
            {
                for (int j = 0; j < stadionokLista.Count; j++)
                {
                    if (adatok[i].helyszin == stadionokLista[j])
                    {
                        stadiondb[j]++;
                        break;
                    }
                }
            }
            Console.WriteLine("7. feladat:");
            for (int i = 0; i < stadionokLista.Count; i++)
            {
                if (stadiondb[i] > 20)
                {
                    Console.WriteLine($"\t{stadionokLista[i]}: {stadiondb[i]}");
                }
            }
        }
    }
}
