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

namespace WindowsFormsAppMath1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        // Με αυτό το κουμπί ο χρήστης αποσυνδέεται και επιστρέφει στην φόρμα σύνδεσης.
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormLogin formLogin = new FormLogin();
            formLogin.Show();
            this.Hide();
        }

        // Με αυτό το κουμπί ο χρήστης πηγαίνει στην φόρμα TestForm.
        private void button1_Click(object sender, EventArgs e)
        {
            string username = label2.Text;
            TestsForm testsForm = new TestsForm();
            // Παιρνάει το value του username στην επόμενη φόρμα.
            testsForm.Username = username;
            testsForm.Show();
            this.Hide();
        }

        public string Username { get; set; }

        private void MainForm_Load(object sender, EventArgs e)
        {
            label2.Text = Username;
        }
    }
}
