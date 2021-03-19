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
    public partial class FrmHastaBilgi : Form
    {
        public FrmHastaBilgi()
        {
            InitializeComponent();
        }
        public string Tc;
        sqlbaglantisi connect = new sqlbaglantisi();
        private void FrmHastaBilgi_Load(object sender, EventArgs e)
        {
            //TC Çekme

            LblTc.Text = Tc;

            //Ad Soyad Çekme

            SqlCommand komut = new SqlCommand("Select HastaAd,HastaSoyad,HastaTelefon from Tbl_Hasta where HastaTc=@p1", connect.baglanti());
            komut.Parameters.AddWithValue("@p1", LblTc.Text);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                LblAd.Text = oku[0].ToString();
                LblSoyad.Text = oku[1].ToString();
                LblTelefon.Text = oku[2].ToString();
            }
            connect.baglanti().Close();
        }
    }
}
