using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace low_office
{
    public partial class lowyers : Form
    {
        public lowyers()
        {
            InitializeComponent();
            Showlow();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\free bytes\OneDrive\Documents\lowoffice_db.mdf"";Integrated Security=True;Connect Timeout=30");
        private void Showlow()
        {
            conn.Open();
            string Query = "select * from lowyers_TB";
            SqlDataAdapter sda = new SqlDataAdapter(Query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            low_dgv.DataSource = ds.Tables[0];
            conn.Close();
        }
        private void Reset()
        {
            lowyer_id.Text = "";
            lowyer_Name.Text = "";
            phone.Text = "";
            exp.Text = "";
            legal.Text = "";
            salary.Text = "";
            address.Text = "";
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            if (lowyer_id.Text == "" || lowyer_Name.Text == "" || phone.Text == "" || exp.Text == "" || legal.Text == "" || salary.Text == "" || address.Text == "")
            {
                MessageBox.Show("Missing information!\n please complete your info");
            }
            else
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("insert into lowyers_TB(Lowyer_ID, Lowyer_Name, Phone, Experience, Legal_ID, Salary, address)values(@LI,@LN,@LP,@LE,@LD,@LS,@LA)", conn);
                    cmd.Parameters.AddWithValue("@LI", lowyer_id.Text);
                    cmd.Parameters.AddWithValue("@LN", lowyer_Name.Text);
                    cmd.Parameters.AddWithValue("@LP", phone.Text);
                    cmd.Parameters.AddWithValue("@LE", exp.Text);
                    cmd.Parameters.AddWithValue("@LD", legal.Text);
                    cmd.Parameters.AddWithValue("@LS", salary.Text);
                    cmd.Parameters.AddWithValue("@LA", address.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Department Added");
                    conn.Close();
                    Showlow();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void editbtn_Click(object sender, EventArgs e)
        {
            if (lowyer_id.Text == "" || lowyer_Name.Text == "" || phone.Text == "" || exp.Text == "" || legal.Text == "" || salary.Text == "" || address.Text == "")
            {
                MessageBox.Show("Missing information!\n please complete your info");
            }
            else
            {
                try
                {                          
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("Update lowyers_TB Set Lowyer_ID=@LI, Lowyer_Name=@LN, Phone=@LP, Experience=@LE,Legal_ID=@LD,Salary=@LS,address=@LA where Lowyer_ID=@Lkey", conn);
                    cmd.Parameters.AddWithValue("@LI", lowyer_id.Text);
                    cmd.Parameters.AddWithValue("@LN", lowyer_Name.Text);
                    cmd.Parameters.AddWithValue("@LP", phone.Text);
                    cmd.Parameters.AddWithValue("@LE", exp.Text);
                    cmd.Parameters.AddWithValue("@LD", legal.Text);
                    cmd.Parameters.AddWithValue("@LS", salary.Text);
                    cmd.Parameters.AddWithValue("@LA", address.Text);
                    cmd.Parameters.AddWithValue("@Lkey", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Department Updated");
                    conn.Close();
                    Showlow();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            if (lowyer_id.Text == "" || lowyer_Name.Text == "" || phone.Text == "" || exp.Text == "" || legal.Text == "" || salary.Text == "" || address.Text == "")
            {
                MessageBox.Show("Missing information!\n please complete your info");
            }
            else
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("Delete from lowyers_TB where Lowyer_ID=@Lkey", conn);
                    cmd.Parameters.AddWithValue("@LI", lowyer_id.Text);
                    cmd.Parameters.AddWithValue("@Lkey", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Department Deleted");
                    conn.Close();
                    Showlow();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            obj.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Clients obj = new Clients();
            obj.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            legals obj = new legals();
            obj.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Departments obj = new Departments();
            obj.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            login obj = new login();
            obj.Show();
            this.Hide();
        }

        private void lowyers_Load(object sender, EventArgs e)
        {

        }
        int key = 0;
        private void low_dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            lowyer_id.Text = low_dgv.SelectedRows[0].Cells[0].Value.ToString();
            lowyer_Name.Text = low_dgv.SelectedRows[0].Cells[1].Value.ToString();
            phone.Text = low_dgv.SelectedRows[0].Cells[2].Value.ToString();
            exp.Text = low_dgv.SelectedRows[0].Cells[3].Value.ToString();
            legal.Text = low_dgv.SelectedRows[0].Cells[4].Value.ToString();
            salary.Text = low_dgv.SelectedRows[0].Cells[5].Value.ToString();
            address.Text = low_dgv.SelectedRows[0].Cells[6].Value.ToString();
            if (lowyer_id.Text == "")
            {
                key = 0;
                /*dep_id.Text = "";
                Dep_Name.Text = "";
                Dep_fees.Text = "";
                Dep_date.Text = "";*/
            }
            else
            {
                key = Convert.ToInt32(low_dgv.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
