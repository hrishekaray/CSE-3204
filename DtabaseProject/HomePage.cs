using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DtabaseProject
{
    public partial class HomePage : Form
    {
        DBAccess objDbAccess = new DBAccess();
        public HomePage()
        {
            InitializeComponent();
        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            lblWelcomeName.Text = "Welcome " + Signin.name;
            txtNameHome.Text = Signin.name;
            txtEmailHome.Text = Signin.email;
            txtPasswordHome.Text = Signin.password;
            txtCountryHome.Text = Signin.country;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdateInfo_Click(object sender, EventArgs e)
        {
            string newUserName = txtNameHome.Text;
            string newUserEmail = txtEmailHome.Text;
            string newUserPassword = txtPasswordHome.Text;
            string newUserCountry = txtCountryHome.Text;

            if(newUserName.Equals(""))
            {
                MessageBox.Show("Please write your Name");
            }

            else if (newUserEmail.Equals(""))
            {
                MessageBox.Show("Please write your Email Address");
            }

            else if (newUserPassword.Equals(""))
            {
                MessageBox.Show("Please write your Password");
            }

            else if (newUserCountry.Equals(""))
            {
                MessageBox.Show("Please write your Country Name");
            }

            else 
            {
                string query = "Update Users SET Name='"+ @newUserName +"', Email='"+ @newUserEmail +"', Password='" + @newUserPassword +"', Country='" + @newUserCountry +"' where ID='"+ Signin.id+ "'";

                SqlCommand updateCommand = new SqlCommand(query);

                updateCommand.Parameters.AddWithValue("@userName", @newUserName);
                updateCommand.Parameters.AddWithValue("@userEmail", @newUserEmail);
                updateCommand.Parameters.AddWithValue("@userPassword", @newUserPassword);
                updateCommand.Parameters.AddWithValue("@userCountry", @newUserCountry);

                int row = objDbAccess.executeQuery(updateCommand);

                if (row == 1)
                {
                    MessageBox.Show("Account Information Updated successfully");

                    this.Hide();
                    Signin sign = new Signin();
                    sign.Show();
                }

                else
                {
                    MessageBox.Show("Try Again");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Are you sure?", "Delete Account",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);

            if(dialog == DialogResult.Yes)
            {
                string query = "DELETE from Users Where ID='" + Signin.id +"'";

                SqlCommand deleteCommand = new SqlCommand(query);

                int row = objDbAccess.executeQuery(deleteCommand);

                if (row == 1)
                {
                    MessageBox.Show("Account Deleted successfully");

                    this.Hide();
                    Signin sign = new Signin();
                    sign.Show();
                }

                else
                {
                    MessageBox.Show("Try Again");
                }

            }
        }
    }
}
