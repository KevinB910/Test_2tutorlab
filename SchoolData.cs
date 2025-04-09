using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TutorLab
{
    public partial class SchoolData : Form
    {
        public SchoolData()
        {
            InitializeComponent();
        }


        public void getData()
        {
            string conString = "server=localhost;uid=root;database=tutor_lab;";
            MySqlConnection con = new MySqlConnection(conString);
            con.Open();
            string query = "SELECT student_num, student_fname FROM student";
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dataGridView1.DataSource = dt;

            
        }


        private void showButton_Click(object sender, EventArgs e)
        {
            getData();
        }

    }
}

