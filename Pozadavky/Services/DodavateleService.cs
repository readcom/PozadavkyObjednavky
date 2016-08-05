using Pozadavky.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pozadavky.DTO;

namespace Pozadavky.Services
{
    class DodavateleService
    {
        public List<DodavateleDTO> GetDodavateleOrderedByName()
        {
            using (var db = new PozContext())
            {
                return db.Dodavatele
                    .Select(d => new DodavateleDTO()
                    {
                        ID = d.ID,
                        Nazev = d.Nazev,
                        Adresa = d.Adresa,
                        IC = d.IC,
                        DIC = d.DIC,
                        PozadavkyId = d.Pozadavky.Select(t => t.Id)
                    })
                    .OrderBy(a => a.Nazev)
                    .ToList();
            }

        }

    }
}
