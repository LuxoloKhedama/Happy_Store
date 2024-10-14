using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RESTART
{
    public partial class PRODUCT_MANAGEMENT : Form
    {
        public PRODUCT_MANAGEMENT()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CATEGORIES CAT = new CATEGORIES();
            CAT.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CATEGORIES CAT = new CATEGORIES();
            CAT.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CATEGORIES CAT = new CATEGORIES();
            CAT.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CATEGORIES CAT = new CATEGORIES();
            CAT.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 F = new Form1();
            F.Show();
            this.Hide();
        }

       

    }
}
       