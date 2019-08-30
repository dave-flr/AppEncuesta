using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using DXApplication1.Classes;

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

            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT iii_sexo.valor, COUNT( * ) as cantidad FROM respuestas INNER JOIN iii_sexo ON respuestas.III = iii_sexo.clave GROUP BY III", dbConnection.Connection);
            DataTable table = new DataTable();
            adapter.Fill(dataSet1);

            table = dataSet1.Tables[0];

            List<Iii> list = new List<Iii>();
        }
    }
}
