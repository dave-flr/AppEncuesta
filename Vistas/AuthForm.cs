using System;
using DXApplication1.Classes;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DXApplication1.Vistas
{
    public partial class AuthForm : DevExpress.XtraEditors.XtraForm
    {
        public AuthForm()
        {
            InitializeComponent();
        }

        private void SimpleButton1_Click(object sender, EventArgs e)
        {
            if (connect())
            {
                DialogResult = DialogResult.OK;
            } else
            {
                DialogResult = DialogResult.No;
            }
            
        }
        private bool connect()
        {
            var db = DB.Instance();
            db.ServerName = serverNameTextEdit.Text;
            db.UserName = userNameTextEdit.Text;
            db.Password1 = passwordTextEdit.Text;
            db.DatabaseName = "encuesta";

            if (!db.IsConnect())
            {
                return false;
            }
            db.Close();
            return true;
        }
    }
}
