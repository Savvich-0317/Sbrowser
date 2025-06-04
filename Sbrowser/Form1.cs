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
        string CheckSource = "https://google.com";
        string PrevSource = "";
        public Form1()
        {
            Timer timer;
            timer = new Timer();
            timer.Interval = 1;
            timer.Tick += CheckerCycle;
            timer.Start();
            InitializeComponent();
            
        }

        private void CheckerCycle(object sender, EventArgs e)
        {
            
            
            
            

            if (PrevSource == "" || PrevSource == webView21.Source.ToString())
            {
                button2.Enabled = false;
            }
            else {
                button2.Enabled = true;
            }
        }

        private void WebView21_ContentLoading(object sender, Microsoft.Web.WebView2.Core.CoreWebView2ContentLoadingEventArgs e)
        {
            throw new NotImplementedException();
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
            if (CheckSource != webView21.Source.ToString())
            {
                PrevSource = CheckSource;
                CheckSource = webView21.Source.ToString();
                button2.Text = PrevSource;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {

                SendAdress();
            }
        }

       
        private void button2_Click(object sender, EventArgs e)
        {
            if (PrevSource != "")
            {
                textBox1.Text = PrevSource;
                webView21.Source = new Uri(PrevSource);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            webView21.Reload();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            webView21.Source = new Uri("https://google.com");
        }
    }
}
