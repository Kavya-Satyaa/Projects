using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdoDotNetApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string sc = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(sc))
            {


                //Not working
                //dataGridView1.DataSource = cmd.ExecuteReader();
                //dataGridView1.DataBind();


                //Working - ExecuteReader
                //SqlCommand cmd = new SqlCommand("Select * from Cities", con);
                //con.Open();
                //SqlDataReader reader = cmd.ExecuteReader();
                //DataTable dt = new DataTable();
                //dt.Load(reader);
                //dataGridView1.DataSource = dt;


                //Working- ExecuteScalar
                //SqlCommand cmd = new SqlCommand();
                //cmd.CommandText= "Select count(Gender) from Employees";
                //cmd.Connection = con;
                //con.Open();
                //int TotalRows = (int)cmd.ExecuteScalar();
                //MessageBox.Show("Total rows = " + TotalRows.ToString());


                //Working- ExecuteNonQuery

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                //SQL Injuection Possible
                //string command = "Select City from Employees where City like '"+textBox1.Text+"%'";
                //SqlCommand cmd = new SqlCommand(command, con);


                //Preventing SQL injection -  Method 1 using parameterised values
                //string command = "Select City from Employees where City like @CityName";
                //SqlCommand cmd = new SqlCommand(command, con);
                //cmd.Parameters.AddWithValue("@CityName", textBox1.Text + "%");

                //Preventing SQL Injection - Metgod 2 using stored procedures
                SqlCommand cmd = new SqlCommand("spCityNames", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CityName", textBox1.Text + "%");


                con.Open();
                SqlDataReader reader=cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                dataGridView1.DataSource= dt;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using(SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spAddEmployee", con);
                cmd.CommandType= CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name",txtName.Text);
                cmd.Parameters.AddWithValue("@Gender", ddlGender.SelectedItem);
                cmd.Parameters.AddWithValue("@Salary", txtSalary.Text);

                SqlParameter outputParameter = new SqlParameter();
                outputParameter.ParameterName = "@EmployeeID";
                outputParameter.SqlDbType = SqlDbType.Int;
                outputParameter.Direction= ParameterDirection.Output;

                cmd.Parameters.Add(outputParameter);

                con.Open();
                cmd.ExecuteNonQuery(); //Insert
                string EmpId = outputParameter.Value.ToString();
                lblEmpID.Text = EmpId;

            }
        }
    }
}
