using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DXApplication1.Vistas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DXApplication1
{
    public partial class Form1 : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ChangeView(UserControl control)
        {
            if (this.panelControl1.Controls.Count > 0)
            {
                this.panelControl1.Controls.RemoveAt(0);
            }

            control.Dock = DockStyle.Fill;
            this.panelControl1.Controls.Add(control);
            this.panelControl1.Tag = control;
            control.Show();
        }

        private void AccordionControlElement9_Click(object sender, EventArgs e)
        {
            ChangeView(new question1());
        }

        private void AccordionControlElement18_Click(object sender, EventArgs e)
        {
            ChangeView(new question2());
        }

        private void AccordionControlElement19_Click(object sender, EventArgs e)
        {
            ChangeView(new question3());
        }

        private void AccordionControlElement20_Click(object sender, EventArgs e)
        {
            ChangeView(new question4());
        }

        private void AccordionControlElement21_Click(object sender, EventArgs e)
        {
            ChangeView(new question5());
        }

        private void AccordionControlElement22_Click(object sender, EventArgs e)
        {
            ChangeView(new question6());
        }
        private void AccordionControlElement23_Click(object sender, EventArgs e)
        {
            ChangeView(new question7());
        }
        private void AccordionControlElement24_Click(object sender, EventArgs e)
        {
            ChangeView(new question8());
        }
        private void AccordionControlElement25_Click(object sender, EventArgs e)
        {
            ChangeView(new question9());
        }
        private void AccordionControlElement26_Click(object sender, EventArgs e)
        {
            ChangeView(new question_10());
        }

        private void AccordionControlElement27_Click(object sender, EventArgs e)
        {
            ChangeView(new question_11());
        }

        private void AccordionControlElement28_Click(object sender, EventArgs e)
        {
            ChangeView(new question_12());
        }

        private void AccordionControlElement29_Click(object sender, EventArgs e)
        {
            ChangeView(new question_13());
        }
        // fijate ahora carnal
        private void AccordionControlElement30_Click(object sender, EventArgs e)
        {
            ChangeView(new question_14());
        }

        private void AccordionControlElement31_Click(object sender, EventArgs e)
        {
            ChangeView(new question_15());
        }

        private void AccordionControlElement32_Click(object sender, EventArgs e)
        {
            ChangeView(new question_16());
        }

        private void AccordionControlElement33_Click(object sender, EventArgs e)
        {
            ChangeView(new question_17());
        }
    }
}
