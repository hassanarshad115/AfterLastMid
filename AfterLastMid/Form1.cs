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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void addRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DatabaseSydataLynyklye(0, false);
        }

        private void DatabaseSydataLynyklye(int inttypeveriable, bool booltypeveriable)
        {
            InsertForm2 obj = new InsertForm2();
            obj.pId = inttypeveriable;
            obj.pIsUpdate = booltypeveriable;
            obj.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }

        private DataTable GetData()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(ConfigurationClass.ConfigurationMethod());
            SqlDataAdapter adapter = new SqlDataAdapter("select * from  emptbl", conn);
            adapter.Fill(dt);
            return dt;
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            int rowIndex = dataGridView1.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            int row =Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells[0].Value);
            DatabaseSydataLynyklye(row, true);
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                //notifyIcon1.Icon = SystemIcons.Application;
                notifyIcon1.Text = "Your Form has been minimized bossss";
                notifyIcon1.BalloonTipText = "Your Form has been minimized bossss";
                notifyIcon1.ShowBalloonTip(10);
            }
            else if (WindowState == FormWindowState.Normal)
            {
                notifyIcon1.Text = "Your form has back to form bhia wapis thq hogya";
                notifyIcon1.BalloonTipText = "Your form has back to form bhia wapis thq hogya";
                notifyIcon1.ShowBalloonTip(1000);
            }
        }

        private void addrecordToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = GetData();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
        }
    }
}
