
namespace Final
{
    partial class EmanetIslemleri
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmanetIslemleri));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbKitapAl = new System.Windows.Forms.RadioButton();
            this.dtpTeslimTarihi = new System.Windows.Forms.DateTimePicker();
            this.rbKitapVer = new System.Windows.Forms.RadioButton();
            this.tbOgrenciNumarasi = new System.Windows.Forms.TextBox();
            this.btnKapat = new System.Windows.Forms.Button();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.tbKitapBarkodNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.nudBorcOdeme = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBorcOgrNumarasi = new System.Windows.Forms.TextBox();
            this.btnOde = new System.Windows.Forms.Button();
            this.cbBorcOde = new System.Windows.Forms.CheckBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.lblEmanetKitapSayisi = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBorcOdeme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.groupBox1.Controls.Add(this.rbKitapAl);
            this.groupBox1.Controls.Add(this.dtpTeslimTarihi);
            this.groupBox1.Controls.Add(this.rbKitapVer);
            this.groupBox1.Controls.Add(this.tbOgrenciNumarasi);
            this.groupBox1.Controls.Add(this.btnKapat);
            this.groupBox1.Controls.Add(this.btnKaydet);
            this.groupBox1.Controls.Add(this.tbKitapBarkodNo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(324, 170);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // rbKitapAl
            // 
            this.rbKitapAl.AutoSize = true;
            this.rbKitapAl.Location = new System.Drawing.Point(15, 142);
            this.rbKitapAl.Name = "rbKitapAl";
            this.rbKitapAl.Size = new System.Drawing.Size(61, 17);
            this.rbKitapAl.TabIndex = 5;
            this.rbKitapAl.TabStop = true;
            this.rbKitapAl.Text = "Kitap Al";
            this.rbKitapAl.UseVisualStyleBackColor = true;
            this.rbKitapAl.CheckedChanged += new System.EventHandler(this.rbKitapAl_CheckedChanged);
            // 
            // dtpTeslimTarihi
            // 
            this.dtpTeslimTarihi.Location = new System.Drawing.Point(110, 71);
            this.dtpTeslimTarihi.Name = "dtpTeslimTarihi";
            this.dtpTeslimTarihi.Size = new System.Drawing.Size(200, 20);
            this.dtpTeslimTarihi.TabIndex = 5;
            // 
            // rbKitapVer
            // 
            this.rbKitapVer.AutoSize = true;
            this.rbKitapVer.Location = new System.Drawing.Point(15, 119);
            this.rbKitapVer.Name = "rbKitapVer";
            this.rbKitapVer.Size = new System.Drawing.Size(68, 17);
            this.rbKitapVer.TabIndex = 4;
            this.rbKitapVer.TabStop = true;
            this.rbKitapVer.Text = "Kitap Ver";
            this.rbKitapVer.UseVisualStyleBackColor = true;
            this.rbKitapVer.CheckedChanged += new System.EventHandler(this.rbKitapVer_CheckedChanged);
            // 
            // tbOgrenciNumarasi
            // 
            this.tbOgrenciNumarasi.Location = new System.Drawing.Point(110, 45);
            this.tbOgrenciNumarasi.Name = "tbOgrenciNumarasi";
            this.tbOgrenciNumarasi.Size = new System.Drawing.Size(200, 20);
            this.tbOgrenciNumarasi.TabIndex = 4;
            // 
            // btnKapat
            // 
            this.btnKapat.Location = new System.Drawing.Point(220, 119);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new System.Drawing.Size(90, 45);
            this.btnKapat.TabIndex = 3;
            this.btnKapat.Text = "Kapat";
            this.btnKapat.UseVisualStyleBackColor = true;
            this.btnKapat.Click += new System.EventHandler(this.btnKapat_Click);
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(110, 119);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(90, 45);
            this.btnKaydet.TabIndex = 2;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // tbKitapBarkodNo
            // 
            this.tbKitapBarkodNo.Location = new System.Drawing.Point(110, 19);
            this.tbKitapBarkodNo.Name = "tbKitapBarkodNo";
            this.tbKitapBarkodNo.Size = new System.Drawing.Size(200, 20);
            this.tbKitapBarkodNo.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Teslim Tarihi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Öğrenci Numarası";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kitap Barkod No";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.DarkRed;
            this.label4.Location = new System.Drawing.Point(16, 303);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(306, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "UYARI: Tüm kitapların teslim süresi 30 gündür!";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.groupBox3.Controls.Add(this.nudBorcOdeme);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txtBorcOgrNumarasi);
            this.groupBox3.Controls.Add(this.btnOde);
            this.groupBox3.Controls.Add(this.cbBorcOde);
            this.groupBox3.Location = new System.Drawing.Point(12, 212);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(324, 76);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // nudBorcOdeme
            // 
            this.nudBorcOdeme.Location = new System.Drawing.Point(100, 18);
            this.nudBorcOdeme.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudBorcOdeme.Name = "nudBorcOdeme";
            this.nudBorcOdeme.Size = new System.Drawing.Size(120, 20);
            this.nudBorcOdeme.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Öğrenci Numarası";
            // 
            // txtBorcOgrNumarasi
            // 
            this.txtBorcOgrNumarasi.Location = new System.Drawing.Point(100, 44);
            this.txtBorcOgrNumarasi.Name = "txtBorcOgrNumarasi";
            this.txtBorcOgrNumarasi.Size = new System.Drawing.Size(120, 20);
            this.txtBorcOgrNumarasi.TabIndex = 3;
            // 
            // btnOde
            // 
            this.btnOde.Location = new System.Drawing.Point(226, 18);
            this.btnOde.Name = "btnOde";
            this.btnOde.Size = new System.Drawing.Size(84, 46);
            this.btnOde.TabIndex = 2;
            this.btnOde.Text = "Öde";
            this.btnOde.UseVisualStyleBackColor = true;
            this.btnOde.Click += new System.EventHandler(this.btnOde_Click);
            // 
            // cbBorcOde
            // 
            this.cbBorcOde.AutoSize = true;
            this.cbBorcOde.Location = new System.Drawing.Point(23, 19);
            this.cbBorcOde.Name = "cbBorcOde";
            this.cbBorcOde.Size = new System.Drawing.Size(71, 17);
            this.cbBorcOde.TabIndex = 0;
            this.cbBorcOde.Text = "Borç Öde";
            this.cbBorcOde.UseVisualStyleBackColor = true;
            this.cbBorcOde.CheckedChanged += new System.EventHandler(this.cbBorcOde_CheckedChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(342, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(480, 306);
            this.dataGridView1.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 196);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Beklenen Kitap Sayısı:";
            // 
            // lblEmanetKitapSayisi
            // 
            this.lblEmanetKitapSayisi.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblEmanetKitapSayisi.AutoSize = true;
            this.lblEmanetKitapSayisi.Location = new System.Drawing.Point(127, 196);
            this.lblEmanetKitapSayisi.Name = "lblEmanetKitapSayisi";
            this.lblEmanetKitapSayisi.Size = new System.Drawing.Size(13, 13);
            this.lblEmanetKitapSayisi.TabIndex = 5;
            this.lblEmanetKitapSayisi.Text = "0";
            // 
            // EmanetIslemleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 331);
            this.Controls.Add(this.lblEmanetKitapSayisi);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EmanetIslemleri";
            this.Text = "Emanet İşlemleri";
            this.Load += new System.EventHandler(this.EmanetIslemleri_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBorcOdeme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpTeslimTarihi;
        private System.Windows.Forms.TextBox tbOgrenciNumarasi;
        private System.Windows.Forms.TextBox tbKitapBarkodNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnKapat;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.RadioButton rbKitapAl;
        private System.Windows.Forms.RadioButton rbKitapVer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox cbBorcOde;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBorcOgrNumarasi;
        private System.Windows.Forms.Button btnOde;
        private System.Windows.Forms.NumericUpDown nudBorcOdeme;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblEmanetKitapSayisi;
    }
}