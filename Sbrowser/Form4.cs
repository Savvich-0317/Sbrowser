using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sbrowser
{
    public partial class Form4 : Form
    {
        

        public Form4()
        {
            InitializeComponent();
            label3.Text = trackBar1.Value.ToString();


            label2.Text = trackBar1.Value.ToString() + " minutes to focus!";
        }
        
        private void CheckerCycle(object sender, EventArgs e)
        {
            label3.Text = (trackBar1.Value = trackBar1.Value - 1).ToString();
            
        }

        


        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label2.Text = trackBar1.Value.ToString() + " minutes to focus!";
            label3.Text = trackBar1.Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Timer timer;
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 60000;
            timer.Tick += CheckerCycle;
            timer.Start();
            trackBar1.Enabled = false;
            button1.Enabled = false;
        }
    }
}
