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
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;

namespace DXApplication1.Vistas.FormsEdition
{
    public partial class Search_EditionUserControl : DevExpress.XtraEditors.XtraUserControl
    {
        private DB dbConnection = null;
        private int Contador = 0, NumeroDeEncuestas = 10000;
        List<Respuestas> listRespuestas;

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

            fill();
            fillFields(listRespuestas[Contador]);
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
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM respuestas where IV= '" + textBoxSearchCedula.Text + "'", dbConnection.Connection);
            DataTable table = new DataTable();
            adapter.Fill(dataSet1);

            table = dataSet1.Tables[0];

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
            if (Contador > 0)
            {
                Contador--;
                fillFields(listRespuestas[Contador]);
            }
        }

        private void SimpleButton3_Click(object sender, EventArgs e)
        {//Siguiente
            if (Contador >= 0 && Contador < listRespuestas.Count-1)
            {
                Contador++;
                fillFields(listRespuestas[Contador]);
            }
        }

        private void XtraTabControl1_Click(object sender, EventArgs e)
        {
            //fillFields(listRespuestas[Contador]);
        }

        private void fillFields(Respuestas result) {
            textEditSearch.Text = (Contador+1).ToString();
            textEditFinal.Text = listRespuestas.Count.ToString();

            textBoxNombres.Text = result.I;
            textBoxApellidos.Text = result.Ii;
            radioGroupSexo.SelectedIndex = result.Iii;
            textBoxCedula.Text = result.Iv;

            textBoxDepartamento.Text = returnValue(result.V, TableNames.returnTableName(5));
            textBoxCiudad.Text = returnValue(result.Vi, TableNames.returnTableName(6));
            textBoxFacultad.Text = returnValue(result.Vii, TableNames.returnTableName(7));
            textBoxCarrera.Text = returnValue(result.Viii, TableNames.returnTableName(8));

            textBoxAnioEstudio.Text = result.Ix.ToString();
            radioGroupTipoMatricula.SelectedIndex = result.X;
            radioGroupBecado.SelectedIndex = result.Xi;
            radioGroup1.SelectedIndex = result.Xii;
            radioGroup2.SelectedIndex = result.Xiii;
            radioGroup3.SelectedIndex = result.Xiv;
            radioGroup4.SelectedIndex = result.Xv;

            textBox1.Text = result.Xvi.ToString();

            radioGroup5.SelectedIndex = result.Xvii;

        }

        private string returnValue(int key, string tableName) { //Un solo metodo para todas las consultas
            string Value = null;
            try{
                if (!dbConnection.IsConnect())
                    MessageBox.Show("Hay un error con la base de Datos", "Información");
            }
            catch (Exception erro){
                MessageBox.Show("Error" + erro);
            }

            MySqlConnection temp = dbConnection.Connection;
            temp.Open();
            MySqlCommand cmd = temp.CreateCommand();
            cmd.CommandText = ("SELECT valor From " + tableName + " INNER JOIN respuestas WHERE clave = " + key + " GROUP BY valor");
            
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Value = reader.GetString(0);
            }

            temp.Close();
            return Value;
        }
    }
}
