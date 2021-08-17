using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

//1. feladat
namespace HegyekMo
{
    class Hegy
    {
        public string hegycsucs;
        public string hegyseg;
        public int magassag;
        public double lab;

        public Hegy(string [] sor)
        {
            hegycsucs = sor[0];
            hegyseg = sor[1];
            magassag = Convert.ToInt32(sor[2]);
            lab = magassag * 3.280839895;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //segédváltozók
            List<Hegy> hegyek = new List<Hegy>();
            double magassagSum = 0;
            int borzsonyMax = 0;
            int magasLabDB = 0;
            HashSet<string> segedHegysegek = new HashSet<string>();

            //2. feladat
            StreamReader be = new StreamReader("hegyekMo.txt");
            be.ReadLine();
            while (!be.EndOfStream)
            {
                Hegy akt = new Hegy(be.ReadLine().Split(';'));
                hegyek.Add(akt);

                //4. feladathoz
                magassagSum += akt.magassag;
                //7. feladathoz
                if (akt.lab > 3000)
                {
                    magasLabDB++;
                }
                //8. feladathoz
                segedHegysegek.Add(akt.hegyseg);
            }
            be.Close();
            //8. feladathoz
            List<string> hegysegNevek = segedHegysegek.ToList<string>();
            int[] hegysegDB = new int[hegysegNevek.Count];

            //3. feladat
            Console.WriteLine($"3. feladat: Hegycsúcsok száma: {hegyek.Count} db");

            //4. feladat
            Console.WriteLine($"4. feladat: Hegycsúcsok átlagos magassága: {Math.Round(magassagSum / hegyek.Count, 2)} m");

            //5. feladat
            int maxMagassag = 0, maxIndex = 0;
            for (int i = 0; i < hegyek.Count; i++)
            {
                if (hegyek[i].magassag > maxMagassag)
                {
                    maxMagassag = hegyek[i].magassag;
                    maxIndex = i;
                }

                //6. feladahoz
                if (hegyek[i].hegyseg == "Börzsöny")
                {
                    if (hegyek[i].magassag > borzsonyMax)
                    {
                        borzsonyMax = hegyek[i].magassag;
                    }
                }

                //8. feladathoz
                for (int j = 0; j < hegysegNevek.Count; j++)
                {
                    if (hegyek[i].hegyseg == hegysegNevek[j])
                    {
                        hegysegDB[j]++;
                        break;
                    }
                }
            }
            Console.WriteLine("5. feladat: A legmagasabb hegycsúcs adatai:");
            Console.WriteLine($"\tNév: {hegyek[maxIndex].hegycsucs}\n\tHegység: {hegyek[maxIndex].hegyseg}\n\tMagasság: {hegyek[maxIndex].magassag} m");

            //6. feladat
            Console.Write("6. feladat: Kérek egy magasságot: ");
            int beMagassag = Convert.ToInt32(Console.ReadLine());
            string vanE = (beMagassag < borzsonyMax) ? "Van" : "Nincs";
            Console.WriteLine($"\t{vanE} {beMagassag}m-nél magasabb hegycsúcs a Börzsönyben!");

            //7. feladat
            Console.WriteLine($"7. feladat: 3000 lábnál magasabb hegycsúcsok száma: {magasLabDB}");

            //8. feladat
            Console.WriteLine("8. feladat: Hegység statisztika");
            for (int i = 0; i < hegysegNevek.Count; i++)
            {
                Console.WriteLine($"\t{hegysegNevek[i]} - {hegysegDB[i]} db");
            }

            //9. feladat
            StreamWriter ki = new StreamWriter("bukk-videk.txt");
            ki.WriteLine("Hegycsúcs neve;Magasság láb");
            for (int i = 0; i < hegyek.Count; i++)
            {
                if (hegyek[i].hegyseg == "Bükk-vidék")
                {
                    double labKi = Math.Round(hegyek[i].lab, 1);
                    ki.WriteLine($"{hegyek[i].hegycsucs};{labKi.ToString(CultureInfo.InvariantCulture)}");
                }
            }
            ki.Close();
        }
    }
}
