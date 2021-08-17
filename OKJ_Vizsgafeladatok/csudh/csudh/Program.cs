using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

//1. feladat
namespace csudh
{
    class DomainClass
    {
        public string nev;
        public string ipCim;

        public DomainClass(string[] beSor)
        {
            nev = beSor[0];
            ipCim = beSor[1];
        }

        //4. feladat
        public string Domain(int szint)
        {
            string[] szintek = nev.Split('.');
            if (szint > szintek.Length)
            {
                return "nincs";
            }
            else
            {
                return szintek[szintek.Length - szint];
            }
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            //segédváltozók
            List<DomainClass> domainek = new List<DomainClass>();

            //2. feladat
            StreamReader be = new StreamReader("csudh.txt");
            be.ReadLine();
            while (!be.EndOfStream)
            {
                DomainClass akt = new DomainClass(be.ReadLine().Split(';'));
                domainek.Add(akt);
            }
            be.Close();
            //3. feladat
            Console.WriteLine($"3. feladat: Domainek száma: {domainek.Count}");
            //5. feladat
            Console.WriteLine("5. feladat: Az első domain felépítése:");
            for (int i = 1; i < 6; i++)
            {
                Console.WriteLine("\t{0}. szint: {1}", i, domainek[0].Domain(i));
            }
            //6. feladat
            StreamWriter ki = new StreamWriter("table.html");
            string igazitas = "left";
            ki.WriteLine("<table>\n<tr>");
            ki.WriteLine("<th style='text-align: {0}'>Ssz</th>", igazitas);
            ki.WriteLine("<th style='text-align: {0}'>Host domain neve</th>", igazitas);
            ki.WriteLine("<th style='text-align: {0}'>Host IP cime</th>", igazitas);
            ki.WriteLine("<th style='text-align: {0}'>1. szint</th>", igazitas);
            ki.WriteLine("<th style='text-align: {0}'>2. szint</th>", igazitas);
            ki.WriteLine("<th style='text-align: {0}'>3. szint</th>", igazitas);
            ki.WriteLine("<th style='text-align: {0}'>4. szint</th>", igazitas);
            ki.WriteLine("<th style='text-align: {0}'>5. szint</th>\n</tr>", igazitas);
            for (int i = 0; i < domainek.Count; i++)
            {
                ki.WriteLine("<tr>\n<th style='text-align: {0}'>{1}.</th>", igazitas, i + 1);
                ki.WriteLine("<td>{0}</td>", domainek[i].nev);
                ki.WriteLine("<td>{0}</td>", domainek[i].ipCim);
                for (int j = 1; j < 6; j++)
                {
                    ki.WriteLine("<td>{0}</td>", domainek[i].Domain(j));
                }
                ki.WriteLine("</tr>");
            }
            ki.WriteLine("</table>");
            ki.Close();
        }
    }
}
