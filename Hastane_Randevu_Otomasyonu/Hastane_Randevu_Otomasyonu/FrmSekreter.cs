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
    public partial class FrmSekreter : Form
    {
        public FrmSekreter()
        {
            InitializeComponent();
        }

        public string TcSekreter;
        sqlbaglantisi connect = new sqlbaglantisi();

        private void FormGetir(Form frm)
        {
            panel3.Controls.Clear();
            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            panel3.Controls.Add(frm);
            frm.Show();
        }
        private void BtnSekreterBilgi_Click(object sender, EventArgs e)
        {
            FrmSekreterBilgi frm = new FrmSekreterBilgi();
            frm.TcS = TcSekreter;
            FormGetir(frm);
        }

        private void BtnRandevuPaneli_Click(object sender, EventArgs e)
        {
            FrmSekreterRandevuPaneli frm = new FrmSekreterRandevuPaneli();
            FormGetir(frm);
        }

        private void BtnRandevuListesi_Click(object sender, EventArgs e)
        {
            FrmSekreterRandevuListesi frm = new FrmSekreterRandevuListesi();
            FormGetir(frm);
        }

        private void BtnDoktorEkleSil_Click(object sender, EventArgs e)
        {
            FrmSekreterDoktorDüzenle frm = new FrmSekreterDoktorDüzenle();
            FormGetir(frm);
        }

        private void BtnBransEkleSil_Click(object sender, EventArgs e)
        {
            FrmSekreterBransDuzenle frm = new FrmSekreterBransDuzenle();
            FormGetir(frm);
        }

        private void BtnDuyuruOlustur_Click(object sender, EventArgs e)
        {
            FrmSekreterDuyuruOluştur frm = new FrmSekreterDuyuruOluştur();
            FormGetir(frm);
        }
        private void BtnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #region Border ile ilgili kodlar

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
