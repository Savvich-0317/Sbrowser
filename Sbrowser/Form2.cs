using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sbrowser.Properties;

namespace Sbrowser
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            
            InitializeComponent();
            comboBox1.SelectedIndex = Convert.ToInt32(Settings.Default.theme);
            textBox1.Text = Settings.Default.homepage;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Settings.Default.homepage = textBox1.Text;
            Settings.Default.theme =Convert.ToBoolean(comboBox1.SelectedIndex);
            Settings.Default.Save();
            button1.Text = "Saved!";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
