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
    public partial class FormLogin : Form
    {      

        public FormLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Server=LAPTOP-5EVJL794;Database=StudentsDB;Trusted_Connection=True;"); // Κάνουμε την σύνδεση με την βάση. 
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM TableStudents WHERE Username='" + usernameText.Text + "' AND Password='" + passwordText.Text + "'", con);
            /* Στην παραπάνω γραμμή το πρόγραμμα επιλέγει ολόκληρα τα δεδομένα από τον πίνακα και τα αντιστοιχεί με το όνομα χρήστη και τον κωδικό πρόσβασης που παρέχονται από τον χρήστη. */
            DataTable dt = new DataTable(); // Εδω δημιουργούμε έναν εικονικό πίνακα.  
            sda.Fill(dt); // Γεμίζουμε τον πίνακα με τα δεδομένα.
            if (dt.Rows[0][0].ToString() == "1")
            {
                /* Έφτιαξα μια νέα σελίδα που ονομάζεται MainForm. Εάν ο χρήστης πιστοποιηθεί επιτυχώς, τότε η φόρμα θα μετακινηθεί στην επόμενη φόρμα */
                string username = usernameText.Text;
                MainForm mainForm = new MainForm();
                mainForm.Username = username;
                mainForm.Show();
                this.Hide();
            }
            else
                // Μήνυμα ανεπιτυχούς σύνδεσης.
                MessageBox.Show("Invalid username or password");

        }

        // Κουμπί που μας πηγαίνει στην φόρμα εγγραφής αν ο χρήστης δεν έχει κάποιον λογαριασμό.
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormRegister formRegister = new FormRegister();
            formRegister.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HelpForm helpForm = new HelpForm();
            helpForm.ShowDialog();
        }
    }
}
