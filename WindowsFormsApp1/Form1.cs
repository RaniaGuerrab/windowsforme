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

namespace WindowsFormsApp1
{
    public partial class Local : Form
    {
        public Local()
        {
            InitializeComponent();
        }
        static string ch = "server=DESKTOP-EBD0L04;database=TAFWIJASERVICE;integrated security=true";
        SqlConnection con = new SqlConnection(ch);
        DataSet ds = new DataSet();

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void vider()
        {
            guna2TextBox1.Text = "";
            guna2TextBox2.Text = "";
            guna2ComboBox1.Text = "";

        }
        public void enrg()
        {
            SqlDataAdapter dr = new SqlDataAdapter("select * from local", con);
            SqlCommandBuilder b = new SqlCommandBuilder(dr);
            dr.Update(ds, "local");
            MessageBox.Show("enregister bien");
        }

        private void Local_Load(object sender, EventArgs e)
        {
            string req = "select * from local";
            SqlDataAdapter dr = new SqlDataAdapter(req, con);
            dr.Fill(ds, "local");

            guna2DataGridView1.DataSource = ds.Tables["local"];

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
         
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            DataRow l;
            l = ds.Tables["local"].NewRow();
            l[0] = int.Parse(guna2TextBox1.Text);
            l[1] = guna2TextBox2.Text;
            l[2] = guna2ComboBox1.Text;
            ds.Tables[" local"].Rows.Add(l);
            MessageBox.Show("ajouter bien");
            enrg();
            vider();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ds.Tables["local"].Rows.Count; i++)
            {
                if (int.Parse(guna2TextBox1.Text) == int.Parse(ds.Tables["local"].Rows[i][0].ToString()))
                {
                    ds.Tables["local"].Rows[i][1] = guna2TextBox2.Text;
                    ds.Tables["local"].Rows[i][2] = guna2ComboBox1.Text;


                    MessageBox.Show("modifier bien");

                }
            }

            enrg();
            vider();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ds.Tables["local"].Rows.Count; i++)
            {
                if (int.Parse(guna2TextBox1.Text) == int.Parse(ds.Tables["local"].Rows[i][0].ToString()))
                {
                    ds.Tables["local"].Rows[i].Delete();

                    MessageBox.Show("supprimer bien");

                }
            }

            enrg();
            vider();
        }
    }
}
