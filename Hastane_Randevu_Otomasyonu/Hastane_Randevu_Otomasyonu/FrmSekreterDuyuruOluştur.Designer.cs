namespace Hastane_Randevu_Otomasyonu
{
    partial class FrmSekreterDuyuruOluştur
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnOluştur = new System.Windows.Forms.Button();
            this.RchDuyuru = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // BtnOluştur
            // 
            this.BtnOluştur.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.BtnOluştur.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnOluştur.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnOluştur.ForeColor = System.Drawing.SystemColors.Control;
            this.BtnOluştur.Location = new System.Drawing.Point(334, 449);
            this.BtnOluştur.Name = "BtnOluştur";
            this.BtnOluştur.Size = new System.Drawing.Size(141, 43);
            this.BtnOluştur.TabIndex = 1;
            this.BtnOluştur.Text = "Oluştur";
            this.BtnOluştur.UseVisualStyleBackColor = false;
            this.BtnOluştur.Click += new System.EventHandler(this.BtnOluştur_Click);
            // 
            // RchDuyuru
            // 
            this.RchDuyuru.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.RchDuyuru.Location = new System.Drawing.Point(62, 42);
            this.RchDuyuru.Name = "RchDuyuru";
            this.RchDuyuru.Size = new System.Drawing.Size(702, 392);
            this.RchDuyuru.TabIndex = 0;
            this.RchDuyuru.Text = "";
            // 
            // FrmSekreterDuyuruOluştur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(821, 524);
            this.Controls.Add(this.BtnOluştur);
            this.Controls.Add(this.RchDuyuru);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmSekreterDuyuruOluştur";
            this.Text = "FrmSekreterDuyuruOluştur";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnOluştur;
        private System.Windows.Forms.RichTextBox RchDuyuru;
    }
}