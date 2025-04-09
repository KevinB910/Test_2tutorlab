using MySql.Data.MySqlClient;
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace TutorLab
{
    public partial class tutorCheckIn : Form
    {
        StreamWriter punchFile = new StreamWriter("D:\\CapStone\\TutorLab\\Punches.txt", true);

        string regPattern = @"^%(\d+)?";
        Regex regie;
        public tutorCheckIn()
        {
            InitializeComponent();
            regie = new Regex(regPattern);
        }

        public void compareStudentID()
        { 
            string conString = "server=localhost;uid=root;database=tutor_lab;";
            MySqlConnection con = new MySqlConnection(conString);
            con.Open();
            string query = "SELECT student_num FROM student";
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader reader = cmd.ExecuteReader();
        }

        private bool ReaderIsValid()
        {
            var valid = false;
            try
            {
                string input = studentIdTextBox.Text;
                string studentID = Regex.Replace(input, @"(\s+|@|&|'|\(|\)|<|>|#|%)", "");
                string readID = studentID.Length >= 7 ? studentID.Substring(0, 7) : studentID;
                Match match2 = regie.Match(studentID);
                string digits = match2.Groups[1].Value;
                int studentIDNum;
                studentNumLabel.Text = readID;
                if (match2.Success || int.TryParse(readID, out studentIDNum))
                {

                    valid = true;
                }
                else
                {
                    int studentNum;
                    if (int.TryParse(readID, out studentNum))
                    {
                        valid = true;
                    }
                }
            }
            catch (Exception)
            {

                string input = studentIdTextBox.Text;
            }
            return valid;
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            ReaderIsValid();

            
            if (ReaderIsValid())
            {
                DateTime epochStart = new DateTime(1970, 1, 1);
                DateTime currentTime = DateTime.UtcNow;
                TimeSpan timeDifference = currentTime - epochStart;
                long epochTime = (long)timeDifference.TotalSeconds;
                punchFile.WriteLine(studentNumLabel.Text + ", " + currentTime);
                
                MessageBox.Show("Logged In");
            }


            else
            {
                MessageBox.Show("Wrong");
            }

            studentIdTextBox.Text = string.Empty;


        }

        

        private void databaseButton_Click(object sender, EventArgs e)
        {
            SchoolData frm = new SchoolData();
            frm.Show();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            punchFile.Close();
            this.Close();
        }

        private void formClosed(object sender, FormClosedEventArgs e)
        {
            punchFile.Close();
        }
    }
}
