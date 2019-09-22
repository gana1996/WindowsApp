using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SampleWindowsApp
{
    public partial class Form1 : Form
    {
        string con = "Data Source=(local);Initial Catalog=WindowsDB;Integrated Security=True";
        public Form1()
        {
            InitializeComponent();
            countries();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TextBox name = new TextBox();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            RichTextBox address = new RichTextBox();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "insert into Sample(Name,Country,Address) values(@Name,@Country,@Address)";
            
            try
            {
                SqlConnection sc = new SqlConnection(con);
                sc.Open();
                try
                {
                    SqlCommand sco = new SqlCommand(query, sc);
                    sco.Parameters.AddWithValue("@Name", txtName.Text);
                    sco.Parameters.AddWithValue("@Country", ctrCombo.Text);
                    sco.Parameters.AddWithValue("@Address", txtAddress.Text);
                    int test = sco.ExecuteNonQuery();
                    if (test > 0)
                    {
                        MessageBox.Show("Data inserted successfully");
                    }
                    else
                        MessageBox.Show("Data not inserted");
                }
                catch (Exception ex)
                {
                    string error = ex.ToString();
                    MessageBox.Show(error);
                }
            }
            catch(Exception ex)
            {
                string error = ex.ToString();
                MessageBox.Show(error);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
        private void countries()
        {
            string query = "select distinct Country from Sample";
            try
            {
                SqlConnection sc = new SqlConnection(con);
                sc.Open();
                SqlCommand sco = new SqlCommand(query, sc);
                SqlDataReader data =sco.ExecuteReader();
                String country = ctrCombo.Text;
                while (data.Read())
                {
                        ctrCombo.Items.Add(data.GetString(0));   
                }
            }
            catch(Exception ex)
            {
                string error = ex.ToString();
                MessageBox.Show(error);
            }
        }
    }
}
