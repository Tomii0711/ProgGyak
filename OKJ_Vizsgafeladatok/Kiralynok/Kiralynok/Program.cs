using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace Kiralynok
{
    //1. feladat [sor,oszlop]
    class Tábla
    {
        //2. feladat
        private char[,] T;
        private char ÜresCella;

        //3. feladat
        public Tábla(char ÜresCellaÉrték)
        {
            T = new char[8,8];
            ÜresCella = ÜresCellaÉrték;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    T[i, j] = ÜresCella;
                }
            }
        }

        //4. feladathoz
        public string Megjelenít()
        {
            string KiIr = "";
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    KiIr += T[i,j];
                }
                KiIr += "\n";
            }
            return KiIr;
        }

        //5. feladat
        public void Elhelyez(int N)
        {
            int elhelyezettDB = 0;
            while (elhelyezettDB != N)
            {
                Random rand = new Random();
                int sor = rand.Next(0, 8);
                int oszlop = rand.Next(0, 8);
                if (T[sor,oszlop] != 'K')
                {
                    T[sor, oszlop] = 'K';
                    elhelyezettDB++;
                }
            }
        }

        //7. feladat
        public bool ÜresOszlop(int O)
        {
            bool üres = true;
            for (int i = 0; i < 8; i++)
            {
                if (T[i,O] == 'K')
                {
                    üres = false;
                    break;
                }
            }
            return üres;
        }
        public bool ÜresSor(int S)
        {
            bool üres = true;
            for (int i = 0; i < 8; i++)
            {
                if (T[S,i] == 'K')
                {
                    üres = false;
                    break;
                }
            }
            return üres;
        }

        //8. feladat
        public int ÜresOszlopokSzáma
        {
            get
            {
                int db = 0;
                for (int i = 0; i < 8; i++)
                {
                    if (this.ÜresOszlop(i))
                    {
                        db++;
                    }
                }
                return db;
            }
        }
        public int ÜresSorokSzáma
        {
            get
            {
                int db = 0;
                for (int i = 0; i < 8; i++)
                {
                    if (this.ÜresSor(i))
                    {
                        db++;
                    }
                }
                return db;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //4. feladat
            Tábla akt = new Tábla('#');
            Console.WriteLine("4. feladat: Az üres tábla:");
            Console.WriteLine(akt.Megjelenít());

            //6. feladat
            akt.Elhelyez(8);
            Console.WriteLine("\n6. feladat: A feltöltött tábla");
            Console.WriteLine(akt.Megjelenít());

            //9. feladat
            Console.WriteLine($"\n9. feladat: Üres oszlopok és sorok száma:\nOszlopok: {akt.ÜresOszlopokSzáma}\nSorok: {akt.ÜresSorokSzáma}");

            //10. feladat
            StreamWriter ki = new StreamWriter("tablak64.txt");
            for (int i = 1; i < 65; i++)
            {
                Tábla uj = new Tábla('*');
                uj.Elhelyez(i);
                ki.WriteLine(uj.Megjelenít());
            }
            ki.Close();
        }
    }
}
