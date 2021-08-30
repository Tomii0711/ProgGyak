using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Data;

namespace Operátorok
{
    //1. feladathoz
    class Kifejezes
    {
        public int elso;
        public string oper;
        public int masodik;
        public string szovegkent;


        public Kifejezes(string[] sor)
        {
            elso = Convert.ToInt32(sor[0]);
            oper = sor[1];
            masodik = Convert.ToInt32(sor[2]);
            if (oper == "div")
            {
                szovegkent = sor[0] + "/" + sor[2];
            }
            else if (oper == "mod")
            {
                szovegkent = sor[0] + "%" + sor[2];
            }
            else
            {
                szovegkent = sor[0] + sor[1] + sor[2];
            }
        }

        //6. feladat
        public string Ertek()
        {
            string kiValasz = "";
            if (Program.operTomb.Contains(oper))
            {
                try
                {
                    DataTable szam = new DataTable();
                    kiValasz = szam.Compute(szovegkent, "").ToString();
                    int osztasNullaval = elso / masodik;
                }
                catch (Exception)
                {
                    return "Egyéb hiba!";
                    throw;
                }
            }
            else
            {
                kiValasz = "Hibás operátor!";
            }
            return kiValasz;
        }
    }

    class Program
    {
        public static string[] operTomb = { "mod", "/", "div", "-", "*", "+" };
        static void Main(string[] args)
        {
            //segédváltozók
            List<Kifejezes> adatok = new List<Kifejezes>();
            int maradekosok = 0;
            int[] operDB = new int[operTomb.Length];
            StreamWriter ki = new StreamWriter("eredmenyek.txt");

            //1. feladat
            StreamReader be = new StreamReader("kifejezesek.txt");
            while (!be.EndOfStream)
            {
                string sor = be.ReadLine();
                Kifejezes akt = new Kifejezes(sor.Split(' '));
                adatok.Add(akt);

                //3. feladathoz
                if (akt.oper == "mod")
                {
                    maradekosok++;
                }
                //5. feladathoz
                for (int i = 0; i < operTomb.Length; i++)
                {
                    if (akt.oper == operTomb[i])
                    {
                        operDB[i]++;
                        break;
                    }
                }
                //8. feladathoz
                ki.WriteLine($"{sor} = {akt.Ertek()}");
            }
            be.Close();
            ki.Close();

            //2. feladat
            Console.WriteLine($"2. feladat: Kifejezések száma: {adatok.Count}");

            //3. feladat
            Console.WriteLine($"3. feladat: Kifejezések maradékos osztással: {maradekosok}");

            //4. feladat
            string vanE = "Nincs";
            for (int i = 0; i < adatok.Count; i++)
            {
                if ((adatok[i].elso % 10 == 0) && (adatok[i].masodik % 10 == 0))
                {
                    vanE = "Van";
                    break;
                }
            }
            Console.WriteLine($"4. feladat: {vanE} ilyen kifejezés!");

            //5. feladat
            Console.WriteLine("5. feladat: Statisztika");
            for (int i = 0; i < operTomb.Length; i++)
            {
                Console.WriteLine($"\t{operTomb[i], 3} -> {operDB[i]} db");
            }

            //7. feladat
            string beMuvelet = "";
            while (true)
            {
                Console.Write("7. feladat: Kérek egy kifejezést (pl.: 1 + 1): ");
                beMuvelet = Console.ReadLine();
                if (beMuvelet == "vége")
                {
                    break;
                }
                else
                {
                    Kifejezes uj = new Kifejezes(beMuvelet.Split(' '));
                    Console.WriteLine($"\t{beMuvelet} = {uj.Ertek()}");
                }
            }

            //8. feladat
            Console.WriteLine("8. feladat: eredmenyek.txt");
        }
    }
}
