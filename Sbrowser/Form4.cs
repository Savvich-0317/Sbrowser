using Sbrowser;
using Sbrowser.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sbrowser
{
    public partial class Form4 : Form
    {
        System.Windows.Forms.Timer timer;


        public Form4()
        {
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 6000;
            timer.Tick += CheckerCycle;
            InitializeComponent();
            label3.Text = trackBar1.Value.ToString();
            label2.Text = trackBar1.Value.ToString() + " minutes to focus!";
        }
    
    

            
            
        
        
        private void CheckerCycle(object sender, EventArgs e)
        {
            if (trackBar1.Value <= 1)
            {
                label3.Text = "✔";
                timer.Stop();
                trackBar1.Enabled = true;
                button1.Enabled = true;
                SoundPlayer notify = new SoundPlayer(@".\notify.wav");
                notify.Play();
                
            }
            else
            {
                label3.Text = (trackBar1.Value = trackBar1.Value - 1).ToString();
              

            }
            Settings.Default.Pomodoro = label3.Text;
            Settings.Default.Save();

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
            timer.Start();
            trackBar1.Enabled = false;
            button1.Enabled = false;
        }



        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                this.Visible = false;
                e.Cancel = true;
            }
        }
    }
}

