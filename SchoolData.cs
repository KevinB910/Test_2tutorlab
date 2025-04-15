using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TutorLab
{
    public partial class SchoolData : Form
    {
        private string studentNum;

        public SchoolData(string studentNum)
        {
            InitializeComponent();
            this.studentNum = studentNum;
        }


        public void getData()
        {

            string conString = "server=localhost;uid=root;database=tutor_lab;";
            MySqlConnection con = new MySqlConnection(conString);
            con.Open();

            // Query to get all available courses that the student isn't enrolled in
            string query = @"
                    SELECT c.course_name, c.course_descript
                    FROM course c
                    INNER JOIN enrollment e ON c.course_id = e.course_id
                    INNER JOIN student s ON s.student_id = e.student_id
                    WHERE s.student_num = @studentNum";

            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@studentNum", studentNum);  // Pass the studentNum into the query

            MySqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dataGridView1.DataSource = dt;

            con.Close();

        }


        public event Action<string> CourseSelected;



        private void showButton_Click(object sender, EventArgs e)
        {
            getData();
        }

        private void dataGridCourseSelect_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0) 
                {
                    string selectedCourse = dataGridView1.Rows[e.RowIndex].Cells["course_name"].Value.ToString();

                    CourseSelected?.Invoke(selectedCourse);

                    this.Close();
                }
        }

        private void selectedCourseBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                string selectedCourse = dataGridView1.CurrentRow.Cells["course_name"].Value.ToString();

                CourseSelected?.Invoke(selectedCourse);

                this.Close();
            }
            else
            {
                MessageBox.Show("Please select a course first.");
            }
        }
    }
}

