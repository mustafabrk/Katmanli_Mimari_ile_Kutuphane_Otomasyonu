
namespace Final
{
    partial class AnaForm
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnaForm));
            this.btnKitapIslemleri = new System.Windows.Forms.Button();
            this.btnOgrenciIslemleri = new System.Windows.Forms.Button();
            this.btnEmanetIslemleri = new System.Windows.Forms.Button();
            this.btnKitapListele = new System.Windows.Forms.Button();
            this.btnOgrenciListele = new System.Windows.Forms.Button();
            this.btnEmanetListele = new System.Windows.Forms.Button();
            this.btnYardim = new System.Windows.Forms.Button();
            this.btnCikis = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGrafik = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblMevcut = new System.Windows.Forms.Label();
            this.lblEmanet = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblToplam = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnKitapIslemleri
            // 
            this.btnKitapIslemleri.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnKitapIslemleri.Image = ((System.Drawing.Image)(resources.GetObject("btnKitapIslemleri.Image")));
            this.btnKitapIslemleri.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKitapIslemleri.Location = new System.Drawing.Point(87, 62);
            this.btnKitapIslemleri.Name = "btnKitapIslemleri";
            this.btnKitapIslemleri.Size = new System.Drawing.Size(150, 50);
            this.btnKitapIslemleri.TabIndex = 0;
            this.btnKitapIslemleri.Text = "Kitap İşlemleri";
            this.btnKitapIslemleri.UseVisualStyleBackColor = true;
            this.btnKitapIslemleri.Click += new System.EventHandler(this.btnKitapIslemleri_Click);
            // 
            // btnOgrenciIslemleri
            // 
            this.btnOgrenciIslemleri.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnOgrenciIslemleri.Image = ((System.Drawing.Image)(resources.GetObject("btnOgrenciIslemleri.Image")));
            this.btnOgrenciIslemleri.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnOgrenciIslemleri.Location = new System.Drawing.Point(242, 62);
            this.btnOgrenciIslemleri.Name = "btnOgrenciIslemleri";
            this.btnOgrenciIslemleri.Size = new System.Drawing.Size(150, 50);
            this.btnOgrenciIslemleri.TabIndex = 1;
            this.btnOgrenciIslemleri.Text = "Öğrenci İşlemleri";
            this.btnOgrenciIslemleri.UseVisualStyleBackColor = true;
            this.btnOgrenciIslemleri.Click += new System.EventHandler(this.btnOgrenciIslemleri_Click);
            // 
            // btnEmanetIslemleri
            // 
            this.btnEmanetIslemleri.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnEmanetIslemleri.Image = ((System.Drawing.Image)(resources.GetObject("btnEmanetIslemleri.Image")));
            this.btnEmanetIslemleri.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmanetIslemleri.Location = new System.Drawing.Point(398, 62);
            this.btnEmanetIslemleri.Name = "btnEmanetIslemleri";
            this.btnEmanetIslemleri.Size = new System.Drawing.Size(150, 50);
            this.btnEmanetIslemleri.TabIndex = 2;
            this.btnEmanetIslemleri.Text = "Emanet İşlemleri";
            this.btnEmanetIslemleri.UseVisualStyleBackColor = true;
            this.btnEmanetIslemleri.Click += new System.EventHandler(this.btnEmanetIslemleri_Click);
            // 
            // btnKitapListele
            // 
            this.btnKitapListele.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnKitapListele.Image = ((System.Drawing.Image)(resources.GetObject("btnKitapListele.Image")));
            this.btnKitapListele.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKitapListele.Location = new System.Drawing.Point(87, 118);
            this.btnKitapListele.Name = "btnKitapListele";
            this.btnKitapListele.Size = new System.Drawing.Size(150, 50);
            this.btnKitapListele.TabIndex = 4;
            this.btnKitapListele.Text = "Kitap Listele";
            this.btnKitapListele.UseVisualStyleBackColor = true;
            this.btnKitapListele.Click += new System.EventHandler(this.btnKitapListele_Click);
            // 
            // btnOgrenciListele
            // 
            this.btnOgrenciListele.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnOgrenciListele.Image = ((System.Drawing.Image)(resources.GetObject("btnOgrenciListele.Image")));
            this.btnOgrenciListele.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnOgrenciListele.Location = new System.Drawing.Point(242, 118);
            this.btnOgrenciListele.Name = "btnOgrenciListele";
            this.btnOgrenciListele.Size = new System.Drawing.Size(150, 50);
            this.btnOgrenciListele.TabIndex = 5;
            this.btnOgrenciListele.Text = "Öğrenci Listele";
            this.btnOgrenciListele.UseVisualStyleBackColor = true;
            this.btnOgrenciListele.Click += new System.EventHandler(this.btnOgrenciListele_Click);
            // 
            // btnEmanetListele
            // 
            this.btnEmanetListele.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnEmanetListele.Image = ((System.Drawing.Image)(resources.GetObject("btnEmanetListele.Image")));
            this.btnEmanetListele.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmanetListele.Location = new System.Drawing.Point(398, 118);
            this.btnEmanetListele.Name = "btnEmanetListele";
            this.btnEmanetListele.Size = new System.Drawing.Size(150, 50);
            this.btnEmanetListele.TabIndex = 6;
            this.btnEmanetListele.Text = "Emanet Listele";
            this.btnEmanetListele.UseVisualStyleBackColor = true;
            this.btnEmanetListele.Click += new System.EventHandler(this.btnEmanetListele_Click);
            // 
            // btnYardim
            // 
            this.btnYardim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnYardim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYardim.ForeColor = System.Drawing.SystemColors.Control;
            this.btnYardim.Image = ((System.Drawing.Image)(resources.GetObject("btnYardim.Image")));
            this.btnYardim.Location = new System.Drawing.Point(12, 469);
            this.btnYardim.Name = "btnYardim";
            this.btnYardim.Size = new System.Drawing.Size(30, 30);
            this.btnYardim.TabIndex = 7;
            this.btnYardim.UseVisualStyleBackColor = true;
            this.btnYardim.Click += new System.EventHandler(this.btnYardim_Click);
            // 
            // btnCikis
            // 
            this.btnCikis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCikis.Image = ((System.Drawing.Image)(resources.GetObject("btnCikis.Image")));
            this.btnCikis.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCikis.Location = new System.Drawing.Point(532, 469);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(90, 30);
            this.btnCikis.TabIndex = 8;
            this.btnCikis.Text = "Çıkış";
            this.btnCikis.UseVisualStyleBackColor = true;
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 181);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(610, 282);
            this.dataGridView1.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(156, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(309, 33);
            this.label1.TabIndex = 10;
            this.label1.Text = "Kütüphane Otomasyonu";
            // 
            // btnGrafik
            // 
            this.btnGrafik.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGrafik.Image = ((System.Drawing.Image)(resources.GetObject("btnGrafik.Image")));
            this.btnGrafik.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGrafik.Location = new System.Drawing.Point(436, 469);
            this.btnGrafik.Name = "btnGrafik";
            this.btnGrafik.Size = new System.Drawing.Size(90, 30);
            this.btnGrafik.TabIndex = 11;
            this.btnGrafik.Text = "Grafik";
            this.btnGrafik.UseVisualStyleBackColor = true;
            this.btnGrafik.Click += new System.EventHandler(this.btnGrafik_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 478);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Mevcut Kitap Adedi: ";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(203, 478);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Emanet Kitap Sayısı: ";
            // 
            // lblMevcut
            // 
            this.lblMevcut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMevcut.AutoSize = true;
            this.lblMevcut.Location = new System.Drawing.Point(159, 478);
            this.lblMevcut.Name = "lblMevcut";
            this.lblMevcut.Size = new System.Drawing.Size(13, 13);
            this.lblMevcut.TabIndex = 14;
            this.lblMevcut.Text = "0";
            // 
            // lblEmanet
            // 
            this.lblEmanet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblEmanet.AutoSize = true;
            this.lblEmanet.Location = new System.Drawing.Point(304, 478);
            this.lblEmanet.Name = "lblEmanet";
            this.lblEmanet.Size = new System.Drawing.Size(13, 13);
            this.lblEmanet.TabIndex = 15;
            this.lblEmanet.Text = "0";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(344, 478);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Toplam: ";
            // 
            // lblToplam
            // 
            this.lblToplam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblToplam.AutoSize = true;
            this.lblToplam.Location = new System.Drawing.Point(389, 478);
            this.lblToplam.Name = "lblToplam";
            this.lblToplam.Size = new System.Drawing.Size(13, 13);
            this.lblToplam.TabIndex = 17;
            this.lblToplam.Text = "0";
            // 
            // AnaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(634, 511);
            this.Controls.Add(this.lblToplam);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblEmanet);
            this.Controls.Add(this.lblMevcut);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnGrafik);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnCikis);
            this.Controls.Add(this.btnYardim);
            this.Controls.Add(this.btnEmanetListele);
            this.Controls.Add(this.btnOgrenciListele);
            this.Controls.Add(this.btnKitapListele);
            this.Controls.Add(this.btnEmanetIslemleri);
            this.Controls.Add(this.btnOgrenciIslemleri);
            this.Controls.Add(this.btnKitapIslemleri);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AnaForm";
            this.Text = "Kütüphane Otomasyonu ";
            this.Load += new System.EventHandler(this.AnaForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnKitapIslemleri;
        private System.Windows.Forms.Button btnOgrenciIslemleri;
        private System.Windows.Forms.Button btnEmanetIslemleri;
        private System.Windows.Forms.Button btnKitapListele;
        private System.Windows.Forms.Button btnOgrenciListele;
        private System.Windows.Forms.Button btnEmanetListele;
        private System.Windows.Forms.Button btnYardim;
        private System.Windows.Forms.Button btnCikis;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGrafik;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblMevcut;
        private System.Windows.Forms.Label lblEmanet;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblToplam;
    }
}

