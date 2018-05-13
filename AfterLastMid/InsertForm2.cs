using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AfterLastMid
{
    public partial class InsertForm2 : Form
    {
        public InsertForm2()
        {
            InitializeComponent();
        }

        public int pId { get; set; }
        public bool pIsUpdate { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isEmpty())
            {
                if (pIsUpdate)
                {
                    UpdateRecord();
                    Form1 obj = new Form1();
                    obj.Show();
                }
                else
                {
                    SaveRecord();
                    Form1 obj = new Form1();
                    obj.Show();
                }
            }


        }

        private bool isEmpty()
        {
            if (nametextBox1.Text.Trim() == string.Empty)
            {
                MessageBox.Show(" Name is Required", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nametextBox1.Focus();
                return false;
            }
            if (passwordtextBox2.Text.Trim() == string.Empty)
            {
                MessageBox.Show(" Password is Required", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                passwordtextBox2.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// agr ak bar b name ismy enter hoa hoa ha r agr again whe name add kia tw ye error dyga k
        /// apny ye name phly he mojod ha database ma
        /// so isko change kry name ko phly fr kam hoga
        /// r ye just phly form ma he add krna ha agr bad ma mm kse  add ni krna isko
        /// </summary>
        SqlConnection conn = new SqlConnection(ConfigurationClass.ConfigurationMethod());
        DataSet ds = new DataSet();
        private void SaveRecord()
        {
            string c1 = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            SqlConnection conn1 = new SqlConnection(c1);
            SqlCommand cm = new SqlCommand("select * from [emptbl] where [Name]='" + nametextBox1.Text.Trim() + "'", conn1);

            SqlDataAdapter adapter = new SqlDataAdapter(cm);
            adapter.Fill(ds);
            int i = ds.Tables[0].Rows.Count;
            if (i > 0)
            {
                MessageBox.Show("Employee Name " + nametextBox1.Text + " is already exists");

            }
            else
            {
                //SqlCommand cmd = new SqlCommand(@"insert into emptbl(Name,Password) values('" + textBox2.Text.Trim() + "','" + textBox1.Text.Trim() + "') ", conn);
                SqlCommand cmd = new SqlCommand("i", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", nametextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@p", passwordtextBox2.Text.Trim());

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Insert Successfully"+nametextBox1.Text.ToUpper());
            }
        }

        private void UpdateRecord()
        {
            //SqlCommand cmd = new SqlCommand(@"update emptbl set Name = '" + textBox2.Text.Trim() + "' where password ='" + textBox1.Text.Trim() + "' ", conn);
            SqlCommand cmd = new SqlCommand("up", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", nametextBox1.Text.Trim());
            cmd.Parameters.AddWithValue("@p", passwordtextBox2.Text.Trim());

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Update Succeessfully");
        }


        private void InsertForm2_Load(object sender, EventArgs e)
        {
            if (pIsUpdate)
            {
                DataTable dt = GetDataById(pId);
                DataRow dr = dt.Rows[0];

                nametextBox1.Text = dr["Name"].ToString();
                passwordtextBox2.Text = dr["Password"].ToString();
            }
        }

        private DataTable GetDataById(object pidv)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("byId", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id", pidv);
            //conn.Open();
            //SqlDataReader reader = cmd.ExecuteReader();
            //dt.Load(reader);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            return dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            SqlCommand cmd = new SqlCommand("delete from emptbl where Name = '" + nametextBox1.Text.Trim() + "'", conn);
           
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Delete Record Succeessfully");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void nametextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void passwordtextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
