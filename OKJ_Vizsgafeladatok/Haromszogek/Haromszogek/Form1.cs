using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

//1.1 feladat
namespace Haromszogek
{
    //1.6 feladat
    public partial class Form1 : Form
    {
        public string path;
        public string tartalom;
        public static List<string> hibák = new List<string>();
        static List<DHaromszog> derekSzoguek = new List<DHaromszog>();
        public int kivalasztva;

        public Form1()
        {
            InitializeComponent();
        }

        //1.7 feladat
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog be = new OpenFileDialog();
            be.InitialDirectory = "";
            if (be.ShowDialog() == DialogResult.OK)
            {
                path = be.FileName;
                StreamReader olvas = new StreamReader(path);
                tartalom = olvas.ReadToEnd();

                listBox1.Items.Clear();
                listBox2.Items.Clear();
                label1.Text = "Kerület = ";
                label2.Text = "Terület = ";
                hibák.Clear();
                derekSzoguek.Clear();

                string [] sorok = tartalom.Split('\n');
                for (int i = 0; i < sorok.Length; i++)
                {
                    DHaromszog akt = new DHaromszog(sorok[i], i + 1);
                    if (Math.Pow(akt.c, 2) == (Math.Pow(akt.a, 2) + Math.Pow(akt.b, 2)))
                    {
                        derekSzoguek.Add(akt);
                    }
                }
                for (int i = 0; i < hibák.Count; i++)
                {
                    listBox2.Items.Add(hibák[i]);
                }
                for (int i = 0; i < derekSzoguek.Count; i++)
                {
                    DHaromszog t = derekSzoguek[i];
                    string szoveg = ($"{t.sorSzam}. sor: a={t.a} b={t.b} c={t.c}");
                    listBox1.Items.Add(szoveg);
                }
            }
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            label1.Text = "Kerület = " + derekSzoguek[listBox1.SelectedIndex].Kerulet;
            label2.Text = "Terület = " + derekSzoguek[listBox1.SelectedIndex].Terulet;
        }
    }
}
