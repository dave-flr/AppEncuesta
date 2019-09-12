using System;
using System.Data;
using DXApplication1.Classes;
using System.Windows.Forms;
using System.Diagnostics;
using Npgsql;

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

            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter("SELECT * FROM respuestas", dbConnection.Connection);
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
