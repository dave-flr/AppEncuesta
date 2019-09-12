using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Npgsql;
using DXApplication1.Classes;
using DXApplication1.Classes.Charts;

namespace DXApplication1.Vistas
{
    public partial class question3 : UserControl
    {
        public question3()
        {
            InitializeComponent();
        }

        private void Question3_Load(object sender, EventArgs e)
        {
            var dbConnection = DB.Instance();
            dbConnection.DatabaseName = "respuestas";
            if (!dbConnection.IsConnect())
                MessageBox.Show("Hay un error con la base de Datos", "Información");

            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter("SELECT iii_sexo.valor, COUNT( * ) as cantidad FROM respuestas INNER JOIN iii_sexo ON respuestas.III = iii_sexo.clave GROUP BY III", dbConnection.Connection);
            DataTable table = new DataTable();
            adapter.Fill(dataSet1);

            table = dataSet1.Tables[0];

            List<Questions> list = Convertions.ConvertoToList(table);
            
            chartControl1.Series[0].DataSource = list;
            chartControl1.Series[0].ArgumentDataMember = "valor";
            chartControl1.Series[0].ValueDataMembers.AddRange(new string[] { "cantidad" });

            chartControl1.Series[0].Label.TextPattern = "{V} ({VP:p0})";
            chartControl1.Series[0].LegendTextPattern = "{A}";
        }
    }
}
