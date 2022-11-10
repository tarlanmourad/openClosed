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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace openClosed
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection("Data Source=TARLAN\\LOCALHOST;Initial Catalog=Northwind;Integrated Security=True");

        private void btnSql_Click(object sender, EventArgs e)
        {
            //conn.Open();
            Check();

            if (conn.State != ConnectionState.Open)
            {
                btnSql.Text = "Connect";
            }
            else if (conn.State == ConnectionState.Open)
            {
                btnSql.Text = "Disconnect";
            }
            else
            {
                lblResult.Text = "Problem in connection";
            }
        }


        private void Check()
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
                lblResult.Text = "Connected to Db";
            }
            else if (conn.State == ConnectionState.Open)
            {
                conn.Close();
                lblResult.Text = "Disconnected";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnSql.Text = "Disconnect";
            Check();
        }
    }
}
