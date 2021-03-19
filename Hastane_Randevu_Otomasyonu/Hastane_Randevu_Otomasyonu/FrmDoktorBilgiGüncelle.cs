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
    public partial class FrmDoktorBilgiGüncelle : Form
    {
        public FrmDoktorBilgiGüncelle()
        {
            InitializeComponent();
        }

        sqlbaglantisi connect = new sqlbaglantisi();
        public string Tcno;

        private void FrmDoktorBilgiGüncelle_Load(object sender, EventArgs e)
        {
            MskTc.Text = Tcno;
            SqlCommand komut = new SqlCommand("Select * From Tbl_Doktor where DoktorTc=@p1", connect.baglanti());
            komut.Parameters.AddWithValue("@p1",MskTc.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                TxtAd.Text = dr[1].ToString();
                TxtSoyad.Text = dr[2].ToString();
                TxtSifre.Text = dr[5].ToString();

            }
            connect.baglanti().Close();
        }

        private void BtnKayit_Click(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("update Tbl_Doktor set DoktorAd=@p1,DoktorSoyad=@p2,DoktorSifre=@p5 where DoktorTc=@p4", connect.baglanti());
            komut2.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut2.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komut2.Parameters.AddWithValue("@p4", MskTc.Text);
            komut2.Parameters.AddWithValue("@p5", TxtSifre.Text);
            komut2.ExecuteNonQuery();
            connect.baglanti().Close();
            MessageBox.Show("Bilgileriniz Başarıyla Güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            this.Hide();
        }
    }
}
