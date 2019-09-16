using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SchoolManagementSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\GG\School Management System C#\SchoolManagementSystem\SchoolManagementSystem\school.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            string str = "SELECT emp_id FROM employee WHERE username = '" + textBox1.Text + "' and password = '" + textBox2.Text + "'";
            SqlCommand cmd = new SqlCommand(str, con);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                this.Visible = false;
                Home obj2 = new Home();
                obj2.ShowDialog();
            }
            else
            {
                MessageBox.Show("Invalid username and Password.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisterEmployee obj2 = new RegisterEmployee();
            obj2.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        
    }
}
