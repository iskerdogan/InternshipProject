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
    public partial class FrmSekreterBilgi : Form
    {
        public FrmSekreterBilgi()
        {
            InitializeComponent();
        }

        public string TcS;
        sqlbaglantisi connect = new sqlbaglantisi();

        private void FrmSekreterBilgi_Load(object sender, EventArgs e)
        {
            //TC Çekme

            LblTc.Text = TcS;

            //Ad Soyad Çekme

            SqlCommand komut = new SqlCommand("select SekreterAdSoyad From Tbl_Sekreter where SekreterTc=@p1", connect.baglanti());
            komut.Parameters.AddWithValue("@p1", LblTc.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                LblAdSoyad.Text = dr[0].ToString();
            }
            connect.baglanti().Close();
        }
    }
}
