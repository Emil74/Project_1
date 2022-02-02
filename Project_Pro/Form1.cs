using Entity;
using Facade;
using System;
using System.Windows.Forms;

namespace Project_Pro
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        UrunlerORM orm = new UrunlerORM();
        //KategorilerORM ktg = new KategorilerORM();
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = orm.Select();

            dataGridView1.DataSource = orm.Select();
            KategorilerORM o = new KategorilerORM();
            cmbKategori.DataSource = o.Select();
            cmbKategori.DisplayMember = "KategoriAdi";
            cmbKategori.ValueMember = "KategoriID";
            TedarikciORM ted = new TedarikciORM();
            cmbTedarikci.DataSource = ted.Select();
            cmbTedarikci.DisplayMember = "SirketAdi";
            cmbTedarikci.ValueMember = "TedarikciID";
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Urunler u = new Urunler();
            u.UrunAdi = txtUrunAdi.Text;
            u.Fiyat = nudFiyat.Value;
            u.Stok = Convert.ToInt16(nudStok.Value);
            u.KategoriID = (int)cmbKategori.SelectedValue;
            u.TedarikciID = (int)cmbTedarikci.SelectedValue;
            u.BirimdekiMiktar = "";

            /*  Kategoriler ted = new Kategoriler();
              ted.KategoriAdi = txtUrunAdi.Text;
              ted.Tanimi = textBox1.Text;*/

            bool sonuc = orm.Insert(u);
            if (sonuc)
            {
                MessageBox.Show("Eklendi");
                dataGridView1.DataSource = orm.Select();

            }
            else
            {
                MessageBox.Show("Hata");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            txtUrunAdi.Text = dataGridView1.CurrentRow.Cells["UrunAdi"].Value.ToString();
            nudFiyat.Value = (decimal)dataGridView1.CurrentRow.Cells["Fiyat"].Value;
            nudStok.Value = Convert.ToInt16(dataGridView1.CurrentRow.Cells["Stok"].Value);
            if (dataGridView1.CurrentRow.Cells["KategoriID"].Value == null)
            {
                cmbKategori.SelectedValue = "";
            }
            else
            {
                cmbKategori.SelectedValue = Convert.ToInt32(dataGridView1.CurrentRow.Cells["KategoriID"].Value);
            }

            cmbKategori.SelectedValue = Convert.ToInt32(dataGridView1.CurrentRow.Cells["TedarikciID"].Value);
            textBox1.Tag = Convert.ToInt32(dataGridView1.CurrentRow.Cells["UrunID"].Value);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Urunler u = new Urunler();
            u.UrunAdi = txtUrunAdi.Text;
            u.Fiyat = nudFiyat.Value;
            u.Stok = (short)nudStok.Value;
            u.KategoriID = Convert.ToInt32(cmbKategori.SelectedValue);
            u.TedarikciID = Convert.ToInt32(cmbTedarikci.SelectedValue);
            u.BirimdekiMiktar = "";
            u.UrunID = Convert.ToInt32(textBox1.Tag);
            bool sonuc = orm.Update(u);
            if (sonuc)
            {
                MessageBox.Show("Guncellendi");
                dataGridView1.DataSource = orm.Select();
            }
            else
            {
                MessageBox.Show("Hata");
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox1.Tag);
            bool sonuc = orm.Delete(id);
            if (sonuc)
            {
                MessageBox.Show("Silindi");
                dataGridView1.DataSource = orm.Select();

            }
            else
            {
                MessageBox.Show("Hata");
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmbTedarikci_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void nudStok_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void cmbKategori_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void nudFiyat_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtUrunAdi_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
