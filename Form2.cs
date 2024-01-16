using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Melody_Music_System
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtuser.Text == "Admin" && txtpass.Text == "Admin123")
            {
                MessageBox.Show("Valid UserName & Password");
                Form3 form = new Form3();
                form.Show();
                this.Hide();
            }
            else if (txtuser.Text == "User" && txtpass.Text == "User123")
            {
                MessageBox.Show("Valid UserName & Password");
                Form3 form = new Form3();
                form.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Username & Passward");
                txtuser.Clear();
                txtpass.Clear();
                txtuser.Focus();

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dl;
            dl = MessageBox.Show("Do you want to Exit?", "Exit",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2,
                MessageBoxOptions.DefaultDesktopOnly);
            if (dl.ToString() == "Yes")
            {
                Application.Exit();
            }
        }
    }
}
