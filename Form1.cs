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

        private void AccordionControlElement9_Click(object sender, EventArgs e)
        {
            ChangeView(new question1());
        }

        private void ChangeView(question1 control)
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
    }
}
