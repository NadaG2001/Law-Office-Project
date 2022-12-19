using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace low_office
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            if(user_name.Text == "" || password.Text == "")
            {
                MessageBox.Show("please Enter Username and password");
            }
            else if(user_name.Text == "Admin" && password.Text == "pass")
            {
                Form1 obj = new Form1();
                obj.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong Username Or Password");
                user_name.Text = "";
                password.Text = "";
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            user_name.Text = "";
            password.Text = "";
        }
    }
}
