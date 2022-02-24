using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final
{
    class Baglanti
    {
        public string Adres = System.IO.File.ReadAllText(@"C:\Test.txt");   //C diskindeki Text dosyasında yer alan veritabanı sunucu adresini okuyoruz. 
    }                                                                       //boylelikle farklı bilgisayarlara kurulum yaparken text'teki adresi  
}                                                                           //kurulum yapilan bilgisayarin adresine esitlemek baglanti icin yeterli olacaktir
