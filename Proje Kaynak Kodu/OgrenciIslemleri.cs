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

namespace Final
{
    public partial class OgrenciIslemleri : Form
    {
        public OgrenciIslemleri()
        {
            InitializeComponent();
        }

        Baglanti bglnt = new Baglanti();    //Baglanti sinifinda belirlenen text'teki veritabani adresine ulasmak icin bu kodu yaziyoruz

        void fill() //dataGridView1'deki sutunlarimizi otomatik olarak sigdiran fonksiyonumuzu olusturuyoruz
        {
            this.dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;   //dataGridView1'deki sutunlarimizi otomatik sigdiriyoruz
            this.dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;   //dataGridView1'deki sutunlarimizi otomatik sigdiriyoruz
            this.dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;   //dataGridView1'deki sutunlarimizi otomatik sigdiriyoruz
            this.dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;   //dataGridView1'deki sutunlarimizi otomatik sigdiriyoruz
            this.dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;   //dataGridView1'deki sutunlarimizi otomatik sigdiriyoruz
            this.dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;   //dataGridView1'deki sutunlarimizi otomatik sigdiriyoruz
            this.dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;   //dataGridView1'deki sutunlarimizi otomatik sigdiriyoruz
            this.dataGridView1.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;   //dataGridView1'deki sutunlarimizi otomatik sigdiriyoruz
        }

        bool sayiMi(string text)    //textboxlara girilen ifadelerin sayi olup olmadigini kontrol eden kod blogu burada yer almaktadir
        {
            foreach (char chr in text)
            {
                if (!Char.IsNumber(chr)) return false;  //ifade sayi degilse false donduruyoruz
            }
            return true;
        }

        public void sutunTopla()    //gecikme ücretlerini dataGridView1 üzerinden toplama islemini gerceklestiren fonksiyon
        {
            int toplam = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)  //tum satirlari dolasmamizi saglayan for dongusunu aciyoruz
            {
                toplam += Convert.ToInt32(dataGridView1.Rows[i].Cells[7].Value);    //toplam degerini her satirdaki 7. sutun degerlerinin toplamina esitliyoruz
            }
            lblToplamGecikme.Text = toplam.ToString();  //degerimizi ilgili label'a yazdiriyoruz
        }

        public void renkDegistir()  //kodun satir sayisini azaltmak icin bu metodu olusturuyoruz ve renk islemlerini bu blogu cagirarak gerceklestiriyoruz
        {
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)  //tum satirlari dolasmamizi saglayan for dongusunu aciyoruz
            {
                DataGridViewCellStyle renk = new DataGridViewCellStyle();   //Hucre stilini duzenlememizi saglayan nesneyi olusturuyoruz

                DateTime verilmeTarihi = Convert.ToDateTime(dataGridView1.Rows[i].Cells[3].Value);  //satirlardaki 4. hucrenin degerini DateTime'a donusturerek verilmeTarihi degiskenine atiyoruz 
                DateTime beklenenTarih = Convert.ToDateTime(dataGridView1.Rows[i].Cells[4].Value);  //satirlardaki 5. hucrenin degerini DateTime'a donusturerek beklenenTarih degiskenine atiyoruz 
                DateTime verilmeTarihinden_28gunSonrasi = verilmeTarihi.AddDays(+28);   //verilme tarihinin 28 gun sonrasini degiskene atiyoruz
                DateTime bugun = DateTime.Now;  //kodun calistigi anin zaman bilgilerini bugun degiskenine atiyoruz

                if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[6].Value) == true)    //eger kitapTeslim bilgisi true ise bu bloga giriyoruz ve arkaplani yesil renkli olarak ayarliyoruz
                {
                    renk.BackColor = Color.GreenYellow;
                    renk.ForeColor = Color.Black;
                }
                if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[6].Value) == false)   //eger kitapTeslim bilgisi false ise bu bloga giriyoruz ve...
                {
                    if (beklenenTarih < bugun)  //beklenen tarihin bugunden kucuk olmasi durumunda yani kitabin zamaninda teslim edilmemesi durumunda bu bloga girip arkaplani kirmizi renkli yapiyoruz
                    {
                        renk.BackColor = Color.OrangeRed;
                        renk.ForeColor = Color.Black;
                    }
                    else if (bugun <= verilmeTarihinden_28gunSonrasi)   //bugunun verilme tarihinin 28 gun oncesinden kucuk olmasi durumunda yani kitabin teslim tarihinin henuz yaklasmadigi durumunda bu bloga girip arkaplani default ayarli yapiyoruz
                    {
                        dataGridView1.Rows[i].DefaultCellStyle = renk;
                    }
                    else //diger durumda yani kitabin teslim suresinin yaklastigi durumda da bu bloga girip arkaplani sari renkli olarak ayarliyoruz
                    {
                        renk.BackColor = Color.Yellow;
                        renk.ForeColor = Color.Black;
                    }
                }
                dataGridView1.Rows[i].DefaultCellStyle = renk;  //dongunun tekrar ettiginde default rengine donmesini saglayarak renklerin karismasini onluyoruz
            }
        }

        private void OgrenciIslemleri_Load(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(bglnt.Adres);    //baglanti adresimizi baglanti sinifindaki adresten cekiyoruz

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from Ogrenci", baglanti);    //data set ile veritabani arasinda kopru gorevi gorur. Ogrenci tablosunun tum sutunlarini secer
                DataSet ds = new DataSet(); //sanal tablomuzu olusturuyoruz
                da.Fill(ds);    //data adapter'in icini data set ile dolduruyoruz
                dataGridView1.DataSource = ds.Tables[0];    //son olarak da formdaki data grid view aracına sql tablomu 0. indisten itibaren yazdiriyoruz
                fill(); //dataGridView1'deki sutunlarimizi otomatik olarak sigdiran fonksiyonumuzu cagiriyoruz

                lblOgrenciSayisi.Text = dataGridView1.RowCount.ToString();  //toplam ogrenci sayisini yani satir sayisini label'a yazdiriyoruz

                string[] fakulteler = { "Tıp Fakültesi", "Sağlık Bilimleri Fakültesi", "Eğitim Fakültesi", "Fen-Edebiyat Fakültesi", "İlahiyat Fakültesi", "İşletme Fakültesi",
                                    "Mühendislik Fakültesi", "Orman Fakültesi", "Sanat, Tasarım ve Mimarlık Fakültesi", "Teknoloji Fakültesi", "Ziraat Fakültesi"}; //fakulteleri kod tekrari olmaması icin diziye aktariyoruz
                cbOkuduguFakulte.Items.AddRange(fakulteler);    //ardından dizimizi cagirarak combo boxa fakulteleri ekliyoruz

                string[] siniflar = { "Hazırlık Sınıfı", "1. Sınıf", "2. Sınıf", "3. Sınıf", "4. Sınıf", "Mezun" }; //Siniflari kod tekrari olmaması icin diziye aktariyoruz
                cbSinifi.Items.AddRange(siniflar);  //ardından dizimizi cagirarak comboBoxa siniflari ekliyoruz

                cbOkuduguBolum.Enabled = false; //eger kullanici fakulte secmediyse bu comboBox'u kapali tutuyoruz
                cbSinifi.Enabled = false;   //eger kullanici okudugu bolumu secmediyse bu comboBox'u kapali tutuyoruz

                sutunTopla();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); baglanti.Close(); }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(bglnt.Adres);    //baglanti adresimizi baglanti sinifindaki adresten cekiyoruz

            try
            {
                baglanti.Open();    //veritabani ile kodun arasındaki baglantiyi aciyoruz
                SqlCommand kayitEkle = new SqlCommand("insert into Ogrenci(OgrenciNumarasi, OgrenciAdi, OgrenciSoyadi, OgrenciTelefonNo, OkuduguFakulte, OkuduguBolum, Sinifi, GecikmeUcreti) " +
                                                      "values (@o1, @o2, @o3, @o4, @o5, @o6, @o7, @o8)", baglanti); //sql'in kayit ekleme kodunun atamalarini c# uzerinden  gerceklestirdim. Denk gelen sutun adlarina @ ifadesiyle atama yapan nesneyi olusturuyoruz
                kayitEkle.Parameters.AddWithValue("@o1", tbOgrenciNumarasi.Text);   //yaptigimiz atamalarin degerlerini de formdaki text box ve comboboxtaki text degerlerine esitliyoruz
                kayitEkle.Parameters.AddWithValue("@o2", tbIsmi.Text);              //yaptigimiz atamalarin degerlerini de formdaki text box ve comboboxtaki text degerlerine esitliyoruz
                kayitEkle.Parameters.AddWithValue("@o3", tbSoyismi.Text);           //yaptigimiz atamalarin degerlerini de formdaki text box ve comboboxtaki text degerlerine esitliyoruz
                kayitEkle.Parameters.AddWithValue("@o4", tbTelefonNumarasi.Text);   //yaptigimiz atamalarin degerlerini de formdaki text box ve comboboxtaki text degerlerine esitliyoruz
                kayitEkle.Parameters.AddWithValue("@o5", cbOkuduguFakulte.Text);    //yaptigimiz atamalarin degerlerini de formdaki text box ve comboboxtaki text degerlerine esitliyoruz
                kayitEkle.Parameters.AddWithValue("@o6", cbOkuduguBolum.Text);      //yaptigimiz atamalarin degerlerini de formdaki text box ve comboboxtaki text degerlerine esitliyoruz
                kayitEkle.Parameters.AddWithValue("@o7", cbSinifi.Text);            //yaptigimiz atamalarin degerlerini de formdaki text box ve comboboxtaki text degerlerine esitliyoruz
                kayitEkle.Parameters.AddWithValue("@o8", 0);                        //yaptigimiz atamalarin degerlerini de formdaki text box ve comboboxtaki text degerlerine esitliyoruz

                kayitEkle.ExecuteNonQuery();    //atamasini yapilan sql kayit ekleme komutunun calismasini sagliyoruz

                MessageBox.Show("Öğrenci Kaydedildi");

                SqlDataAdapter da = new SqlDataAdapter("Select * from Ogrenci", baglanti); //data set ile veritabani arasinda kopru gorevi gorur. Ogrenci tablosunun tum sutunlarini secer
                DataSet ds = new DataSet(); //sanal tablomuzu olusturur
                da.Fill(ds);    //data adapter'in icini data set ile doldurdum
                dataGridView1.DataSource = ds.Tables[0];    //son olarakta formdaki data grid view aracına sql tablomu 0. indistan itibaren yazdırdım 
                                                            //Bu islemleri tabloda yapilan degisiklikleri tekrar ekrana yazdirmak icin yapiyoruz
                fill(); //dataGridView1'deki sutunlarimizi otomatik olarak sigdiran fonksiyonumuzu cagiriyoruz

                baglanti.Close();   //veritabani ile kodun arasındaki baglantiyi kapatiyoruz

                lblOgrenciSayisi.Text = dataGridView1.RowCount.ToString();  //kaydetme isleminden sonra tekrardan toplam ogrenci sayisini label'a yazdiriyoruz
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); baglanti.Close(); }
        }

        private void btnSil_Click(object sender, EventArgs e)   //silme islemini gerceklesitren kod blogu. Silme islemi ogrencinin numarasina göre yapilmistir
        {
            SqlConnection baglanti = new SqlConnection(bglnt.Adres);    //baglanti adresimizi baglanti sinifindaki adresten cekiyoruz

            try
            {
                if (tbOgrenciNumarasi.Text == string.Empty) //Ogrenci Numarasinin yer aldigi textbox bossa bu kosula girer
                {
                    MessageBox.Show("Lütfen silmek istediğiniz öğrencinin yalnızca Öğrenci Numarasını giriniz.", "Girdi Hatası");
                }
                else if(sayiMi(tbOgrenciNumarasi.Text) == true) //OgrenciNo'ya girilen degerin sayi olup olmadigi kontrol ediliyor. Eger sayiysa bu bloga giriyor
                {
                    if (tbOgrenciNumarasi.Text.Length != 9)
                    {
                        MessageBox.Show("Lütfen 9 haneli Öğrenci Numarasını hatasız girdiğinizden emin olun", "Girdi Hatası");
                    }
                    else if (tbOgrenciNumarasi.Text.Length == 9)
                    {
                        baglanti.Open();
                        SqlCommand komutSil1 = new SqlCommand("Delete From Ogrenci where OgrenciNumarasi = @ogrNo", baglanti);  //sql uzerinden komut silme islemini gerceklestirecek kod tanimlandi. Adresi ise ogrencinin numarasindan tayin ediliyor
                        SqlCommand komutSil2 = new SqlCommand("Delete From Emanet where OgrenciNumarasi = @ogrNo", baglanti);   //Eger ogrenci silinirse ogrenciye ait emanet bilgileri de siliniyor
                        komutSil1.Parameters.AddWithValue("@ogrNo", tbOgrenciNumarasi.Text);    //hangi ogrencinin silinecegini girilen ogrenci numarasina göre gerceklestirecek kod
                        komutSil2.Parameters.AddWithValue("@ogrNo", tbOgrenciNumarasi.Text);    //girilen ogrenci numarasina denk gelen emanet edilmis ogrenci de siliniyor
                        komutSil2.ExecuteNonQuery();    //Silme kodlarini aktif hale getiren komut
                        komutSil1.ExecuteNonQuery();    //Silme kodlarini aktif hale getiren komut

                        MessageBox.Show("Öğrenci Silindi");

                        SqlDataAdapter da = new SqlDataAdapter("Select * from Ogrenci", baglanti); //data set ile veritabani arasinda kopru gorevi gorur. Ogrenci tablosunun tum sutunlarini secer
                        DataSet ds = new DataSet(); //sanal tablomuzu olusturur
                        da.Fill(ds);    //data adapter'in icini data set ile doldurdum
                        dataGridView1.DataSource = ds.Tables[0];    //son olarakta formdaki data grid view aracına sql tablomu 0. indistan itibaren yazdırdım 
                                                                    //Bu islemleri tabloda yapilan degisiklikleri tekrar ekrana yazdirmak icin yapiyoruz
                        fill(); //dataGridView1'deki sutunlarimizi otomatik olarak sigdiran fonksiyonumuzu cagiriyoruz

                        baglanti.Close();   //veritabani ile kodun arasındaki baglantiyi kapatiyoruz
                    }
                    else
                    {
                        MessageBox.Show("Hatalı Öğrenci Numarası girdiniz \n" + "Silme işlemi gerçekleştirilemedi...", "Girdi Hatası");
                    }
                }
                else
                {
                    MessageBox.Show("Hatalı Öğrenci Numarası girdiniz \n" + "Silme işlemi gerçekleştirilemedi...", "Girdi Hatası");
                }
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); baglanti.Close(); }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;  //dataGridView uzerinden secilen hucrenin bulundugu tum satiri secili hale getiriyor

            string ogrenciNo = dataGridView1.Rows[secilen].Cells[0].Value.ToString();       //secili hale gelen her bir hucreye karsilik gelen ifadeler string degiskenine donusturuluyor
            string ogrenciAdi = dataGridView1.Rows[secilen].Cells[1].Value.ToString();      //secili hale gelen her bir hucreye karsilik gelen ifadeler string degiskenine donusturuluyor
            string ogrenciSoyadi = dataGridView1.Rows[secilen].Cells[2].Value.ToString();   //secili hale gelen her bir hucreye karsilik gelen ifadeler string degiskenine donusturuluyor
            string ogrenciTelNo = dataGridView1.Rows[secilen].Cells[3].Value.ToString();    //secili hale gelen her bir hucreye karsilik gelen ifadeler string degiskenine donusturuluyor
            string okuduguFakulte = dataGridView1.Rows[secilen].Cells[4].Value.ToString();  //secili hale gelen her bir hucreye karsilik gelen ifadeler string degiskenine donusturuluyor
            string okuduguBolum = dataGridView1.Rows[secilen].Cells[5].Value.ToString();    //secili hale gelen her bir hucreye karsilik gelen ifadeler string degiskenine donusturuluyor
            string sinif = dataGridView1.Rows[secilen].Cells[6].Value.ToString();           //secili hale gelen her bir hucreye karsilik gelen ifadeler string degiskenine donusturuluyor

            tbOgrenciNumarasi.Text = ogrenciNo;     //secili hale gelen tum hucrelerin degerleri textBox'lara ve comboBox'lara aktariliyor
            tbIsmi.Text = ogrenciAdi;               //secili hale gelen tum hucrelerin degerleri textBox'lara ve comboBox'lara aktariliyor
            tbSoyismi.Text = ogrenciSoyadi;         //secili hale gelen tum hucrelerin degerleri textBox'lara ve comboBox'lara aktariliyor
            tbTelefonNumarasi.Text = ogrenciTelNo;  //secili hale gelen tum hucrelerin degerleri textBox'lara ve comboBox'lara aktariliyor
            cbOkuduguFakulte.Text = okuduguFakulte; //secili hale gelen tum hucrelerin degerleri textBox'lara ve comboBox'lara aktariliyor
            cbOkuduguBolum.Text = okuduguBolum;     //secili hale gelen tum hucrelerin degerleri textBox'lara ve comboBox'lara aktariliyor
            cbSinifi.Text = sinif;                  //secili hale gelen tum hucrelerin degerleri textBox'lara ve comboBox'lara aktariliyor
                                                    //boylece guncelleme ve silme islemleri daha kullanisli ve basit hale geliyor

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(bglnt.Adres);    //baglanti adresimizi baglanti sinifindaki adresten cekiyoruz

            try
            {
                baglanti.Open();    //veritabani ile kodun arasindaki baglantiyi actim
                SqlCommand komutGuncelle = new SqlCommand("update Ogrenci set OgrenciNumarasi = @og1, OgrenciAdi = @og2, OgrenciSoyadi = @og3, OgrenciTelefonNo = @og4, " +
                                                          "OkuduguFakulte = @og5, OkuduguBolum = @og6, Sinifi = @og7 where OgrenciNumarasi = @og1", baglanti);  //sql'in kayit guncelleme kodunun atamalarini c# uzerinden  gerceklestirdim. Denk gelen sutun adlarina @ ifadesiyle atama yapan nesneyi olusturuyoruz
                komutGuncelle.Parameters.AddWithValue("@og1", tbOgrenciNumarasi.Text);  //yaptigimiz atamalarin degerlerini de formdaki textBox ve comboBox'taki degerlerine esitliyoruz
                komutGuncelle.Parameters.AddWithValue("@og2", tbIsmi.Text);             //yaptigimiz atamalarin degerlerini de formdaki textBox ve comboBox'taki degerlerine esitliyoruz
                komutGuncelle.Parameters.AddWithValue("@og3", tbSoyismi.Text);          //yaptigimiz atamalarin degerlerini de formdaki textBox ve comboBox'taki degerlerine esitliyoruz
                komutGuncelle.Parameters.AddWithValue("@og4", tbTelefonNumarasi.Text);  //yaptigimiz atamalarin degerlerini de formdaki textBox ve comboBox'taki degerlerine esitliyoruz
                komutGuncelle.Parameters.AddWithValue("@og5", cbOkuduguFakulte.Text);   //yaptigimiz atamalarin degerlerini de formdaki textBox ve comboBox'taki degerlerine esitliyoruz
                komutGuncelle.Parameters.AddWithValue("@og6", cbOkuduguBolum.Text);     //yaptigimiz atamalarin degerlerini de formdaki textBox ve comboBox'taki degerlerine esitliyoruz
                komutGuncelle.Parameters.AddWithValue("@og7", cbSinifi.Text);           //yaptigimiz atamalarin degerlerini de formdaki textBox ve comboBox'taki degerlerine esitliyoruz

                komutGuncelle.ExecuteNonQuery();    //atamasi yapilan sql kayit guncelleme komutunun calismasini sagliyoruz

                MessageBox.Show("Öğrenci Güncellendi");

                SqlDataAdapter da = new SqlDataAdapter("Select * from Ogrenci", baglanti); //data set ile veritabani arasinda kopru gorevi gorur. Ogrenci tablosunun tum sutunlarini secer
                DataSet ds = new DataSet(); //sanal tablomuzu olusturur
                da.Fill(ds);    //data adapter'in icini data set ile doldurdum
                dataGridView1.DataSource = ds.Tables[0];    //son olarakta formdaki data grid view aracına sql tablomu 0. indistan itibaren yazdırdım 
                                                            //Bu islemleri tabloda yapilan degisiklikleri tekrar ekrana yazdirmak icin yapiyoruz
                fill(); //dataGridView1'deki sutunlarimizi otomatik olarak sigdiran fonksiyonumuzu cagiriyoruz

                baglanti.Close();   //veritabani ile kodun arasındaki baglantiyi kapatiyoruz
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); baglanti.Close(); }
        }

        private void btnFiltrele_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(bglnt.Adres);    //baglanti adresimizi baglanti sinifindaki adresten cekiyoruz

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from Ogrenci where OgrenciAdi = '" + tbFiltreleOgrenciAdi.Text + "'", baglanti);   //Ogrenci tablosundan ogrenciAdi girilen degerin satiri seciliyor
                DataSet ds = new DataSet();     //sanal tablomuzu olusturur
                da.Fill(ds);    //data adapter'in icini data set ile doldurdum
                dataGridView1.DataSource = ds.Tables[0];    //son olarakta formdaki data grid view aracına sql tablomu 0. indistan itibaren yazdiriyoruz
                fill(); //dataGridView1'deki sutunlarimizi otomatik olarak sigdiran fonksiyonumuzu cagiriyoruz
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); baglanti.Close(); }
        }

        private void btnOgrenciEmanetListele_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(bglnt.Adres);    //baglanti adresimizi baglanti sinifindaki adresten cekiyoruz

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from Emanet where OgrenciNumarasi = '" + tbListeleOgrenciNumarasi.Text + "'", baglanti);   //Emanet tablosundan Ogrenci Numarasi girilen degerin satiri seciliyor
                DataSet ds = new DataSet();     //sanal tablomuzu olusturur
                da.Fill(ds);    //data adapter'in icini data set ile doldurdum
                dataGridView1.DataSource = ds.Tables[0];    //son olarakta formdaki data grid view aracına sql tablomu 0. indistan itibaren yazdiriyoruz
                this.dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;   //dataGridView1'deki sutunlarimizi otomatik sigdiriyoruz
                this.dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;   //dataGridView1'deki sutunlarimizi otomatik sigdiriyoruz
                this.dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;   //dataGridView1'deki sutunlarimizi otomatik sigdiriyoruz
                this.dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;   //dataGridView1'deki sutunlarimizi otomatik sigdiriyoruz
                this.dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;   //dataGridView1'deki sutunlarimizi otomatik sigdiriyoruz
                this.dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;   //dataGridView1'deki sutunlarimizi otomatik sigdiriyoruz
                this.dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;   //dataGridView1'deki sutunlarimizi otomatik sigdiriyoruz
                renkDegistir(); //renk degistiren metodumuzu cagirdik
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); baglanti.Close(); }
        }

        private void btnOgrenciListele_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(bglnt.Adres);    //baglanti adresimizi baglanti sinifindaki adresten cekiyoruz

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from Ogrenci", baglanti); //data set ile veritabani arasinda kopru gorevi gorur. Ogrenci tablosunun tum sutunlarini secer
                DataSet ds = new DataSet(); //sanal tablomuzu olusturur
                da.Fill(ds);    //data adapter'in icini data set ile doldurdum
                dataGridView1.DataSource = ds.Tables[0];    //son olarakta formdaki data grid view aracına sql tablomu 0. indistan itibaren yazdırdım 
                fill(); //dataGridView1'deki sutunlarimizi otomatik olarak sigdiran fonksiyonumuzu cagiriyoruz
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); baglanti.Close(); }
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            this.Close();   //yalnizca bu formun kapatilmasini gerceklestiriyoruz
        }

        private void cbOkuduguFakulte_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] tipSiniflar = { "Hazırlık Sınıfı", "1. Sınıf", "2. Sınıf", "3. Sınıf", "4. Sınıf", "5. Sınıf", "6. Sınıf", "Mezun" };  //Siniflari kod tekrari olmamasi acisindan diziye aktariyoruz

            cbOkuduguBolum.Items.Clear();   //secilen fakultenin degismesi durumunda cbOkuduguBolum listesinin verilerini temizleyip karisikligi onlemis oluyoruz

            switch (cbOkuduguFakulte.SelectedItem)  //Okudugu Fakulteyi comboBox'tan sectiginde bu donguye giriyoruz
            {
                case "Tıp Fakültesi":   //Eger tip fakultesi secildiyse...
                    cbOkuduguBolum.Items.Add("Tıp");    //Tip fakultesinde tek bolum olan tip bolumunu cbOkuduguBolum listesine ekliyoruz
                    cbSinifi.Items.Clear(); //yalnizca tip bolumunda 6 yil okundugu icin onceden farkli bir bolum secilip sonra tekrardan tip bolumunun secilmesi durumuna karsi listeyi temizliyoruz
                    cbSinifi.Items.AddRange(tipSiniflar);   //tip siniflarini siniflar comboboxuna ekliyoruz 
                    break;
                case "Sağlık Bilimleri Fakültesi":  //Eger saglik bilimleri fakultesi secildiyse...
                    cbOkuduguBolum.Items.Add("Hemşirelik"); //hemsirelik bolumunu bolum comboBox'una dahil ediyoruz
                    cbOkuduguBolum.Items.Add("Sosyal Hizmet");  //Sosyal Hizmet bolumunu bolum comboBox'una dahil ediyoruz
                    break;
                case "Eğitim Fakültesi":    //eger egitim fakultesi secildiyse...
                    string[] egitimFakultesiBolumleri = { "Fen Bilgisi Öğretmenliği", "İlköğretim Matematik Öğretmenliği", "İngilizce Öğretmenliği",
                                                          "Okul Öncesi Öğretmenliği", "Özel Eğitim Öğretmenliği", "Rehberlik ve Psikolojik Danışmanlık",
                                                          "Sınıf Öğretmenliği", "Türkçe Öğretmenliği"}; //bu fakultedeki bolumler kod tekrari olmamasi acisindan diziye aktariliyor
                    cbOkuduguBolum.Items.AddRange(egitimFakultesiBolumleri);    //dizideki bolum isimleri cbOkuduguBolum'un verilerine ekleniyor
                    break;
                case "Fen-Edebiyat Fakültesi":  //fen-edebiyat fakultesi secildiyse...
                    string[] fenEdebiyatBolumleri = { "Arkeoloji", "Biyoloji", "Çerkez Dili ve Kültürü", "Felsefe", "Gürcü Dili ve Edebiyatı", "Kimya",
                                                      "Matematik", "Psikoloji", "Sosyoloji", "Tarih", "Türk Dili ve Edebiyatı" };   //bu fakultedeki bolumler kod tekrari olmamasi acisindan diziye aktariliyor
                    cbOkuduguBolum.Items.AddRange(fenEdebiyatBolumleri);    //dizideki bolum isimleri cbOkuduguBolum'un verilerine ekleniyor
                    break;
                case "İlahiyat Fakültesi":  //ilahiyat fakultesi secildiyse...
                    cbOkuduguBolum.Items.Add("İlahiyat");   //bu fakultedeki tek bolum olan ilahiyat bolumu cbOkuduguBolum'un verilerine ekleniyor
                    break;
                case "İşletme Fakültesi":   //isletme fakultesi secildiyse...
                    string[] isletmeBolumleri = { "Gastronomi ve Mutfak Sanatları", "İşletme", "Sağlık Yönetimi", "Sigortacılık ve Sosyal Güvenlik", "Turizm İşletmeciliği",
                                                  "Uluslararası Ticaret ve Finansman" ,"Yönetim Bilişim Sistemleri" };  //bu fakultedeki bolumler kod tekrari olmamasi acisindan diziye aktariliyor
                    cbOkuduguBolum.Items.AddRange(isletmeBolumleri);    //dizideki bolum isimleri cbOkuduguBolum'un verilerine ekleniyor
                    break;
                case "Mühendislik Fakültesi":   //muhendislik fakultesi secildiyse...
                    string[] muhendislikBolumleri = { "Bilgisayar Mühendisliği", "Biyomedikal Mühendisliği", "Elektrik-Elektronik Mühendisliği", "Endüstri Mühendisliği",
                                                      "İnşaat Mühendisliği", "Makine Mühendisliği", "Mekatronik Mühendisliği" };    //bu fakultedeki bolumler kod tekrari olmamasi acisindan diziye aktariliyor
                    cbOkuduguBolum.Items.AddRange(muhendislikBolumleri);    //dizideki bolum isimleri cbOkuduguBolum'un verilerine ekleniyor
                    break;
                case "Orman Fakültesi": //orman fakultesi secildiyse...
                    cbOkuduguBolum.Items.Add("Ağaç İşleri Endüstri Mühendisliği");  //bolum cbOkuduguBolum'un verilerine ekleniyor
                    cbOkuduguBolum.Items.Add("Orman Endüstri Mühendisliği");        //bolum cbOkuduguBolum'un verilerine ekleniyor
                    cbOkuduguBolum.Items.Add("Orman Mühendisliği");                 //bolum cbOkuduguBolum'un verilerine ekleniyor
                    cbOkuduguBolum.Items.Add("Peyzaj Mimarlığı");                   //bolum cbOkuduguBolum'un verilerine ekleniyor
                    break;  
                case "Sanat, Tasarım ve Mimarlık Fakültesi": //sanat, tasarim ve mimarlik fakultesi secildiyse...
                    cbOkuduguBolum.Items.Add("Mimarlık");                               //bolum cbOkuduguBolum'un verilerine ekleniyor
                    cbOkuduguBolum.Items.Add("Radyo, Televizyon ve Sinema");            //bolum cbOkuduguBolum'un verilerine ekleniyor
                    cbOkuduguBolum.Items.Add("Tiyatro Eleştirmenliği ve Dramaturji");   //bolum cbOkuduguBolum'un verilerine ekleniyor
                    break;
                case "Teknoloji Fakültesi": //teknoloji fakultesi secildiyse
                    cbOkuduguBolum.Items.Add("Bilgisayar Mühendisliği");    //bu fakultedeki tek bolum olan bilgisayar muhendisligi bolumu cbOkuduguBolum'un verilerine ekleniyor
                    break;
                default:
                    cbOkuduguBolum.Items.Add("Bitki Koruma");               //bolum cbOkuduguBolum'un verilerine ekleniyor
                    cbOkuduguBolum.Items.Add("Biyosistem Mühendisliği");    //bolum cbOkuduguBolum'un verilerine ekleniyor
                    cbOkuduguBolum.Items.Add("Tarımsal Biyoteknoloji");     //bolum cbOkuduguBolum'un verilerine ekleniyor
                    cbOkuduguBolum.Items.Add("Tarla Bitkileri");            //bolum cbOkuduguBolum'un verilerine ekleniyor
                    break;
            }

            cbOkuduguBolum.Enabled = true;  //cbOkuduguBolum aktif hale getiriliyor boylece zincirleme ilerleme saglanmaya calisiyoruz
        }

        private void cbOkuduguBolum_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbSinifi.Enabled = true;    //kullanici comboBox'tan bolumu de sectikten sonra cbSinifi aktif hale getiriliyor yani zincirin son halkasi calisir hale geliyor
        }

        private void tbOgrenciNumarasi_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (tbOgrenciNumarasi.Text != null) //ogrenci Numarasi bos olarak gecilmediyse bu bloga giriyoruz
                {
                    if (sayiMi(tbOgrenciNumarasi.Text) == true) //girilen ifadenin sayi mi olup olmadigini kontrol ediyoruz ve sayiysa bu bloga giriyoruz
                    {
                        if (tbOgrenciNumarasi.Text.Length != 9) //girilen ifadenin uzunlugu 9'a esit degilse bu bloga giriyoruz ve kullaniciyi uyariyoruz
                        {
                            MessageBox.Show("Öğrenci Numarası 192114021 şeklinde olmalıdır \n" + "Harf ve özel karakter içermemelidir \n" + "Bu alan boş geçilemez", "Girdi Hatası");
                            e.Cancel = true;    //ifade, istenilen sekilde girilene kadar bu hata mesajinin cikmasini sagliyoruz boylece veritabanina hatali bir veri girerek programin cokmesini engelliyoruz
                        }
                    }
                    else if (sayiMi(tbOgrenciNumarasi.Text) == false)   //girilen ifadenin yalnizca sayi olmasi icin kullaniciyi uyariyoruz
                    {
                        MessageBox.Show("Öğrenci Numarası 192114021 şeklinde olmalıdır \n" + "Harf ve özel karakter içermemelidir\n" + "Bu alan boş geçilemez", "Girdi Hatası");
                        e.Cancel = true;    //ifade, istenilen sekilde girilene kadar bu hata mesajinin cikmasini sagliyoruz boylece veritabanina hatali bir veri girerek programin cokmesini engelliyoruz
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void tbIsmi_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (tbIsmi.Text != null)    //ogrencinin ismi bos olarak gecilmediyse bu bloga giriyoruz
                {
                    if(sayiMi(tbIsmi.Text) == false)    //girilen ifadenin sayi mi olup olmadigini kontrol ediyoruz ve sayi degilse bu bloga giriyoruz
                    {
                        if (tbIsmi.Text.Length > 50)    //50 karakterden uzun olan veri girislerini engelliyoruz. Boylece veritabanini korumaya devam ediyoruz
                        {
                            MessageBox.Show("Öğrenci ismi 50 karakterden uzun olmamalıdır \n" + "Bu alan boş geçilemez \n" + "Lütfen kontrol ediniz", "Girdi Hatası");
                        }
                    }
                    else if (sayiMi(tbIsmi.Text) == true)   //girilen ifadenin sayi ve ozel karakter icermemesi icin kullaniciyi uyariyoruz
                    {
                        MessageBox.Show("Öğrenci ismi Mustafa Burak şeklinde olmalıdır \n" + "Sayı ve özel karakter içermemelidir\n" + "Bu alan boş geçilemez", "Girdi Hatası");
                        e.Cancel = true;    //ifade, istenilen sekilde girilene kadar bu hata mesajinin cikmasini sagliyoruz boylece veritabanina hatali bir veri girerek programin cokmesini engelliyoruz
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void tbSoyismi_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (tbSoyismi.Text != null) //ogrencinin soyismi bos olarak gecilmediyse bu bloga giriyoruz
                {
                    if (sayiMi(tbSoyismi.Text) == false)    //girilen ifadenin sayi mi olup olmadigini kontrol ediyoruz ve sayi degilse bu bloga giriyoruz
                    {
                        if (tbSoyismi.Text.Length > 50) //50 karakterden uzun olan veri girislerini engelliyoruz. Boylece veritabanini korumaya devam ediyoruz
                        {
                            MessageBox.Show("Öğrenci soyismi 50 karakterden uzun olmamalıdır \n" + "Bu alan boş geçilemez \n" + "Lütfen kontrol ediniz", "Girdi Hatası");
                        }
                    }
                    else if (sayiMi(tbSoyismi.Text) == true)    //girilen ifadenin sayi ve ozel karakter icermemesi icin kullaniciyi uyariyoruz
                    {
                        MessageBox.Show("Öğrenci soyismi Sert şeklinde olmalıdır \n" + "Sayı ve özel karakter içermemelidir\n" + "Bu alan boş geçilemez", "Girdi Hatası");
                        e.Cancel = true;    //ifade, istenilen sekilde girilene kadar bu hata mesajinin cikmasini sagliyoruz boylece veritabanina hatali bir veri girerek programin cokmesini engelliyoruz
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void tbTelefonNumarasi_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (tbTelefonNumarasi.Text != null) //ogrencinin telefon numarasi olarak gecilmediyse bu bloga giriyoruz
                {
                    if (sayiMi(tbTelefonNumarasi.Text) == true) //girilen ifadenin sayi mi olup olmadigini kontrol ediyoruz eger sayiysa bu bloga giriyoruz
                    {
                        if (tbTelefonNumarasi.Text.Length != 10)    //girilen ifadenin uzunlugu 10'a esit degilse bu bloga giriyoruz ve kullaniciyi uyariyoruz
                        {
                            MessageBox.Show("Telefon Numarası 5431234567 şeklinde olmalıdır \n" + "Bu alan boş geçilemez \n" + "Lütfen kontrol ediniz", "Girdi Hatası");
                            e.Cancel = true;    //ifade, istenilen sekilde girilene kadar bu hata mesajinin cikmasini sagliyoruz boylece veritabanina hatali bir veri girerek programin cokmesini engelliyoruz
                        }
                    }
                    else if (sayiMi(tbTelefonNumarasi.Text) == false)   //girilen ifadenin yalnizca sayi icermesi icin kullaniciyi uyariyoruz
                    {
                        MessageBox.Show("Telefon Numarası 5431234567 şeklinde olmalıdır \n" + "Harf ve özel karakter içermemelidir \n" + "Bu alan boş geçilemez \n" + "Lütfen kontrol ediniz", "Girdi Hatası");
                        e.Cancel = true;    //ifade, istenilen sekilde girilene kadar bu hata mesajinin cikmasini sagliyoruz boylece veritabanina hatali bir veri girerek programin cokmesini engelliyoruz
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
