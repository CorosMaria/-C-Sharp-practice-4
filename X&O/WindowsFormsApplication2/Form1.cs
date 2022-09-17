using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        System.Drawing.Graphics Desen;
        System.Drawing.Pen Creion_negru;
        bool jucator1;//Pentru alternarea intre jucatori
        bool blocat;//Definim o variabila care indica terminarea jocului
        string[,] tabel = new string[3, 3]//Definim un tablou pentru retinere valori casute
        {
   {"-", "-", "-"} ,   
   {"-", "-", "-"} ,  
   {"-", "-", "-"}  
};
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            int pozX, pozY;
            int rind, col;
            int r, c;
            Point coordonate = e.Location;
            pozX = coordonate.X;
            pozY = coordonate.Y;
            col = 0;
            rind = 0;
            if (blocat == true)
            {
                DialogResult m_box = MessageBox.Show("Jocul s-a terminat!\n Doriti sa incepeti un joc nou?", "Joc terminat", MessageBoxButtons.YesNo);
                if (m_box == DialogResult.Yes)
                {
                    redeseneaza();
                    return;
                }
                if (m_box == DialogResult.No)
                {
                    return;
                }

            }
            //Evaluam pozitia unde se da click si determinam chenarul
            if (pozX < 90)//S-a dat click in afara chenarului, partea stanga
            {
                col = 0;
                rind = 0;
                return;
            }
            if (pozX >= 90)
            {
                col = 1;
            }
            if (pozX >= 170)
            {
                col = 2;
            }
            if (pozX >= 250)
            {
                col = 3;
            }

            if (pozX >= 330)//S-a dat click in afara chenarului, partea dreapta
            {
                col = 0;
                rind = 0;
                return;
            }
            if (pozY < 90)//S-a dat click in afara chenarului, partea de sus
            {
                col = 0;
                rind = 0;
                return;
            }

            if (pozY >= 90)
            {
                rind = 1;
            }

            if (pozY >= 170)
            {
                rind = 2;
            }
            if (pozY >= 250)
            {
                rind = 3;
            }
            if (pozY >= 330) //S-a dat click in afara chenarului, partea de jos
            {
                rind = 0;
                col = 0;
                return;
            }

            if (tabel[rind - 1, col - 1] != "-")
            {
                MessageBox.Show("Alegeti alta casuta!");
                return;
            }


            jucator1 = !jucator1;//Schimbam jucatorii
            switch (jucator1)//Afisam jucatorul care urmeaza sa aleaga 
            {
                case true:
                    lblJucator.Text = "Alege Jucator 1";
                    break;
                case false:
                    lblJucator.Text = "Alege Jucator 2";
                    break;
            }
            string STRpOZX;
            string STRpOZY;
            STRpOZX = col.ToString();
            STRpOZY = rind.ToString();
            System.Drawing.Rectangle cadru = new Rectangle();
            System.Drawing.Pen Creion_albastru;
            System.Drawing.Pen Creion_rosu;
            System.Drawing.Pen Creion_verde;
            Creion_albastru = new System.Drawing.Pen(System.Drawing.Color.Blue);
            Creion_rosu = new System.Drawing.Pen(System.Drawing.Color.Red);
            Creion_verde = new System.Drawing.Pen(System.Drawing.Color.Green);
            cadru.X = 20 + col * 80;
            cadru.Y = 20 + rind * 80;
            cadru.Width = 60;
            cadru.Height = 60;
            if (jucator1 == true)
            {
                Desen.DrawEllipse(Creion_rosu, cadru);
                tabel[rind - 1, col - 1] = "0";//Retinem in vector la poziia aleasa valoarea 0
            }
            else
            {//Trasam doua linii incrucisate pe chenarul ales
                Point inceput = new Point();
                Point sfarsit = new Point();
                inceput.X = col * 80 + 20;
                inceput.Y = rind * 80 + 20;
                sfarsit.X = col * 80 + 80;
                sfarsit.Y = rind * 80 + 80;
                Desen.DrawLine(Creion_albastru, inceput, sfarsit);
                inceput.X = col * 80 + 80;
                inceput.Y = rind * 80 + 20;
                sfarsit.X = col * 80 + 20;
                sfarsit.Y = rind * 80 + 80;
                Desen.DrawLine(Creion_albastru, inceput, sfarsit);
                tabel[rind - 1, col - 1] = "x";//Retinem in vector la poziia aleasa valoarea X
            }
            //Verific completare randuri pentru a determina castigatorul
            if ((tabel[0, 0] == tabel[0, 1]) && (tabel[0, 0] == tabel[0, 2]) && (tabel[0, 0] != "-"))
            {
                Desen.DrawLine(Creion_verde, 90, 10 + rind * 80 + 40, 330, 10 + rind * 80 + 40);
                blocat = true;
            }

            if ((tabel[1, 0] == tabel[1, 1]) && (tabel[1, 0] == tabel[1, 2]) && (tabel[1, 0] != "-"))
            {
                Desen.DrawLine(Creion_verde, 90, 10 + rind * 80 + 40, 330, 10 + rind * 80 + 40);
                blocat = true;
            }

            if ((tabel[2, 0] == tabel[2, 1]) && (tabel[2, 0] == tabel[2, 2]) && (tabel[2, 0] != "-"))
            {
                Desen.DrawLine(Creion_verde, 90, 10 + rind * 80 + 40, 330, 10 + rind * 80 + 40);
                blocat = true;
            }
            //Verific completare coloane

            if ((tabel[0, 0] == tabel[1, 0]) && (tabel[0, 0] == tabel[2, 0]) && (tabel[0, 0] != "-"))
            {
                Desen.DrawLine(Creion_verde, 130 + (col - 1) * 80, 90, 130 + (col - 1) * 80, 330);
                blocat = true;
            }

            if ((tabel[0, 1] == tabel[1, 1]) && (tabel[0, 1] == tabel[2, 1]) && (tabel[0, 1] != "-"))
            {
                Desen.DrawLine(Creion_verde, 130 + (col - 1) * 80, 90, 130 + (col - 1) * 80, 330);
                blocat = true;
            }

            if ((tabel[0, 2] == tabel[1, 2]) && (tabel[0, 2] == tabel[2, 2]) && (tabel[0, 2] != "-"))
            {
                Desen.DrawLine(Creion_verde, 130 + (col - 1) * 80, 90, 130 + (col - 1) * 80, 330);
                blocat = true;
            }
            //Verific completare diagonale
            if ((tabel[0, 0] == tabel[1, 1]) && (tabel[0, 0] == tabel[2, 2]) && (tabel[0, 0] != "-"))
            {
                Desen.DrawLine(Creion_verde, 90, 90, 330, 330);
                blocat = true;
            }

            if ((tabel[0, 2] == tabel[1, 1]) && (tabel[0, 2] == tabel[2, 0]) && (tabel[0, 2] != "-"))
            {
                Desen.DrawLine(Creion_verde, 90, 330, 330, 90);
                blocat = true;
            }
            if (blocat == true)
            {
                string nume_jucator;
                if (jucator1 == false)
                {
                    nume_jucator = "Jucator 1(X)";
                }
                else
                {
                    nume_jucator = "Jucator 2(O)";
                }
                MessageBox.Show(nume_jucator + " a castigat!\n          FELICITARI!!!", "Joc terminat");
                return;
            }
            for (r = 0; r <= 2; r++)
            {
                for (c = 0; c <= 2; c++)
                    if (tabel[r, c] == "-")
                    {
                        return;
                    }
            }
            MessageBox.Show(" Remiza!");
            blocat = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            redeseneaza();
        }
        private void redeseneaza()
        {
            int h, w, rind, col;
            h = 80;
            w = 80;
            rind = 1;
            col = 1;
            int x, y, r, c;
            x = 10;
            y = 10;
            blocat = false;
            Desen = this.CreateGraphics();
            Creion_negru = new System.Drawing.Pen(System.Drawing.Color.Black);
            Desen.Clear(this.BackColor);
            for (rind = 1; rind <= 3; rind++)
            {
                for (col = 1; col <= 3; col++)
                    Desen.DrawRectangle(Creion_negru, x + col * w, y + rind * h, h, w);
            }
            for (r = 0; r <= 2; r++)
            {
                for (c = 0; c <= 2; c++)
                    tabel[r, c] = "-";
            }
            jucator1 = true;
            lblJucator.Visible= true;
        }
    }
}
