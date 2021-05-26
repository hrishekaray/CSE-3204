using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DtabaseProject
{
    public partial class Signin : Form
    {
        public static string id,name,email,password,country;

        DBAccess objDbAccess = new DBAccess();
        DataTable dtUsers = new DataTable();
        public Signin()
        {
            InitializeComponent();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSignin_Click(object sender, EventArgs e)
        {
            string userEmail = txtEmailLogin.Text;
            string userPassword = txtPasswordLogin.Text;

            if (userEmail.Equals(""))
            {
                MessageBox.Show("Please enter Email");
            }

            else if (userPassword.Equals(""))
            {
                MessageBox.Show("Please enter Password");
            }

            else 
            {
                string query = "Select * from Users Where Email='"+ userEmail +"' AND  Password = '"+userPassword+ "'";

                objDbAccess.readDatathroughAdapter(query , dtUsers);

                if(dtUsers.Rows.Count == 1)
                {
                    id = dtUsers.Rows[0]["ID"].ToString();
                    name = dtUsers.Rows[0]["Name"].ToString();
                    email = dtUsers.Rows[0]["Email"].ToString();
                    password = dtUsers.Rows[0]["Password"].ToString();
                    country = dtUsers.Rows[0]["Country"].ToString();


                    MessageBox.Show("Congratulation, you are logged in Successfully.");
                    objDbAccess.closeConn();

                    this.Hide();
                    HomePage home = new HomePage();
                    home.Show();
                }

                else
                {
                    MessageBox.Show("Invalid Credentials! Provide correct Email And Password");
                }
            }
        }

        private void txtEmailLogin_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblCreateAccount_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignUp signup = new SignUp();
            signup.Show();
        }
    }
}
