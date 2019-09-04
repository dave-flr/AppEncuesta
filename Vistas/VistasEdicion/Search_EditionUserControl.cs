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
<<<<<<< HEAD
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
=======
>>>>>>> 309302b7b1f0b26960966e4b4e467cd133316af3

namespace DXApplication1.Vistas.FormsEdition
{
    public partial class Search_EditionUserControl : DevExpress.XtraEditors.XtraUserControl
    {
        private DB dbConnection = null;
<<<<<<< HEAD
        private int Contador = 0, NumeroDeEncuestas = 10000;
        List<Respuestas> listRespuestas;
=======
>>>>>>> 309302b7b1f0b26960966e4b4e467cd133316af3

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
<<<<<<< HEAD

            fill();
            fillFields(listRespuestas[Contador]);
=======
>>>>>>> 309302b7b1f0b26960966e4b4e467cd133316af3
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
<<<<<<< HEAD
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM respuestas where IV= '" + textBoxSearchCedula.Text + "'", dbConnection.Connection);
=======
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT numero, I, II FROM respuestas where IV= '" + textBoxSearchCedula.Text + "'", dbConnection.Connection);
>>>>>>> 309302b7b1f0b26960966e4b4e467cd133316af3
            DataTable table = new DataTable();
            adapter.Fill(dataSet1);

            table = dataSet1.Tables[0];
<<<<<<< HEAD

            listRespuestas = Convertions.ConvertoToListResp(table);

            table.Columns.Remove("numero");
            table.Columns.Remove("III");
            table.Columns.Remove("V");
            table.Columns.Remove("VI");
            table.Columns.Remove("VII");
            table.Columns.Remove("VIII");
            table.Columns.Remove("IX");
            table.Columns.Remove("X");
            table.Columns.Remove("XI");
            table.Columns.Remove("XII");
            table.Columns.Remove("XIII");
            table.Columns.Remove("XIV");
            table.Columns.Remove("XV");
            table.Columns.Remove("XVI");
            table.Columns.Remove("XVII");

            gridControl1.DataSource = table;
=======
>>>>>>> 309302b7b1f0b26960966e4b4e467cd133316af3

            gridControl1.DataSource = table;
        }


        private void fill() {
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM respuestas", dbConnection.Connection);
            DataTable table = new DataTable();
            adapter.Fill(dataSet1);

            table = dataSet1.Tables[0];

            listRespuestas = Convertions.ConvertoToListResp(table);


        }



        private void GridView1_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show("YES");
        }

        private void GridView1_DoubleClick_1(object sender, EventArgs e)
        {
           
        }

        private void WindowsUIButtonPanel1_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            
        }

        private void WindowsUIButtonPanel1_Click(object sender, EventArgs e)
        {
            
        }

        private void SimpleButton2_Click(object sender, EventArgs e)
        {//Anterior
            if (Contador >= 0)
            {
                fillFields(listRespuestas[Contador--]);
            }
        }

        private void SimpleButton3_Click(object sender, EventArgs e)
        {//Siguiente
            if (Contador >= 0 && Contador < NumeroDeEncuestas)
            {
                fillFields(listRespuestas[Contador++]);
            }
        }

        private void XtraTabControl1_Click(object sender, EventArgs e)
        {
            fillFields(listRespuestas[Contador]);
        }

        private void fillFields(Respuestas result) {
            textBoxNombres.Text = result.I;
            textBoxApellidos.Text = result.Ii;
            radioGroupSexo.SelectedIndex = result.Iii;
            textBoxCedula.Text = result.Iv;

            textBoxDepartamento.Text = returnValue(result.V);

            //textBoxCiudad.Text = result.Vi;

        }

        private string returnValue(int key) {
            string Value = null;
            try
            {
                if (!dbConnection.IsConnect())
                    MessageBox.Show("Hay un error con la base de Datos", "Información");
            }
            catch (Exception erro)
            {
                MessageBox.Show("Error" + erro);
            }
            MySqlConnection temp = dbConnection.Connection;
            temp.Open();
            MySqlCommand cmd = temp.CreateCommand();
            cmd.CommandText = ("SELECT valor From v_departamento INNER JOIN respuestas WHERE clave = '7' GROUP BY valor");
            
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            while (reader.Read())
            {
                Value = reader.ToString();
            }
            temp.Close();
            return Value;
        }
    }
}
