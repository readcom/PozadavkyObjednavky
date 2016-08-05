using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pozadavky.DTO
{
    public class PozadavekDTO
    {
        public int ID { get; set; }
        public int ItemId { get; set; }
        public string Vlozil { get; set; }
        public Nullable<System.DateTime> Datum { get; set; }

        public string Popis { get; set; }

        public string ItemPopis { get; set; }

        public int? DodavatelId { get; set; }

        public string DodavatelName { get; set; }

        public string Jednotka { get; set; }

        public int Mnozstvi { get; set; }

        public float CenaZaJednotku { get; set; }

        public float CelkovaCena { get; set; }

        public string Mena { get; set; }

        public DateTime DatumObjednani { get; set; }

        public DateTime TerminDodani { get; set; }

        //public string Nazev { get; set; }
        //public string Adresa { get; set; }
        //public string IC { get; set; }
        //public string DIC { get; set; }

        //public string FileName { get; set; }
        //public string FullPath { get; set; }
        //public string Description { get; set; }
    }
}
