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
    public partial class Form3 : Form
    {
        private Form1 main;/*Очень важная штука*/
        public Form3(Form1 form /*Очень важная штука*/)
        {
            InitializeComponent();
            this.main = form; /*Очень важная штука*/
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            main.SendAdress("https://github.com/Savvich-0317/Sbrowser");
        }
    }
}
