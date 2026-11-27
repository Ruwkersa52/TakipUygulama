using System;
using System.Collections.Generic;
using System.Text;

namespace TakipUygulaması
{
    public class TakiplerinElementListeleri:Form
    {
        List<Control> AnaEkranDefaultElementler = new List<Control>();
        List<Control> TodoElement = new List<Control>();
        public TakiplerinElementListeleri(Todo_ArkaPlan anaEkran)
        {
            AnaEkranDefaultElementler.Add(anaEkran.AnaEkran_todoButon);
            

        }
        public List<Control> TodoElementListeGetir()
        {
            return TodoElement;
        }
        public List<Control> AnaEkranDefaultElementlerListeGetir()
        {
            return AnaEkranDefaultElementler;
        }

    }
    
}
