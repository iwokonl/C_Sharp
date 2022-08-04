using System;
using SQLite_Sample_DB;
using System.Data.SQLite;
namespace App
{
    public partial class Form1 : Form
    {
        public delegate void UpdateDelegate(object sender, UpdateEventArgs args);
        public event UpdateDelegate UpdateEventHandler;
        //public class UpdateEventArgs : EventArgs
        ////{
        ////    public string Data { get; set; }
        ////}



        public Form1()
        {
            InitializeComponent();
            SQLiteConnection sqliteConnection;
            sqliteConnection = Zadanko_Ewelina.QueryToDataBase.CreateConnection();
            Zadanko_Ewelina.QueryToDataBase.CreateTable(sqliteConnection);
            sqliteConnection.Open();
            Zadanko_Ewelina.QueryToDataBase.ReadData(sqliteConnection, Zadanko_Ewelina.Model.IdLocal);
            var users = Zadanko_Ewelina.Model.Users;
            BindingSource binding = new BindingSource();
            binding.DataSource = users;
            dataGridView1.DataSource = binding;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "") 
            {
                MessageBox.Show("WprowadŸ dane");
                return;
            }
            SQLiteConnection sqliteConnection;
            sqliteConnection = Zadanko_Ewelina.QueryToDataBase.CreateConnection();
            Zadanko_Ewelina.QueryToDataBase.InsertData(sqliteConnection, 
                "INSERT INTO Personel_new(FirstName, LastName) VALUES ('" + Zadanko_Ewelina.Model.FirstName2 + "', '" + Zadanko_Ewelina.Model.LastName2 + "');");
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Zadanko_Ewelina.Model.FirstName2 = ((TextBox)sender).Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Zadanko_Ewelina.Model.LastName2 = ((TextBox)sender).Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

            Zadanko_Ewelina.Model.IdLocal = ((TextBox)sender).Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SQLiteConnection sqliteConnection;
            SQLiteConnection sqliteConnection2;
            sqliteConnection = Zadanko_Ewelina.QueryToDataBase.CreateConnection();
            sqliteConnection2 = Zadanko_Ewelina.QueryToDataBase.CreateConnection();
            if (!Zadanko_Ewelina.Model.IdLocal.Any(x => !char.IsLetter(x)))
            {
                MessageBox.Show("Proszê podaæ liczbê");
                return;
            }
            if (textBox3.Text == "" || textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Wype³nij");
                return;
            }
            else if (Int32.Parse(Zadanko_Ewelina.Model.IdLocal) <= 0 | Zadanko_Ewelina.Model.IdLocal == String.Empty)
            {
                MessageBox.Show("Podaj id wiêksze ni¿ 0");
                return;
            }
            else if (Int32.Parse(Zadanko_Ewelina.Model.IdLocal) > Zadanko_Ewelina.QueryToDataBase.GenerateId(sqliteConnection))
            {
                MessageBox.Show("Proszê podaæ mniejsze id");
                sqliteConnection.Close();
                return;
            }
            sqliteConnection.Close();
            Zadanko_Ewelina.QueryToDataBase.UpdateTable(sqliteConnection2, 
                "UPDATE Personel_new SET FirstName = '" + Zadanko_Ewelina.Model.FirstName2 + "' ,LastName = '" + Zadanko_Ewelina.Model.LastName2 + 
                "' WHERE Id = " + Zadanko_Ewelina.Model.IdLocal + ";");
            sqliteConnection2.Close();
            Zadanko_Ewelina.Model.Users.Remove(Zadanko_Ewelina.Model.Users[Int32.Parse(Zadanko_Ewelina.Model.IdLocal) - 1]);
            Zadanko_Ewelina.Model.Users.Insert(Int32.Parse(Zadanko_Ewelina.Model.IdLocal)-1, new Zadanko_Ewelina.Model() 
                { 
                    Id = Int32.Parse(Zadanko_Ewelina.Model.IdLocal),
                    FirstName = Zadanko_Ewelina.Model.FirstName2,
                    LastName = Zadanko_Ewelina.Model.LastName2 
                });
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {

        }
    }


}