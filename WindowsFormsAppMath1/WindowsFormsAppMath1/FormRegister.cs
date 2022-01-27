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
    public partial class FormRegister : Form
    {
        private SqlCommand cmd;
        private SqlDataReader dr;
        private SqlConnection con;

        public FormRegister()
        {
            InitializeComponent();
        }

        // Με αυτό το κουμπί πηγαίνουμε στην πίσω σελίδα.
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormLogin formLogin = new FormLogin();
            formLogin.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Έλεγχος για το αν ο χρήστης έχει συμπληρώσει όλα τα απαραίτητα πεδία.
            if (!(FirstNameText.Text == "") && !(LastNameText.Text == "") && !(UsernameText.Text == "") && !(PasswordText.Text == ""))
            {
                // Έλεγχος για το αν ο χρήστης έχει επαληθεύσει σωστά τον κωδικό του.
                if (ConPassText.Text == PasswordText.Text)
                {
                    // Έλεγχος για το αν ο χρήστης έιναι ήδη εγγεγραμμένος με βάση το όνομα χρήστη του.
                    cmd = new SqlCommand("select * from TableStudents where Username='" + UsernameText.Text + "'", con);
                    dr = cmd.ExecuteReader();
                    // Διαβάζουμε όλη την βάσξ για αν υπάρχει το username που έβαλε ο χρήστης.
                    if (dr.Read())
                    {
                        dr.Close();
                        MessageBox.Show("Username already exist, please try another. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        dr.Close();
                        // Αν δεν έχει εγγραφεί ξανά τότε γίνεται νέα εγγραφή στην βάση με το ακόλουθο sql querry. Οι τιμές των πεδίων των test εννοείτε κατα την εγγραφή είναι κενές.
                        cmd = new SqlCommand("insert into TableStudents values(@FirstName,@LastName,@Username,@Password,@Test_10,@Test_9,@Test_8,@Test_7,@Test_6,@Test_5,@Test_4,@Test_3,@Test_2,@Test_Review)", con);
                        cmd.Parameters.AddWithValue("FirstName", FirstNameText.Text);
                        cmd.Parameters.AddWithValue("LastName", LastNameText.Text);
                        cmd.Parameters.AddWithValue("Username", UsernameText.Text);
                        cmd.Parameters.AddWithValue("Password", PasswordText.Text);
                        cmd.Parameters.AddWithValue("Test_10", DBNull.Value);
                        cmd.Parameters.AddWithValue("Test_9", DBNull.Value);
                        cmd.Parameters.AddWithValue("Test_8", DBNull.Value);
                        cmd.Parameters.AddWithValue("Test_7", DBNull.Value);
                        cmd.Parameters.AddWithValue("Test_6", DBNull.Value);
                        cmd.Parameters.AddWithValue("Test_5", DBNull.Value);
                        cmd.Parameters.AddWithValue("Test_4", DBNull.Value);
                        cmd.Parameters.AddWithValue("Test_3", DBNull.Value);
                        cmd.Parameters.AddWithValue("Test_2", DBNull.Value);
                        cmd.Parameters.AddWithValue("Test_Review", DBNull.Value);

                        cmd.ExecuteNonQuery();
                        // Μύνημα επιτυχούς εγγραφής.
                        MessageBox.Show("Your Account is created . Please login now.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Ανακατεύθυνση στην φόρμα σύνδεσης.
                        this.Hide();
                        FormLogin formLogin = new FormLogin();
                        formLogin.ShowDialog();

                    }
                }
                else
                {
                    MessageBox.Show("Please enter the same password in the required filed. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Please fill all the above fields.");

        }

        private void FormRegister_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Server=LAPTOP-5EVJL794;Database=StudentsDB;Trusted_Connection=True;"); // Πραγματοποιείται η σύνδεση με την βάση όταν φορτώνει η φόρμα. 
            con.Open();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HelpForm helpForm = new HelpForm();
            helpForm.ShowDialog();
        }
    }
}
