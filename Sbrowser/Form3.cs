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
    public partial class Form3 : Form
    {
        private Form1 main;/*Очень важная штука*/
        public Form3(Form1 form /*Очень важная штука*/)
        {
            InitializeComponent();
            this.main = form; /*Очень важная штука*/
        }
        public async Task FormZoomAsync()
        {
            int ScaleModifier = 15;
            for (int i = 0; i < ScaleModifier; i++)
            {
                if (i - ScaleModifier <= i)
                {
                    await Task.Delay(1);
                    this.Location = new Point(this.Location.X - 1, this.Location.Y - 1);
                    this.Height += 2;
                    this.Width += 2;
                }

            }
            for (int i = 0; i < ScaleModifier; i++)
            {
                if (i - ScaleModifier <= i)
                {
                    await Task.Delay(1);
                    this.Location = new Point(this.Location.X + 1, this.Location.Y + 1);
                    this.Height -= 2;
                    this.Width -= 2;
                }

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            main.SendAdress("https://github.com/Savvich-0317/Sbrowser");
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            if (Settings.Default.Animations)
            {
                FormZoomAsync();
            }
            if (Settings.Default.CardSound)
            {
                //SoundPlayer card = new SoundPlayer(@".\card.wav");
                //card.Play();
            }

        }
    }
}
