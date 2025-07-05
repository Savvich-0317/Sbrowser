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
using Microsoft.Web.WebView2.WinForms;
using Sbrowser.Properties;

namespace Sbrowser
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            
            InitializeComponent();
            
            label6.Text = Settings.Default.Opacity.ToString();
            trackBar1.Value = Settings.Default.Opacity;
            comboBox1.SelectedItem = Settings.Default.theme;
            textBox1.Text = Settings.Default.homepage;
          
            checkBox1.Checked = Settings.Default.ClearHistory;
            checkBox2.Checked = Settings.Default.Animations;
            checkBox3.Checked = Settings.Default.CardSound;
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




        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Settings.Default.Opacity = trackBar1.Value;
            Settings.Default.ClearHistory = checkBox1.Checked;
            Settings.Default.homepage = textBox1.Text;
            Settings.Default.theme = comboBox1.SelectedItem.ToString();
            Settings.Default.Animations = checkBox2.Checked;
            Settings.Default.CardSound = checkBox3.Checked;
            Settings.Default.UseStartScreenSize = checkBox4.Checked;
            Settings.Default.Save();
            button1.Text = "Saved!";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        Form1 main = new Form1();
        private void button2_Click(object sender, EventArgs e)
        {
            
            main.DeleteHistory();
            MessageBox.Show("All your data has been removed!");
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label6.Text = trackBar1.Value.ToString();
        }

        private void Form2_Load(object sender, EventArgs e)
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

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
