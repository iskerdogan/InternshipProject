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
    public partial class FrmHastaBilgiGüncelle : Form
    {
       
        public FrmHastaBilgiGüncelle()
        {
            InitializeComponent();
        }

        public string Tc;
        sqlbaglantisi connect = new sqlbaglantisi();

        private void FrmHastaBilgiGüncelle2_Load(object sender, EventArgs e)
        {
            MskTc.Text = Tc;
            SqlCommand komut = new SqlCommand("Select * from Tbl_Hasta where HastaTc=@p1", connect.baglanti());
            komut.Parameters.AddWithValue("@p1", MskTc.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                TxtAd.Text = dr[1].ToString();
                TxtSoyad.Text = dr[2].ToString();
                CmbCinsiyet.Text = dr[3].ToString();
                MskTelefon.Text = dr[5].ToString();
                MskTc.Text = dr[4].ToString();
                TxtSifre.Text = dr[6].ToString();
            }
            connect.baglanti().Close();
        }

        private void BtnKayit_Click(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("update Tbl_Hasta set HastaAd=@p1,HastaSoyad=@p2,HastaCinsiyet=@p3,HastaTelefon=@p4,HastaSifre=@p5 where HastaTc=@p6", connect.baglanti());
            komut2.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut2.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komut2.Parameters.AddWithValue("@p3", CmbCinsiyet.Text);
            komut2.Parameters.AddWithValue("@p4", MskTelefon.Text);
            komut2.Parameters.AddWithValue("@p5", TxtSifre.Text);
            komut2.Parameters.AddWithValue("@p6", MskTc.Text);
            komut2.ExecuteNonQuery();
            connect.baglanti().Close();
            MessageBox.Show("Bilgileriniz Başarıyla Güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            this.Hide();
        }
        
    }
}
