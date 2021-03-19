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

namespace Hastane_Randevu_Otomasyonu
{
    public partial class FrmSekreterBransDuzenle : Form
    {
        
        public FrmSekreterBransDuzenle()
        {
            InitializeComponent();
        }

        sqlbaglantisi connect = new sqlbaglantisi();

        private void FrmSekreterBransDuzenle_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Brans", connect.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int tıklanan = dataGridView1.SelectedCells[0].RowIndex;
            TxtBransid.Text = dataGridView1.Rows[tıklanan].Cells[0].Value.ToString();
            TxtBransAd.Text = dataGridView1.Rows[tıklanan].Cells[1].Value.ToString();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Tbl_Brans (Bransid,BransAd) values (@p1,@p2)", connect.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtBransid.Text);
            komut.Parameters.AddWithValue("@p2", TxtBransAd.Text);
            komut.ExecuteNonQuery();
            connect.baglanti().Close();
            MessageBox.Show("Başarıyla Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from Tbl_Brans where Bransid=@p1", connect.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtBransid.Text);
            komut.ExecuteNonQuery();
            connect.baglanti().Close();
            MessageBox.Show("Seçilen Branş Silindi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            this.Hide();
        }

        private void BtnGuncel_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update Tbl_Brans set BransAd=@p2 where Bransid=@p1", connect.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtBransid.Text);
            komut.Parameters.AddWithValue("@p2", TxtBransAd.Text);
            komut.ExecuteNonQuery();
            connect.baglanti().Close();
            MessageBox.Show("Güncelleme Başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
        }     
    }
}
