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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string connectionString, commandString;
            connectionString = "Data Source=LAKITHA-PC\\SQLEXPRESS;Initial Catalog=Melody;Integrated Security=True";
            commandString = "INSERT INTO Payment VALUES ('" + cboRegNo.Text + "','" + txtCName.Text + "','" + cboPayment.Text + "','" + txtAmount.Text + "')";
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand comm = new SqlCommand(commandString, conn);
            conn.Open();
            comm.ExecuteNonQuery();
            MessageBox.Show("Record Added Succesfully");
            cboRegNo.Items.Add(cboRegNo.Text);
            Clear();
            cboRegNo.Focus();
            conn.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string connectionString, commandString;
            connectionString = "Data Source=LAKITHA-PC\\SQLEXPRESS;Initial Catalog=Melody;Integrated Security=True";
            commandString = "DELETE Payment FROM Payment where Payment.RegNo = '" + cboRegNo.Text + "'";

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
            cboRegNo.Items.Remove(cboRegNo.Text);
            cboRegNo.Focus();
            Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
             string connectionString, commandString;
             connectionString = "Data Source=LAKITHA-PC\\SQLEXPRESS;Initial Catalog=Melody;Integrated Security=True";
             commandString = "UPDATE Payment SET CName = '" + txtCName.Text + "', Payment = '" + cboPayment.Text + "', Amount = '" + txtAmount.Text + "' where RegNo = '" + cboRegNo.Text + "'";

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
            cboRegNo.Focus();
            conn.Close();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            string connectionString, commandString;
            connectionString = "Data Source=LAKITHA-PC\\SQLEXPRESS;Initial Catalog=Melody;Integrated Security=True";
            commandString = "SELECT RegNo FROM Payment";
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
                cboRegNo.Items.Add(reader[0]);
            }
            reader.Close();
            conn.Close();
        }

        private void cboRegNo_SelectedIndexChanged(object sender, EventArgs e)
        {
             string connectionString, commandString;
             connectionString = "Data Source=LAKITHA-PC\\SQLEXPRESS;Initial Catalog=Melody;Integrated Security=True";
            commandString = "SELECT * FROM Payment WHERE RegNo='" + cboRegNo.Text + "'";
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
                cboPayment.Text = reader[2].ToString();
                txtAmount.Text = reader[3].ToString();                
               
            }
            reader.Close();
            conn.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cboRegNo.Text = "";
            txtAmount.Clear();
            cboPayment.Text = "";
            txtCName.Clear();
        }
        public void Clear()
        {
            cboRegNo.Text = "";
            txtAmount.Clear();
            cboPayment.Text = "";
            txtCName.Clear();
        }
    }
}
