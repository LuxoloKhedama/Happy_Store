using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace RESTART
{
    public partial class CATEGORIES : Form
    {
        public CATEGORIES()
        {
            InitializeComponent();
        }
        OleDbCommand cmd;
        OleDbConnection conn;
        private void CATEGORIES_Load_1(object sender, EventArgs e)
        {
            conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\L2G4\Documents\Database10.accdb");
            cmd = new OleDbCommand();
            cmd.Connection = conn;

            LoadProducts();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
              try
            {
                conn.Open();
                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE PRODUCTS SET PRODUCT_NAME = '" + textBox2.Text + "',PRODUCT_DESCRIPTION = '" + textBox3.Text + "',PRODUCT_QUANTITY = " + textBox4.Text + ",PRODUCT_STOCK = " + textBox5.Text + "' WHERE PRODUCTS_NAME = '"+textBox2.Text+"'";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Updated successfully");
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
              try
            {
                conn.Open();
                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO PRODUCT_NAME = '" + textBox2.Text + "',PRODUCT_DESCRIPTION = '" + textBox3.Text + "'";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Added successfully");
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
              try
            {
                conn.Open();
                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE PRODUCT_NAME = '" + textBox2.Text + "'" ;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted successfully");
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }

       
        
            }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM PRODUCTS WHERE PRODUCT_NAME = '" + textBox2.Text + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM PRODUCTS WHERE PRODUCT_NAME = '" + textBox2.Text + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
        }


        private void button5_Click_1(object sender, EventArgs e)
        {
            
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM PRODUCTS;";
                    using (var cmd = new OleDbCommand(query, conn))
                    {
                        DataTable dt = new DataTable();
                        using (var da = new OleDbDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                        dataGridView1.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        

        private void button6_Click_1(object sender, EventArgs e)
        {
           
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM PRODUCTS;";
                    using (var cmd = new OleDbCommand(query, conn))
                    {
                        DataTable dt = new DataTable();
                        using (var da = new OleDbDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                        dataGridView1.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error" + ex.Message);
                }
            }
        

        private void button4_Click_1(object sender, EventArgs e)
        {
            string categoryId = "1"; // You should generate this dynamically
            string categoryName = textBox2.Text; // Get this from the TextBox

            if (IsNullOrWhiteSpace(categoryName))
            {
                MessageBox.Show("Please enter a product name to add.");
                return;
            }

          
                try
                {
                    conn.Open();
                    string query = "INSERT INTO PRODUCTS (PRODUCT_ID, PRODUCT_NAME) VALUES (@productsId, @productsName)";
                    using (var cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@productsId", categoryId);
                        cmd.Parameters.AddWithValue("@productsName", categoryName);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Product added successfully.");
                        textBox2.Clear(); // Clear the textbox if it's being used for product name
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            
        }

        private void LoadProducts()
        {
            
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM PRODUCTS;";
                    using (var cmd = new OleDbCommand(query, conn))
                    {
                        DataTable dt = new DataTable();
                        using (var da = new OleDbDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                        dataGridView1.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            
        }

        // Helper method to check for null or whitespace
        private static bool IsNullOrWhiteSpace(string value)
        {
            return string.IsNullOrEmpty(value) || value.Trim().Length == 0;
        }

        

        
    }
}
