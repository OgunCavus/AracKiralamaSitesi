using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AracKiralamaDB.Models;

namespace AracKiralamaDB.Models
{
    public class ModelToplama
    {
        public List<Adminler> Adminlers { get; set; }
public List<Arabalar> Arabalars { get; set; } 
        public List<ArabaMarkalari> ArabaMarkalaris { get; set; }
        public List<ArabaModelleri> ArabaModelleris { get; set; }
        public List<ArabaResimleri> ArabaResimleris { get; set; }
        public List<ArabaTurleri> ArabaTurleris { get; set; }
        public List<ArabaVitesTurleri> ArabaVitesTurleris { get; set; }
        public List<Cinsiyetler> Cinsiyetlers { get; set; }
        public List<Kiralamalar> Kiralamalars { get; set; }
        public List<Kullanicilar> Kullanicilars { get; set; }
        public List<Musteriler> Musterilers { get; set; }
    }
}