using System;
using System.Data;
using System.Windows.Forms;
using DXApplication1.Classes;
using Npgsql;

namespace DXApplication1.Vistas
{
    public partial class NewResultUserControl : DevExpress.XtraEditors.XtraUserControl
    {
        private DB dbConnection;
        public NewResultUserControl()
        {
            InitializeComponent();
        }
        private void NewResultUserControl_Load(object sender, EventArgs e)
        {
            dbConnection = DB.Instance();
            dbConnection.DatabaseName = "respuestas";
            if (!dbConnection.IsConnect())
                MessageBox.Show("Hay un error con la base de Datos", "Información");

            LoadCombo();
        }

        private void FlowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

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
                    comboBoxCarrera.Properties.Items.Add(reader.GetString(0));
                    i++;
                }

                temp.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Error" + erro);
            }
        }

        private void SimpleButton1_Click(object sender, EventArgs e)
        {// Guardar
            if (NotEmptyFields()) {
                return;
            }
            int succes = -1;
            NpgsqlConnection temp;
            try
            {
                dbConnection.IsConnect();
                temp = dbConnection.Connection;
                if (temp.State == ConnectionState.Closed)
                {
                    temp.Open();
                }


                NpgsqlCommand cmd = temp.CreateCommand();
                cmd.CommandText = ("INSERT INTO `encuesta`.`respuestas`(`I`, `II`, `III`, `IV`, `V`, `VI`, `VII`, `VIII`, `IX`, `X`, `XI`, `XII`, `XIII`, `XIV`, `XV`, `XVI`, `XVII`) VALUES (@I, @II, @III, @IV, @V, @VI, @VII, @VIII, @IX, @X, @XI, @XII, @XIII, @XIV, @XV, @XVI, @XVII)");

                cmd.Parameters.AddWithValue("I", textBoxNombres.Text);
                cmd.Parameters.AddWithValue("II", textBoxApellidos.Text);
                cmd.Parameters.AddWithValue("III", radioGroupSexo.SelectedIndex);
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

                succes = cmd.ExecuteNonQuery();

                if (succes < 0)
                {
                    MessageBox.Show("Error al insertar en la base de datos","Advertencia",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                temp.Close();
                simpleButton1.Enabled = false;
                MessageBox.Show("Respuesta guardada Correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Error" + erro, "Advertencia",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool NotEmptyFields()
        {
            if (String.IsNullOrEmpty(textBoxNombres.Text) || String.IsNullOrEmpty(textBoxApellidos.Text)
                || radioGroupSexo.SelectedIndex < 0 || String.IsNullOrEmpty(textBoxCedula.Text)
                || comboBoxDepartamento.SelectedIndex < 0 || comboBoxCiudad.SelectedIndex < 0
                || comboBoxFacultad.SelectedIndex < 0 || comboBoxCarrera.SelectedIndex < 0
                || String.IsNullOrEmpty(textBoxAnioEstudio.Text) || radioGroupTipoMatricula.SelectedIndex < 0
                || radioGroupBecado.SelectedIndex < 0 || radioGroup1.SelectedIndex < 0
                || radioGroup2.SelectedIndex < 0 || radioGroup3.SelectedIndex < 0
                || radioGroup4.SelectedIndex < 0 || String.IsNullOrEmpty(textBox1.Text)
                || radioGroup5.SelectedIndex < 0)
            {
                MessageBox.Show("Debe llenar todos los datos", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
                return false;
        }
    }
}
