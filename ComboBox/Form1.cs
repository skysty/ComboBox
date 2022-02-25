using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace ComboBox
{
    public partial class Form1 : Form
    {
        
        private SqlConnection conn;
        public Form1()
        {
            InitializeComponent();
        }
        public string GetSqlConnection()
        {

            return @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\source\repos\ComboBox\ComboBox\Data\TestData.mdf;Integrated Security=True";

        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
        //private void PopulateComboBox() {
        //    Lang[] langs = new Lang[] {
        //        new Lang("Компания аты", "CompanyName"),
        //        new Lang("Корпоративті поштасы", "Email")
        //    };
        //    cms.DataSource= langs;
        //    cms.DisplayMember = "Name";
        //    cms.ValueMember = "DataName";
        //}
        private void PopulateGrid() {
            string sql = "SELECT* FROM Users";
            conn = new SqlConnection(GetSqlConnection());
            conn.Open();
            SqlCommand sqlCommand = new SqlCommand(sql, conn);

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            var column = dataGridView1.Columns[0];
            column.HeaderText = "ИД";
            column.Width = 30;
            var column1 = dataGridView1.Columns[1];
            column1.HeaderText = "Компания аты";
            column1.Width = 120;
            var column2 = dataGridView1.Columns[2];
            column2.HeaderText = "Корпоративті поштасы";
            column2.Width = 170;
            var column3 = dataGridView1.Columns[3];
            column3.HeaderText = "Телефон нөмірі";
            column3.Width = 139;
            var column4 = dataGridView1.Columns[4];
            column4.HeaderText = "Мекен жайы";
            column4.Width = 110;
            conn.Close();
        }
        private void Form1_Load_1(object sender, EventArgs e)
        {
           PopulateGrid();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
          
            if (e.KeyCode == Keys.Enter)
            {
                
                var displayrows = cms.SelectedItem.ToString();
                if (string.IsNullOrEmpty(txt.Text))
                {
                    MessageBox.Show("Деректер жок ");
                }
                else
                {
                    conn = new SqlConnection(GetSqlConnection());
                    conn.Open();
                    string sql =string.Format("SELECT * FROM Users Where {0} = '{1}' ", displayrows,txt.Text);
                    SqlCommand command = new SqlCommand(sql, conn);
                    
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    
                    dataGridView1.DataSource = dataTable;
                    conn.Close();
                }
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string sqlExp = string.Format("INSERT INTO Users (CompanyName, Email, MobileNumber,Address) VALUES('{0}','{1}','{2}','{3}')", txtCompany.Text, txtEmail.Text, txtNumber.Text, txtAddress.Text);
            conn = new SqlConnection(GetSqlConnection());
            conn.Open();
            SqlCommand sqlCommand = new SqlCommand(sqlExp, conn);
            sqlCommand.ExecuteNonQuery();
            MessageBox.Show("Cәтті Енгізілді");
            conn.Close();
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            PopulateGrid();
        }
    }
}
