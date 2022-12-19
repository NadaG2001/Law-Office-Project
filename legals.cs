using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace low_office
{
    public partial class legals : Form
    {
        public legals()
        {
            InitializeComponent();
            Showleg();
        }

        private void legals_Load(object sender, EventArgs e)
        {

        }
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\free bytes\OneDrive\Documents\lowoffice_db.mdf"";Integrated Security=True;Connect Timeout=30");
        private void Showleg()
        {
            conn.Open();
            string Query = "select * from legals_TB";
            SqlDataAdapter sda = new SqlDataAdapter(Query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            legals_dgv.DataSource = ds.Tables[0];
            conn.Close();
        }
        private void Reset()
        {
            legal_number.Text = "";
            court.Text = "";
            regdate.Text = "";
            attorney_num.Text = "";
            legal_DepID.Text = "";
        }
        private void savebtn_Click(object sender, EventArgs e)
        {
            if (legal_number.Text == "" || court.Text == "" || regdate.Text == "" || attorney_num.Text == "" || legal_DepID.Text == "")
            {
                MessageBox.Show("Missing information!\n please complete your info");
            }
            else
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("insert into legals_TB(Legal_Number, Court, Reg_Date, attorney_Number, Dep_ID)values(@LLN,@LLC,@LLRD,@LLAN,@LLDI)", conn);
                    cmd.Parameters.AddWithValue("@LLN", legal_number.Text);
                    cmd.Parameters.AddWithValue("@LLC", court.Text);
                    cmd.Parameters.AddWithValue("@LLRD", regdate.Text);
                    cmd.Parameters.AddWithValue("@LLAN", attorney_num.Text);
                    cmd.Parameters.AddWithValue("@LLDI", legal_DepID.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Department Added");
                    conn.Close();
                    Showleg();
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
            if (legal_number.Text == "" || court.Text == "" || regdate.Text == "" || attorney_num.Text == "" || legal_DepID.Text == "")
            {
                MessageBox.Show("Missing information!\n please complete your info");
            }
            else
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("Update legals_TB Set Legal_Number=@LLN, Court=@LLC, Reg_Date=@LLRD, attorney_Number=@LLAN,Dep_ID=@LLDI where Legal_Number=@Legkey", conn);
                    cmd.Parameters.AddWithValue("@LLN", legal_number.Text);
                    cmd.Parameters.AddWithValue("@LLC", court.Text);
                    cmd.Parameters.AddWithValue("@LLRD", regdate.Text);
                    cmd.Parameters.AddWithValue("@LLAN", attorney_num.Text);
                    cmd.Parameters.AddWithValue("@LLDI", legal_DepID.Text);
                    cmd.Parameters.AddWithValue("@Legkey", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Department Updated");
                    conn.Close();
                    Showleg();
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
            if (legal_number.Text == "" || court.Text == "" || regdate.Text == "" || attorney_num.Text == "" || legal_DepID.Text == "")
            {
                MessageBox.Show("Missing information!\n please complete your info");
            }
            else
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("Delete from legals_TB where Legal_Number=@Legkey", conn);
                    cmd.Parameters.AddWithValue("@LLN", legal_number.Text);
                    cmd.Parameters.AddWithValue("@Legkey", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Department Deleted");
                    conn.Close();
                    Showleg();
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

        private void label2_Click(object sender, EventArgs e)
        {
            lowyers obj = new lowyers();
            obj.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Clients obj = new Clients();
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
        int key = 0;
        private void legals_dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            legal_number.Text = legals_dgv.SelectedRows[0].Cells[0].Value.ToString();
            court.Text = legals_dgv.SelectedRows[0].Cells[1].Value.ToString();
            regdate.Text = legals_dgv.SelectedRows[0].Cells[2].Value.ToString();
            attorney_num.Text = legals_dgv.SelectedRows[0].Cells[3].Value.ToString();
            legal_DepID.Text = legals_dgv.SelectedRows[0].Cells[4].Value.ToString();
            if (legal_number.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(legals_dgv.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
    }
}
