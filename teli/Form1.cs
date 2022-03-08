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

namespace teli
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool selected = false;
        public SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-N12RONL;Initial Catalog=telephone;Integrated Security=True");
        private void Form1_Load(object sender, EventArgs e)
        {
            displayData();
            // TODO: This line of code loads data into the 'studentDataSet.Table_1' table. You can move, or remove it, as needed.
            //this.telephoneTableAdapter.Fill(this.studentDataSet.Table_1);
        }
        //selected = false;
        private void displayData()
        {
            sqlConnection.Open();
            string q = "Select  * from telephone";
            SqlDataAdapter sda = new SqlDataAdapter(q, sqlConnection);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            sqlConnection.Close();
        }


        private void phnno_Click(object sender, EventArgs e)
        {

        }

        private void address_Click(object sender, EventArgs e)
        {

        }

        private void email_Click(object sender, EventArgs e)
        {

        }

        private void fullname_Click(object sender, EventArgs e)
        {

        }

        private void search_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void save_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            string FullName = name.Text;

            string Email = textBox3.Text;

            string PhoneNumber = textBox1.Text;
            string address = textBox4.Text;

            string gender = " ";
            if (radioButton1.Checked == true)
            {
                gender = radioButton1.Text;
            }
            if (radioButton2.Checked == true)
            {
                gender = radioButton2.Text;
            }



            string q = "INSERT INTO Telephone(PhoneNumber,FullName,Email,Address,gender) values ('" + PhoneNumber + "','" + FullName + "','" + Email + "','" + address + "','" + gender + "')";


            SqlCommand command = new SqlCommand(q, sqlConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("saved");
            sqlConnection.Close();
            displayData();


        }

        private void cancel_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure to delete?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dr == DialogResult.Yes)
            {
                int PhoneNumber= Convert.ToInt32(dataGridView1.CurrentRow.Cells["PhoneNumber"].Value);
                sqlConnection.Open();
                string q = "DELETE from Telephone where PhoneNumber='" + PhoneNumber + "'";
                SqlCommand command = new SqlCommand(q, sqlConnection);
                command.ExecuteNonQuery();
                sqlConnection.Close();
                displayData();
                MessageBox.Show("deleted");
            }

        }

        private void buttonsearch_Click(object sender, EventArgs e)
        {
            string PhoneNumer = textBox5.Text;
            Form4 form4 = new Form4(PhoneNumer);
            this.Hide();
            form4.Show();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();

            string FullName = name.Text;

            string Email = textBox3.Text;

            string PhoneNumber = textBox1.Text;
            string Address = textBox4.Text;
            string gender = " ";
            if (radioButton1.Checked == true)
            {
                gender = radioButton1.Text;
            }
            if (radioButton2.Checked == true)
            {
                gender = radioButton2.Text;
            }



            string q = "Update Telephone set  FullName='" + FullName + "',Address='" + Address + "',gender='" + gender + "',Email='" + Email + "'where PhoneNumber='" + PhoneNumber + "'";

            SqlCommand command = new SqlCommand(q, sqlConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("RECORD UPDATED SUCCESSFULLY!!!");
            sqlConnection.Close();
            displayData();

        }

        private void edit_Click(object sender, EventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            name.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
           
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}