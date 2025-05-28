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

    
    


    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Timer timer;
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += UpdateAdress;
            timer.Start();

        }

        private void UpdateAdress(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(webView21.Source);
        }




        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                webView21.Source = new Uri(textBox1.Text);
            }
            catch {
                if (textBox1.Text.Contains("https://"))
                {
                    textBox1.Text = "Adress not responding, or not valid";
                }
                else
                {
                    try
                    {
                        webView21.Source = new Uri("https://"+textBox1.Text);
                        textBox1.Text = "https://" + textBox1.Text;
                    }
                    catch {

                        textBox1.Text = "Adress not responding, or not valid";

                    }
                }
               
            }
        }

        
    }
}
