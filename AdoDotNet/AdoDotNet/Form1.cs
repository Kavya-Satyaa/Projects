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

namespace AdoDotNet
{
    public partial class Form1 : Form
    {
        //Connection String
        string ConStr = @"Data Source=LAPTOP-7SUS3SNF; Initial Catalog=AdoDotNet; Integrated Security=True;"
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void PopulateCities()
        {

        }


        private void btnSelectEmployee_Click(object sender, EventArgs e)
        {
            //Connection String
            //string ConStr = @"Data Source=LAPTOP-7SUS3SNF; Initial Catalog=AdoDotNet; Integrated Security=True;";

            //SQL Connection;
            SqlConnection con=new SqlConnection(ConStr);

            try
            {
                con.Open();

                //SQL Query
                string SqlQuery = "Select * from Employees";
                SqlCommand cmd = new SqlCommand(SqlQuery, con);

                //SQL Reader
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    txtFirstName.Text = reader.GetString(1);
                    txtLastName.Text = reader.GetString(2);
                    txtGender.Text = reader.GetString(3);
                    //txtCity.Text = reader.GetString(4);
                    //txtIsActive.Text = reader.GetString(5);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

    }
}
