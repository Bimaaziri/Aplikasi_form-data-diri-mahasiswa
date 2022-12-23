using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace aplikasi_data
{
    public partial class Form1 : Form
    {
        MySqlConnection sqlConn = new MySqlConnection();
        MySqlCommand SqlCmd = new MySqlCommand();
        DataTable sqlDt = new DataTable();
        string sqlQuery;
        MySqlDataAdapter Dta = new MySqlDataAdapter();
        MySqlDataReader sqlRd;

        DataSet DS = new DataSet();

        string server = "localhost";
        string username = "root";
        string password = "masbim";
        string database = "kampus";

        public Form1()
        {
            InitializeComponent();
        }

        private void upLoadData()
        {
            sqlConn.ConnectionString = "server" + server + ";" + "user id =" + username + ";" +
                "password=" + password + ";" + "database=" + database;

            sqlConn.Open(); 

            sqlDt.Load(sqlRd);
            sqlRd.Close();
            sqlConn.Close();
            dataGridView1.DataSource= sqlDt;
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add(txtNim.Text, txtNama.Text, txtKelas.Text, txtAlamat.Text, txtTanggal.Text, txtNomor.Text);
        }

        private void iHapus()
        {
            foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.RemoveAt(item.Index);
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            iHapus();
        }

        private void btnUlang_Click(object sender, EventArgs e)
        {
           try
            {
                foreach(Control c in this.Controls)
                {
                    if (c is TextBox)
                        ((TextBox)c).Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void IUlang()
        {   //============================================= HAPUS DATA TEXTBOX ==============================================
            foreach (var c in this.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Text = String.Empty;
                }
            }

            //============================================= HAPUS DATA GRIDVIEW ==============================================
            int numRows = dataGridView1.Rows.Count;
            for(int i = 0; i < numRows; i++)
            {
                try
                {
                    int max = dataGridView1.Rows.Count - 1;
                    dataGridView1.Rows.Remove(dataGridView1.Rows[max]);
                }
                catch (Exception exe)
                {
                    MessageBox.Show("Semua akan di hapus " + exe, "Data di hapus",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        Bitmap bitmap;
        private void btnCetak_Click(object sender, EventArgs e)
        {
            int height = dataGridView1.Height;
            dataGridView1.Height = dataGridView1.RowCount * dataGridView1.RowTemplate.Height * 2;
            bitmap = new Bitmap(dataGridView1.Width, dataGridView1.Height);
            dataGridView1.DrawToBitmap(bitmap, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            printPreviewDialog1.ShowDialog();
            dataGridView1.Height = height;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 0);
        }

        private void btnKeluar_Click(object sender, EventArgs e)
        {
            DialogResult iKeluar;
            try
            {
            
            iKeluar = MessageBox.Show("Apakah anda yakin ingin keluar?", "Form Data Diri Mahasiswa",
                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);

             if (iKeluar == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
