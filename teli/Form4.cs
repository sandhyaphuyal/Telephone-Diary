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

namespace teli
{
    public partial class Form4 : Form
    {
        public SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-N12RONL;Initial Catalog=telephone;Integrated Security=True");
        string PhoneNumber;
        public Form4(string number)
        {
            PhoneNumber = number;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.Show();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            sqlConnection.Open();
            string q;
            if (PhoneNumber == "")
            {
                q = "Select * from telephone";
            }
            else
            {
                q = "Select * from dbo.telephone where PhoneNumber='" + PhoneNumber+"'";
            }
            SqlDataAdapter sda = new SqlDataAdapter(q, sqlConnection);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                textBox1.Text = dt.Rows[0]["PhoneNumber"].ToString();
                textBox4.Text = dt.Rows[0]["Email"].ToString();
                textBox3.Text = dt.Rows[0]["FullName"].ToString();
                textBox2.Text = dt.Rows[0]["Address"].ToString();
                textBox5.Text = dt.Rows[0]["Gender"].ToString();



            }
        }
    }
}
