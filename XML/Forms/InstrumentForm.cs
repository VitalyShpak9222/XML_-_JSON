﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace XML
{
    public partial class InstrumentForm : Form
    {
        private static InstrumentForm instance = null;
        private static Point pointCursor = new Point();
        private static SoundPlayer Player = null;

        private InstrumentForm()
        {
            InitializeComponent();
        }

        public static InstrumentForm GetInstrument() 
        {
            if (instance == null) 
            {
                instance = new InstrumentForm();
            }
            return instance;
        }

        public void SetInfoForm(string type, string name, string date, string price, string fnm, string link) 
        {
            labelTypeValue.Text = type;
            labelNamementValue.Text = name;
            labelDataBirthValue.Text = date;
            labelPriceValue.Text = price;
            labelMasterValue.Text = fnm;
            Player = new SoundPlayer(link);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            Player.Play();
        }

        private void labelExit_Click(object sender, EventArgs e)
        {
            Player.Stop(); 
            this.Hide();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            Player.Stop();
        }

        private void labelNameForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - pointCursor.X;
                this.Top += e.Y - pointCursor.Y;
            }
        }

        private void labelNameForm_MouseDown(object sender, MouseEventArgs e)
        {
            pointCursor = new Point(e.X, e.Y);
        }
    }
}
