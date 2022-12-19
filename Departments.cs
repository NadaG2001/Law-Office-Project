using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace low_office
{
    public partial class Departments : Form
    {
        public Departments()
        {
            InitializeComponent();
            ShowDep();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\free bytes\OneDrive\Documents\lowoffice_db.mdf"";Integrated Security=True;Connect Timeout=30");
        private void ShowDep()
        {
            conn.Open();
            string Query = "select * from Department_T";
            SqlDataAdapter sda = new SqlDataAdapter(Query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dep_dgv.DataSource =ds.Tables[0];
            conn.Close();
        }
        private void Reset()
        {
            dep_id.Text = "";
            Dep_Name.Text = "";
            Dep_fees.Text = "";
            Dep_date.Text = "";
        }
        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            if (dep_id.Text == "" || Dep_Name.Text == ""|| Dep_fees.Text=="" || Dep_date.Text == "")
            {
                MessageBox.Show("Missing information!\n please complete your info");
            }
            else
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("insert into Department_T(Dep_ID, Dep_Name, Fees, Date)values(@DI,@DN,@DF,@DD)", conn);
                    cmd.Parameters.AddWithValue("@DI", dep_id.Text);
                    cmd.Parameters.AddWithValue("@DN", Dep_Name.Text);
                    cmd.Parameters.AddWithValue("@DF", Dep_fees.Text);
                    cmd.Parameters.AddWithValue("@DD", Dep_date.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Department Added");
                    conn.Close();
                    ShowDep();
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
            if (dep_id.Text == "" || Dep_Name.Text == "" || Dep_fees.Text == "" || Dep_date.Text == "")
            {
                MessageBox.Show("Missing information!\n please complete your info");
            }
            else
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("Update Department_T Set Dep_ID=@DI, Dep_Name=@DN, Fees=@DF, Date=@DD where Dep_ID=@Dkey", conn);
                    cmd.Parameters.AddWithValue("@DI", dep_id.Text);
                    cmd.Parameters.AddWithValue("@DN", Dep_Name.Text);
                    cmd.Parameters.AddWithValue("@DF", Dep_fees.Text);
                    cmd.Parameters.AddWithValue("@DD", Dep_date.Text);
                    cmd.Parameters.AddWithValue("@Dkey", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Department Updated");
                    conn.Close();
                    ShowDep();
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
            if (dep_id.Text == "" || Dep_Name.Text == "" || Dep_fees.Text == "" || Dep_date.Text == "")
            {
                MessageBox.Show("Missing information!\n please complete your info");
            }
            else
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("Delete from Department_T where Dep_ID=@Dkey", conn);
                    cmd.Parameters.AddWithValue("@DI", dep_id.Text);
                    cmd.Parameters.AddWithValue("@Dkey", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Department Deleted");
                    conn.Close();
                    ShowDep();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
                  }
            }

        private void label4_Click(object sender, EventArgs e)
        {
            Clients obj = new Clients();
            obj.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            obj.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            lowyers obj = new lowyers();
            obj.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            legals obj = new legals();
            obj.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            login obj = new login();
            obj.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
        int key = 0;
        private void dep_dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dep_id.Text = dep_dgv.SelectedRows[0].Cells[0].Value.ToString();
            Dep_Name.Text = dep_dgv.SelectedRows[0].Cells[1].Value.ToString();
            Dep_fees.Text = dep_dgv.SelectedRows[0].Cells[2].Value.ToString();
            Dep_date.Text = dep_dgv.SelectedRows[0].Cells[3].Value.ToString();
            if(dep_id.Text == "")
            {
                key = 0;
                /*dep_id.Text = "";
                Dep_Name.Text = "";
                Dep_fees.Text = "";
                Dep_date.Text = "";*/
            }
            else
            {
                key = Convert.ToInt32(dep_dgv.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
    }
}
