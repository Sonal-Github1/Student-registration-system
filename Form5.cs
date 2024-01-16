using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Melody_Music_System
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string connectionString, commandString;
            connectionString = "Data Source=LAKITHA-PC\\SQLEXPRESS;Initial Catalog=Melody;Integrated Security=True";
            commandString = "INSERT INTO Course VALUES ('" + cboCOID.Text + "','" + txtCName.Text + "','" + cboDivision.Text + "','" + txtDuration.Text + "','" + txtFee.Text + "')";
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand comm = new SqlCommand(commandString, conn);
            conn.Open();
            comm.ExecuteNonQuery();
            MessageBox.Show("Record Added Succesfully");
            cboCOID.Items.Add(cboCOID.Text);
            Clear();
            cboCOID.Focus();
            conn.Close();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            string connectionString, commandString;
            connectionString = "Data Source=LAKITHA-PC\\SQLEXPRESS;Initial Catalog=Melody;Integrated Security=True";
            commandString = "SELECT COID FROM Course";
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand comm = new SqlCommand(commandString, conn);

            SqlDataReader reader = null;
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            reader = comm.ExecuteReader();
            while (reader.Read())
            {
                cboCOID.Items.Add(reader[0]);
            }
            reader.Close();
            conn.Close();
        }

        private void cboCOID_SelectedIndexChanged(object sender, EventArgs e)
        {
            string connectionString, commandString;
            connectionString = "Data Source=LAKITHA-PC\\SQLEXPRESS;Initial Catalog=Melody;Integrated Security=True";
            commandString = "SELECT * FROM Course WHERE COID='" + cboCOID.Text + "'";
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand comm = new SqlCommand(commandString, conn);
            SqlDataReader reader = null;

            try
            { conn.Open(); }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
            reader = comm.ExecuteReader();

            while (reader.Read())
            {
                txtCName.Text = reader[1].ToString();
                cboDivision.Text = reader[2].ToString();
                txtDuration.Text = reader[3].ToString();
                txtFee.Text = reader[4].ToString();
               
            }
            reader.Close();
            conn.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string connectionString, commandString;
            connectionString = "Data Source=LAKITHA-PC\\SQLEXPRESS;Initial Catalog=Melody;Integrated Security=True";
            commandString = "UPDATE Course SET CName = '" + txtCName.Text + "', Division = '" + cboDivision.Text + "', CDuration = '" + txtDuration.Text + "', CFee = '" + txtFee.Text + "' where COID = '" + cboCOID.Text + "'";

            if (MessageBox.Show("Are you sure, you want to Update this record?", "Sure?", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand comm = new SqlCommand(commandString, conn);
            conn.Open();
            comm.ExecuteNonQuery();
            MessageBox.Show("Record Updated Succesfully");
            Clear();
            cboCOID.Focus();
            conn.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string connectionString, commandString;
            connectionString = "Data Source=LAKITHA-PC\\SQLEXPRESS;Initial Catalog=Melody;Integrated Security=True";
            commandString = "DELETE Course FROM Course where Course.COID = '" + cboCOID.Text + "'";

            if (MessageBox.Show("Are you sure, you want to delete this record?", "Sure?", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand comm = new SqlCommand(commandString, conn);
            conn.Open();
            comm.ExecuteNonQuery();
            MessageBox.Show("Record Deleted Successfully");
            conn.Close();
            cboCOID.Items.Remove(cboCOID.Text);
            cboCOID.Focus();
            Clear();
        }
        public void Clear()
        {
            cboCOID.Text="";
            txtCName.Clear();
            txtDuration.Clear();
            txtFee.Clear();
            cboDivision.Text="";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cboCOID.Text="";
            txtCName.Clear();
            txtDuration.Clear();
            txtFee.Clear();
            cboDivision.Text="";
        }
    }
}
