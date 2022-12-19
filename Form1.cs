using System.Data;
using System.Data.SqlClient;

namespace low_office
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Countslowyers();
            CountsClients();
            Countslegals();
            CountsDep();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void Countslegals()
        {
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from legals_TB", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            st_legals_num.Text = dt.Rows[0][0].ToString();
            conn.Close();
        }
        private void label3_Click(object sender, EventArgs e)
        {
            legals obj = new legals();
            obj.Show();
            this.Hide();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\free bytes\OneDrive\Documents\lowoffice_db.mdf"";Integrated Security=True;Connect Timeout=30");
        private void Countslowyers()
        {
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from lowyers_TB", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            st_low_num.Text = dt.Rows[0][0].ToString();
            conn.Close();
        }
        private void label2_Click(object sender, EventArgs e)
        {

            lowyers obj = new lowyers();
            obj.Show();
            this.Hide();
        }
        private void CountsClients()
        {
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from Client_TB", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            st_clients_num.Text = dt.Rows[0][0].ToString();
            conn.Close();
        }
        private void label4_Click(object sender, EventArgs e)
        {
            Clients obj = new Clients();
            obj.Show();
            this.Hide();
        }
        private void CountsDep()
        {
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from Department_T", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            st_Dep_num.Text = dt.Rows[0][0].ToString();
            conn.Close();
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
    }
}