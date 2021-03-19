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
    public partial class FrmSekreterDuyuruOluştur : Form
    {
        public FrmSekreterDuyuruOluştur()
        {
            InitializeComponent();
        }

        
        sqlbaglantisi connect = new sqlbaglantisi();

        private void BtnOluştur_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Tbl_Duyurular (Duyuru) values (@p1)", connect.baglanti());
            komut.Parameters.AddWithValue("@p1", RchDuyuru.Text);
            komut.ExecuteNonQuery();
            connect.baglanti().Close();
            MessageBox.Show("Duyuru Başarıyla Oluşturuldu");
        }
    }
}
