using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Desafio1_v1._1
{
    public partial class Login : Form
    {
        private readonly string _credspath = @"../../Creds";
        public Login()
        {
            InitializeComponent();
            txtUser.Focus();
        }

        #region formControls

        private void button1_Click(object sender, EventArgs e)
        {
            //if (txtUser.Text == "" && txtPass.Text == "")
            //{
            //    MessageBox.Show("Ingrese un usuario y contraseña");
            //    txtUser.Clear();
            //    txtPass.Clear();
            //    txtUser.Focus();
            //}
            //else
            //{
                desirializeJson(_credspath);
            //}
                
        }

        private void label1_Click(object sender, EventArgs e)
        {
            txtUser.Clear();
            txtPass.Clear();
            txtUser.Focus();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region json

        private void desirializeJson(string strJson)
        {
            try
            {
                string jsonFile;
                bool valid = false;
                using (var reader = new StreamReader(_credspath))
                {
                    jsonFile = reader.ReadToEnd();
                }

                var jObject = JsonConvert.DeserializeObject<dynamic>(jsonFile);

                foreach (var user in jObject.users)
                {
                     foreach (var pass in jObject.passwords)
                        {
                            if (user.userName == txtUser.Text && pass.userPassword == txtPass.Text && user.type == "admin")
                            {
                                valid = true;
                                this.Hide();
                                new admin_MainProgram().Show();
                            }
                            else if (user.userName == txtUser.Text && pass.userPassword == txtPass.Text && user.type == "regular")
                            {
                                valid = true;
                                this.Hide();
                                new MainProgram().Show();
                            }
                        }
                    }
                if(valid == false)
                {
                    MessageBox.Show("Las credenciales ingresadas son incorrectas o el usuario no existe. Contacto a su administrador de sistemas");
                    txtUser.Clear();
                    txtPass.Clear();
                    txtUser.Focus();
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
        }

        #endregion
    }
}
