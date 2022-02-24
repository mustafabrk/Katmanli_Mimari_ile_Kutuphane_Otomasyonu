using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; //SQL komutlarını aktif edebilmem için gerekli olan kütüphaneyi çağırdım

namespace Final
{
    public partial class KitapIslemleri : Form
    {
        public KitapIslemleri()
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
            this.dataGridView1.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;   //dataGridView1'deki sutunlarimizi otomatik sigdiriyoruz
            this.dataGridView1.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;   //dataGridView1'deki sutunlarimizi otomatik sigdiriyoruz
        }

        bool sayiMi(string text)    //textboxlara girilen ifadelerin sayi olup olmadigini kontrol eden kod blogu burada yer almaktadir
        {
            foreach (char chr in text)
            {
                if (!Char.IsNumber(chr)) return false; //ifade sayi degilse false donduruyoruz
            }
            return true;
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

        private void KitapIslemleri_Load(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(bglnt.Adres);    //baglanti adresimizi baglanti sinifindaki adresten cekiyoruz

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from Kitap", baglanti);    //data set ile veritabani arasinda kopru gorevi gorur. Kitap tablosunun tum sutunlarini secer
                DataSet ds = new DataSet(); //sanal tablomuzu olusturuyoruz
                da.Fill(ds);    //data adapter'in icini data set ile dolduruyoruz
                dataGridView1.DataSource = ds.Tables[0];    //son olarak da formdaki data grid view aracına sql tablomu 0. indisten itibaren yazdiriyoruz

                string[] kitapTurleri = {"BOŞ", "Anı", "Anlatı", "Araştırma-İnceleme", "Bilim", "Biyografi", "Çizgi Roman", "Deneme", "Edebiyat", "Eğitim", "Fantastik/Bilim Kurgu",
                                     "Felsefe", "Gençlik", "Gezi", "Hikaye", "Hobi", "İnceleme", "İş Ekonomi - Hukuk", "Kişisel Gelişim", "Konuşmalar", "Kurgu", "Masal", "Mizah",
                                     "Öykü", "Polisiye", "Psikoloji", "Resimli Öykü", "Roman", "Sağlık", "Sanat-Tasarım", "Sanat-Müzik", "Sinema Tarihi", "Sosyoloji",
                                     "Söyleşi", "Şiir", "Tarih", "Tiyatro", "Yemek Kitapları"}; //kitap turlerini kod tekrari olmaması icin diziye aktariyoruz
                cbKitapTuru.Items.AddRange(kitapTurleri); //ardından dizimi cagirarak combo boxa kitap türlerini ekliyoruz
                cbKitapTuru.SelectedIndex = 0;  //combo boxun ilk elemaninin secili olmasini saglaniyor

                baglanti.Open();    //veritabani ile kodun arasındaki baglantiyi aciyoruz
                SqlCommand toplamKitap = new SqlCommand("select sum(KitapAdedi) from Kitap", baglanti); //Kitap tablosundan KitapAdedi sutununu degerlerini secen nesneyi olusturuyoruz 
                SqlDataReader oku = toplamKitap.ExecuteReader();    //Olusturdugumuz toplamKitap nesnesinden verileri okuyan ve listeleyen atamayi gerceklestiriyoruz
                while (oku.Read())  //okuma islemi gerceklestiginde lblToplamKitapAdedi'nin textine yazdiriliyor
                {
                    lblMevcutKitapAdedi.Text = oku[0].ToString();
                }
                baglanti.Close();   //veritabani ile kodun arasindaki baglantiyi kapatiyoruz

                fill(); //dataGridView1'deki sutunlarimizi otomatik olarak sigdiran fonksiyonumuzu cagiriyoruz
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); baglanti.Close(); }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(bglnt.Adres);    //baglanti adresimizi baglanti sinifindaki adresten cekiyoruz

            try
            {
                baglanti.Open();    //veritabani ile kodun arasındaki baglantiyi actim
                SqlCommand kayitEkle = new SqlCommand("insert into Kitap(BarkodNo, KitapAdi, YazarAdi, YayinEvi, BasimYili, KitapTuru, SayfaSayisi, CevirmenAdi, KitapRafYeri, KitapAdedi) " +
                                                      "values (@k1, @k2, @k3, @k4, @k5, @k6, @k7, @k8, @k9, @k10)", baglanti);  //sql'in kayit ekleme kodunun atamalarini c# uzerinden  gerceklestirdim. Denk gelen sutun adlarina @ ifadesiyle atama yapan nesneyi olusturuyoruz
                kayitEkle.Parameters.AddWithValue("@k1", tbBarkodNo.Text);      //yaptigimiz atamalarin degerlerini de formdaki text box ve comboboxtaki text degerlerine esitliyoruz
                kayitEkle.Parameters.AddWithValue("@k2", tbKitapAdi.Text);      //yaptigimiz atamalarin degerlerini de formdaki text box ve comboboxtaki text degerlerine esitliyoruz
                kayitEkle.Parameters.AddWithValue("@k3", tbYazarAdi.Text);      //yaptigimiz atamalarin degerlerini de formdaki text box ve comboboxtaki text degerlerine esitliyoruz
                kayitEkle.Parameters.AddWithValue("@k4", tbYayinevi.Text);      //yaptigimiz atamalarin degerlerini de formdaki text box ve comboboxtaki text degerlerine esitliyoruz
                kayitEkle.Parameters.AddWithValue("@k5", tbBasimYili.Text);     //yaptigimiz atamalarin degerlerini de formdaki text box ve comboboxtaki text degerlerine esitliyoruz
                kayitEkle.Parameters.AddWithValue("@k6", cbKitapTuru.Text);     //yaptigimiz atamalarin degerlerini de formdaki text box ve comboboxtaki text degerlerine esitliyoruz
                kayitEkle.Parameters.AddWithValue("@k7", tbSayfaSayisi.Text);   //yaptigimiz atamalarin degerlerini de formdaki text box ve comboboxtaki text degerlerine esitliyoruz
                kayitEkle.Parameters.AddWithValue("@k8", tbCevirmenAdi.Text);   //yaptigimiz atamalarin degerlerini de formdaki text box ve comboboxtaki text degerlerine esitliyoruz
                kayitEkle.Parameters.AddWithValue("@k9", tbKitapRafYeri.Text);  //yaptigimiz atamalarin degerlerini de formdaki text box ve comboboxtaki text degerlerine esitliyoruz
                kayitEkle.Parameters.AddWithValue("@k10", tbKitapAdedi.Text);   //yaptigimiz atamalarin degerlerini de formdaki text box ve comboboxtaki text degerlerine esitliyoruz

                kayitEkle.ExecuteNonQuery();    //atamasini yapilan sql kayit ekleme komutunun calismasini sagliyoruz

                MessageBox.Show("Kitap Kaydedildi");  

                SqlDataAdapter da = new SqlDataAdapter("Select * from Kitap", baglanti); //data set ile veritabani arasinda kopru gorevi gorur. Kitap tablosunun tum sutunlarini secer
                DataSet ds = new DataSet(); //sanal tablomuzu olusturur
                da.Fill(ds);    //data adapter'in icini data set ile doldurdum
                dataGridView1.DataSource = ds.Tables[0];    //son olarakta formdaki data grid view aracına sql tablomu 0. indistan itibaren yazdırdım 
                                                            //Bu islemleri tabloda yapilan degisiklikleri tekrar ekrana yazdirmak icin yapiyoruz
                fill(); //dataGridView1'deki sutunlarimizi otomatik olarak sigdiran fonksiyonumuzu cagiriyoruz
                baglanti.Close();   //veritabani ile kodun arasindaki baglantiyi kapattim
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); baglanti.Close(); }

        }

        private void btnSil_Click(object sender, EventArgs e)   //silme islemini gerceklesitren kod blogu. Silme islemi kitabin barkod no'suna göre yapilmistir
        {
            SqlConnection baglanti = new SqlConnection(bglnt.Adres);    //baglanti adresimizi baglanti sinifindaki adresten cekiyoruz

            try
            {
                if (tbBarkodNo.Text == string.Empty)    //barkodNo'nun yer aldigi textbox bossa bu kosula girer
                {
                    MessageBox.Show("Lütfen silmek istediğiniz kitabın yalnızca Barkod Numarasını giriniz", "Girdi Hatası");
                }
                else if(sayiMi(tbBarkodNo.Text) == true)    //barkodNo'ya girilen degerin sayi olup olmadigi kontrol ediliyor. Eger sayiysa bu bloga giriyor
                {
                    if (tbBarkodNo.Text.Length != 5)
                    {
                        MessageBox.Show("Lütfen 5 haneli Barkod Numarasını hatasız girdiğinizden emin olun", "Girdi Hatası");
                    }
                    else if (tbBarkodNo.Text.Length == 5)
                    {
                        baglanti.Open();    //veritabani ile kodun arasındaki baglantiyi actim
                        SqlCommand komutSil1 = new SqlCommand("Delete From Kitap where BarkodNo = @barkod", baglanti);  //sql uzerinden komut silme islemini gerceklestirecek kod tanimlandi. Adresi ise kitap BarkodNo'sundan tayin edildi
                        SqlCommand komutSil2 = new SqlCommand("Delete From Emanet where BarkodNo = @barkod", baglanti); //Eger kitap silinirse kitaba ait emanet bilgileri de siliniyor
                        komutSil1.Parameters.AddWithValue("@barkod", tbBarkodNo.Text);   // hangi kitabin silinecegini girilen barkod numarasina göre gerceklestirecek kod 
                        komutSil2.Parameters.AddWithValue("@barkod", tbBarkodNo.Text);   // girilen barkodNo'ya denk gelen emanet edilmis kitap da siliniyor
                        komutSil2.ExecuteNonQuery();    //silme kodlarini aktif hale getiren komut
                        komutSil1.ExecuteNonQuery();    //silme kodlarini aktif hale getiren komut

                        MessageBox.Show("Kitap Silindi");

                        SqlDataAdapter da = new SqlDataAdapter("Select * from Kitap", baglanti); //data set ile veritabani arasinda kopru gorevi gorur. Kitap tablosunun tum sutunlarini secer
                        DataSet ds = new DataSet();     //sanal tablomuzu olusturur
                        da.Fill(ds);    //data adapter'in icini data set ile doldurdum
                        dataGridView1.DataSource = ds.Tables[0];    //son olarakta formdaki data grid view aracına sql tablomu 0. indistan itibaren yazdiriyoruz
                        fill(); //dataGridView1'deki sutunlarimizi otomatik olarak sigdiran fonksiyonumuzu cagiriyoruz

                        baglanti.Close();   //veritabani ile kodun arasindaki baglantiyi kapatiyoruz
                    }
                    else
                    {
                        MessageBox.Show("Lütfen 5 karakterli yazdığınızdan emin olun", "Girdi Hatası");
                    }
                }
                else
                {
                    MessageBox.Show("Hatalı Barkod Numarası girdiniz \n" + "Silme işlemi gerçekleştirilemedi...", "Girdi Hatası");
                }
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); baglanti.Close(); }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;  //dataGridView uzerinden secilen hucrenin bulundugu tum satiri secili hale getiriyor

            string barkodNo = dataGridView1.Rows[secilen].Cells[0].Value.ToString();        //secili hale gelen her bir hucreye karsilik gelen ifadeler string degiskenine donusturuluyor
            string kitapAdi = dataGridView1.Rows[secilen].Cells[1].Value.ToString();        //secili hale gelen her bir hucreye karsilik gelen ifadeler string degiskenine donusturuluyor
            string yazarAdi = dataGridView1.Rows[secilen].Cells[2].Value.ToString();        //secili hale gelen her bir hucreye karsilik gelen ifadeler string degiskenine donusturuluyor
            string yayinevi = dataGridView1.Rows[secilen].Cells[3].Value.ToString();        //secili hale gelen her bir hucreye karsilik gelen ifadeler string degiskenine donusturuluyor
            string basimYili = dataGridView1.Rows[secilen].Cells[4].Value.ToString();       //secili hale gelen her bir hucreye karsilik gelen ifadeler string degiskenine donusturuluyor
            string kitapTuru = dataGridView1.Rows[secilen].Cells[5].Value.ToString();       //secili hale gelen her bir hucreye karsilik gelen ifadeler string degiskenine donusturuluyor
            string sayfaSayisi = dataGridView1.Rows[secilen].Cells[6].Value.ToString();     //secili hale gelen her bir hucreye karsilik gelen ifadeler string degiskenine donusturuluyor
            string cevirmenAdi = dataGridView1.Rows[secilen].Cells[7].Value.ToString();     //secili hale gelen her bir hucreye karsilik gelen ifadeler string degiskenine donusturuluyor
            string kitapRafYeri = dataGridView1.Rows[secilen].Cells[8].Value.ToString();    //secili hale gelen her bir hucreye karsilik gelen ifadeler string degiskenine donusturuluyor
            string kitapAdedi = dataGridView1.Rows[secilen].Cells[9].Value.ToString();      //secili hale gelen her bir hucreye karsilik gelen ifadeler string degiskenine donusturuluyor
                                                                                            
            tbBarkodNo.Text = barkodNo;         //secili hale gelen tum hucrelerin degerleri textBox'lara ve comboBox'lara aktariliyor
            tbKitapAdi.Text = kitapAdi;         //secili hale gelen tum hucrelerin degerleri textBox'lara ve comboBox'lara aktariliyor
            tbYazarAdi.Text = yazarAdi;         //secili hale gelen tum hucrelerin degerleri textBox'lara ve comboBox'lara aktariliyor
            tbYayinevi.Text = yayinevi;         //secili hale gelen tum hucrelerin degerleri textBox'lara ve comboBox'lara aktariliyor
            tbBasimYili.Text = basimYili;       //secili hale gelen tum hucrelerin degerleri textBox'lara ve comboBox'lara aktariliyor
            cbKitapTuru.Text = kitapTuru;       //secili hale gelen tum hucrelerin degerleri textBox'lara ve comboBox'lara aktariliyor
            tbSayfaSayisi.Text = sayfaSayisi;   //secili hale gelen tum hucrelerin degerleri textBox'lara ve comboBox'lara aktariliyor
            tbCevirmenAdi.Text = cevirmenAdi;   //secili hale gelen tum hucrelerin degerleri textBox'lara ve comboBox'lara aktariliyor
            tbKitapRafYeri.Text = kitapRafYeri; //secili hale gelen tum hucrelerin degerleri textBox'lara ve comboBox'lara aktariliyor
            tbKitapAdedi.Text = kitapAdedi;     //secili hale gelen tum hucrelerin degerleri textBox'lara ve comboBox'lara aktariliyor
                                                //boylece guncelleme ve silme islemleri daha kullanisli ve basit hale geliyor
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(bglnt.Adres);    //baglanti adresimizi baglanti sinifindaki adresten cekiyoruz

            try
            {
                baglanti.Open();    //veritabani ile kodun arasindaki baglantiyi actim
                SqlCommand komutGuncelle = new SqlCommand("update Kitap set BarkodNo = @kg1, KitapAdi = @kg2, YazarAdi = @kg3, YayinEvi = @kg4, BasimYili = @kg5, KitapTuru = @kg6," +
                                                          " SayfaSayisi = @kg7, CevirmenAdi = @kg8, KitapRafYeri = @kg9, KitapAdedi = @kg10 where BarkodNo = @kg1", baglanti);  //sql'in kayit guncelleme kodunun atamalarini c# uzerinden  gerceklestirdim. Denk gelen sutun adlarina @ ifadesiyle atama yapan nesneyi olusturuyoruz
                komutGuncelle.Parameters.AddWithValue("@kg1", tbBarkodNo.Text);     //yaptigimiz atamalarin degerlerini de formdaki textBox ve comboBox'taki degerlerine esitliyoruz
                komutGuncelle.Parameters.AddWithValue("@kg2", tbKitapAdi.Text);     //yaptigimiz atamalarin degerlerini de formdaki textBox ve comboBox'taki degerlerine esitliyoruz
                komutGuncelle.Parameters.AddWithValue("@kg3", tbYazarAdi.Text);     //yaptigimiz atamalarin degerlerini de formdaki textBox ve comboBox'taki degerlerine esitliyoruz
                komutGuncelle.Parameters.AddWithValue("@kg4", tbYayinevi.Text);     //yaptigimiz atamalarin degerlerini de formdaki textBox ve comboBox'taki degerlerine esitliyoruz
                komutGuncelle.Parameters.AddWithValue("@kg5", tbBasimYili.Text);    //yaptigimiz atamalarin degerlerini de formdaki textBox ve comboBox'taki degerlerine esitliyoruz
                komutGuncelle.Parameters.AddWithValue("@kg6", cbKitapTuru.Text);    //yaptigimiz atamalarin degerlerini de formdaki textBox ve comboBox'taki degerlerine esitliyoruz
                komutGuncelle.Parameters.AddWithValue("@kg7", tbSayfaSayisi.Text);  //yaptigimiz atamalarin degerlerini de formdaki textBox ve comboBox'taki degerlerine esitliyoruz
                komutGuncelle.Parameters.AddWithValue("@kg8", tbCevirmenAdi.Text);  //yaptigimiz atamalarin degerlerini de formdaki textBox ve comboBox'taki degerlerine esitliyoruz
                komutGuncelle.Parameters.AddWithValue("@kg9", tbKitapRafYeri.Text); //yaptigimiz atamalarin degerlerini de formdaki textBox ve comboBox'taki degerlerine esitliyoruz
                komutGuncelle.Parameters.AddWithValue("@kg10", tbKitapAdedi.Text);  //yaptigimiz atamalarin degerlerini de formdaki textBox ve comboBox'taki degerlerine esitliyoruz

                komutGuncelle.ExecuteNonQuery();    //atamasi yapilan sql kayit guncelleme komutunun calismasini sagliyoruz

                MessageBox.Show("Kitap Güncellendi");

                SqlDataAdapter da = new SqlDataAdapter("Select * from Kitap", baglanti); //data set ile veritabani arasinda kopru gorevi gorur. Kitap tablosunun tum sutunlarini secer
                DataSet ds = new DataSet();     //sanal tablomuzu olusturur
                da.Fill(ds);    //data adapter'in icini data set ile doldurdum
                dataGridView1.DataSource = ds.Tables[0];    //son olarakta formdaki data grid view aracına sql tablomu 0. indistan itibaren yazdiriyoruz
                fill(); //dataGridView1'deki sutunlarimizi otomatik olarak sigdiran fonksiyonumuzu cagiriyoruz

                baglanti.Close();   //veritabani ile kodun arasindaki baglantiyi kapattim
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); baglanti.Close(); }
        }

        private void btnFiltrele_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(bglnt.Adres);    //baglanti adresimizi baglanti sinifindaki adresten cekiyoruz

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from Kitap where KitapAdi = '" + tbFiltreleKitapAdi.Text + "'", baglanti); //Kitap tablosundan kitapAdi girilen degerin satiri seciliyor
                DataSet ds = new DataSet();     //sanal tablomuzu olusturur
                da.Fill(ds);    //data adapter'in icini data set ile doldurdum
                dataGridView1.DataSource = ds.Tables[0];    //son olarakta formdaki data grid view aracına sql tablomu 0. indistan itibaren yazdiriyoruz
                fill(); //dataGridView1'deki sutunlarimizi otomatik olarak sigdiran fonksiyonumuzu cagiriyoruz

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnKitapEmanetListele_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(bglnt.Adres);    //baglanti adresimizi baglanti sinifindaki adresten cekiyoruz

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from Emanet where BarkodNo = '" + tbListeleBarkodNo.Text + "'", baglanti); //Emanet tablosundan barkodNo'su girilen degerin satiri seciliyor
                DataSet ds = new DataSet();     //sanal tablomuzu olusturur
                da.Fill(ds);    //data adapter'in icini data set ile doldurdum
                dataGridView1.DataSource = ds.Tables[0];    //son olarakta formdaki data grid view aracına sql tablomu 0. indistan itibaren yazdiriyoruz
                fill(); //dataGridView1'deki sutunlarimizi otomatik olarak sigdiran fonksiyonumuzu cagiriyoruz

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

        private void btnKitaplariListele_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(bglnt.Adres);    //baglanti adresimizi baglanti sinifindaki adresten cekiyoruz

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from Kitap", baglanti); //data set ile veritabani arasinda kopru gorevi gorur. Kitap tablosunun tum sutunlarini secer
                DataSet ds = new DataSet();     //sanal tablomuzu olusturur
                da.Fill(ds);    //data adapter'in icini data set ile doldurdum
                dataGridView1.DataSource = ds.Tables[0];    //son olarakta formdaki data grid view aracına sql tablomu 0. indistan itibaren yazdiriyoruz
                fill(); //dataGridView1'deki sutunlarimizi otomatik olarak sigdiran fonksiyonumuzu cagiriyoruz

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); baglanti.Close(); }
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbBarkodNo_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if(tbBarkodNo.Text != null) //barkodNo boş olarak gecilmediyse bu bloga giriyoruz
                {
                    if (sayiMi(tbBarkodNo.Text) == true)    //girilen ifadenin sayi mi olup olmadigini kontrol ediyoruz ve sayiysa bu bloga giriyoruz
                    {
                        if (tbBarkodNo.Text.Length != 5)    //girilen ifadenin uzunlugu 5'e esit degilse bu bloga giriyoruz ve kullaniciyi uyariyoruz
                        {
                            MessageBox.Show("Barkod Numarası 00023 şeklinde olmalıdır \n" + "Harf ve özel karakter içermemelidir \n" + "Bu alan boş geçilemez", "Girdi Hatası");
                            e.Cancel = true;    //ifade, istenilen sekilde girilene kadar bu hata mesajinin cikmasini sagliyoruz boylece veritabanina hatali bir veri girerek programin cokmesini engelliyoruz
                        }
                    }
                    else if (sayiMi(tbBarkodNo.Text) == false)  //girilen ifadenin yalnizca sayi olmasi icin kullaniciyi uyariyoruz
                    {
                        MessageBox.Show("Barkod Numarası 00023 şeklinde olmalıdır \n" + "Harf ve özel karakter içermemelidir\n" + "Bu alan boş geçilemez", "Girdi Hatası");
                        e.Cancel = true;    //ifade, istenilen sekilde girilene kadar bu hata mesajinin cikmasini sagliyoruz boylece veritabanina hatali bir veri girerek programin cokmesini engelliyoruz
                    }
                }
            } catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void tbKitapAdi_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (tbKitapAdi.Text != null)    //kitapAdi bos olarak gecilmediyse bu bloga giriyoruz
                {
                    if(tbKitapAdi.Text.Length > 50) //50 karakterden uzun kitap adlarinin girisini engelliyoruz. Boylece veritabanini korumaya devam ediyoruz
                    {
                        MessageBox.Show("Kitap adı 50 karakterden uzun olmamalıdır \n" + "Bu alan boş geçilemez \n" + "Lütfen kontrol ediniz", "Girdi Hatası");
                    }
                }
            } catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void tbYazarAdi_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (tbYazarAdi.Text != null)    //yazarAdi bos olarak gecilmediyse bu bloga giriyoruz
                {
                    if (sayiMi(tbYazarAdi.Text) == true)    //girilen degerin sayi olup olmadigini kontrol ediyoruz. Sayiysa bu bloga giriyoruz
                    {
                        MessageBox.Show("Yazar adı özel karakter veya sayı içermemelidir \n" + "Bu alan boş geçilemez \n" + "Lütfen kontrol ediniz", "Girdi Hatası");
                        e.Cancel = true;    //ifade, istenilen sekilde girilene kadar bu hata mesajinin cikmasini sagliyoruz boylece veritabanina hatali bir veri girerek programin cokmesini engelliyoruz
                    }
                    else if (tbYazarAdi.Text.Length > 50)   //50 karakterden uzun yazar adlarinin girisini engelliyoruz. Boylece veritabanini korumaya devam ediyoruz
                    {
                        MessageBox.Show("Yazar adı 50 karakterden uzun olmamalıdır \n" + "Bu alan boş geçilemez \n" + "Lütfen kontrol ediniz", "Girdi Hatası");
                        e.Cancel = true;    //ifade, istenilen sekilde girilene kadar bu hata mesajinin cikmasini sagliyoruz boylece veritabanina hatali bir veri girerek programin cokmesini engelliyoruz
                    }
                }
            } catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void tbYayinevi_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (tbYayinevi.Text != null)    //yazarAdi bos olarak gecilmediyse bu bloga giriyoruz
                {
                    if (sayiMi(tbYayinevi.Text) == true)    //girilen degerin sayi olup olmadigini kontrol ediyoruz. Sayiysa bu bloga giriyoruz
                    {
                        MessageBox.Show("Yayınevi özel karakter veya sayı içermemelidir \n" + "Bu alan boş geçilemez \n" + "Lütfen kontrol ediniz", "Girdi Hatası");
                        e.Cancel = true;    //ifade, istenilen sekilde girilene kadar bu hata mesajinin cikmasini sagliyoruz boylece veritabanina hatali bir veri girerek programin cokmesini engelliyoruz
                    }
                    else if (tbYayinevi.Text.Length > 50)   //50 karakterden uzun yazar adlarinin girisini engelliyoruz. Boylece veritabanini korumaya devam ediyoruz
                    {
                        MessageBox.Show("Yayınevi 50 karakterden uzun olmamalıdır \n" + "Bu alan boş geçilemez \n" +"Lütfen kontrol ediniz", "Girdi Hatası");
                        e.Cancel = true;    //ifade, istenilen sekilde girilene kadar bu hata mesajinin cikmasini sagliyoruz boylece veritabanina hatali bir veri girerek programin cokmesini engelliyoruz
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void tbBasimYili_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (tbBasimYili.Text != null)   //basimYili bos olarak gecilmediyse bu bloga giriyoruz
                {
                    if (sayiMi(tbBasimYili.Text) == false)  //girilen degerin sayi olup olmadigini kontrol ediyoruz. Sayiysa bu bloga giriyoruz
                    {
                        MessageBox.Show("Basım yılı 2009 şeklinde olmalıdır \n" + "Bu alan boş geçilemez \n" + "Lütfen kontrol ediniz", "Girdi Hatası");
                        e.Cancel = true;    //ifade, istenilen sekilde girilene kadar bu hata mesajinin cikmasini sagliyoruz boylece veritabanina hatali bir veri girerek programin cokmesini engelliyoruz
                    }
                    else if (tbBasimYili.Text.Length != 4)  //girilen degerin 4 haneli olup olmadigini kontrol ediyoruz. 4 haneli degilse bu bloga giriyoruz
                    {
                        MessageBox.Show("Basım yılı 4 karakterden uzun veya kısa olmamalıdır \n" + "Bu alan boş geçilemez \n" + "Lütfen kontrol ediniz", "Girdi Hatası");
                        e.Cancel = true;    //ifade, istenilen sekilde girilene kadar bu hata mesajinin cikmasini sagliyoruz boylece veritabanina hatali bir veri girerek programin cokmesini engelliyoruz
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void tbSayfaSayisi_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (tbSayfaSayisi.Text != null) //SayfaSayisi bos olarak gecilmediyse bu bloga giriyoruz
                {
                    if (sayiMi(tbSayfaSayisi.Text) == false)    //girilen degerin sayi olup olmadigini kontrol ediyoruz. Sayi degilse bu bloga giriyoruz
                    {
                        MessageBox.Show("Sayfa sayısı 142 şeklinde olmalıdır \n" + "Bu alan boş geçilemez \n" + "Lütfen kontrol ediniz", "Girdi Hatası");
                        e.Cancel = true;    //ifade, istenilen sekilde girilene kadar bu hata mesajinin cikmasini sagliyoruz boylece veritabanina hatali bir veri girerek programin cokmesini engelliyoruz
                    }
                    if (tbSayfaSayisi.Text.Length > 4 && tbBasimYili.Text.Length < 1) //girilen degerin 10-9999 degerleri arasinda olup olmadigini kontrol ediyoruz
                    {
                        MessageBox.Show("Sayfa sayısı 9 ve 9999 sayıları arasında olmamalıdır \n" + "Bu alan boş geçilemez \n" + "Lütfen kontrol ediniz", "Girdi Hatası");
                        e.Cancel = true;    //ifade, istenilen sekilde girilene kadar bu hata mesajinin cikmasini sagliyoruz boylece veritabanina hatali bir veri girerek programin cokmesini engelliyoruz
                    }
                    else
                    {
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void tbKitapRafYeri_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (tbKitapRafYeri.Text != null)    //KitapRafYeri bos olarak gecilmediyse bu bloga giriyoruz
                {
                    if (tbKitapRafYeri.Text.Length > 50)    //50 karakterden uzun kitap raf yerlerinin girisini engelliyoruz
                    {
                        MessageBox.Show("Kitap raf yeri 50 karakterden uzun olmamalıdır \n" + "Bu alan boş geçilemez \n" + "Lütfen kontrol ediniz", "Girdi Hatası");
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void tbKitapAdedi_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (tbKitapAdedi.Text != null)  //KitapRafYeri bos olarak gecilmediyse bu bloga giriyoruz
                {
                    if (sayiMi(tbKitapAdedi.Text) == false)     //girilen degerin sayi olup olmadigini kontrol ediyoruz. Sayi degilse bu bloga giriyoruz
                    {
                        MessageBox.Show("Kitap adedi 12 şeklinde olmalıdır \n" + "Bu alan boş geçilemez \n" + "Lütfen kontrol ediniz", "Girdi Hatası");
                        e.Cancel = true;    //ifade, istenilen sekilde girilene kadar bu hata mesajinin cikmasini sagliyoruz boylece veritabanina hatali bir veri girerek programin cokmesini engelliyoruz
                    }
                    else if (tbKitapAdedi.Text.Length > 2 && tbBasimYili.Text.Length < 0)
                    {
                        MessageBox.Show("Kitap adedi 0 ve 99 sayıları arasında olmamalıdır \n" + "Bu alan boş geçilemez \n" + "Lütfen kontrol ediniz", "Girdi Hatası");
                        e.Cancel = true;    //ifade, istenilen sekilde girilene kadar bu hata mesajinin cikmasini sagliyoruz boylece veritabanina hatali bir veri girerek programin cokmesini engelliyoruz
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
