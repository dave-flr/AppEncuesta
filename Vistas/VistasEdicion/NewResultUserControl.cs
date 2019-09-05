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
                MySqlConnection temp = dbConnection.Connection;
                temp.Open();
                MySqlCommand cmd = temp.CreateCommand();
                cmd.CommandText = ("SELECT valor From viii_carrera");

                MySqlDataReader reader = cmd.ExecuteReader();
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
            int succes = -1;
            MySqlConnection temp;
            try
            {
                dbConnection.IsConnect();
                temp = dbConnection.Connection;
                if (temp.State == ConnectionState.Closed)
                {
                    temp.Open();
                }


                MySqlCommand cmd = temp.CreateCommand();
                cmd.CommandText = ("INSERT INTO `encuesta`.`respuestas`(`I`, `II`, `III`, `IV`, `V`, `VI`, `VII`, `VIII`, `IX`, `X`, `XI`, `XII`, `XIII`, `XIV`, `XV`, `XVI`, `XVII`) VALUES (@I, @II, @III, @IV, @V, @VI, @VII, @VIII, @IX, @X, @XI, @XII, @XIII, @XIV, @XV, @XVI, @XVII)");

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



                succes = cmd.ExecuteNonQuery();

                if (succes < 0)
                {
                    MessageBox.Show("Error al insertar en la base de datos");
                }

                temp.Close();
                simpleButton1.Enabled = false;
            }
            catch (Exception erro)
            {
                MessageBox.Show("Error" + erro);
            }
        }

        
    }
}
