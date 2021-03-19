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
    public partial class FrmHastaRandevuAl : Form
    {
        public FrmHastaRandevuAl()
        {
            InitializeComponent();
        }

        public string Tc;
        sqlbaglantisi connect = new sqlbaglantisi();

        private void FrmHasta_Load(object sender, EventArgs e)
        {
            //Branş çekme

            SqlCommand komut2 = new SqlCommand("Select BransAd From Tbl_Brans",connect.baglanti());
            SqlDataReader oku2 = komut2.ExecuteReader();
            while (oku2.Read())
            {
                CmbBrans.Items.Add(oku2[0]);
            }
            connect.baglanti().Close();
        }

        private void CmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbDoktor.Items.Clear();
            SqlCommand komut3 = new SqlCommand("Select DoktorAd,DoktorSoyad From Tbl_Doktor where DoktorBrans=@p1", connect.baglanti());
            komut3.Parameters.AddWithValue("@p1", CmbBrans.Text);
            SqlDataReader oku3 = komut3.ExecuteReader();
            while (oku3.Read())
            {
                CmbDoktor.Items.Add(oku3[0] + " " + oku3[1]);
            }
            connect.baglanti().Close();
        }

        private void CmbDoktor_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Randevu where RandevuBrans='" + CmbBrans.Text + "'" + "and RandevuDoktor='" + CmbDoktor.Text + "'and RandevuDurum=0", connect.baglanti());
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int tıklanan = dataGridView2.SelectedCells[0].RowIndex;
            Txtid.Text = dataGridView2.Rows[tıklanan].Cells[0].Value.ToString();
        }

        private void BtnRandevuAl_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update Tbl_Randevu set RandevuDurum=1,HastaTc=@p1,HastaSikayet=@p2 where Randevuid=@p3", connect.baglanti());
            komut.Parameters.AddWithValue("@p1", Tc);
            komut.Parameters.AddWithValue("@p2", RchSikayet.Text);
            komut.Parameters.AddWithValue("@p3", Txtid.Text);
            komut.ExecuteNonQuery();
            connect.baglanti().Close();
            MessageBox.Show("Randevunuz Alındı", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            this.Hide();
        }
    }
}
