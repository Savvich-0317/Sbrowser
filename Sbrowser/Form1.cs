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
using Sbrowser.Properties;



namespace Sbrowser
{
    


    public partial class Form1 : Form
    {
        string CheckSource = Settings.Default.homepage;
        string PrevSource = "";
        public Form1()
        {
            Timer timer;
            timer = new Timer();
            timer.Interval = 1;
            timer.Tick += CheckerCycle;
            timer.Start();
            InitializeComponent();
            SendAdress(Settings.Default.homepage);
            

        }

        private void CheckerCycle(object sender, EventArgs e)
        {
            if (Settings.Default.theme == false)
            {
                this.BackColor = Color.Gray;
                webView21.BackColor = Color.Gray;
                textBox1.BackColor = Color.Gray;
                
            }
            else
            {
                this.BackColor = Color.AntiqueWhite;
                webView21.BackColor = Color.AntiqueWhite;
                textBox1.BackColor = Color.AntiqueWhite;
                
            }




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

            
            SendAdress(textBox1.Text);
        }

        
        private void webView21_SourceChanged(object sender, Microsoft.Web.WebView2.Core.CoreWebView2SourceChangedEventArgs e)
        {
            textBox1.Text = webView21.Source.ToString();

            if (CheckSource != webView21.Source.ToString())
            {
                PrevSource = CheckSource;
                CheckSource = webView21.Source.ToString();
                
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {

                SendAdress(textBox1.Text);
            }
        }

       
        private void button2_Click(object sender, EventArgs e)
        {
            if (PrevSource != "")
            {
                webView21.Source = new Uri(PrevSource);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            webView21.Reload();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SendAdress(Settings.Default.homepage);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 settings = new Form2();
            settings.ShowDialog();
        }

        private void SendAdress(string uris)
        {

            try
            {

                webView21.Source = new Uri(uris);
            }
            catch
            {
                if (uris.Contains("https://"))
                {
                    uris = "Adress not responding, or not valid";
                }
                else
                {
                    try
                    {

                        webView21.Source = new Uri("https://" + uris);
                        uris = "https://" + uris;
                    }
                    catch
                    {

                        uris = "Adress not responding, or not valid";

                    }
                }

            }
        }

        private void webView21_ContentLoading_1(object sender, Microsoft.Web.WebView2.Core.CoreWebView2ContentLoadingEventArgs e)
        {
            label1.Text = "loading...";
            label1.BackColor = Color.Yellow;
        }

        private void webView21_NavigationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs e)
        {
            label1.Text = "loaded!";
            label1.BackColor = Color.Green;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form3 about = new Form3();
            about.ShowDialog();
        }
        bool pinned = false;
        private void button7_Click(object sender, EventArgs e)
        {
            if (!pinned) {
                pinned = true;
                this.TopMost = true;
                button7.Text = "📎";
            }
            else
            {
                pinned = false;
                this.TopMost = false;
                button7.Text = "🧷";
            }
            
        }

    }
}
