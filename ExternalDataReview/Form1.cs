using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// New code

namespace ExternalDataReview
{
    public partial class Form1 : Form
    {
        string connectionString = @"server=(localdb)\MSSQLLocalDB;database=Dominican;Trusted_connection=true";
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Student student = new Student();
            student.Id = int.Parse(tbID.Text);
            student.FirstName = tbFirstName.Text;
            student.LastName = tbLastName.Text;
            student.Major = tbMajor.Text;
            MessageBox.Show("All student data received.");
            AddStudentToDb(student);
        }

        public void AddStudentToDb(Student student)
        {
            //Open up the SQL Connection
            //Insert into my Student Table
            //*INSERTION QUERY*
            //INSERT INTO dbo.Student(Id, FirstName, LastName, Major)
            //VALUES(@Id, @FirstName, @LastName, @Major) <-- With the @ sign are called "parameters" and they can be thought of as variables
            //below, populate these parameters

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                string newQuery = "INSERT INTO dbo.Student(Id, FirstName, LastName, Major)" + "VALUES(@Id, @FirstName, @LastName, @Major)";

                using (SqlCommand sql = new SqlCommand(newQuery, sqlConnection))
                {
                    sql.Parameters.AddWithValue("@Id", student.Id);
                    sql.Parameters.AddWithValue("@FirstName", student.FirstName);
                    sql.Parameters.AddWithValue("@LastName", student.LastName);
                    sql.Parameters.AddWithValue("@Major", student.Major);
                    sql.ExecuteNonQuery();
                }

                MessageBox.Show("Done.");
            }

        }

        private void btnViewStudents_Click(object sender, EventArgs e)
        {
            //Open up a SQL Connection
            //Populate my DataTable with the data I get from my Select Query
            //Populate my DataGridView with my DataTable

            using (SqlConnection newSqlConnection = new SqlConnection(connectionString))
            {
                newSqlConnection.Open();
                string query = "SELECT * FROM dbo.Student";

                using (SqlCommand newSql = new SqlCommand(query, newSqlConnection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, newSqlConnection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvStudents.DataSource = dt;
                }
                MessageBox.Show("Student data fetched successfully.");
            }
        }
    }
}
