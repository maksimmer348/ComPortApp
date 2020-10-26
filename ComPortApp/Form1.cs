using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using ZedGraph;
using System.Timers;

namespace ComPortApp
{
    public partial class Form1 : Form
    {
        private TemperatureGraph TG;
        private ComSettings comSettings;
        public Form1()
        {
            InitializeComponent();

            //класс для исеользования графика
            TG = new TemperatureGraph(GraphTemperature);
            comSettings = new ComSettings();
            comSettings.ShowDialog();
            
        }

       


        private void Form1_Load(object sender, EventArgs e)
        {
            TG.Graph();
            this.Close();
        }

        private void PowerSupplyControl_Enter(object sender, EventArgs e)
        {

        }


        public void GraphTemperature_Load(object sender, EventArgs e)
        {
            //график температуры
        }

         
       

        private void DeltaOne_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void DeltaTwo_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void TemperatureOne_TextChanged(object sender, EventArgs e)
        {

        }

        private void TemperatureTwo_TextChanged(object sender, EventArgs e)
        {

        }

        private void ComMenu_Click(object sender, EventArgs e)
        {
            comSettings.ShowDialog();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Output_Click(object sender, EventArgs e)
        {

        }

        private void VoltageValueWrite_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
