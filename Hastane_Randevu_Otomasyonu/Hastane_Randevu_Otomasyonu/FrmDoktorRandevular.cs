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
    public partial class FrmDoktorRandevular : Form
    {
        public FrmDoktorRandevular()
        {
            InitializeComponent();
        }

        sqlbaglantisi connect = new sqlbaglantisi();
        public string tcno;
        public string adsoyad;

        private void FrmDoktor_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select DoktorAd,DoktorSoyad from Tbl_Doktor where DoktorTc=@p1", connect.baglanti());
            komut.Parameters.AddWithValue("@p1", tcno);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                adsoyad = oku[0] +" "+ oku[1];
                
            }
            connect.baglanti().Close();

            //Randevular

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Randevu where RandevuDoktor='" + adsoyad + "'", connect.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int tıklanan = dataGridView1.SelectedCells[0].RowIndex;
            RchSikayet.Text = dataGridView1.Rows[tıklanan].Cells[7].Value.ToString();
        }
    }
}
