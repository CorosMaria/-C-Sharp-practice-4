using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Binar___Vumetru
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public System.Drawing.Graphics Desen;
        public System.Drawing.Pen Creion_negru;
        public System.Drawing.SolidBrush Pensula_albastra;
        public System.Drawing.SolidBrush Radiera;
        public binar Binar;
        System.Random nr;
        UInt64 n;
        UInt64 increment1 = 256;
        UInt64 increment2 = 1;
        UInt64 increment3 = 255;
        UInt64 increment4 = 255;
        UInt64 increment5 = 6;
        int i;
    
        public class binar
        {
            int x0;
            int y0;
            int Latime_chenar;
            int Inaltime_chenar;
            
            public void setval(int Numar_becuri, UInt64 n, System.Drawing.Graphics Zona_desenare, System.Drawing.Pen Creion_n, System.Drawing.SolidBrush Pensula_albastra, System.Drawing.SolidBrush Radiera)
            {

                int Latime_bec = Latime_chenar / (3 * Numar_becuri);
                int Inaltime_bec = Inaltime_chenar / 3;
                int x = x0 + Latime_chenar - 3 * Latime_bec;
                int y = y0 + Inaltime_bec;
                int i;
                Zona_desenare.DrawRectangle(Creion_n, x0, y0, Latime_chenar, Inaltime_chenar);//Deseneaza chenar
                for (i = Numar_becuri - 1; i >= 0; i--)
                {
                    System.UInt64 bit = ((n >> (Numar_becuri - i - 1)) & 1);
                    Zona_desenare.DrawRectangle(Creion_n, x - 1, y - 1, Latime_bec + 1, Inaltime_bec + 1);
                    if (bit == 1)
                        Zona_desenare.FillRectangle(Pensula_albastra, x, y, Latime_bec, Inaltime_bec);
                    else
                        Zona_desenare.FillRectangle(Radiera, x, y, Latime_bec, Inaltime_bec);

                    x -= 3 * Latime_bec;

                }
            }
            public void init_binar(int pozx, int pozy, int lat, int inalt)
            {
                x0 = pozx;
                y0 = pozy;
                Latime_chenar = lat;
                Inaltime_chenar = inalt;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Creion_negru = new System.Drawing.Pen(System.Drawing.Color.Black);
            Pensula_albastra = new System.Drawing.SolidBrush(System.Drawing.Color.Blue);
            Radiera = new System.Drawing.SolidBrush(this.BackColor);
            Desen = this.CreateGraphics();
            nr = new System.Random();
            Binar = new binar();
            
        }
  
        private void timer1_Tick(object sender, EventArgs e)
        {
              
            for (i = 1; i <= 8; i++) 
            {
                increment1 = increment1 / 2;//deplasare stanga-dreapta
                Binar.setval(8, increment1, Desen, Creion_negru, Pensula_albastra, Radiera);
                System.Threading.Thread.Sleep(500);
            }
            timer1.Enabled = false;
            increment1 = 256;


        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                timer1.Enabled = true;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Binar.init_binar(100, 100, 500, 50);
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                timer2.Enabled = true;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            for (i = 1; i <= 8; i++)
            {
                increment2 = increment2 * 2; //deplasare drepata-stanga
                Binar.setval(8, increment2, Desen, Creion_negru, Pensula_albastra, Radiera);
                System.Threading.Thread.Sleep(500);
            }
            timer2.Enabled = false;
            increment2 = 1;

        }

        private void radioButton3_Click(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                timer3.Enabled = true;
                
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            for (i = 1; i <= 8; i++)
            {
                increment3 = increment3 / 2; //creste
                Binar.setval(8, 255 - increment3, Desen, Creion_negru, Pensula_albastra, Radiera);
                System.Threading.Thread.Sleep(500);
            }
            timer3.Enabled = false;
            increment3 = 255;
            
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            for (i = 1; i <= 8; i++)
            {
                increment4 = increment4 * 2; //scade
                Binar.setval(8, increment4, Desen, Creion_negru, Pensula_albastra, Radiera);
                System.Threading.Thread.Sleep(500);
            }
            timer4.Enabled = false;
            increment4 = 255;

        }

        private void radioButton4_Click(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true)
            {
                timer4.Enabled = true;
            }
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
           Binar.setval(8, System.Convert.ToUInt64(nr.Next(1999999999)), Desen, Creion_negru, Pensula_albastra, Radiera);  //Random     
        }

        private void radioButton5_Click(object sender, EventArgs e)
        {
            if (radioButton5.Checked == true)
            {
                timer5.Enabled = true;
            }
        }

        private void radioButton6_Click(object sender, EventArgs e)
        {
            if (radioButton6.Checked == true)
            {
                timer6.Enabled = true;
            }
        }

        private void timer6_Tick(object sender, EventArgs e)
        {
            UInt64 increment6 = 129;
            Binar.setval(8, increment6, Desen, Creion_negru, Pensula_albastra, Radiera);
            System.Threading.Thread.Sleep(500);
            UInt64 increment7 = 195;
            Binar.setval(8,  increment7, Desen, Creion_negru, Pensula_albastra, Radiera);
            System.Threading.Thread.Sleep(500);
            UInt64 increment8 = 231;
            Binar.setval(8, increment8, Desen, Creion_negru, Pensula_albastra, Radiera);
            System.Threading.Thread.Sleep(500);
            UInt64 increment9 = 255;
            Binar.setval(8, increment9, Desen, Creion_negru, Pensula_albastra, Radiera);
            System.Threading.Thread.Sleep(500);

            timer4.Enabled = false;
            increment6 = 129;
        }

        private void timer7_Tick(object sender, EventArgs e)
        {
            
            UInt64 increment6 = 24;
            Binar.setval(8, increment6, Desen, Creion_negru, Pensula_albastra, Radiera);
            System.Threading.Thread.Sleep(500);
            UInt64 increment7 = 60;
            Binar.setval(8, increment7, Desen, Creion_negru, Pensula_albastra, Radiera);
            System.Threading.Thread.Sleep(500);
            UInt64 increment8 = 126;
            Binar.setval(8, increment8, Desen, Creion_negru, Pensula_albastra, Radiera);
            System.Threading.Thread.Sleep(500);
            UInt64 increment9 = 255;
            Binar.setval(8, increment9, Desen, Creion_negru, Pensula_albastra, Radiera);
            System.Threading.Thread.Sleep(500);

            timer7.Enabled = false;
            increment6 = 24;
        }
        private void radioButton7_Click(object sender, EventArgs e)
        { 
            if (radioButton7.Checked == true)
            {
                timer7.Enabled = true;
            }

        }
    }
}
