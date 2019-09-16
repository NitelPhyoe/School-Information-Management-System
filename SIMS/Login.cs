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

        static string constr = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\C#\Final W-Proj\SIMS\SIMS.mdf;Integrated Security=True;Connect Timeout=30";
        
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(constr);
            cn.Open();
            string query = "select * from roles";string msg="";
            SqlCommand ck = new SqlCommand(query, cn);
             SqlDataReader rdr = ck.ExecuteReader();
             while (rdr.Read())
                 msg += rdr[0].ToString()+",";
             MessageBox.Show(msg, "test", MessageBoxButtons.OK);
        }
    }
}
