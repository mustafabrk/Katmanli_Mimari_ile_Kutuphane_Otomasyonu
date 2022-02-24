using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace Final
{
    public partial class Grafik : Form
    {
        public Grafik()
        {
            InitializeComponent();
        }

        public double mevcutKitap;  //anaForm'daki ilgili label'dan verileri alabilmemiz icin erisim belirteci public olan bir degisken olusturuyoruz
        public double emanetKitap;  //anaForm'daki ilgili label'dan verileri alabilmemiz icin erisim belirteci public olan bir degisken olusturuyoruz
        public double toplamKitap;  //anaForm'daki ilgili label'dan verileri alabilmemiz icin erisim belirteci public olan bir degisken olusturuyoruz

        private void Grafik_Load(object sender, EventArgs e)
        {            
            GraphPane myPane = zedGraphControl1.GraphPane;  //grafik bolmelerimizi kontrol edecegimiz ve cogu islemimizi gerceklestirecegimiz kontrolu olusturuyoruz

            myPane.Title.Text = "Kitap Sayısı Arşiv Grafiği";   //grafigin ismini/basligini belirliyoruz
            myPane.XAxis.Title.Text = "Verilen Kitaplar / Verilmeye Hazır Kitaplar / Tüm Kitaplar"; //x ekseninin adini belirliyoruz
            myPane.YAxis.Title.Text = "Kitap Sayıları"; //y ekseninin adini belirliyoruz

            string[] etiketler = { "Kitap Bilgileri" }; //x aksisinde ne yazacagini bu satirda belirliyoruz (ancak henuz aktif etmedik)

            double[] y1 = { emanetKitap };  //ilk sutunun iceriklerini anaFormdaki ilgili label'dan kalitim ile cekiyoruz
            double[] y2 = { mevcutKitap };  //ikinci sutunun iceriklerini anaFormdaki ilgili label'dan kalitim ile cekiyoruz
            double[] y3 = { toplamKitap };  //ucuncu sutunun iceriklerini anaFormdaki ilgili label'dan kalitim ile cekiyoruz

            BarItem myBar1 = myPane.AddBar("Verilen Kitaplar", null, y1, Color.OrangeRed);  //sutun grafiginin ilk sutunu ekleniyor. Sutun ismi, aldigi deger ve renk ayarlari yapiliyor
            BarItem myBar2 = myPane.AddBar("Verilmeye Hazır Kitaplar", null, y2, Color.GreenYellow);    //sutun grafiginin ikinci sutunu ekleniyor. Sutun ismi, aldigi deger ve renk ayarlari yapiliyor
            BarItem myBar3 = myPane.AddBar("Tüm Kitaplar", null, y3, Color.BlueViolet); //sutun grafiginin son sutunu ekleniyor. Sutun ismi, aldigi deger ve renk ayarlari yapiliyor

            TextObj barLabel1 = new TextObj(myBar1.Points[0].Y.ToString(), myBar1.Points[0].X - 0.27, myBar1.Points[0].Y + 7);  //sutunun degerini gosterecek olan text objesi olusturuluyor ve konumlandirma ayarlari yapiliyor
            barLabel1.FontSpec.Border.IsVisible = false;    //sutunun degerini gosteren text objesinin cercevesini gorunmez olarak ayarliyoruz
            myPane.GraphObjList.Add(barLabel1); //text objemiz grafige ekleniyor

            TextObj barLabel2 = new TextObj(myBar2.Points[0].Y.ToString(), myBar2.Points[0].X, myBar2.Points[0].Y + 7); //sutunun degerini gosterecek olan text objesi olusturuluyor ve konumlandirma ayarlari yapiliyor
            barLabel2.FontSpec.Border.IsVisible = false;    //sutunun degerini gosteren text objesinin cercevesini gorunmez olarak ayarliyoruz
            myPane.GraphObjList.Add(barLabel2); //text objemiz grafige ekleniyor

            TextObj barLabel3 = new TextObj(myBar3.Points[0].Y.ToString(), myBar3.Points[0].X + 0.27, myBar3.Points[0].Y + 7);  //sutunun degerini gosterecek olan text objesi olusturuluyor ve konumlandirma ayarlari yapiliyor
            barLabel3.FontSpec.Border.IsVisible = false;    //sutunun degerini gosteren text objesinin cercevesini gorunmez olarak ayarliyoruz
            myPane.GraphObjList.Add(barLabel3); //text objemiz grafige ekleniyor

            myPane.XAxis.MajorTic.IsBetweenLabels = true;   //sutunlari x eksenindeki degerlerin/degerin arasina ekliyoruz
            myPane.XAxis.Scale.TextLabels = etiketler;  //etiketler degiskenimizi cagirarak x eksenindeki araligi isimlendiriyoruz
            myPane.XAxis.Type = AxisType.Text;  //x eksenine string degerleri yazmak icin axisType'ini text olarak ayarliyoruz

            myPane.Chart.Fill = new Fill(Color.White, Color.FromArgb(255, 255, 166), 90F);  //grafigin arkaplanini renklendiriyoruz
            myPane.Fill = new Fill(Color.FromArgb(250, 250, 255));  //grafigin arkaplani disindaki alanlari renklendiriyoruz

            myBar1.Label.IsVisible = true;  //etiket gorunurlukleri aktif hale getiriliyor
            myBar2.Label.IsVisible = true;  //etiket gorunurlukleri aktif hale getiriliyor
            myBar3.Label.IsVisible = true;  //etiket gorunurlukleri aktif hale getiriliyor

            zedGraphControl1.AxisChange();  //eksen degisiklikleri uygulaniyor boylece form acildiginda sutunlar istenen deger araliklarina konumlandirilmis oluyor ve ekrana ortalaniyor 
        }
    }
}
