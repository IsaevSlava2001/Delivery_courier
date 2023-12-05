using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Delivery_courier
{
    public partial class Form1 : Form
    {
        DataBase dataBase = new DataBase();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ID = textBox1.Text;
            string querry = $"Select * FROM Couriers WHERE ID_Courier={Convert.ToInt32(ID)}";
            SqlCommand command = new SqlCommand(querry, dataBase.GetConnection());
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count == 1)
            {
                MessageBox.Show($"Добро пожаловать, {table.Rows[0][1]}");
                mainForm mainForm = new mainForm(Convert.ToInt32(ID), table.Rows[0][1].ToString(), table.Rows[0][2].ToString());
                mainForm.Show();
                this.Hide();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
