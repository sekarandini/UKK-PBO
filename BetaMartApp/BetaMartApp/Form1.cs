using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace BetaMartApp
{
    public partial class Form1 : Form
    {
        OleDbConnection koneksi = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\SMK\UKK PBO_Sekar\BetaMartApp\BetaMartApp\bin\Debug\dbbarang.accdb");
        public Form1()
        {
            InitializeComponent();
        }

        //method show data
        void showData()
        {
            koneksi.Open();
            string perintah = "Select * from tbarang";
            OleDbDataAdapter da = new OleDbDataAdapter(perintah, koneksi);

            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            koneksi.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            showData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            koneksi.Open();
            string perintah = "insert into tbarang (id, namabarang, stokbarang, hargabeli, hargajual) values ('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text+ "', '" + textBox4.Text + "', '" + textBox5.Text + "')";
            OleDbCommand cmd = new OleDbCommand(perintah, koneksi);
            cmd.ExecuteNonQuery();

            koneksi.Close();
            MessageBox.Show("Data Berhasil Disimpan");
            showData();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            koneksi.Open();
            string perintah = "Delete from tbarang where id='"+textBox1.Text+"'";
            OleDbCommand cmd = new OleDbCommand(perintah, koneksi);
            cmd.ExecuteNonQuery();

            koneksi.Close();
            MessageBox.Show("Data Berhasil Disimpan");
            showData();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            koneksi.Open();
            string perintah = "Update tbarang set stokbarang='"+textBox3.Text+"' where namabarang='"+textBox2.Text+"'";
            OleDbCommand cmd = new OleDbCommand(perintah, koneksi);
            cmd.ExecuteNonQuery();

            koneksi.Close();
            MessageBox.Show("Data Berhasil Disimpan");
            showData();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }
    }
}
