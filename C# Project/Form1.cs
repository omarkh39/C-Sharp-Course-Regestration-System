using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "20180170" && textBox2.Text == "omar123")
            {

                //Omar Khwaileh 20180170
                //Bakir AL Khatib 20180583
               
                    Form2 f2 = new Form2();
                    f2.Show();
                    this.Hide();
             
            }
            else if(textBox1.Text == "20180583" && textBox2.Text == "bakir123")
            {
                Form3 f3 = new Form3();
                f3.Show();
                this.Hide();


            }
            else
                MessageBox.Show("Either User Name/Password ins't Correct", "Error");
        }
    }
}
