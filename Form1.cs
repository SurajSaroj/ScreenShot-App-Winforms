﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace ScreenCaptureDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonCapture_Click(object sender, EventArgs e)
        {
           this.Hide();
           CaptureMyScreen();
           this.Show();
        }

        private void CaptureMyScreen()
        {   
            try
            {
                System.Threading.Thread.Sleep(500);
                Bitmap captureBitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb);
				Rectangle captureRectangle = Screen.AllScreens[0].Bounds;
				Graphics captureGraphics = Graphics.FromImage(captureBitmap);
				captureGraphics.CopyFromScreen(captureRectangle.Left,captureRectangle.Top,0,0,captureRectangle.Size);
				string path = textBox1.Text;
                string filename=null;
				if (path.Last().ToString() != @"\")
                {
                path = path + @"\";
				}
                if (!(textBox2.Text == ""))
                {
                    filename = textBox2.Text + ".jpg";
                }
                else { filename =  System.Guid.NewGuid().ToString()+".jpg"; }
                captureBitmap.Save(path+filename,ImageFormat.Jpeg);
			}

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message+"\n Run as Admin");
            }
           
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if(!checkBox1.Checked)
            textBox2.Text = "";
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
			Application.Exit();
        }

        private void Form1_MinimumSizeChanged(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
            }
        }

        private void Capture_MouseClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
        }
    }
}
