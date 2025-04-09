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
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace TutorLab
{
    public partial class tutorCheckIn : Form
    {
        StreamWriter punchFile = new StreamWriter("D:\\School\\0Spring2025\\CSC289\\TutorLab\\TutorLab\\Punches.txt", true);
        
        public class CustomPunch
        {
            public string DisplayedName { get; set; }
            public int HiddenPunchId { get; set; }

            public override string ToString()
            {
                return DisplayedName;
            }
        }

        string regPattern = @"^%(\d+)?";
        Regex regie;
        public tutorCheckIn()
        {
            InitializeComponent();
            regie = new Regex(regPattern);
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


        public bool DateIsValid()
        {
            
            var valid = false;
            string studentNum = studentNumLabel.Text;
            string conString = "server=localhost;uid=root;database=tutor_lab;";
            MySqlConnection con = new MySqlConnection(conString);
            con.Open();
            string query = "SELECT s.student_id, cs.day_of_week, cs.class_time, cs.end_class " +
                "FROM course_schedule cs " +
                "INNER JOIN course c ON cs.course_id = c.course_id " +
                "INNER JOIN enrollment e ON c.course_id = e.course_id " +
                "INNER JOIN student s ON e.student_id = s.student_id " +
                "WHERE s.student_num = @student_num";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@student_num", studentNum);
            DayOfWeek today = DateTime.Now.DayOfWeek;
            DateTime time = DateTime.Now;
            string timeNow = time.ToLongTimeString();
            string weekDay;
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int studentId = reader.GetInt32(0);
                    string dayWeek = reader.GetString(1);
                    TimeSpan classTime = reader.GetTimeSpan(2);
                    TimeSpan endTime = reader.GetTimeSpan(3);
                    if (today == DayOfWeek.Monday)
                    {
                        weekDay = "M";
                    }
                    else if (today == DayOfWeek.Tuesday)
                    {
                        weekDay = "Tu";
                    }
                    else if (today == DayOfWeek.Wednesday)
                    {
                        weekDay = "W";
                    }
                    else if (today == DayOfWeek.Thursday)
                    {
                        weekDay = "Th";
                    }
                    else if (today == DayOfWeek.Friday)
                    {
                        weekDay = "F";
                    }
                    else
                    {
                        weekDay = "Weekend";
                    }

                    if (dayWeek.Contains(weekDay))
                    {
                        TimeSpan currentTime = time.TimeOfDay;

                        if (currentTime <= classTime || currentTime >= endTime)
                        {
                            valid = true;
                            punchFile.WriteLine(weekDay);
                        }
                        else
                        {
                            valid = false;
                        }

                    }
                }
            }
            return valid;
        }

        private int DBInsertTime(string studentNum, string studentName, DayOfWeek punchDay, DateTime punchInTime)
        {
            int punchId = 0;
            string conString = "server=localhost;uid=root;database=tutor_lab;";
            using (MySqlConnection con = new MySqlConnection(conString))
            {
                con.Open();
                string insertQuery = "INSERT INTO punches (student_num, student_name, punch_day, punch_in_time) " +
                                     "VALUES (@student_num, @student_name, @punch_day, @punch_in_time)";
                using (MySqlCommand insertCmd = new MySqlCommand(insertQuery, con))
                {
                    insertCmd.Parameters.AddWithValue("@student_num", studentNum);
                    insertCmd.Parameters.AddWithValue("@student_name", studentName);
                    insertCmd.Parameters.AddWithValue("@punch_day", punchDay.ToString());
                    insertCmd.Parameters.AddWithValue("@punch_in_time", punchInTime);
                    insertCmd.ExecuteNonQuery(); // Execute the insert

                    string selectQuery = "SELECT LAST_INSERT_ID();";
                    using (MySqlCommand idCmd = new MySqlCommand(selectQuery, con))
                    {
                        punchId = Convert.ToInt32(idCmd.ExecuteScalar());
                    }
                }
            }
            return punchId;
        }


        private void PopulatePunchListBox()
        {
            string conString = "server=localhost;uid=root;database=tutor_lab;";
            using (MySqlConnection con = new MySqlConnection(conString))
            {
                con.Open();
                string query = "SELECT DISTINCT punch_id, student_name FROM punches WHERE punch_out_time IS NULL";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        punchListBox.Items.Clear(); // Clear existing items
                        while (reader.Read())
                        {
                            CustomPunch item = new CustomPunch
                            {
                                HiddenPunchId = reader.GetInt32("punch_id"), // Get punch_id
                                DisplayedName = reader.GetString("student_name") // Get student_name
                            };
                            punchListBox.Items.Add(item);
                        }
                    }
                }
            }
        }


        private void DBPunchOutTime(DateTime punchOutTime, int punchId)
        {
            {
                string conString = "server=localhost;uid=root;database=tutor_lab;";
                using (MySqlConnection con = new MySqlConnection(conString))
                {
                    try
                    {
                        con.Open();
                        string query = "UPDATE punches " +
                                       "SET punch_out_time = @punch_out_time " +
                                       "WHERE punch_id = @punch_id AND punch_out_time IS NULL";

                        using (MySqlCommand cmd = new MySqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@punch_out_time", punchOutTime);
                            cmd.Parameters.AddWithValue("@punch_id", punchId);

                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Logged Out");
                            }
                            else
                            {
                                MessageBox.Show("Update failed. No matching record found.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred: {ex.Message}");
                    }
                }
            }
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            bool readerValid = ReaderIsValid();
            bool dateValid = DateIsValid();

            if (readerValid)
            {
                string conString = "server=localhost;uid=root;database=tutor_lab;";
                using (MySqlConnection con = new MySqlConnection(conString))
                {
                    con.Open();
                    // Querying for student_id, student_num, student_fname, and student_lname
                    string query = "SELECT student_num, student_fname, student_lname FROM student WHERE student_num =" + studentNumLabel.Text;
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@student_num", studentNumLabel.Text);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            MessageBox.Show("No student record in Database");
                        }
                        else
                        {
                            while (reader.Read())
                            {

                                string studentNum = reader.GetString(0); // student_num, if needed
                                string fName = reader.GetString(1);
                                string lName = reader.GetString(2);

                                // Compare student_num from the database with studentNumLabel.Text
                                if (studentNumLabel.Text == studentNum)
                                {
                                    DateTime epochStart = new DateTime(1970, 1, 1);
                                    DateTime currentTime = DateTime.UtcNow;

                                    TimeSpan timeDifference = currentTime - epochStart;
                                    long epochTime = (long)timeDifference.TotalSeconds;
                                    nameResultLabel.Text = fName + " " + lName;
                                    DayOfWeek today = DateTime.Now.DayOfWeek;
                                    punchFile.WriteLine(nameResultLabel.Text + ", " + studentNumLabel.Text + ", " + today + ", " + currentTime);

                                    // DB INSERT: Pass the correct student_id
                                    DBInsertTime(studentNum, fName + " " + lName, today, currentTime);

                                    MessageBox.Show("Logged In");
                                    PopulatePunchListBox();
                                
                                }
                                else
                                {
                                    MessageBox.Show("Wrong number input");
                                }

                                studentIdTextBox.Text = string.Empty;
                                nameResultLabel.Text = string.Empty;
                                studentNumLabel.Text = string.Empty;
                            }
                        }
                    }
                }
            }

            if (dateValid)
            {

                extraCreditLabel.Text = "Yes";
            }
            else
            {
                extraCreditLabel.Text = "No";
            }
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

        private void logOutButton_Click(object sender, EventArgs e)
        {
            if (punchListBox.SelectedItem is CustomPunch selectedItem)
            {
                int punchId = selectedItem.HiddenPunchId; // Get punch_id
                DateTime currentTime = DateTime.UtcNow;

                // Call the method to update the punch_out_time
                DBPunchOutTime(currentTime, punchId);
                punchListBox.Items.Remove(selectedItem);
            }
            else
            {
                MessageBox.Show("Please select a student from the list.");
            }
        }
    }
}
