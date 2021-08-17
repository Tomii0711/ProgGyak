using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

//1. feladat
namespace AutóVerseny
{
    class Adat
    {
        public string csapat;
        public string versenyzo;
        public int eletkor;
        public string palya;
        public string ido;
        public int kor;
        public int mpBe;

        public Adat(string [] sor)
        {
            csapat = sor[0];
            versenyzo = sor[1];
            eletkor = Convert.ToInt32(sor[2]);
            palya = sor[3];
            ido = sor[4];
            kor = Convert.ToInt32(sor[5]);
            string[] idoDarab = ido.Split(':');
            mpBe = Convert.ToInt32(idoDarab[0]) * 3600 + Convert.ToInt32(idoDarab[1]) * 60 + Convert.ToInt32(idoDarab[2]);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //segédváltozók
            List<Adat> adatok = new List<Adat>();
            int FFGPC3mp = 0;

            //2. feladat
            StreamReader be = new StreamReader("autoverseny.csv");
            be.ReadLine();
            while (!be.EndOfStream)
            {
                Adat akt = new Adat(be.ReadLine().Split(';'));
                adatok.Add(akt);
                if (akt.versenyzo == "Fürge Ferenc")
                {
                    if (akt.palya == "Gran Prix Circuit")
                    {
                        if (akt.kor == 3)
                        {
                            FFGPC3mp = akt.mpBe;
                        }
                    }
                }
            }
            be.Close();

            //3. feladat
            Console.WriteLine($"3. feladat: {adatok.Count}");

            //4. feladat
            Console.WriteLine($"4. feladat: {FFGPC3mp} másodperc");

            //5. feladat
            Console.WriteLine("5. feladat:\nKérem egy versenyző nevét:");
            string beNev = Console.ReadLine();

            //6. feladat
            bool van = false;
            string hol = "", minIdo = "";
            int minMp = adatok[0].mpBe;
            for (int i = 0; i < adatok.Count; i++)
            {
                if (adatok[i].versenyzo == beNev)
                {
                    van = true;
                    if (adatok[i].mpBe < minMp)
                    {
                        hol = adatok[i].palya;
                        minIdo = adatok[i].ido;
                        minMp = adatok[i].mpBe;
                    }
                }
            }
            if (van)
            {
                Console.WriteLine($"6. feladat: {hol}, {minIdo}");
            }
            else
            {
                Console.WriteLine("6. feladat: Nincs ilyen versenyző az állományban!");
            }
        }
    }
}
