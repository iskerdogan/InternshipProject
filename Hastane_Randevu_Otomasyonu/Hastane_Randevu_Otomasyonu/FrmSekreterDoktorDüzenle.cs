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
    public partial class FrmSekreterDoktorDüzenle : Form
    {
        
        public FrmSekreterDoktorDüzenle()
        {
            InitializeComponent();
        }

        sqlbaglantisi connect = new sqlbaglantisi();

        private void FrmSekreterDoktorDüzenle_Load(object sender, EventArgs e)
        {
            //doktor çekme

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Doktor", connect.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
               
            //ComboBox 'a brans çekme
            
            SqlCommand komut1 = new SqlCommand("select BransAd from Tbl_Brans", connect.baglanti());
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                CmbBrans.Items.Add(dr1[0]);
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int tıklanan = dataGridView1.SelectedCells[0].RowIndex;
            TxtAd.Text = dataGridView1.Rows[tıklanan].Cells[1].Value.ToString();
            TxtSoyad.Text = dataGridView1.Rows[tıklanan].Cells[2].Value.ToString();
            CmbBrans.Text = dataGridView1.Rows[tıklanan].Cells[3].Value.ToString();
            MskTc.Text = dataGridView1.Rows[tıklanan].Cells[4].Value.ToString();
            TxtSifre.Text = dataGridView1.Rows[tıklanan].Cells[5].Value.ToString();

        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Tbl_Doktor (DoktorAd,DoktorSoyad,DoktorBrans,DoktorTc,DoktorSifre) values (@p1,@p2,@p3,@p4,@p5)", connect.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", CmbBrans.Text);
            komut.Parameters.AddWithValue("@p4", MskTc.Text);
            komut.Parameters.AddWithValue("@p5", TxtSifre.Text);
            komut.ExecuteNonQuery();
            connect.baglanti().Close();
            MessageBox.Show("Doktor Ekleme Başarılı","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            this.Hide();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from Tbl_Doktor where DoktorTc=@p1", connect.baglanti());
            komut.Parameters.AddWithValue("@p1", MskTc.Text);
            komut.ExecuteNonQuery();
            connect.baglanti().Close();
            MessageBox.Show("Seçilen Doktor Silindi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            this.Hide();
        }

        private void BtnGuncel_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update Tbl_Doktor set DoktorAd=@p1,DoktorSoyad=@p2,DoktorBrans=@p3,DoktorSifre=@p5 where DoktorTc=@p4", connect.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", CmbBrans.Text);
            komut.Parameters.AddWithValue("@p4", MskTc.Text);
            komut.Parameters.AddWithValue("@p5", TxtSifre.Text);
            komut.ExecuteNonQuery();
            connect.baglanti().Close();
            MessageBox.Show("Güncelleme Başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
        }
    }
}
