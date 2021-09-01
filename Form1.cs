using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using CefSharp.Internals;
using System.Diagnostics;

namespace Notchmodsbrowser2._1
{
    public partial class Form1 : Form
    {   
        public ChromiumWebBrowser browser;
        public Form1()
        {
            InitializeComponent();
            CefSettings settings = new CefSettings();
            Cef.Initialize(settings);
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 0;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;
            button7.FlatAppearance.BorderSize = 0;
            button7.FlatStyle = FlatStyle.Flat;
            button8.FlatAppearance.BorderSize = 0;
            button8.FlatStyle = FlatStyle.Flat;
            textBox1.BorderStyle = BorderStyle.None;
            KeyPreview = true;
            TabPage tabpages = new TabPage();
            tabControl1.Controls.Add(tabpages);
            tabControl1.SelectTab(tabControl1.TabCount - 1);
            browser = new CefSharp.WinForms.ChromiumWebBrowser("https://google.com");
            browser.Dock = DockStyle.Fill;
            browser.Parent = tabpages;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cef.Shutdown();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            browser.Load(textBox1.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (browser.CanGoForward)
                browser.Forward();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            browser.Reload();   
            textBox1.Text = browser.Address;
            tabControl1.SelectedTab.Name = browser.Address; 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (browser.CanGoBack)
                browser.Back();
        }   

        private void button5_Click(object sender, EventArgs e)
        {
            browser.Load("https://google.com");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            TabPage tabpages = new TabPage();
            tabControl1.Controls.Add(tabpages);
            tabControl1.SelectTab(tabControl1.TabCount - 1);
            browser = new CefSharp.WinForms.ChromiumWebBrowser("https://google.com");
            browser.Dock = DockStyle.Fill;
            browser.Parent = tabpages;
            browser.TitleChanged += browsertitle_changed;
        }

        private void browsertitle_changed(object sender, TitleChangedEventArgs e)
        {
            this.Invoke(new MethodInvoker(()=>{
                tabControl1.SelectedTab.Text = e.Title;
            }));
        }

        private void button7_Click(object sender, EventArgs e)
        {
            TabPage tabpages = new TabPage();
            tabControl1.Controls.Remove(tabControl1.SelectedTab);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            browser.GetCookieManager().DeleteCookies("", "");
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.SelectAll();
            textBox1.BorderStyle = BorderStyle.None;
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            button3.BackColor = Color.Lime;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.Transparent;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (textBox1.Text.Contains("https://") == false)
                {
                    browser.Load("https://www.google.com/search?q=" + textBox1.Text );
                    textBox1.Text = "";
                }
                else
                {
                    browser.Load(textBox1.Text);
                    textBox1.Text = "";
                }
            }
            if(e.Alt && e.KeyCode == Keys.Right)
            {
                if (browser.CanGoForward)
                    browser.Forward();
            }

            if (e.Alt && e.KeyCode == Keys.Left)
            {
                if (browser.CanGoBack)
                    browser.Back();
            }
        }

        private void button7_MouseHover(object sender, EventArgs e)
        {
            button7.BackColor = Color.Red;
        }

        private void button7_MouseLeave(object sender, EventArgs e)
        {
            button7.BackColor = Color.Transparent;
        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            textBox1.BorderStyle = BorderStyle.None;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F11)
            {
                tabControl1.Location = new Point(1, 2);
                tabControl1.Size = new Size(1300, 700);
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
                button6.Visible = false;
                button7.Visible = false;
                textBox1.Enabled = false;
            }
            if (e.KeyCode == Keys.Escape)
            {
                tabControl1.Location = new Point(1,65);
                tabControl1.Size = new Size(1300,635);
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                button7.Enabled = true;
                button6.Visible = true;
                button7.Visible = true;
                textBox1.Enabled = true;
            }

            if (e.Control&&e.KeyCode == Keys.T)
            {
                    TabPage tabpages = new TabPage();
                  tabControl1.Controls.Add(tabpages);
                    tabControl1.SelectTab(tabControl1.TabCount - 1);
                    browser = new CefSharp.WinForms.ChromiumWebBrowser("https://google.com");
                    browser.Dock = DockStyle.Fill;
                browser.Parent = tabpages;
            }

            if(e.Control&&e.KeyCode == Keys.W) 
            {
                TabPage tabpages = new TabPage();
                tabControl1.Controls.Remove(tabControl1.SelectedTab);
            }

            if(e.Alt&&e.KeyCode == Keys.Left)
            {
                if (browser.CanGoBack)
                    browser.Back();
            }

            if (e.Alt && e.KeyCode == Keys.Right)
            {
                if (browser.CanGoForward)
                    browser.Forward();
            }

            if(e.KeyCode == Keys.F12)
            {
                browser.ShowDevTools();
            }
            if (e.KeyCode == Keys.U&&e.Control)
            {
                browser.ViewSource();
            }
        }

        private void tabControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                browser.Load(textBox1.Text);
            }

        }
        private void button8_Click_1(object sender, EventArgs e)
        {
            try
            {
                Process processor = Process.GetCurrentProcess();
                processor.Kill();
            }
            catch
            {

            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int zoomlevel = 0;
            zoomlevel++;
            browser.SetZoomLevel(zoomlevel++);
        }

        private void button8_Click_2(object sender, EventArgs e)
        {
            int zoomlevel = 0;
            zoomlevel--;
            browser.SetZoomLevel(zoomlevel);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_MouseHover(object sender, EventArgs e)
        {
            textBox1.BorderStyle = BorderStyle.Fixed3D;
        }
