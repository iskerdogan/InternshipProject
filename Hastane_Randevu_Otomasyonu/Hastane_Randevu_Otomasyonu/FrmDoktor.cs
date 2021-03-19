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
    public partial class FrmDoktor : Form
    {
        public FrmDoktor()
        {
            InitializeComponent();
        }

        public string TcDoktor;
        sqlbaglantisi connect = new sqlbaglantisi();

        private void FormGetir(Form frm)
        {
            panel3.Controls.Clear();
            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            panel3.Controls.Add(frm);
            frm.Show();
        }

        private void BtnDoktorBilgi_Click(object sender, EventArgs e)
        {
            FrmDoktorBilgi frm = new FrmDoktorBilgi();
            frm.Tcno = TcDoktor;
            FormGetir(frm);
        }
        
        private void BtnDoktorBilgiDüzenle_Click(object sender, EventArgs e)
        {
            FrmDoktorBilgiGüncelle frm = new FrmDoktorBilgiGüncelle();
            frm.Tcno = TcDoktor;
            FormGetir(frm);
        }

        private void BtnDuyurular_Click(object sender, EventArgs e)
        {
            FrmDuyurular frm = new FrmDuyurular();
            FormGetir(frm);
        }

        private void BtnRandevular_Click(object sender, EventArgs e)
        {
            FrmDoktorRandevular frm = new FrmDoktorRandevular();
            frm.tcno = TcDoktor;
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
