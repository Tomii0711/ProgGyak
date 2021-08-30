using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

//1. feladat
namespace Jackie
{
    //2. feladathoz
    class Sor
    {
        public int ev;
        public int versenyek;
        public int győzelmek;
        public int dobogós;
        public int pole;
        public int leggyorsabb;

        public Sor(string [] sor)
        {
            ev = Convert.ToInt32(sor[0]);
            versenyek = Convert.ToInt32(sor[1]);
            győzelmek = Convert.ToInt32(sor[2]);
            dobogós = Convert.ToInt32(sor[3]);
            pole = Convert.ToInt32(sor[4]);
            leggyorsabb = Convert.ToInt32(sor[5]);
        }
    }

    class Program
    {
        static int evtized(int ev)
        {
            return ev - (1900 + (ev % 10));
        }
        static void Main(string[] args)
        {
            //segédváltozók
            List<Sor> adatok = new List<Sor>();
            int legtobb = 0, legtobbEv = 0;
            HashSet<int> segedEvTizedek = new HashSet<int>();

            //2. feladat
            StreamReader be = new StreamReader("jackie.txt");
            be.ReadLine();
            while (!be.EndOfStream)
            {
                Sor akt = new Sor(be.ReadLine().Split('\t'));
                adatok.Add(akt);

                //4. feladathoz
                if (akt.versenyek > legtobb)
                {
                    legtobbEv = akt.ev;
                    legtobb = akt.versenyek;
                }
                //5. feladathoz
                segedEvTizedek.Add(evtized(akt.ev));
            }
            be.Close();

            //3. feladat
            Console.WriteLine("3. feladat: " + adatok.Count);

            //4. feladat
            Console.WriteLine("4. feladat: " + legtobbEv);

            //5. feladat
            List<int> evtizedek = segedEvTizedek.ToList<int>();
            int[] evtizedDB = new int[evtizedek.Count];
            for (int i = 0; i < adatok.Count; i++)
            {
                for (int j = 0; j < evtizedek.Count; j++)
                {
                    if (evtized(adatok[i].ev) == evtizedek[j])
                    {
                        evtizedDB[j] += adatok[i].győzelmek;
                        break;
                    }
                }
            }
            Console.WriteLine("5. feladat:");
            for (int i = 0; i < evtizedDB.Length; i++)
            {
                Console.WriteLine($"\t{evtizedek[i]}-es évek: {evtizedDB[i]} megnyert verseny");
            }

            //6. feladat
            StreamWriter html = new StreamWriter("jackie.html");
            html.WriteLine("<!doctype html>\n<html>\n<head></head>\n" +
                "<style>td { border:1px solid black;}</style>\n<body>\n<h1>Jackie Stewart</h1>\n" +
                "<table>");
            for (int i = 0; i < adatok.Count; i++)
            {
                html.WriteLine($"<tr><td>{adatok[i].ev}</td><td>{adatok[i].versenyek}</td>" +
                    $"<td>{adatok[i].győzelmek}</td></tr>");
            }
            html.WriteLine("</table>\n</body>\n</html>");
            html.Close();
            Console.WriteLine("6. feladat: jackie.html");
        }
    }
}
