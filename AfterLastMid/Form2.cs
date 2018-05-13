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

namespace AfterLastMid
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void insertFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            InsertForm2 i = new InsertForm2();
            i.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = GetData();
        }

        private DataTable GetData()
        {
            DataTable dt = new DataTable();
            string query = "select * from emptbl";
            SqlConnection conn = new SqlConnection(ConfigurationClass.ConfigurationMethod());

            SqlDataAdapter adp = new SqlDataAdapter(query, conn);
            adp.Fill(dt);

            return dt;
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            int rowindex = dataGridView1.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            string row = Convert.ToString(dataGridView1.Rows[rowindex].Cells["Name"].Value);
            string row1 = Convert.ToString(dataGridView1.Rows[rowindex].Cells["Password"].Value);


            textBox1.Text = row.ToString();
            textBox2.Text = row1.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //    SqlConnection conn = new SqlConnection(ConfigurationClass.ConfigurationMethod());
            //    string query = "insert into emptbl values( '" + textBox1.Text + "','" + textBox2.Text + "' )";
            //    SqlCommand cmd = new SqlCommand(query, conn);

            //    conn.Open();
            //    cmd.ExecuteNonQuery();
            //    conn.Close();
            empModel.empModelClass obj = new empModel.empModelClass()
            {
                nameP = textBox1.Text,
                fnameP = textBox2.Text
            };
            empBusiness.empBusinessClass.businessMethod(obj);
            MessageBox.Show("successfully enter data");
        }


        int a = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            a++;
            if (a == 4)
            {
                dataGridView1.Columns.Clear();
            }
            else
            {
                MessageBox.Show(a.ToString());

            }

        }
    }
}
