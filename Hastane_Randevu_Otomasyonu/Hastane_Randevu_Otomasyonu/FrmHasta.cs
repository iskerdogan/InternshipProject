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
    public partial class FrmHasta : Form
    {
        public FrmHasta()
        {
            InitializeComponent();
        }

        public string TcHasta;
        sqlbaglantisi connect = new sqlbaglantisi();
        private void FormGetir(Form frm)
        {
            panel3.Controls.Clear();
            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            panel3.Controls.Add(frm);
            frm.Show();
        }


        private void BtnHastaBilgi_Click(object sender, EventArgs e)
        {
            FrmHastaBilgi frm = new FrmHastaBilgi();
            frm.Tc = TcHasta;
            FormGetir(frm);
        }
        private void BtnHastaBilgiDüzenle_Click(object sender, EventArgs e)
        {
            FrmHastaBilgiGüncelle frm = new FrmHastaBilgiGüncelle();
            frm.Tc = TcHasta;
            FormGetir(frm);
        }
        private void BtnRandevuGecmis_Click(object sender, EventArgs e)
        {
            FrmHastaRandevuGecmisi frm = new FrmHastaRandevuGecmisi();
            frm.Tc = TcHasta;
            FormGetir(frm);
        }
        private void BtnRandevuAl_Click(object sender, EventArgs e)
        {
            FrmHastaRandevuAl frm = new FrmHastaRandevuAl();
            frm.Tc = TcHasta;
            FormGetir(frm);
        }

        private void BtnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #region Border ile İlgili Kodlar

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
