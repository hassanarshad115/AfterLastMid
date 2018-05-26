using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AfterLastMid
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showMessage();
        }

        private void showMessage()
        {
            switch (comboBox1.Text)
            {
                case "1":
                    MessageBox.Show("Test 1");
                    break;
                case "2":
                    MessageBox.Show("Test 2");
                    break;
                case "3":
                    MessageBox.Show("Test 3");
                    break;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            showMessage();
        }
    }
}
