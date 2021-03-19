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
    public partial class FrmSekreterRandevuPaneli : Form
    {
        
        public FrmSekreterRandevuPaneli()
        {
            InitializeComponent();
        }

        public string tc;
        sqlbaglantisi connect = new sqlbaglantisi();

        private void FrmSekreter_Load(object sender, EventArgs e)
        {
            //Branş Aktarma

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Brans", connect.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            //Doktor Aktarma

            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("select (DoktorAd + ' ' + DoktorSoyad) as 'Doktorlar',DoktorBrans from Tbl_Doktor", connect.baglanti());
            da1.Fill(dt1);
            dataGridView2.DataSource = dt1;

            //Bransı Combobax a Aktarma
            SqlCommand komut2 = new SqlCommand("select BransAd from Tbl_Brans", connect.baglanti());
            SqlDataReader dr1 = komut2.ExecuteReader();
            while (dr1.Read())
            {
                CmbBrans.Items.Add(dr1[0]);
            }
        }

        private void CmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbDoktor.Items.Clear();
            SqlCommand komut = new SqlCommand("Select (DoktorAd + ' ' + DoktorSoyad)  From Tbl_Doktor where DoktorBrans=@p1", connect.baglanti());
            komut.Parameters.AddWithValue("@p1", CmbBrans.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                CmbDoktor.Items.Add(dr[0]);
            }
            connect.baglanti().Close();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut1 = new SqlCommand("insert into Tbl_Randevu(RandevuTarih,RandevuSaat,RandevuBrans,RandevuDoktor) values (@p1,@p2,@p3,@p4)", connect.baglanti());
            komut1.Parameters.AddWithValue("@p1", MskTarih.Text);
            komut1.Parameters.AddWithValue("@p2", MskSaat.Text);
            komut1.Parameters.AddWithValue("@p3", CmbBrans.Text);
            komut1.Parameters.AddWithValue("@p4", CmbDoktor.Text);
            komut1.ExecuteNonQuery();
            connect.baglanti().Close();
            MessageBox.Show("Randevu Başarıyla Oluşturuldu");
            this.Hide();
        }

       
    }
}
