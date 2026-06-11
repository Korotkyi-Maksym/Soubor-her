using System;
using System.Collections.Generic;
using System.Text;

namespace databaze_hry_2
{
    internal class Hry
    {
        public string Zanr { get; set; }
        public string StavHry { get; set; }
        public int ID { get; set; }
        public string Nazev { get; set; }
        private int hodnoceni;

        public int Hodnoceni
        {
            get { return hodnoceni; }
            set
            {
                if (value > 10)
                {
                    hodnoceni = 10;
                }
                else if (value < 1)
                {
                    hodnoceni = 1;
                }
                else
                {
                    hodnoceni = value;
                }
            }
        }
        public int Cena { get; set; }
        
        
    }
}
