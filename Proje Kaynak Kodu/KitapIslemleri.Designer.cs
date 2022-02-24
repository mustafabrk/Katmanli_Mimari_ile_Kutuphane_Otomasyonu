
namespace Final
{
    partial class KitapIslemleri
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KitapIslemleri));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbKitapAdedi = new System.Windows.Forms.TextBox();
            this.tbBasimYili = new System.Windows.Forms.TextBox();
            this.cbKitapTuru = new System.Windows.Forms.ComboBox();
            this.tbKitapRafYeri = new System.Windows.Forms.TextBox();
            this.tbCevirmenAdi = new System.Windows.Forms.TextBox();
            this.tbSayfaSayisi = new System.Windows.Forms.TextBox();
            this.tbYayinevi = new System.Windows.Forms.TextBox();
            this.tbYazarAdi = new System.Windows.Forms.TextBox();
            this.tbKitapAdi = new System.Windows.Forms.TextBox();
            this.tbBarkodNo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnFiltrele = new System.Windows.Forms.Button();
            this.tbFiltreleKitapAdi = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tbListeleBarkodNo = new System.Windows.Forms.TextBox();
            this.btnKitapEmanetListele = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnKitaplariListele = new System.Windows.Forms.Button();
            this.btnCikis = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.lblMevcutKitapAdedi = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.tbKitapAdedi);
            this.groupBox1.Controls.Add(this.tbBasimYili);
            this.groupBox1.Controls.Add(this.cbKitapTuru);
            this.groupBox1.Controls.Add(this.tbKitapRafYeri);
            this.groupBox1.Controls.Add(this.tbCevirmenAdi);
            this.groupBox1.Controls.Add(this.tbSayfaSayisi);
            this.groupBox1.Controls.Add(this.tbYayinevi);
            this.groupBox1.Controls.Add(this.tbYazarAdi);
            this.groupBox1.Controls.Add(this.tbKitapAdi);
            this.groupBox1.Controls.Add(this.tbBarkodNo);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(659, 162);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(365, 127);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(61, 13);
            this.label12.TabIndex = 19;
            this.label12.Text = "Kitap Adedi";
            // 
            // tbKitapAdedi
            // 
            this.tbKitapAdedi.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbKitapAdedi.Location = new System.Drawing.Point(429, 124);
            this.tbKitapAdedi.Name = "tbKitapAdedi";
            this.tbKitapAdedi.Size = new System.Drawing.Size(200, 20);
            this.tbKitapAdedi.TabIndex = 18;
            this.tbKitapAdedi.Text = "1";
            this.tbKitapAdedi.Validating += new System.ComponentModel.CancelEventHandler(this.tbKitapAdedi_Validating);
            // 
            // tbBasimYili
            // 
            this.tbBasimYili.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbBasimYili.Location = new System.Drawing.Point(84, 124);
            this.tbBasimYili.Name = "tbBasimYili";
            this.tbBasimYili.Size = new System.Drawing.Size(200, 20);
            this.tbBasimYili.TabIndex = 17;
            this.tbBasimYili.Validating += new System.ComponentModel.CancelEventHandler(this.tbBasimYili_Validating);
            // 
            // cbKitapTuru
            // 
            this.cbKitapTuru.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbKitapTuru.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbKitapTuru.FormattingEnabled = true;
            this.cbKitapTuru.Location = new System.Drawing.Point(429, 19);
            this.cbKitapTuru.Name = "cbKitapTuru";
            this.cbKitapTuru.Size = new System.Drawing.Size(200, 21);
            this.cbKitapTuru.TabIndex = 16;
            // 
            // tbKitapRafYeri
            // 
            this.tbKitapRafYeri.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbKitapRafYeri.Location = new System.Drawing.Point(429, 98);
            this.tbKitapRafYeri.Name = "tbKitapRafYeri";
            this.tbKitapRafYeri.Size = new System.Drawing.Size(200, 20);
            this.tbKitapRafYeri.TabIndex = 15;
            this.tbKitapRafYeri.Validating += new System.ComponentModel.CancelEventHandler(this.tbKitapRafYeri_Validating);
            // 
            // tbCevirmenAdi
            // 
            this.tbCevirmenAdi.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbCevirmenAdi.Location = new System.Drawing.Point(429, 72);
            this.tbCevirmenAdi.Name = "tbCevirmenAdi";
            this.tbCevirmenAdi.Size = new System.Drawing.Size(200, 20);
            this.tbCevirmenAdi.TabIndex = 14;
            // 
            // tbSayfaSayisi
            // 
            this.tbSayfaSayisi.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbSayfaSayisi.Location = new System.Drawing.Point(429, 46);
            this.tbSayfaSayisi.Name = "tbSayfaSayisi";
            this.tbSayfaSayisi.Size = new System.Drawing.Size(200, 20);
            this.tbSayfaSayisi.TabIndex = 13;
            this.tbSayfaSayisi.Validating += new System.ComponentModel.CancelEventHandler(this.tbSayfaSayisi_Validating);
            // 
            // tbYayinevi
            // 
            this.tbYayinevi.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbYayinevi.Location = new System.Drawing.Point(84, 98);
            this.tbYayinevi.Name = "tbYayinevi";
            this.tbYayinevi.Size = new System.Drawing.Size(200, 20);
            this.tbYayinevi.TabIndex = 12;
            this.tbYayinevi.Validating += new System.ComponentModel.CancelEventHandler(this.tbYayinevi_Validating);
            // 
            // tbYazarAdi
            // 
            this.tbYazarAdi.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbYazarAdi.Location = new System.Drawing.Point(84, 72);
            this.tbYazarAdi.Name = "tbYazarAdi";
            this.tbYazarAdi.Size = new System.Drawing.Size(200, 20);
            this.tbYazarAdi.TabIndex = 11;
            this.tbYazarAdi.Validating += new System.ComponentModel.CancelEventHandler(this.tbYazarAdi_Validating);
            // 
            // tbKitapAdi
            // 
            this.tbKitapAdi.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbKitapAdi.Location = new System.Drawing.Point(84, 46);
            this.tbKitapAdi.Name = "tbKitapAdi";
            this.tbKitapAdi.Size = new System.Drawing.Size(200, 20);
            this.tbKitapAdi.TabIndex = 10;
            this.tbKitapAdi.Validating += new System.ComponentModel.CancelEventHandler(this.tbKitapAdi_Validating);
            // 
            // tbBarkodNo
            // 
            this.tbBarkodNo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbBarkodNo.Location = new System.Drawing.Point(84, 20);
            this.tbBarkodNo.Name = "tbBarkodNo";
            this.tbBarkodNo.Size = new System.Drawing.Size(200, 20);
            this.tbBarkodNo.TabIndex = 9;
            this.tbBarkodNo.Validating += new System.ComponentModel.CancelEventHandler(this.tbBarkodNo_Validating);
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(351, 101);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Kitap Raf Yeri";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(354, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Çevirmen Adı";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(359, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Sayfa Sayısı";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(367, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Kitap Türü";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Basım Yılı";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Yayınevi";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Yazar Adı";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Kitap Adı";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Barkod No";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox2.Controls.Add(this.btnGuncelle);
            this.groupBox2.Controls.Add(this.btnKaydet);
            this.groupBox2.Controls.Add(this.btnSil);
            this.groupBox2.Location = new System.Drawing.Point(12, 181);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(237, 75);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Location = new System.Drawing.Point(84, 19);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(70, 50);
            this.btnGuncelle.TabIndex = 1;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(8, 19);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(70, 50);
            this.btnKaydet.TabIndex = 0;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(160, 19);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(70, 50);
            this.btnSil.TabIndex = 2;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox3.Controls.Add(this.btnFiltrele);
            this.groupBox3.Controls.Add(this.tbFiltreleKitapAdi);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Location = new System.Drawing.Point(255, 181);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(172, 75);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            // 
            // btnFiltrele
            // 
            this.btnFiltrele.Image = ((System.Drawing.Image)(resources.GetObject("btnFiltrele.Image")));
            this.btnFiltrele.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFiltrele.Location = new System.Drawing.Point(6, 45);
            this.btnFiltrele.Name = "btnFiltrele";
            this.btnFiltrele.Size = new System.Drawing.Size(160, 23);
            this.btnFiltrele.TabIndex = 2;
            this.btnFiltrele.Text = "Filtrele";
            this.btnFiltrele.UseVisualStyleBackColor = true;
            this.btnFiltrele.Click += new System.EventHandler(this.btnFiltrele_Click);
            // 
            // tbFiltreleKitapAdi
            // 
            this.tbFiltreleKitapAdi.Location = new System.Drawing.Point(62, 19);
            this.tbFiltreleKitapAdi.Name = "tbFiltreleKitapAdi";
            this.tbFiltreleKitapAdi.Size = new System.Drawing.Size(104, 20);
            this.tbFiltreleKitapAdi.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Kitap Adı";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox4.Controls.Add(this.tbListeleBarkodNo);
            this.groupBox4.Controls.Add(this.btnKitapEmanetListele);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Location = new System.Drawing.Point(441, 181);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(231, 75);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            // 
            // tbListeleBarkodNo
            // 
            this.tbListeleBarkodNo.Location = new System.Drawing.Point(108, 19);
            this.tbListeleBarkodNo.Name = "tbListeleBarkodNo";
            this.tbListeleBarkodNo.Size = new System.Drawing.Size(117, 20);
            this.tbListeleBarkodNo.TabIndex = 2;
            // 
            // btnKitapEmanetListele
            // 
            this.btnKitapEmanetListele.Location = new System.Drawing.Point(8, 45);
            this.btnKitapEmanetListele.Name = "btnKitapEmanetListele";
            this.btnKitapEmanetListele.Size = new System.Drawing.Size(217, 23);
            this.btnKitapEmanetListele.TabIndex = 1;
            this.btnKitapEmanetListele.Text = "Kitap Emanet Bilgilerini Listele";
            this.btnKitapEmanetListele.UseVisualStyleBackColor = true;
            this.btnKitapEmanetListele.Click += new System.EventHandler(this.btnKitapEmanetListele_Click);
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(44, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Barkod No";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 262);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(660, 251);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // btnKitaplariListele
            // 
            this.btnKitaplariListele.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKitaplariListele.Location = new System.Drawing.Point(465, 519);
            this.btnKitaplariListele.Name = "btnKitaplariListele";
            this.btnKitaplariListele.Size = new System.Drawing.Size(100, 30);
            this.btnKitaplariListele.TabIndex = 4;
            this.btnKitaplariListele.Text = "Kitapları Listele";
            this.btnKitaplariListele.UseVisualStyleBackColor = true;
            this.btnKitaplariListele.Click += new System.EventHandler(this.btnKitaplariListele_Click);
            // 
            // btnCikis
            // 
            this.btnCikis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCikis.Image = ((System.Drawing.Image)(resources.GetObject("btnCikis.Image")));
            this.btnCikis.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCikis.Location = new System.Drawing.Point(571, 520);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(100, 30);
            this.btnCikis.TabIndex = 5;
            this.btnCikis.Text = "Çıkış";
            this.btnCikis.UseVisualStyleBackColor = true;
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(9, 529);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(103, 13);
            this.label13.TabIndex = 6;
            this.label13.Text = "Mevcut Kitap Adedi:";
            // 
            // lblMevcutKitapAdedi
            // 
            this.lblMevcutKitapAdedi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMevcutKitapAdedi.AutoSize = true;
            this.lblMevcutKitapAdedi.Location = new System.Drawing.Point(118, 529);
            this.lblMevcutKitapAdedi.Name = "lblMevcutKitapAdedi";
            this.lblMevcutKitapAdedi.Size = new System.Drawing.Size(13, 13);
            this.lblMevcutKitapAdedi.TabIndex = 7;
            this.lblMevcutKitapAdedi.Text = "0";
            // 
            // KitapIslemleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 561);
            this.Controls.Add(this.lblMevcutKitapAdedi);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btnCikis);
            this.Controls.Add(this.btnKitaplariListele);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "KitapIslemleri";
            this.Text = "Kitap İşlemleri";
            this.Load += new System.EventHandler(this.KitapIslemleri_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbBasimYili;
        private System.Windows.Forms.ComboBox cbKitapTuru;
        private System.Windows.Forms.TextBox tbKitapRafYeri;
        private System.Windows.Forms.TextBox tbCevirmenAdi;
        private System.Windows.Forms.TextBox tbSayfaSayisi;
        private System.Windows.Forms.TextBox tbYayinevi;
        private System.Windows.Forms.TextBox tbYazarAdi;
        private System.Windows.Forms.TextBox tbKitapAdi;
        private System.Windows.Forms.TextBox tbBarkodNo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnFiltrele;
        private System.Windows.Forms.TextBox tbFiltreleKitapAdi;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox tbListeleBarkodNo;
        private System.Windows.Forms.Button btnKitapEmanetListele;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbKitapAdedi;
        private System.Windows.Forms.Button btnKitaplariListele;
        private System.Windows.Forms.Button btnCikis;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblMevcutKitapAdedi;
    }
}