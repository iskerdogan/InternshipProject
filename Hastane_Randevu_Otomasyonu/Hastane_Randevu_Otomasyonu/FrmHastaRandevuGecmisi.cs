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
    public partial class FrmHastaRandevuGecmisi : Form
    {
        public FrmHastaRandevuGecmisi()
        {
            InitializeComponent();
        }

        public string Tc;
        sqlbaglantisi connect = new sqlbaglantisi();

        private void FrmHastaRandevuGecmisi_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Randevu where HastaTC=" + Tc, connect.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
