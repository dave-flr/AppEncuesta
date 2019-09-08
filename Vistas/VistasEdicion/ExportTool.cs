using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using DXApplication1.Classes;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DevExpress.XtraGrid.Views.Grid;
using System.Diagnostics;

namespace DXApplication1.Vistas.VistasEdicion
{
    public partial class ExportTool : UserControl
    {
        public ExportTool()
        {
            InitializeComponent();
        }

        private void ExportTool_Load(object sender, EventArgs e)
        {
            var dbConnection = DB.Instance();
            dbConnection.DatabaseName = "respuestas";
            if (!dbConnection.IsConnect())
                MessageBox.Show("Hay un error con la base de Datos", "Información");

            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM respuestas", dbConnection.Connection);
            DataTable table = new DataTable();
            adapter.Fill(dataSet1);

            table = dataSet1.Tables[0];

            gridControl1.DataSource = table;
        }

        private void BarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {//Exportar a Excel
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xlsx)|*.xlsx";
            sfd.FileName = "export.xlsx";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                gridControl1.ExportToXlsx(sfd.FileName);
                Process.Start(sfd.FileName);
            }
        }
    }
}
