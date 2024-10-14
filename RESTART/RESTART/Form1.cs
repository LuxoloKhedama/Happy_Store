using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace RESTART
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void TBClear()
        {
            textBox2.Clear();
            textBox3.Clear();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                string username = textBox2.Text;
                string password = textBox3.Text;

                using (OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\L2G4\Documents\Database10.accdb"))
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand("SELECT Username, Password FROM USERS WHERE Username = @username AND Password = @password ", conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        using (OleDbDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                MessageBox.Show("CORRECT LOGIN DETAILS");
                                this.Hide();
                                PRODUCT_MANAGEMENT PM = new PRODUCT_MANAGEMENT();
                                PM.Show();
                            }
                            else
                            {
                                MessageBox.Show("YOU ARE NOT A USER");
                            }
                        }
                    }
                }
                TBClear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Connection initialization moved to button2_Click_1 method.
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.UseSystemPasswordChar = !checkBox1.Checked; // Changed to textBox3 for password
        }


    }

}
