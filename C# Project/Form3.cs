using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;


namespace Project
{
    public partial class Form3 : Form
    {
        SQLiteConnection m_dbConnection;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

            string sql;
            m_dbConnection = new SQLiteConnection(@"Data Source=Database101.sqlite; Version=3;");
            m_dbConnection.Open();

            //create table subject and insert needed data 
            try
            {

                sql = "create table IF NOT EXISTS Subject (Sub_Id number (5) Constraint PK_M Primary Key , Sub_Name varchar2(10) NOT NULL , Credit number (1) , Registered number (10))";
                SQLiteCommand command2 = new SQLiteCommand(sql, m_dbConnection);
                command2.ExecuteNonQuery();

                sql = "insert into Subject (Sub_Name , Sub_id , Credit ,Registered) values ('English Language',11102,3 , 7)";
                SQLiteCommand command3 = new SQLiteCommand(sql, m_dbConnection);
                int insertrecord = command3.ExecuteNonQuery();

                sql = "insert into Subject (Sub_Name , Sub_id , Credit ,Registered) values ('Structured Programming',11103,3 ,9)";
                SQLiteCommand command4 = new SQLiteCommand(sql, m_dbConnection);
                command4.ExecuteNonQuery();

                sql = "insert into Subject (Sub_Name , Sub_id , Credit ,Registered) values ('Object Oriented Programming',11206,3 ,10)";
                SQLiteCommand command5 = new SQLiteCommand(sql, m_dbConnection);
                command5.ExecuteNonQuery();

                sql = "insert into Subject (Sub_Name , Sub_id , Credit ,Registered) values ('Object Oriented Programming Lab',11253,1 ,14)";
                SQLiteCommand command6 = new SQLiteCommand(sql, m_dbConnection);
                command6.ExecuteNonQuery();

                sql = "insert into Subject (Sub_Name , Sub_id , Credit ,Registered) values ('Database Systems',11323,3 ,16)";
                SQLiteCommand command7 = new SQLiteCommand(sql, m_dbConnection);
                command7.ExecuteNonQuery();

                sql = "insert into Subject (Sub_Name , Sub_id , Credit ,Registered) values ('Operating Systems',11335,3 ,18)";
                SQLiteCommand command8 = new SQLiteCommand(sql, m_dbConnection);
                command8.ExecuteNonQuery();

                sql = "insert into Subject (Sub_Name , Sub_id , Credit ,Registered) values ('Database Systems Lab',11354,1 ,19)";
                SQLiteCommand command9 = new SQLiteCommand(sql, m_dbConnection);
                command9.ExecuteNonQuery();

                sql = "insert into Subject (Sub_Name , Sub_id , Credit ,Registered) values ('Operating Systems Lab',11355,1 ,18)";
                SQLiteCommand command10 = new SQLiteCommand(sql, m_dbConnection);
                command10.ExecuteNonQuery();

                sql = "insert into Subject (Sub_Name , Sub_id , Credit ,Registered) values ('Webpage Design and Internet programming LAB',12242,1,19)";
                SQLiteCommand command11 = new SQLiteCommand(sql, m_dbConnection);
                command11.ExecuteNonQuery();

                sql = "insert into Subject (Sub_Name , Sub_id , Credit ,Registered) values ('Webpage Design and Internet programming',12243,3, 18)";
                SQLiteCommand command13 = new SQLiteCommand(sql, m_dbConnection);
                command13.ExecuteNonQuery();

                sql = "insert into Subject (Sub_Name , Sub_id , Credit ,Registered) values ('Visual Programming',12343,3, 28)";
                SQLiteCommand command14 = new SQLiteCommand(sql, m_dbConnection);
                command14.ExecuteNonQuery();

                sql = "insert into Subject (Sub_Name , Sub_id , Credit ,Registered) values ('introduction to Software Engineering',13211,3, 18)";
                SQLiteCommand command15 = new SQLiteCommand(sql, m_dbConnection);
                command15.ExecuteNonQuery();

                sql = "insert into Subject (Sub_Name , Sub_id , Credit ,Registered) values ('Graduation Project 1',13491,1, 15)";
                SQLiteCommand command16 = new SQLiteCommand(sql, m_dbConnection);
                command16.ExecuteNonQuery();

                sql = "insert into Subject (Sub_Name , Sub_id , Credit ,Registered) values ('Graduation Project 2',13493,2, 11)";
                SQLiteCommand command17 = new SQLiteCommand(sql, m_dbConnection);
                command17.ExecuteNonQuery();

                sql = "insert into Subject (Sub_Name , Sub_id , Credit ,Registered) values ('Calculus (1)',20132,3, 13)";
                SQLiteCommand command18 = new SQLiteCommand(sql, m_dbConnection);
                command18.ExecuteNonQuery();
            }
            catch { }

            sql = "create table IF NOT EXISTS Registration (Sub_Id number (5) Constraint PK_M Primary Key , Sub_Name varchar2(10) NOT NULL , Credit number (1) )";
            SQLiteCommand command20 = new SQLiteCommand(sql, m_dbConnection);
            command20.ExecuteNonQuery();


            sql = " SELECT * from subject order by Sub_Name desc";
            SQLiteDataAdapter da = new SQLiteDataAdapter(sql, m_dbConnection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            sql = " SELECT * from Registration order by Sub_Name desc";
            SQLiteDataAdapter daa = new SQLiteDataAdapter(sql, m_dbConnection);
            DataSet dsa = new DataSet();
            daa.Fill(dsa);
            dataGridView2.DataSource = dsa.Tables[0];

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sql = "drop table Subject";
            SQLiteCommand command100 = new SQLiteCommand(sql, m_dbConnection);
            command100.ExecuteNonQuery();

            sql = "drop table Registration";
            SQLiteCommand command101 = new SQLiteCommand(sql, m_dbConnection);
            command101.ExecuteNonQuery();

            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string sql = "select Sub_Name from Subject where Sub_Id=" + int.Parse(textBox1.Text) + ";";
            SQLiteCommand command15 = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command15.ExecuteReader();
            string output = "";
            while (reader.Read())
            {
                output = "" + reader["Sub_Name"];
            }
            MessageBox.Show(output, "Course Naem");



            sql = "select credit from Subject where Sub_Id=" + int.Parse(textBox1.Text) + ";";
            SQLiteCommand command25 = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader1 = command25.ExecuteReader();
            string outputs = "";
            while (reader1.Read())
            {
                outputs = "" + reader1["credit"];
            }
            MessageBox.Show(outputs, "Credit Hours");



            try
            {
                sql = "insert into Registration (Sub_Name , Sub_id ,Credit ) values ('" + output + "'," + textBox1.Text + "," + int.Parse(outputs) + ")";
                SQLiteCommand command9 = new SQLiteCommand(sql, m_dbConnection);

                command9.ExecuteNonQuery();


                sql = "select Registered from Subject where Sub_Id=" + int.Parse(textBox1.Text) + ";";
                SQLiteCommand command18 = new SQLiteCommand(sql, m_dbConnection);
                SQLiteDataReader reader2 = command18.ExecuteReader();

                string re = "";
                while (reader2.Read())
                {
                    re = "" + reader2["Registered"];
                }
                MessageBox.Show(re);


                int numb;
                numb = int.Parse(re);
                numb += 1;

                sql = "Update  Subject  set Registered =" + numb + " where Sub_Id=" + int.Parse(textBox1.Text);
                SQLiteCommand command110 = new SQLiteCommand(sql, m_dbConnection);
                int insertrecord = command110.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Already Registered", "Error");
            }


            sql = " SELECT * from subject order by Sub_Name desc";
            SQLiteDataAdapter da = new SQLiteDataAdapter(sql, m_dbConnection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            sql = " SELECT * from Registration order by Sub_Name desc";
            SQLiteDataAdapter daa = new SQLiteDataAdapter(sql, m_dbConnection);
            DataSet dsa = new DataSet();
            daa.Fill(dsa);
            dataGridView2.DataSource = dsa.Tables[0];


        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = " DELETE FROM Registration where Sub_id=" + textBox2.Text;
            SQLiteCommand command8 = new SQLiteCommand(sql, m_dbConnection);
            int insert = command8.ExecuteNonQuery();


            if (insert > 0)
            {

                sql = "select Registered from Subject where Sub_Id=" + int.Parse(textBox2.Text);
                SQLiteCommand command18 = new SQLiteCommand(sql, m_dbConnection);
                SQLiteDataReader reader2 = command18.ExecuteReader();

                string re = "";
                while (reader2.Read())
                {
                    re = "" + reader2["Registered"];
                }
                MessageBox.Show(re);


                int numb;
                numb = int.Parse(re);
                numb -= 1;

                sql = "Update  Subject  set Registered =" + numb + " where Sub_Id=" + int.Parse(textBox1.Text);
                SQLiteCommand command11 = new SQLiteCommand(sql, m_dbConnection);
                int insertrecord = command11.ExecuteNonQuery();

                sql = " SELECT * from subject order by Sub_Name desc";
                SQLiteDataAdapter da = new SQLiteDataAdapter(sql, m_dbConnection);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];

                sql = " SELECT * from Registration order by Sub_Name desc";
                SQLiteDataAdapter daa = new SQLiteDataAdapter(sql, m_dbConnection);
                DataSet dsa = new DataSet();
                daa.Fill(dsa);
                dataGridView2.DataSource = dsa.Tables[0];
            }
        }
    }
}
