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
    public partial class FrmDoktorBilgi : Form
    {
        public FrmDoktorBilgi()
        {
            InitializeComponent();
        }
        public string Tcno;
        sqlbaglantisi connect = new sqlbaglantisi();

        private void FrmDoktorBilgi_Load(object sender, EventArgs e)
        {
            //TC Çekme

            LblTc.Text = Tcno;

            //Ad Soyad Çekme

            SqlCommand komut = new SqlCommand("Select DoktorAd,DoktorSoyad from Tbl_Doktor where DoktorTc=@p1", connect.baglanti());
            komut.Parameters.AddWithValue("@p1", LblTc.Text);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                LblAd.Text = oku[0].ToString();
                LblSoyad.Text = oku[1].ToString();
            }
            connect.baglanti().Close();
        }
    }
}
