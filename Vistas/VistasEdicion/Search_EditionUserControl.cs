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
using DXApplication1.Classes;
using MySql.Data.MySqlClient;

namespace DXApplication1.Vistas.FormsEdition
{
    public partial class Search_EditionUserControl : DevExpress.XtraEditors.XtraUserControl
    {
        private DB dbConnection = null;

        public Search_EditionUserControl()
        {

            InitializeComponent();
        }

        private void XtraTabPage1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Search_EditionUserControl_Load(object sender, EventArgs e)
        {
            dbConnection = DB.Instance();
            dbConnection.DatabaseName = "respuestas";
            if (!dbConnection.IsConnect())
                MessageBox.Show("Hay un error con la base de Datos", "Información");
        }

        private void FlowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Panel1_Resize(object sender, EventArgs e)
        {
        }

        private void XtraTabPage3_Resize(object sender, EventArgs e)
        {
        }

        private void FlowLayoutPanel1_Resize(object sender, EventArgs e)
        {
        }

        private void PanelControl2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void TextBox8_KeyUp(object sender, KeyEventArgs e)
        {
        }

        private void SimpleButton1_Click(object sender, EventArgs e)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT numero, I, II FROM respuestas where IV= '" + textBoxSearchCedula.Text + "'", dbConnection.Connection);
            DataTable table = new DataTable();
            adapter.Fill(dataSet1);

            table = dataSet1.Tables[0];

            gridControl1.DataSource = table;
        }
    }
}
