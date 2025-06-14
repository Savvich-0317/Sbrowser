using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            comboBox1.SelectedIndex = Convert.ToInt32(Settings.Default.theme);
            textBox1.Text = Settings.Default.homepage;
            if (Settings.Default.ClearHistory)
            {
                checkBox1.Checked = true;
            }
            else
            {
                checkBox1.Checked = false;
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
            Settings.Default.theme =Convert.ToBoolean(comboBox1.SelectedIndex);
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
    }
}
