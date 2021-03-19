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
    public partial class FrmHastaGiris : Form
    {
        public FrmHastaGiris()
        {
            InitializeComponent();
        }

        sqlbaglantisi connect = new sqlbaglantisi();
        private void LnkKayıtOl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmHastaKayıtOl frm = new FrmHastaKayıtOl();
            frm.Show();
            
        }

        private void BtnGiris_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * From Tbl_Hasta Where HastaTc=@p1 and HastaSifre=@p2", connect.baglanti());
            komut.Parameters.AddWithValue("@p1", MskTc.Text);
            komut.Parameters.AddWithValue("@p2", TxtSifre.Text);
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                FrmHasta frm = new FrmHasta();
                frm.TcHasta = MskTc.Text;
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("TC veya Şifre Hatalı!","Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        #region borderr kodları

        int hareket;
        int hareketX;
        int hareketY;

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (hareket == 1)
            {
                this.SetDesktopLocation(MousePosition.X - hareketX, MousePosition.Y - hareketY);
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            hareket = 1;
            hareketX = e.X;
            hareketY = e.Y;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            hareket = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
#endregion

    }
}
