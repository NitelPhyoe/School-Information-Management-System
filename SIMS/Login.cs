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

namespace SIMS
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        static string constr = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\GG\GG\School-Information-Management-System-master\SIMS.mdf;Integrated Security=True;Connect Timeout=30";
        //change directory
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(constr);
            cn.Open();

            string str = "SELECT roleId FROM users WHERE name = '" + txtUsr.Text + "' and pwd = '" + txtPwd.Text + "'";
            SqlCommand cmd = new SqlCommand(str, cn);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.Read() & dr.GetValue(0).Equals(1))
            {
                
                this.Visible = false;
                AdminView obj2 = new AdminView();
                obj2.ShowDialog();
              
            }
            if (dr.Read() & dr.GetValue(0).Equals(2))
            {

                this.Visible = false;
                TeacherView obj2 = new TeacherView();
                obj2.ShowDialog();

            } 
            if(dr.Read() & dr.GetValue(0).Equals(3))
            {

                this.Visible = false;
                UserView obj2 = new UserView();
                obj2.ShowDialog();

            }
            else
            {
                MessageBox.Show("Invalid username and Password.");
            }

            /*string query = "select * from roles";string msg="";
            SqlCommand ck = new SqlCommand(query, cn);
             SqlDataReader rdr = ck.ExecuteReader();
             while (rdr.Read())
                 msg += rdr[0].ToString()+",";
             MessageBox.Show(msg, "test", MessageBoxButtons.OK);*/
        }

        private void pnlRight_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
