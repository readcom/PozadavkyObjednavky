using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pozadavky.DTO
{
    public class DodavateleDTO
    {

        public int ID { get; set; }

        public string Nazev { get; set; }

        public string Adresa { get; set; }

        public string IC { get; set; }

        public string DIC { get; set; }

        public IEnumerable<int> PozadavkyId { get; set; }

       
    }
}
