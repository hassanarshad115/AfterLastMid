using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using DarrenLee.Translator;

namespace AfterLastMid
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ComboBox c = new ComboBox();
            c.Size = new Size(500, 5);
            this.Controls.Add(c);
            c.Show();

            Button b = new Button();
            b.Height = 100;
            b.Text = "\nBtn bnaya h";
            this.Controls.Add(b);

            DataGrid dv = new DataGrid();
            dv.Height = 70;
            dv.Width = 70;

            this.Controls.Add(dv);

        }
        //string text = null;
        //Translator.LanguageServiceClient client = new Translator.LanguageServiceClient();

        //client = new Translator.LanguageServiceClient();
        //text = client.Translate("hassan", textBox1.Text, "en", "ur");
        //textBox2.Text = text;
        //textBox2.Text = h;

        //....................................
        //       < connectionStrings >
        //< add name = "db"  providerName = "System.Data.SqlClient"  connectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HASSAN MALIK\Documents\AfterLastMidDB.mdf;Integrated Security=True;Connect Timeout=30" />

        //   </ connectionStrings >






























        private void button2_Click(object sender, EventArgs e)
        {
            string h = DarrenLee.Translator.Translator.Translate(textBox1.Text, "en", "ur");

            MessageBox.Show(h);

        }
    }
}
