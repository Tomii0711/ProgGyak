using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Haromszogek
{
    //1.2 feladat
    class DHaromszog
    {
        private double aOldal;
        private double bOldal;
        private double cOldal;
        private bool oldalHiba = false;
        public int sorSzam;

        //1.3 feladat
        public DHaromszog(string sor, int sorSzáma)
        {
            sorSzam = sorSzáma;
            string[] sorDB = sor.Split(' ');
            a = Convert.ToDouble(sorDB[0]);
            b = Convert.ToDouble(sorDB[1]);
            c = Convert.ToDouble(sorDB[2]);
            bool voltHiba = false;
            if (!oldalHiba)
            {
                if (!EllNovekvoSorrend)
                {
                    Form1.hibák.Add($"{sorSzáma}. sor: Az adatok nincsenek növekvő sorrendben!");
                    voltHiba = true;
                }
                if (!EllMegszerkesztheto)
                {
                    if (!voltHiba)
                    {
                        Form1.hibák.Add($"{sorSzáma}. sor: A háromszöget nem lehet megszerkeszteni!");
                        voltHiba = true;
                    }
                }
                if (!EllDerekszogu)
                {
                    if (!voltHiba)
                    {
                        Form1.hibák.Add($"{sorSzáma}. sor: A háromszög nem derékszögű!");
                    }
                }
            }
        }
        private bool EllDerekszogu
        {
            get
            {
                if (Math.Pow(c, 2) == (Math.Pow(a, 2) + Math.Pow(b, 2)))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        private bool EllMegszerkesztheto
        {
            get
            {
                if (a + b > c)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        private bool EllNovekvoSorrend
        {
            get
            {
                if (a <= b && b <= c)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        //1.4 feladat
        public double a 
        {
            get => aOldal;
            set
            {
                if (value > 0)
                {
                    aOldal = value;
                }
                else
                {
                    Form1.hibák.Add(sorSzam +". sor: A(z) 'a' oldal nem lehet nulla vagy negatív!");
                    oldalHiba = true;
                }
            }
        }
        public double b
        {
            get => bOldal;
            set
            {
                if (value > 0)
                {
                    bOldal = value;
                }
                else
                {
                    Form1.hibák.Add(sorSzam + ". sor: A(z) 'b' oldal nem lehet nulla vagy negatív!");
                    oldalHiba = true;
                }
            }
        }
        public double c
        {
            get => cOldal;
            set
            {
                if (value > 0)
                {
                    cOldal = value;
                }
                else
                {
                    Form1.hibák.Add(sorSzam + ". sor: A(z) 'c' oldal nem lehet nulla vagy negatív!");
                    oldalHiba = true;
                }
            }
        }

        //1.5 feladat
        public double Kerulet
        {
            get
            {
                return(a + b + c);
            }
        }
        public double Terulet
        {
            get
            {
                return (a * b / 2);
            }
        }
    }
}