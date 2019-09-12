using System;
using System.Data;
using System.Windows.Forms;
using DXApplication1.Classes;
using Npgsql;
namespace DXApplication1.Vistas
{
    public partial class question2 : UserControl
    {
        public question2()
        {
            InitializeComponent();
        }

        private void Question2_Load(object sender, EventArgs e)
        {
            var dbConnection = DB.Instance();
            dbConnection.DatabaseName = "respuestas";
            if (!dbConnection.IsConnect())
                MessageBox.Show("Hay un error con la base de Datos", "Información");

            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter("SELECT II FROM respuestas", dbConnection.Connection);
            DataTable table = new DataTable();
            adapter.Fill(dataSet1);

            table = dataSet1.Tables[0];

            gridControl1.DataSource = table;
        }
    }
}
