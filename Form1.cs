using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace login_Page
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=DESKTOP-AS9KRJV;Initial Catalog=login_Page;Integrated Security=True";
            InitializeComponent();
            
        }

        private void txtUserEnter(object sender, EventArgs e)
        {
            if (txtUsername.Text.Equals(@"Username \ Email"))
            {
                txtUsername.Text = "";
            }
        }

        private void txtUserLeave(object sender, EventArgs e)
        {
            if (txtUsername.Text.Equals(""))
            {
                txtUsername.Text = @"Username \ Email";
            }
        }

        private void txtPasswordEnter(object sender, EventArgs e)
        {
            if (txtPassword.Text.Equals("Password"))
            {
                txtPassword.Text = "";
            }
        }

        private void txtPasswordLeave(object sender, EventArgs e)
        {
            if (txtPassword.Text.Equals(""))
            {
                txtPassword.Text = "Password";
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source =.; Initial Catalog = login_Page; Integrated Security = True";
            con.Open();
            
            SqlCommand command = new SqlCommand();
            command.CommandText = "select * from AUTH";
            command.Connection = con;
            SqlDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {
                if (txtUsername.Text.Equals(dr["username"].ToString()) && txtPassword.Text.Equals(dr["password"].ToString()))
                {
                    MessageBox.Show("Login Successfully", "Congrates", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Either your username or password is incorrect","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
