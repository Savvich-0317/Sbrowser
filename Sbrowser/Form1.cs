using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;
using Sbrowser.Properties;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;



namespace Sbrowser
{
    


    public partial class Form1 : Form
    {

        string CheckSource = Settings.Default.homepage;
        string PrevSource = "";
        bool ForCheckerHistory = true;
        public Form1()
        {
            
            System.Windows.Forms.Timer timer;
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1;
            timer.Tick += CheckerCycle;
            timer.Start();
            InitializeComponent();
            Settings.Default.Focused = false;
            Settings.Default.Save();
            SendAdress(Settings.Default.homepage);

            UpdateList2();

        }
        Form4 Pomodoro = new Form4();


        private void CheckerCycle(object sender, EventArgs e)
        {
            button9.Text = Settings.Default.Pomodoro;
            this.Opacity = Convert.ToDouble( Settings.Default.Opacity / 100.0);


            if (textBox1.Text.Contains("https://"))
            {
                label3.Visible = true;
            }
            else
            {
                label3.Visible = false;
            }

            if (Settings.Default.theme == "gray")
            {
                label3.ForeColor = Color.Black;
                label2.ForeColor = Color.Black;
                checkBox1.ForeColor = Color.Black;
                this.BackColor = Color.Gray;
                listBox1.BackColor = Color.White;
                webView21.BackColor = Color.Gray;
                textBox1.BackColor = Color.Gray;
                
            }
            else if (Settings.Default.theme == "white")
            {
                label3.ForeColor = Color.Black;
                label2.ForeColor = Color.Black;
                checkBox1.ForeColor = Color.Black;
                this.BackColor = Color.AntiqueWhite;
                listBox1.BackColor = Color.White;
                webView21.BackColor = Color.AntiqueWhite;
                textBox1.BackColor = Color.AntiqueWhite;
                
            }
            else if (Settings.Default.theme == "neon dark")
            {
                label3.ForeColor = Color.White;
                label2.ForeColor = Color.White;
                checkBox1.ForeColor = Color.White;
                this.BackColor = Color.FromArgb(23, 26, 33);
                listBox1.BackColor = Color.FromArgb(128, 172, 170);
                textBox1.BackColor = Color.FromArgb(102, 192, 244);
            }

            else if (Settings.Default.theme == "custom theme")
            {
                if (Settings.Default.UseWhiteText)
                {
                    checkBox1.ForeColor = Color.White;
                    label3.ForeColor = Color.White;
                    label2.ForeColor = Color.White;
                }
                else
                {
                    checkBox1.ForeColor = Color.Black;
                    label3.ForeColor = Color.Black;
                    label2.ForeColor = Color.Black;
                }

                listBox1.BackColor = Settings.Default.SecondColor;
                textBox1.BackColor = Settings.Default.SecondColor;
                this.BackColor = Settings.Default.MainColor;
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

        int HistoryCursorShift = 0;
        bool IsItBackChange = false;
        private void webView21_SourceChanged(object sender, Microsoft.Web.WebView2.Core.CoreWebView2SourceChangedEventArgs e)
        {
            if (IsItBackChange)
            {
                
                listBox3.SelectedIndex = (listBox3.Items.Count - HistoryCursorShift - 1);
                IsItBackChange = false;
            }
            else
            {
                listBox3.Items.Insert(listBox3.Items.Count - HistoryCursorShift, webView21.Source.ToString());
                listBox3.SelectedIndex = (listBox3.Items.Count - HistoryCursorShift - 1);

            }

            



            for (int i = 0; i < Settings.Default.Blacklist.Count; i++) {
                if (Settings.Default.Focused && webView21.Source.ToString().Contains(Settings.Default.Blacklist[i].ToString().ToLower()))
                {
                    SendAdress("https://savvich.ru/discord");
                    break;
                }
            
            }

            textBox1.Text = webView21.Source.ToString();

            if (CheckSource != webView21.Source.ToString())
            {
                PrevSource = CheckSource;
                CheckSource = webView21.Source.ToString();
                if (!listBox1.Items.Contains(webView21.Source.ToString())){
                    listBox1.Items.Add(webView21.Source.ToString());
                    listBox1.SelectedIndex = listBox1.Items.Count - 1;
                }
                
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
            if (listBox3.Items.Count - HistoryCursorShift - 2 >= 0)
            {
                HistoryCursorShift += 1;
                listBox3.SelectedIndex = (listBox3.Items.Count - HistoryCursorShift - 1);
                IsItBackChange = true;
                SendAdress(listBox3.SelectedItem.ToString());
                listBox1.SelectedItem = listBox3.SelectedItem;
                
            }

        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (listBox3.SelectedIndex + 2 <= listBox3.Items.Count)
            {
                HistoryCursorShift -= 1;
                listBox3.SelectedIndex = (listBox3.Items.Count - HistoryCursorShift - 1);
                IsItBackChange = true;
                SendAdress(listBox3.SelectedItem.ToString());
                listBox1.SelectedItem = listBox3.SelectedItem;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            stopwatch.Reset();
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


        public void DeleteHistory() {
            webView21.CoreWebView2.Profile.ClearBrowsingDataAsync();
        }
        public void SendAdress(string uris)
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
        Stopwatch stopwatch = new Stopwatch();
        public void webView21_ContentLoading_1(object sender, Microsoft.Web.WebView2.Core.CoreWebView2ContentLoadingEventArgs e)
        {
            if (ForCheckerHistory && Settings.Default.ClearHistory) {
                DeleteHistory();
                ForCheckerHistory = false;
                webView21.Reload();
            }
            
            stopwatch.Reset();
            stopwatch.Start();
            label1.Text = "loading...";
            label1.BackColor = Color.Yellow;
        }

        private void webView21_NavigationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs e)
        {
            if (stopwatch.Elapsed.Minutes == 0)
            {
                label1.Text = "loaded! " + stopwatch.Elapsed.Seconds + "." + stopwatch.Elapsed.Milliseconds + "s";
            }
            else
            {
                label1.Text = "loaded! Big";
            }
            
            label1.BackColor = Color.Green;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form3 about = new Form3(this /*Очень важная штука*/);
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

        private void button8_Click(object sender, EventArgs e)
        {
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            
        }

        private void listBox1_MouseLeave(object sender, EventArgs e)
        {
            listBox1.Width = 130;
            this.ActiveControl = null;
        }

        private void listBox1_MouseEnter(object sender, EventArgs e)
        {
            listBox1.Focus();
            listBox1.Width = 260;
            
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D)
            {
                listBox1.Items.Remove(listBox1.SelectedItem);
            }

            if (e.KeyCode == Keys.E && listBox1.SelectedItem != null && !Settings.Default.Best.Contains(listBox1.SelectedItem.ToString()))
            {
                Settings.Default.Best.Add(listBox1.SelectedItem.ToString());
                Settings.Default.Save();
                UpdateList2();
            }

            if (e.KeyCode == Keys.Q)
            {
                if (!listBox2.Visible)
                {
                    listBox2.Visible = true;
                    listBox1.Visible = false;
                }

            }
            
        }

        private void webView21_Layout(object sender, LayoutEventArgs e)
        {
            if (Settings.Default.ClearHistory)
            {
                DeleteHistory();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Height = Convert.ToInt32(Settings.Default.StartScreenSize[0]);
            this.Width = Convert.ToInt32(Settings.Default.StartScreenSize[1]);
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                SendAdress(listBox1.SelectedItem.ToString());
            }
        }
        private System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            var buttonsWithTooltips = new[]
            {
                (button: button2, tip: "Previous page."),
                (button: button3, tip: "Reload page."),
                (button: button4, tip: "Home page."),
                (button: button5, tip: "Settings."),
                (button: button6, tip: "About."),
                (button: button1, tip: "Go to adress."),
                (button: button7, tip: "Clip/unclip window."),
                (button: button8, tip: "Clear all history of pages."),

            };

            if (checkBox1.Checked)
            {
                foreach (var btn in buttonsWithTooltips)
                {
                    ToolTip1.SetToolTip(btn.button, btn.tip);
                    ToolTip1.SetToolTip(listBox1, "Pages history.");
                    ToolTip1.SetToolTip(label1, "Page status.");
                    ToolTip1.SetToolTip(label3, "This page is secured.");
                }
            }
            else
            {
                foreach (var btn in buttonsWithTooltips)
                {
                    ToolTip1.SetToolTip(btn.button, "");
                    ToolTip1.SetToolTip(listBox1, "");
                    ToolTip1.SetToolTip(label1, "");
                    ToolTip1.SetToolTip(label3, "");
                }
            }
        }

        private void webView21_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void listBox2_DoubleClick(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem != null)
            {
                SendAdress(listBox2.SelectedItem.ToString());
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void listBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Q)
            {
                
               
                listBox2.Visible = false;
                listBox1.Visible = true;
                
            }

            if (e.KeyCode == Keys.D && listBox2.SelectedItem != null)
            {
                Settings.Default.Best.RemoveAt(listBox2.SelectedIndex);
                Settings.Default.Save();
                UpdateList2();
            }
        }

        private void listBox2_MouseEnter(object sender, EventArgs e)
        {
            listBox2.Focus();
            listBox2.Width = 260;
        }

        private void listBox2_MouseLeave(object sender, EventArgs e)
        {
            listBox2.Width = 130;
            this.ActiveControl = null;
        }

        public void UpdateList2()
        {
            listBox2.Items.Clear();

            for (int i = 0; i < Settings.Default.Best.Count; i++)
            {
                listBox2.Items.Add(Settings.Default.Best[i]);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Pomodoro.Show();

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.Pomodoro = "🍅";
            Settings.Default.Save();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Settings.Default.UseStartScreenSize)
            {
                Settings.Default.StartScreenSize[0] = this.Height.ToString();
                Settings.Default.StartScreenSize[1] = this.Width.ToString();
                Settings.Default.Save();
            }
        }


    }
}
    