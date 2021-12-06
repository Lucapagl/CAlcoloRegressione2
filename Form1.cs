using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CAlcoloRegressione
{
    
    public partial class Form1 : Form
    {
        private int modello;
        double[] Con = new  Double[6]  ;
        double[] Dos = new double [6] ;
        double[] Parametri = new double[6];
        double OdDaCalcolare, ConcDaCalcolare;
        double odDaCalcolare;
        Double concDaCalcolare;
        int numPar;
        int Errorer;
        int Modello;
        double odmin;

        double odmax;
        double CMin;
        double Cmax;
        Graphics Piano;
        long l, h;

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            modello = 1;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            modello = 2;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            modello = 3;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            Modello = 4;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            modello = 5;
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            modello = 6;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Declare the first few notes of the song, "Mary Had A Little Lamb".
         
                {
                Sample.testsound();
        };
            // Play the song
           
        }

        private Double Scalax, Scalay;

        
        public Form1()
        {
            Pen Penna;
             Penna = new Pen(Color.Black, 1);
            InitializeComponent();
        }
    }
}
