using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace low_office
{
    public partial class Clients : Form
    {
        public Clients()
        {
            InitializeComponent();
            Showclients();
        }

        private void Clients_Load(object sender, EventArgs e)
        {

        }
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\free bytes\OneDrive\Documents\lowoffice_db.mdf"";Integrated Security=True;Connect Timeout=30");
        private void Showclients()
        {
            conn.Open();
            string Query = "select * from Client_TB";
            SqlDataAdapter sda = new SqlDataAdapter(Query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            clients_dgv.DataSource = ds.Tables[0];
            conn.Close();
        }
        private void Reset()
        {
            clientid.Text = "";
            clientname.Text = "";
            clientphone.Text = "";
            clientadd.Text = "";
            rivalname.Text = "";
            rivaladd.Text = "";
            legalnum.Text = "";
        }
        private void savebtn_Click(object sender, EventArgs e)
        {
            if (clientid.Text == "" || clientname.Text == "" || clientphone.Text == "" || clientadd.Text == "" || rivalname.Text == "" || rivaladd.Text == "" || legalnum.Text == "")
            {
                MessageBox.Show("Missing information!\n please complete your info");
            }
            else
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("insert into Client_TB(Client_ID, Client_Name, Client_Phone, Client_address, Rival_Name, Rival_address, Legal_Number)values(@CI,@CN,@CP,@CA,@RCN,@RCA,@LNC)", conn);
                    cmd.Parameters.AddWithValue("@CI", clientid.Text);
                    cmd.Parameters.AddWithValue("@CN", clientname.Text);
                    cmd.Parameters.AddWithValue("@CP", clientphone.Text);
                    cmd.Parameters.AddWithValue("@CA", clientadd.Text);
                    cmd.Parameters.AddWithValue("@RCN", rivalname.Text);
                    cmd.Parameters.AddWithValue("@RCA", rivaladd.Text);
                    cmd.Parameters.AddWithValue("@LNC", legalnum.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Department Added");
                    conn.Close();
                    Showclients();
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
            if (clientid.Text == "" || clientname.Text == "" || clientphone.Text == "" || clientadd.Text == "" || rivalname.Text == "" || rivaladd.Text == "" || legalnum.Text == "")
            {
                MessageBox.Show("Missing information!\n please complete your info");
            }
            else
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("Update Client_TB Set Client_ID=@CI, Client_Name=@CN, Client_Phone=@CP, Client_address=@CA,Rival_Name=@RCN,Rival_address=@RCA,Legal_Number=@LNC where Client_ID=@Ckey", conn);
                    cmd.Parameters.AddWithValue("@CI", clientid.Text);
                    cmd.Parameters.AddWithValue("@CN", clientname.Text);
                    cmd.Parameters.AddWithValue("@CP", clientphone.Text);
                    cmd.Parameters.AddWithValue("@CA", clientadd.Text);
                    cmd.Parameters.AddWithValue("@RCN", rivalname.Text);
                    cmd.Parameters.AddWithValue("@RCA", rivaladd.Text);
                    cmd.Parameters.AddWithValue("@LNC", legalnum.Text);
                    cmd.Parameters.AddWithValue("@Ckey", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Department Updated");
                    conn.Close();
                    Showclients();
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

            if (clientid.Text == "" || clientname.Text == "" || clientphone.Text == "" || clientadd.Text == "" || rivalname.Text == "" || rivaladd.Text == "" || legalnum.Text == "")
            {
                MessageBox.Show("Missing information!\n please complete your info");
            }
            else
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("Delete from Client_TB where Client_ID=@Ckey", conn);
                    cmd.Parameters.AddWithValue("@CI", clientid.Text);
                    cmd.Parameters.AddWithValue("@Ckey", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Department Deleted");
                    conn.Close();
                    Showclients();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Departments obj = new Departments();
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
        int key = 0;
        private void clients_dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            clientid.Text = clients_dgv.SelectedRows[0].Cells[0].Value.ToString();
            clientname.Text = clients_dgv.SelectedRows[0].Cells[1].Value.ToString();
            clientphone.Text = clients_dgv.SelectedRows[0].Cells[2].Value.ToString();
            clientadd.Text = clients_dgv.SelectedRows[0].Cells[3].Value.ToString();
            rivalname.Text = clients_dgv.SelectedRows[0].Cells[4].Value.ToString();
            rivaladd.Text = clients_dgv.SelectedRows[0].Cells[5].Value.ToString();
            legalnum.Text = clients_dgv.SelectedRows[0].Cells[6].Value.ToString();
            if (clientid.Text == "")
            {
                key = 0;

            }
            else
            {
                key = Convert.ToInt32(clients_dgv.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
    }
}
