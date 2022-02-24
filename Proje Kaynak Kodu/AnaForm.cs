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
    public partial class AnaForm : Form
    {
        public AnaForm()
        {
            InitializeComponent();
        }

        Baglanti bglnt = new Baglanti();    //Baglanti sinifinda belirlenen text'teki veritabani adresine ulasmak icin bu kodu yaziyoruz
        
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
                    baglanti.Open();
                    borcGuncelle.ExecuteNonQuery(); //atamasi yapilan sql borc guncelleme komutunun calismasini sagliyoruz
                    baglanti.Close();
                }
            }
            renkDegistir(); //renk degistiren metodumuzu cagirdik
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
                dataGridView1.Rows[i].DefaultCellStyle = renk;  //dongunun tekrar ettiginde default rengine donmesini saglayarak renk karmasikligini onluyoruz
            }
        }

        private void AnaForm_Load(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(bglnt.Adres);    //baglanti adresimizi baglanti sinifindaki adresten cekiyoruz

            SqlDataAdapter da = new SqlDataAdapter("Select * from Emanet", baglanti);    //data set ile veritabani arasinda kopru gorevi gorur. Emanet tablosunun tum sutunlarini secer
            DataSet ds = new DataSet(); //sanal tablomuzu olusturuyoruz
            da.Fill(ds);    //data adapter'in icini data set ile dolduruyoruz
            dataGridView1.DataSource = ds.Tables[0];    //son olarak da formdaki data grid view aracına sql tablomu 0. indisten itibaren yazdiriyoruz
                                                        //Acilista bu tabloyu cagirmamizin nedeni ogrencilerin borc bilgilerini uygulama acilirken guncellemek. Butonlara bagimli kalmamak ve en guncel veriyi elde etmek
            renkDegistir(); //renk degistiren metodumuzu cagirdik
            borcGuncelle(); 

            baglanti.Open();    //veritabani ile kodun arasındaki baglantiyi aciyoruz
            SqlCommand toplamKitap = new SqlCommand("select sum(KitapAdedi) from Kitap", baglanti); //Kitap tablosundan KitapAdedi sutununu degerlerini secen nesneyi olusturuyoruz 
            SqlDataReader oku = toplamKitap.ExecuteReader();    //Olusturdugumuz toplamKitap nesnesinden verileri okuyan ve listeleyen atamayi gerceklestiriyoruz
            while (oku.Read())  //okuma islemi gerceklestiginde lblToplamKitapAdedi'nin textine yazdiriliyor
            {
                lblMevcut.Text = oku[0].ToString(); //mevcut kitap sayisini sql'in ilgili sutundaki degerleri toplamasini ve okumasini saglayan komutlar ile gerceklestirdik. Label'a aktardik
            }
            baglanti.Close();   //veritabani ile kodun arasindaki baglantiyi kapatiyoruz

            int sayac = 0;  //teslim edilmeyen her kitap icin tek tek artacak olan sayacimizi olusturuyoruz
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)  //tum satirlari dolasmamizi saglayan for dongusunu aciyoruz
            {
                bool teslimBilgisi = Convert.ToBoolean(dataGridView1.Rows[i].Cells[6].Value);   //teslim bilgisi degerlerini datagridview'den elde ediyoruz ve bool hale ceviriyoruz
                if (teslimBilgisi == false)  //teslim edilmeyen kitaplar oldugunda bu bloga giriyoruz ve sayacimizi yani beklenen kitap sayisini bir arttiriyoruz
                {
                    sayac++;
                }
                lblEmanet.Text = sayac.ToString();  //toplam emanet sayisini yani satir sayisini label'a yazdiriyoruz
            }

            int a = Convert.ToInt32(lblMevcut.Text);    //mevcut kitap sayisini int degere donusturerek a degiskenine atiyoruz
            int b = Convert.ToInt32(lblEmanet.Text);    //emanet edilmis kitap sayisini int degere donusturerek b degiskenine atiyoruz
            lblToplam.Text = (a + b).ToString();    //atadigimiz degerleri topluyoruz ve toplam kitap sayisini gosteren labela aktariyoruz

            this.dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;   //acilista dataGridView1'deki sutunlarimizi otomatik sigdiriyoruz
            this.dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;   //acilista dataGridView1'deki sutunlarimizi otomatik sigdiriyoruz
            this.dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;   //acilista dataGridView1'deki sutunlarimizi otomatik sigdiriyoruz
            this.dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;   //acilista dataGridView1'deki sutunlarimizi otomatik sigdiriyoruz
            this.dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;   //acilista dataGridView1'deki sutunlarimizi otomatik sigdiriyoruz
            this.dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;   //acilista dataGridView1'deki sutunlarimizi otomatik sigdiriyoruz
            this.dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;   //acilista dataGridView1'deki sutunlarimizi otomatik sigdiriyoruz
        }

        private void btnKitapIslemleri_Click(object sender, EventArgs e)
        {
            KitapIslemleri formAc = new KitapIslemleri();   //KitapIslemleri formunun formAc nesnesi olusturuluyor
            formAc.ShowDialog();  //formun acilmasi saglaniyor
        }

        private void btnKitapListele_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(bglnt.Adres);    //baglanti adresimizi baglanti sinifindaki adresten cekiyoruz

            SqlDataAdapter da = new SqlDataAdapter("Select * from Kitap", baglanti);    //data set ile veritabani arasinda kopru gorevi gorur. Kitap tablosunun tum sutunlarini secer
            DataSet ds = new DataSet(); //sanal tablomuzu olusturuyoruz
            da.Fill(ds);    //data adapter'in icini data set ile dolduruyoruz
            dataGridView1.DataSource = ds.Tables[0];    //son olarak da formdaki data grid view aracına sql tablomu 0. indisten itibaren yazdiriyoruz

            this.dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;   //acilista dataGridView1'deki sutunlarimizi otomatik sigdiriyoruz
            this.dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;   //acilista dataGridView1'deki sutunlarimizi otomatik sigdiriyoruz
            this.dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;   //acilista dataGridView1'deki sutunlarimizi otomatik sigdiriyoruz
            this.dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;   //acilista dataGridView1'deki sutunlarimizi otomatik sigdiriyoruz
            this.dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;   //acilista dataGridView1'deki sutunlarimizi otomatik sigdiriyoruz
            this.dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;   //acilista dataGridView1'deki sutunlarimizi otomatik sigdiriyoruz
            this.dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;   //acilista dataGridView1'deki sutunlarimizi otomatik sigdiriyoruz
            this.dataGridView1.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;   //acilista dataGridView1'deki sutunlarimizi otomatik sigdiriyoruz
            this.dataGridView1.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;   //acilista dataGridView1'deki sutunlarimizi otomatik sigdiriyoruz
            this.dataGridView1.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;   //acilista dataGridView1'deki sutunlarimizi otomatik sigdiriyoruz
        }

        private void btnOgrenciIslemleri_Click(object sender, EventArgs e)
        {
            OgrenciIslemleri formAc = new OgrenciIslemleri();   //OgrenciIslemleri formunun formac nesnesi olusturuluyor
            formAc.ShowDialog();  //formun acilmasi saglaniyor
        }

        private void btnOgrenciListele_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(bglnt.Adres);    //baglanti adresimizi baglanti sinifindaki adresten cekiyoruz

            SqlDataAdapter da = new SqlDataAdapter("Select * from Ogrenci", baglanti);    //data set ile veritabani arasinda kopru gorevi gorur. Ogrenci tablosunun tum sutunlarini secer
            DataSet ds = new DataSet(); //sanal tablomuzu olusturuyoruz
            da.Fill(ds);    //data adapter'in icini data set ile dolduruyoruz
            dataGridView1.DataSource = ds.Tables[0];    //son olarak da formdaki data grid view aracına sql tablomu 0. indisten itibaren yazdiriyoruz

            this.dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;   //acilista dataGridView1'deki sutunlarimizi otomatik sigdiriyoruz
            this.dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;   //acilista dataGridView1'deki sutunlarimizi otomatik sigdiriyoruz
            this.dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;   //acilista dataGridView1'deki sutunlarimizi otomatik sigdiriyoruz
            this.dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;   //acilista dataGridView1'deki sutunlarimizi otomatik sigdiriyoruz
            this.dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;   //acilista dataGridView1'deki sutunlarimizi otomatik sigdiriyoruz
            this.dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;   //acilista dataGridView1'deki sutunlarimizi otomatik sigdiriyoruz
            this.dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;   //acilista dataGridView1'deki sutunlarimizi otomatik sigdiriyoruz
            this.dataGridView1.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;   //acilista dataGridView1'deki sutunlarimizi otomatik sigdiriyoruz
        }

        private void btnEmanetIslemleri_Click(object sender, EventArgs e)
        {
            EmanetIslemleri formAc = new EmanetIslemleri(); //EmanetIslemleri formunun formac nesnesi olusturuluyor
            formAc.ShowDialog();  //formun acilmasi saglaniyor
        }

        private void btnEmanetListele_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(bglnt.Adres);    //baglanti adresimizi baglanti sinifindaki adresten cekiyoruz

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from Emanet", baglanti);    //data set ile veritabani arasinda kopru gorevi gorur. Emanet tablosunun tum sutunlarini secer
                DataSet ds = new DataSet(); //sanal tablomuzu olusturuyoruz
                da.Fill(ds);    //data adapter'in icini data set ile dolduruyoruz
                dataGridView1.DataSource = ds.Tables[0];    //son olarak da formdaki data grid view aracına sql tablomu 0. indisten itibaren yazdiriyoruz

                renkDegistir(); //renk degistiren metodumuzu cagirdik

                this.dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;   //acilista dataGridView1'deki sutunlarimizi otomatik sigdiriyoruz
                this.dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;   //acilista dataGridView1'deki sutunlarimizi otomatik sigdiriyoruz
                this.dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;   //acilista dataGridView1'deki sutunlarimizi otomatik sigdiriyoruz
                this.dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;   //acilista dataGridView1'deki sutunlarimizi otomatik sigdiriyoruz
                this.dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;   //acilista dataGridView1'deki sutunlarimizi otomatik sigdiriyoruz
                this.dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;   //acilista dataGridView1'deki sutunlarimizi otomatik sigdiriyoruz
                this.dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;   //acilista dataGridView1'deki sutunlarimizi otomatik sigdiriyoruz
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); baglanti.Close(); }
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            this.Close();   //bu formun kapatilmasi saglaniyor
            Application.Exit(); //uygulamanin kapatilmasi saglaniyor
        }

        private void btnGrafik_Click(object sender, EventArgs e)
        {
            Grafik aktar = new Grafik();    //bu formdaki label degerlerimizi Grafik formunda olusturdugumuz public degiskenlere atamak icin bir nevi kopru olusturuyoruz
            aktar.emanetKitap = Convert.ToDouble(lblEmanet.Text);   //Grafik formunda olusturdugumuz emanetKitap degiskenine bu formdaki emanet kitap sayisini gosteren label degerini atiyoruz
            aktar.mevcutKitap = Convert.ToDouble(lblMevcut.Text);   //Grafik formunda olusturdugumuz mevcutKitap degiskenine bu formdaki mevcut kitap sayisini gosteren label degerini atiyoruz
            aktar.toplamKitap = Convert.ToDouble(lblToplam.Text);   //Grafik formunda olusturdugumuz toplamKitap degiskenine bu formdaki toplam kitap sayisini gosteren label degerini atiyoruz
            aktar.ShowDialog();   //yaptigimiz degisiklikleri uygulamak icin bu kodu yaziyoruz. Zaten sirf bu yuzden bu kodlari btnGrafik_Click eylemine atiyoruz. Aksi takdirde degisiklikleirmizi uygulayamayiz veya ben uygulayamadim
        }

        private void btnYardim_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Kitap ekleme, güncelleme, silme, filtreleme ve emanet edilen kitapları görmek için kitap işlemleri butonuna tıklayabilirsiniz. \n\n" +
                            "Öğrenci ekleme, güncelleme, silme, filtreleme ve öğrencilere emanet edilen kitapları görmek için kitap işlemleri butonuna tıklayabilirsiniz. \n\n" +
                            "Emanet kitap verme, emanet kitap alma ve borç ödemesi yapmak için emanet işlemleri butonuna tıklayabilirsiniz. \n\n", "Yardım");
        }
    }
}
