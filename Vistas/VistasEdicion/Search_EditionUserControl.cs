using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using DXApplication1.Classes;
using Npgsql;
using DevExpress.XtraGrid.Views.Grid;

namespace DXApplication1.Vistas.FormsEdition
{
    public partial class Search_EditionUserControl : DevExpress.XtraEditors.XtraUserControl
    {
        private DB dbConnection = null;
        private int Contador = 0;
        private int indicatorRowIndex = 0;
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
            LoadCombo();
            fillFields(listRespuestas[Contador]);
            simpleButton4.Enabled = false;
        }

        private void LoadCombo()
        {
            try
            {
                dbConnection.IsConnect();
                NpgsqlConnection temp = dbConnection.Connection;
                temp.Open();
                NpgsqlCommand cmd = temp.CreateCommand();
                cmd.CommandText = ("SELECT valor From viii_carrera");

                NpgsqlDataReader reader = cmd.ExecuteReader();
                int i = 0;
                while (reader.Read())
                {
                    comboBoxCarrera.Properties.Items.Add(reader.GetString(0)); i++;
                }

                temp.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Error" + erro, "Hay un error con la base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            dataSet2.Reset();
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter("SELECT * FROM respuestas WHERE IV = '" + textBoxSearchCedula.Text + "'", dbConnection.Connection);
            DataTable table = new DataTable();
            adapter.Fill(dataSet2);

            table = dataSet2.Tables[0];

            if (table.Rows.Count == 0) return;
            

            List<Respuestas> listRespuestas2 = Convertions.ConvertoToListResp(table);

            //table.Columns.Remove("numero");
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
        }


        private void fill() {
            dataSet1.Reset();
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter("SELECT * FROM respuestas", dbConnection.Connection);
            DataTable table = new DataTable();
            adapter.Fill(dataSet1);

            table = dataSet1.Tables[0];

            listRespuestas = Convertions.ConvertoToListResp(table);
        }



        private void GridView1_DoubleClick(object sender, EventArgs e)
        {
            //MessageBox.Show("YES");
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
            if (listRespuestas.Count > 0 && Contador > 0)
            {
                Contador--;
                fillFields(listRespuestas[Contador]);
                simpleButton4.Enabled = false;
            }
        }

        private void SimpleButton3_Click(object sender, EventArgs e)
        {//Siguiente
            if (Contador >= 0 && Contador < listRespuestas.Count-1)
            {
                Contador++;
                fillFields(listRespuestas[Contador]);
                simpleButton4.Enabled = false;
            }
        }

        private void XtraTabControl1_Click(object sender, EventArgs e)
        {
            //fillFields(listRespuestas[Contador]);
        }

        private void fillFields(Respuestas result) {
            if (result == null) return;
            textEditSearch.Text = (Contador+1).ToString();
            textEditFinal.Text = listRespuestas.Count.ToString();

            textBoxNombres.Text = result.I;
            textBoxApellidos.Text = result.Ii;
            radioGroupSexo.SelectedIndex = result.Iii;
            textBoxCedula.Text = result.Iv;

            /*comboBoxDepartamento.SelectedIndex = returnValue(result.V, TableNames.returnTableName(5));
            textBoxCiudad.Text = returnValue(result.Vi, TableNames.returnTableName(6));
            textBoxFacultad.Text = returnValue(result.Vii, TableNames.returnTableName(7));
            textBoxCarrera.Text = returnValue(result.Viii, TableNames.returnTableName(8));*/

            comboBoxDepartamento.SelectedIndex = result.V;
            comboBoxCiudad.SelectedIndex = result.Vi;
            comboBoxFacultad.SelectedIndex = result.Vii;
            comboBoxCarrera.SelectedIndex = result.Viii;

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

        private int returnValue(int key, string tableName) { //Un solo metodo para todas las consultas
            int Value = -1;
            try{
                dbConnection.IsConnect();
                NpgsqlConnection temp = dbConnection.Connection;
                temp.Open();
                NpgsqlCommand cmd = temp.CreateCommand();
                cmd.CommandText = ("SELECT clave From " + tableName + " INNER JOIN respuestas WHERE clave = " + key + " GROUP BY valor");

                NpgsqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Value = reader.GetInt32(0);
                }

                temp.Close();
                return Value;
            }
            catch (Exception erro){
                MessageBox.Show("Error" + erro, "Hay un error con la base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        private void enableSaveButton()
        {
            simpleButton4.Enabled = true;
        }

        private void TextBoxNombres_TextChanged(object sender, EventArgs e)
        {
            enableSaveButton();
        }

        private void RadioGroupSexo_Click(object sender, EventArgs e)
        {
            enableSaveButton();
        }

        private void SimpleButton4_Click(object sender, EventArgs e)
        {//Boton guardar cambios
            if (listRespuestas.Count == 0) return;

            int succes = -1;
            try
            {
                dbConnection.IsConnect();
                NpgsqlConnection temp = dbConnection.Connection;
                temp.Open();


                NpgsqlCommand cmd = temp.CreateCommand();
                cmd.CommandText = ("UPDATE `encuesta`.`respuestas` SET `I` = @I, `II` = @II, `III` = @III, `IV` = @IV, `V` = @V, `VI` = @VI, `VII` = @VII, `VIII` = @VIII, `IX` = @IX, `X` = @X, `XI` = @XI, `XII` = @XII, `XIII` = @XIII, `XIV` = @XIV, `XV` = @XV, `XVI` = @XVI, `XVII` = @XVII WHERE `numero` = @save");

                cmd.Parameters.AddWithValue("I", textBoxNombres.Text);
                cmd.Parameters.AddWithValue("II", textBoxApellidos.Text);
                cmd.Parameters.AddWithValue("III", Convert.ToInt32(radioGroupSexo.SelectedIndex));//
                cmd.Parameters.AddWithValue("IV", textBoxCedula.Text);
                cmd.Parameters.AddWithValue("V", comboBoxDepartamento.SelectedIndex);
                cmd.Parameters.AddWithValue("VI", comboBoxCiudad.SelectedIndex);
                cmd.Parameters.AddWithValue("VII", comboBoxFacultad.SelectedIndex);
                cmd.Parameters.AddWithValue("VIII", comboBoxCarrera.SelectedIndex);
                cmd.Parameters.AddWithValue("IX", Convert.ToInt32(textBoxAnioEstudio.Text));
                cmd.Parameters.AddWithValue("X", radioGroupTipoMatricula.SelectedIndex);
                cmd.Parameters.AddWithValue("XI", radioGroupBecado.SelectedIndex);
                cmd.Parameters.AddWithValue("XII", radioGroup1.SelectedIndex);
                cmd.Parameters.AddWithValue("XIII", radioGroup2.SelectedIndex);
                cmd.Parameters.AddWithValue("XIV", radioGroup3.SelectedIndex);
                cmd.Parameters.AddWithValue("XV", radioGroup4.SelectedIndex);
                cmd.Parameters.AddWithValue("XVI", Convert.ToInt32(textBox1.Text));
                cmd.Parameters.AddWithValue("XVII", radioGroup5.SelectedIndex);
                cmd.Parameters.AddWithValue("save", listRespuestas[Contador].Numero);



                succes = cmd.ExecuteNonQuery();

                if (succes < 0)
                {
                    MessageBox.Show("Error al insertar en la base de datos");
                }

                temp.Close();
                simpleButton4.Enabled = false;
                MessageBox.Show("Respuesta editada correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Error al actualizar la base de datos","Error" + erro);
            }
        }

        private void ComboBoxDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            enableSaveButton();
        }

        private void GridView1_RowClick(object sender, RowClickEventArgs e)
        {

        }

        private void GridView1_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show();
                indicatorRowIndex = gridView1.GetDataSourceRowIndex(e.RowHandle);
            }
        }

        // Funcion para obtener el valor
        private int getColumnNumeroValue()
        {
            var valor = gridView1.GetRowCellValue(indicatorRowIndex, "numero");
            if (valor == null)
                return -1;
            else
                return (int)valor;
        }

        public void DeleteInquestByNumero(int numero)
        {
            int succes = -1;
            try
            {
                dbConnection.IsConnect();
                NpgsqlConnection temp = dbConnection.Connection;
                temp.Open();

                NpgsqlCommand cmd = temp.CreateCommand();
                cmd.CommandText = String.Format("delete from respuestas where numero = {0}", numero);
                cmd.ExecuteNonQuery();

                succes = cmd.ExecuteNonQuery();

                if (succes < 0)
                {
                    MessageBox.Show("Error al insertar en la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                temp.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Error" + erro, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //return null;
            }
        }

        private void ContextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
        }

        private void DeleteInquestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int columNumeroValue = getColumnNumeroValue();
            if (columNumeroValue > 0)
            {
                DeleteInquestByNumero(columNumeroValue);
                gridView1.DeleteSelectedRows();
                gridControl1.DataSource = null;

                listRespuestas = null;
                fill();
                if (listRespuestas.Count > 0)
                {
                    fillFields(listRespuestas[0]);
                    Contador = 0;
                    textEditSearch.Text = (Contador + 1).ToString();
                } else
                {
                    blankFields();
                }
                MessageBox.Show("Campo borrado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void blankFields()
        {
            textEditSearch.Text = "";
            textEditFinal.Text = "";

            textBoxNombres.Text = "";
            textBoxApellidos.Text = "";
            radioGroupSexo.SelectedIndex = -1;
            textBoxCedula.Text = "";

            comboBoxDepartamento.SelectedIndex = -1;
            comboBoxCiudad.SelectedIndex = -1;
            comboBoxFacultad.SelectedIndex = -1;
            comboBoxCarrera.SelectedIndex = -1;

            textBoxAnioEstudio.Text = "";
            radioGroupTipoMatricula.SelectedIndex = -1;
            radioGroupBecado.SelectedIndex = -1;
            radioGroup1.SelectedIndex = -1;
            radioGroup2.SelectedIndex = -1;
            radioGroup3.SelectedIndex = -1;
            radioGroup4.SelectedIndex = -1;

            textBox1.Text = "";

            radioGroup5.SelectedIndex = -1;
        }
    }
}
