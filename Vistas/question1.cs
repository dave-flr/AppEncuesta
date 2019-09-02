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
using MySql.Data;
using MySql.Data.MySqlClient;
using DXApplication1.Classes;

namespace DXApplication1.Vistas
{
    public partial class question1 : DevExpress.XtraEditors.XtraUserControl
    {
        public question1()
        {
            InitializeComponent();
        }

        private void Question1_Load(object sender, EventArgs e)
        {
            var dbConnection = DB.Instance();
            dbConnection.DatabaseName = "respuestas";
            if (!dbConnection.IsConnect()) 
                MessageBox.Show("Hay un error con la base de Datos","Información");

            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT I FROM respuestas",dbConnection.Connection);
            DataTable table = new DataTable();
            adapter.Fill(dataSet1);

            table = dataSet1.Tables[0];

            gridControl1.DataSource = table;
        }

        private void GridView1_ColumnWidthChanged(object sender, DevExpress.XtraGrid.Views.Base.ColumnEventArgs e)
        {

        }
    }
}
