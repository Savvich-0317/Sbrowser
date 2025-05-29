using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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

            
            SendAdress();
        }

        private void SendAdress()
        {
            

            try
            {
                
                webView21.Source = new Uri(textBox1.Text);
            }
            catch
            {
                if (textBox1.Text.Contains("https://"))
                {
                    textBox1.Text = "Adress not responding, or not valid";
                }
                else
                {
                    try
                    {
                        
                        webView21.Source = new Uri("https://" + textBox1.Text);
                        textBox1.Text = "https://" + textBox1.Text;
                    }
                    catch
                    {

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

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {

                SendAdress();
            }
        }

        private void webView21_ContentLoading(object sender, Microsoft.Web.WebView2.Core.CoreWebView2ContentLoadingEventArgs e)
        {
            pictureBox1.Visible = true;
        }

        private void webView21_NavigationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs e)
        {
            pictureBox1.Visible = false;
        }
    }
}
