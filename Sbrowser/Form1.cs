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
            tabPage1.Name = "Page1";
        }

        private void webView21_Click(object sender, EventArgs e)
        {
        }

        

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                webView21.Source = new Uri(textBox1.Text);
            }
            catch { 
                textBox1.Text = "Error";
            }
        }
    }
}
