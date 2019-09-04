using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace DXApplication1.Vistas.FormsEdition
{
    public partial class Search_EditionUserControl : DevExpress.XtraEditors.XtraUserControl
    {
        public Search_EditionUserControl()
        {

            InitializeComponent();
        }

        private void XtraTabPage1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void EditQuizForm_Load(object sender, EventArgs e)
        {

        }

        private void FlowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Panel1_Resize(object sender, EventArgs e)
        {
        }

        private void XtraTabPage3_Resize(object sender, EventArgs e)
        {
        
            //fijate aqui
            
            // Donde? en Form1.cs ahi te comenté algo 
            //flowLayoutPanel1.Width = this.Width;
        }

        private void FlowLayoutPanel1_Resize(object sender, EventArgs e)
        {
            //MessageBox.Show("" + this.Width);
            //panelControl1.Width = this.Width;
            //panelControl2.Width = this.Width;
        }

        private void PanelControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
