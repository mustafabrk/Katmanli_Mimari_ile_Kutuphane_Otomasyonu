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
    public partial class EmanetIslemleri : Form
    {
        public EmanetIslemleri()
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

        public void borcGuncelle()  //borc bilgisini bugunun tarihine gore guncelleyen metodu olusturuyoruz
        {
            SqlConnection baglanti = new SqlConnection(bglnt.Adres);    //baglanti adresimizi baglanti sinifindaki adresten cekiyoruz

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)  //tum satirlari dolasmamizi saglayan for dongusunu aciyoruz
            {
                DateTime bugun = DateTime.Now;  //bugunun tarih bilgilerini degiskene atiyoruz
                DateTime beklenenTarih = Convert.ToDateTime(dataGridView1.Rows[i].Cells[4].Value);  //beklenen tarihin bilgilerini dataGridView1'deki ilgili hucre degerinden aliyoruz
                TimeSpan gecenGunler = bugun - beklenenTarih;   //Kitaplarin teslim suresi 30 gun oldugundan bu zaman diliminde kullaniciya borc eklememek icin su anki tarihten beklenenTarih'i cikartiyoruz ve degiskene atiyoruz
                int borc = gecenGunler.Days;    //gecenGunler degiskenini borc degiskenine atiyoruz
                int ogrNo = Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value);    //ogrenci numarasi bilgilerini dataGridView1'deki ilgili hucre degerinden aliyoruz

                SqlCommand borcGuncelle = new SqlCommand("update Ogrenci set GecikmeUcreti = " + borc.ToString() + " where OgrenciNumarasi = '" + ogrNo.ToString() + "'", baglanti);   //sql'in kayit guncelleme kodunun atamalarini c# uzerinden  gerceklestiriyoruz

                if (bugun > beklenenTarih)    //bugunun beklenen tarihten buyuk olmasi durumunda yani kitabin gec kalmasi durumunda...
                {
                    if (ogrNo.ToString() == tbOgrenciNumarasi.Text) //atamasini yaptigimiz ogrNo degiskenini textBox'taki ogrenci numarasi ile kiyasliyoruz
                    {                                               //bu islemi hangi ogrencinin siraNo'sunu bulacagimizi belirlemek icin yapiyoruz
                        borcGuncelle.ExecuteNonQuery(); //atamasi yapilan sql borc guncelleme komutunun calismasini sagliyoruz
                    }
                }
            }
            renkDegistir(); //renk degistiren metodumuzu cagirdik
        }

        private void EmanetIslemleri_Load(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(bglnt.Adres);    //baglanti adresimizi baglanti sinifindaki adresten cekiyoruz

            SqlDataAdapter da = new SqlDataAdapter("Select * from Emanet", baglanti);    //data set ile veritabani arasinda kopru gorevi gorur. Kitap tablosunun tum sutunlarini secer
            DataSet ds = new DataSet(); //sanal tablomuzu olusturuyoruz
            da.Fill(ds);    //data adapter'in icini data set ile dolduruyoruz
            dataGridView1.DataSource = ds.Tables[0];    //son olarak da formdaki data grid view aracına sql tablomu 0. indisten itibaren yazdiriyoruz
            renkDegistir(); //renk degistiren fonksiyonumuzu cagiriyoruz
            fill(); //acilista dataGridView1'deki sutunlarimizi otomatik olarak sigdiran fonksiyonumuzu cagiriyoruz

            int sayac = 0;  //teslim edilmeyen her kitap icin tek tek artacak olan sayacimizi olusturuyoruz
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)  //tum satirlari dolasmamizi saglayan for dongusunu aciyoruz
            {
                bool teslimBilgisi = Convert.ToBoolean(dataGridView1.Rows[i].Cells[6].Value);   //teslim bilgisi degerlerini datagridview'den elde ediyoruz ve bool hale ceviriyoruz
                if(teslimBilgisi == false)  //teslim edilmeyen kitaplar oldugunda bu bloga giriyoruz ve sayacimizi yani beklenen kitap sayisini bir arttiriyoruz
                {
                    sayac++;
                }
                lblEmanetKitapSayisi.Text = sayac.ToString();  //toplam emanet sayisini yani satir sayisini label'a yazdiriyoruz
            }

            nudBorcOdeme.Enabled = false;   //borc odeme checkBox'ı form yuklenme isleminde isaretlenmemis oldugu icin numeric up down islem yapilamaz hale getiriliyor
            txtBorcOgrNumarasi.Enabled = false;   //borc odeme checkBox'ı form yuklenme isleminde isaretlenmemis oldugu icin borc odeyecek ogrencinin numarasi girilen alan islem yapilamaz hale getiriliyor
            btnOde.Enabled = false;   //borc odeme checkBox'ı form yuklenme isleminde isaretlenmemis oldugu icin odeme butonu islem yapilamaz hale getiriliyor
            btnKaydet.Enabled = false;   //form yuklenme isleminde kitabin alinacak mi yoksa verilecek mi oldugunu belirleyen radio button'u isaretlenmemis oldugu icin kaydetme butonu islem yapilamaz hale getiriliyor
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(bglnt.Adres);    //baglanti adresimizi baglanti sinifindaki adresten cekiyoruz

            try
            {   //eger gecmis tarihteki kayitlari uygulamaya eklemek istersek diye borc ve emanet bilgisini guncellemek amaciyla 103, 104 ve 105. satirdaki atamalardan tarih bilgileri cekilir 
                DateTime verilmeTarihi = Convert.ToDateTime(dtpTeslimTarihi.Value); //kitabin verildigi tarihin atamasini date time picker araciligiyla yapan komut
                DateTime otuzGunSonrasi = verilmeTarihi.AddDays(+30);   //verilme tarihinin 30 gun sonrasini atayan komut
                DateTime bugun = DateTime.Now;  //bugunun tarihini alan komut

                baglanti.Open();    //veritabani ile kodun arasindaki baglantiyi aciyoruz
                SqlCommand kayitEkle = new SqlCommand("insert into Emanet(BarkodNo, OgrenciNumarasi, VerilmeTarihi, BeklenenTarih, AlınmaTarihi, TeslimBilgisi) values (@e1, @e2, @e3, @e4, @e5, @e6)", baglanti);  //sql'in kayit ekleme kodunun atamalarini c# uzerinden  gerceklestirdim. Denk gelen sutun adlarina @ ifadesiyle atama yapan nesneyi olusturuyoruz
                SqlCommand kitapAdediAzalt = new SqlCommand("update Kitap set KitapAdedi = KitapAdedi-1 where  BarkodNo = '" + tbKitapBarkodNo.Text + "'", baglanti);   //ogrenciye kitap verildigi takdirde kutuphanedeki kitap sayisini 1 azaltacak olan sql komutu
                SqlCommand kitapAdediArttır = new SqlCommand("update Kitap set KitapAdedi = KitapAdedi+1 where  BarkodNo = '" + tbKitapBarkodNo.Text + "'", baglanti);  //ogrenciden kitap alindigi takdirde kutuphanedeki kitap sayisini 1 arttiracak olan sql komutu

                if (rbKitapVer.Checked == true) //kitap verme islemi gerceklesecekse bu bloga giriyoruz
                {
                    kayitEkle.Parameters.AddWithValue("@e1", tbKitapBarkodNo.Text);     //yaptigimiz atamalarin degerlerini formdaki text box degerlerine esitliyoruz
                    kayitEkle.Parameters.AddWithValue("@e2", tbOgrenciNumarasi.Text);   //yaptigimiz atamalarin degerlerini formdaki text box degerlerine esitliyoruz
                    kayitEkle.Parameters.AddWithValue("@e3", verilmeTarihi);            //yaptigimiz atamalarin degerlerini formdaki dateTimePicker degerine esitliyoruz
                    kayitEkle.Parameters.AddWithValue("@e4", otuzGunSonrasi);           //yaptigimiz atamalarin degerlerini formdaki dateTimePicker degerinin 30 gun sonrasina esitliyoruz
                    kayitEkle.Parameters.AddWithValue("@e5", "Bekleniyor");             //henuz kitap verme islemi gerceklestirilidgi icin kitap teslim alma tarihi "bekleniyor" olarak ayarlaniyor
                    kayitEkle.Parameters.AddWithValue("@e6", false);                    //henuz kitap verme islemi gerceklestirildigi icin kitap teslim bilgi kutucugu bos birakiliyor


                    kayitEkle.ExecuteNonQuery();    //atamasi yapilan emanet kaydetme sql komutu calistiriliyor
                    kitapAdediAzalt.ExecuteNonQuery();  //kitap verildigi icin mevcut kitap adedini 1 azaltan komut calistiriliyor
                    borcGuncelle(); //borc guncelleyen metodumuzu cagirdik
                }
                if (rbKitapAl.Checked == true)  //kitap alma islemi gerceklesecekse bu bloga giriyoruz
                {
                                                                            //tum satirlari dolasmamizi saglayan for dongusunu aciyoruz
                    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)  //burada teslim islemini ogrenci numarasi yerine sira no uzerinden gerceklestiriyoruz.
                    {                                                       //Ogrenci numarasi uzerinden teslim islemi yapildiginda ogrencinin aldigi diger kitaplar da teslim edilmis gibi oluyordu.
                                                                            //Bu sorundan kurtulmak icin bu for dongusunu acip textBox'taki ogrenci numarasini ve barkod no'sunu dataGridView1'deki sira numarasina esitliyoruz

                        int ogrNo = Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value);    //ogrenci numarasi bilgilerini dataGridView1'deki ilgili hucre degerinden aliyoruz
                        int barkodNo = Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value);    //barkod numarasi bilgilerini dataGridView1'deki ilgili hucre degerinden aliyoruz
                        bool teslimBilgisi = Convert.ToBoolean(dataGridView1.Rows[i].Cells[6].Value);   //teslim bilgisini dataGridView1'deki ilgili hucre degerinden aliyoruz
                        DateTime beklenenTarih = Convert.ToDateTime(dataGridView1.Rows[i].Cells[4].Value);//beklenen tarih bilgisini datagridView1'den cekiyoruz

                        DateTime verilmeTRH = Convert.ToDateTime(dataGridView1.Rows[i].Cells[3].Value); //verilme tarihi bilgisini yukaridakinin aksine dataGridView1'deki ilgili hucreden aliyoruz. Cunku kitap teslim alindiginda ekrana kullanicinin borcunu yazdiriyoruz
                                                                                                        //ve bu borc degerini date time picker'dan alirsak yanlis borc bilgisi ekrana getirebiliriz bu sekilde bunun onune gecmis oluyoruz
                        DateTime otuzGS = verilmeTRH.AddDays(+30);  //yeni tanimlanan verilme tarihine göre 30 gun sonrasini degiskene atiyoruz.Bu bizim ogrenciye tanidigimiz kitap teslim surensinin son gunu oluyor.
                        TimeSpan gunler = bugun - otuzGS;   //zamaninda teslim edilen kitaplar icin borc bilgisi cikmamasi acisindan bugunun tarihinden teslim edilmesi gereken son tarih cikartiliyor
                        int borc = gunler.Days; //gunler degiskeninin her bir gunu borc degiskenine ataniyor yani gunluk 1 TL gecikme ucreti degiskene atanmis oluyor.
                        if (teslimBilgisi == false)  //teslim edilen kitaplari dolasmiyoruz. Bu dongu olmazsa onceden ogrenciden teslim alinmis bir kitabin bilgileri uzerine islem yapacaktir ve istenen kitap teslim islemi gerceklesemeyecektir
                        {                           //yani ogrencinin ayni kitabi 2 kere aldigini ve ilk aldigini teslim ettigini dusunelim. Ikinciyi de almaya calistigimizda ilk kitabin oldugu satira girip kodun orada islem yapmaya calismasini onluyoruz
                            if (ogrNo.ToString() == tbOgrenciNumarasi.Text) //atamasini yaptigimiz ogrNo degiskenini textBox'taki ogrenci numarasi ile kiyasliyoruz
                            {                                               //eger bu islemi yapmazsak 132. satirda hangi ogrencinin siraNo'sunu bulacagimizi bilemeyiz
                                if (barkodNo.ToString() == tbKitapBarkodNo.Text)    //atamasini yaptigimiz barkodNo degiskenini textBox'taki barkod numarasi ile kiyasliyoruz
                                {                                                   //eger bu islemi yapmazsak 132. satirda hangi kitabin siraNo'sunu bulacagimizi bilemeyiz
                                    int siraNo = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);    //sira numarasi bilgilerini dataGridView1'deki ilgili hucre degerinden aliyoruz
                                    SqlCommand kayitGuncelle = new SqlCommand("update Emanet set AlınmaTarihi = @eg5, TeslimBilgisi = @eg6 where SiraNo = '" + siraNo.ToString() + "'", baglanti);  //sql'in kayit guncelleme kodunun atamalarini c# uzerinden  gerceklestirdim. Denk gelen sutun adlarina @ ifadesiyle atama yapan nesneyi olusturuyoruz
                                                                                                                                                                                                    //bu islemleri anahtar deger olan siraNo'ya gore gerceklestiriyoruz 
                                    kayitGuncelle.Parameters.AddWithValue("@eg5", bugun);   //yaptigimiz atamalarin degerlerini de bugunun yani teslim alinan tarihin degerine esitliyoruz
                                    kayitGuncelle.Parameters.AddWithValue("@eg6", true);    //yaptigimiz atamalarin degerlerini de teslim edildi bilgisini true olarak ayarliyoruz
                                    kayitGuncelle.ExecuteNonQuery();    //atamasi yapilan sql kayit guncelleme komutunun calismasini sagliyoruz

                                    if (bugun > beklenenTarih) //teslim suresi asildiysa ekrana gecen her gun kadar borc bilgisi yazdiriliyor
                                        MessageBox.Show("Gecikme ücreti " + borc.ToString() + " TL'dir", "Borç Bilgisi");
                                    if (bugun <= otuzGunSonrasi)    //henuz beklenen teslim suresi asilmadiysa bu bloga giriliyor 
                                        MessageBox.Show("Kitap zamanında teslim edilmiştir", "Borç Bilgisi");

                                    break;  //bu dongunun olmazsa olmazi break komutunu ekliyoruz. Bu komut olmadiginda dongu, ogrenci numarasi girilen kisinin tum kitaplarini teslim etmis gibi basa sayiyor
                                }
                            }
                        }
                    }
                    kitapAdediArttır.ExecuteNonQuery();
                }
                MessageBox.Show("Emanet Bilgisi Kaydedildi", "Bilgi Mesajı");

                SqlDataAdapter da = new SqlDataAdapter("Select * from Emanet", baglanti);    //data set ile veritabani arasinda kopru gorevi gorur. Kitap tablosunun tum sutunlarini secer
                DataSet ds = new DataSet(); //sanal tablomuzu olusturuyoruz
                da.Fill(ds);    //data adapter'in icini data set ile dolduruyoruz
                dataGridView1.DataSource = ds.Tables[0];    //son olarak da formdaki data grid view aracına sql tablomu 0. indisten itibaren yazdiriyoruz
                fill(); //dataGridView1'deki sutunlarimizi otomatik olarak sigdiran fonksiyonumuzu cagiriyoruz

                lblEmanetKitapSayisi.Text = dataGridView1.RowCount.ToString();  //toplam emanet sayisini yani satir sayisini label'a yazdiriyoruz

                renkDegistir(); //renk degistiren metodumuzu cagirdik
                baglanti.Close();   //veritabani ile kodun arasindaki baglantiyi kapatiyoruz
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); baglanti.Close(); }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();   //yalnizca bu formun kapatilmasini gerceklestiriyoruz
        }

        private void rbKitapAl_CheckedChanged(object sender, EventArgs e)   //load isleminde islem yapilamaz olarak ayarladigimiz butonu aktif eden blok
        {
            dtpTeslimTarihi.Enabled = false;    //kitap alinacagi esnada yalnizca bugunun tarihini almasi acisindan kullanicinin tarih girmesi onleniyor
            btnKaydet.Enabled = true;   //kaydetme tusu aktif hale getiriliyor
        }

        private void rbKitapVer_CheckedChanged(object sender, EventArgs e)  //load isleminde islem yapilamaz olarak ayarladigimiz butonu aktif eden blok
        {
            dtpTeslimTarihi.Enabled = true; //gecmis kitaplari emanete kaydetmek icin date time picker aktif hale getiriliyor
            btnKaydet.Enabled = true;   //kaydetme tusu aktif hale getiriliyor
        }

        private void btnOde_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(bglnt.Adres);    //baglanti adresimizi baglanti sinifindaki adresten cekiyoruz

            try
            {
                baglanti.Open();    //veritabani ile kodun arasındaki baglantiyi aciyoruz
                int odenenBorc = (int)nudBorcOdeme.Value;   //numeric up down daki degeri odenenBorc degiskenine atiyoruz
                SqlCommand borcGuncelle = new SqlCommand("update Ogrenci set GecikmeUcreti = GecikmeUcreti - " + odenenBorc + " where OgrenciNumarasi = '" + txtBorcOgrNumarasi.Text + "'", baglanti);  //ogrenci tablosunda tutulan borc bilgisini guncelleyecek olan sql komutu
                borcGuncelle.ExecuteNonQuery(); //sql komutu calistiriliyor
                MessageBox.Show("Borç Bilgisi Güncellendi");    //bilgi amacli mesaj ekrana veriliyor
                baglanti.Close();   //veritabani ile kodun arasındaki baglantiyi kapatiyoruz
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); baglanti.Close();
            } 
        } 
        
        private void cbBorcOde_CheckedChanged(object sender, EventArgs e)   //borc odeme checkbox'ının degismesi durumunda butonlarin ve kutularin aktifligini degistiren islemler burada yer alir
        {
            if (cbBorcOde.Checked == true)  //borc odeme kutusu isaretlenirse butonlar vs. aktif hale getiriliyor
            {
                nudBorcOdeme.Enabled = true;
                txtBorcOgrNumarasi.Enabled = true;
                btnOde.Enabled = true;
            }
            else     //borc odeme kutusu isareti kaldirilirsa butonlar vs. pasif hale getiriliyor
            {
                nudBorcOdeme.Enabled = false;
                txtBorcOgrNumarasi.Enabled = false;
                btnOde.Enabled = false;
            }
        }
    }
}
