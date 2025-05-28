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

        private void webView21_SourceChanged(object sender, Microsoft.Web.WebView2.Core.CoreWebView2SourceChangedEventArgs e)
        {
            if (textBox1.Text != webView21.Source.ToString())
            {
                textBox1.Text = webView21.Source.ToString();
            }
        }
    }
}
