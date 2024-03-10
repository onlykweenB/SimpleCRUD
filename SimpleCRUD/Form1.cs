using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace SimpleCRUD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connection = "server=localhost; user id=root; password=; database=studentrecord";
            string query = "INSERT INTO tbl_student(FullName, City, Gender, Age) VALUES ('" + this.FullName.Text + "', '" + this.City.Text + "', '" + this.Gender.Text + "', '" + this.Age.Text + "')";
            MySqlConnection conn = new MySqlConnection(connection);
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader dr;
            conn.Open();
            dr = cmd.ExecuteReader();
            MessageBox.Show("Successfully saved.");
            conn.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connection = "server=localhost; user id=root; password=; database=studentrecord";
            string query = "UPDATE tbl_student SET FullName = '" + this.FullName.Text + "', City = '" + this.City.Text + "', Gender =  '" + this.Gender.Text + "', Age =  '" + this.Age.Text + "' WHERE StudentID = '" + this.StudentID.Text + "' ";
            MySqlConnection conn = new MySqlConnection(connection);
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader dr;
            conn.Open();
            dr = cmd.ExecuteReader();
            MessageBox.Show("Updated Successfully.");
            conn.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string connection = "server=localhost; user id=root; password=; database=studentrecord";
            string query = "SELECT * FROM tbl_student";
            MySqlConnection conn = new MySqlConnection(connection);
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string connection = "server=localhost; user id=root; password=; database=studentrecord";
            string query = "DELETE FROM tbl_student WHERE StudentID = '" + this.StudentID.Text + "'";
            MySqlConnection conn = new MySqlConnection(connection);
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader dr;
            conn.Open();
            dr = cmd.ExecuteReader();
            MessageBox.Show("Deleted Successfully.");
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            string connection = "server=localhost; user id=root; password=; database=studentrecord";
            MySqlConnection con = new MySqlConnection(connection);
            MySqlDataAdapter da;
            DataTable dt;
            con.Open();
            da = new MySqlDataAdapter("SELECT * FROM tbl_student WHERE FullName LIKE'" + this.textBox6.Text + "%'", con);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();    
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string connection = "server=localhost; user id=root; password=; database=studentrecord";
            string query = "SELECT * FROM tbl_student";
            MySqlConnection conn = new MySqlConnection(connection);
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
