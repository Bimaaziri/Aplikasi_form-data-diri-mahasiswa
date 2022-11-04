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

            iKeluar = MessageBox.Show("Kamu yakin untuk keluar ", "Simpan Data ", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (iKeluar == DialogResult.Yes )
            {
                Application.Exit();

            }
        }

        private void keluarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MeKeluar();
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
