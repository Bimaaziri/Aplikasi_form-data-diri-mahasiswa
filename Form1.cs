using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aplikasi_data
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtKeluar_Click(object sender, EventArgs e)
        {
            MeKeluar();
        }

        private void MeKeluar()
        {
            DialogResult iKeluar;

            iKeluar = MessageBox.Show("Yakin untuk keluar? ", "Simpan Data ", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (iKeluar == DialogResult.Yes )
            {
                Application.Exit();

            }
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add(txtNim.Text, txtNama.Text, txtKelas.Text, txtAlamat.Text, txtTanggal.Text, txtNomor.Text);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MeKeluar();
        }

        private void cetakToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int height = dataGridView1.Height;
            dataGridView1.Height = dataGridView1.RowCount * dataGridView1.RowTemplate.Height * 2;
            bitmap = new Bitmap(dataGridView1.Width, dataGridView1.Height);
            dataGridView1.DrawToBitmap(bitmap, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            printPreviewDialog1.ShowDialog();
            dataGridView1.Height = height;
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

        private void hapusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iHapus();
        }

        private void btnUlang_Click(object sender, EventArgs e)
        {
            IUlang();
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

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }
    }
}
