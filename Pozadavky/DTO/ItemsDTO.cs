using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pozadavky.DTO
{
    public class ItemsDTO
    {

        public int ID { get; set; }

        public string Vlozil { get; set; }

        public DateTime? Datum { get; set; }

        public string CelkovyPopis { get; set; }

        public bool Smazano { get; set; }

        public string SmazalUzivatel { get; set; }

        public DateTime? SmazanoDne { get; set; }


    }
}
