using DotVVM.Framework.Controls;
using Pozadavky.Data;
using Pozadavky.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using DotVVM.Framework.ViewModel;

namespace Pozadavky.Services
{
    public static class PozadavkyServices
    {


        public static List<PozadavekDTO> GetPozadavkyByName(string name = "")
        {
            using (var db = new PozContext())
            {

                if (name != "")
                {
                    var query = (from i in db.Items
                        join p in db.Pozadavky
                            on i.ID equals p.ItemId
                        where i.Vlozil == name
                        select new PozadavekDTO()
                        {
                            ID = (int?) i.ID ?? 0,
                            Vlozil = i.Vlozil,
                            Datum = i.Datum,
                            Popis = p.Popis,
                            Mena = p.Mena,
                            CelkovaCena = p.CelkovaCena
                        }
                        );
                    return query.ToList();
                }
                else
                {
                    var query = (from i in db.Items
                        join p in db.Pozadavky
                            on i.ID equals p.ItemId
                        select new PozadavekDTO()
                        {
                            ID = (int?) i.ID ?? 0,
                            Vlozil = i.Vlozil,
                            Datum = i.Datum,
                            Popis = p.Popis,
                            Mena = p.Mena,
                            CelkovaCena = p.CelkovaCena
                        }
                        );
                    return query.ToList();

                }
            }
        }

        internal static void DeletePozadavek(int id)
        {
            using (var db = new PozContext())
            {
                var pozadavek = db.Pozadavky.Find(id);

                pozadavek.Smazano = true;
                pozadavek.SmazalUzivatel = UserServices.GetActiveUser();
                pozadavek.SmazanoDne = DateTime.Now;
                //db.Pozadavky.Remove(pozadavek);
                db.SaveChanges();
            }
        }



        public static void FillGridViewPozadavkyByUser(GridViewDataSet<PozadavekDTO> dataSet, string name = "")
        {
            using (var db = new PozContext())
            {

                if (name != "")
                {
                    var query = (from i in db.Items
                        join p in db.Pozadavky on i.ID equals p.ItemId
                        join d in db.Dodavatele on p.DodavatelId equals d.ID
                        where i.Vlozil == name & p.Smazano == false
                        select new PozadavekDTO()
                        {
                            ID = (int?) p.Id ?? 0,
                            ItemId = (int?)i.ID ?? 0,
                            Vlozil = i.Vlozil,
                            Datum = i.Datum,
                            Popis = p.Popis,
                            Mena = p.Mena,
                            CelkovaCena = p.CelkovaCena,
                            DodavatelName = d.Nazev
                        });

                    // lepsi, bud rucne pres Items, ale pres LoadFromQ se o vse stara sam
                    dataSet.LoadFromQueryable(query);
                }
                else
                {
                    var query = (from i in db.Items
                        join p in db.Pozadavky on i.ID equals p.ItemId
                        join d in db.Dodavatele on p.DodavatelId equals d.ID
                        where p.Smazano == false
                        select new PozadavekDTO()
                        {
                            ID = (int?) p.Id ?? 0,
                            ItemId = (int?)i.ID ?? 0,
                            Vlozil = i.Vlozil,
                            Datum = i.Datum,
                            Popis = p.Popis,
                            Mena = p.Mena,
                            CelkovaCena = p.CelkovaCena,
                            DodavatelName = d.Nazev
                        });

                    // lepsi, bud rucne pres Items, ale pres LoadFromQ se o vse stara sam
                    dataSet.LoadFromQueryable(query);
                }
            }
        }

        public static void FillGridViewPozadavkyByUserAndItemId(GridViewDataSet<PozadavekDTO> dataSet, int? itemId, string name = "")
        {
            using (var db = new PozContext())
            {

                if (name != "")
                {
                    var query = (from i in db.Items
                                 join p in db.Pozadavky on i.ID equals p.ItemId
                                 join d in db.Dodavatele on p.DodavatelId equals d.ID
                                 where i.Vlozil == name & p.Smazano == false & p.ItemId == itemId
                                 select new PozadavekDTO()
                                 {
                                     ID = (int?)p.Id ?? 0,
                                     ItemId = (int?)i.ID ?? 0,
                                     Vlozil = i.Vlozil,
                                     Datum = i.Datum,
                                     Popis = p.Popis,
                                     Mena = p.Mena,
                                     CelkovaCena = p.CelkovaCena,
                                     DodavatelName = d.Nazev,
                                     ItemPopis = i.CelkovyPopis
                                 });

                    // lepsi, bud rucne pres Items, ale pres LoadFromQ se o vse stara sam
                    dataSet.LoadFromQueryable(query);
                }
                else
                {
                    var query = (from i in db.Items
                                 join p in db.Pozadavky on i.ID equals p.ItemId
                                 join d in db.Dodavatele on p.DodavatelId equals d.ID
                                 where p.Smazano == false & p.ItemId == itemId
                                 select new PozadavekDTO()
                                 {
                                     ID = (int?)p.Id ?? 0,
                                     ItemId = (int?)i.ID ?? 0,
                                     Vlozil = i.Vlozil,
                                     Datum = i.Datum,
                                     Popis = p.Popis,
                                     Mena = p.Mena,
                                     CelkovaCena = p.CelkovaCena,
                                     DodavatelName = d.Nazev,
                                     ItemPopis = i.CelkovyPopis
                                 });

                    // lepsi, bud rucne pres Items, ale pres LoadFromQ se o vse stara sam
                    dataSet.LoadFromQueryable(query);
                }
            }
        }

        public static void PozadavekInsert(PozadavekDTO pozadavekData)
        {
            using (var db = new PozContext())
            {
                //var i = new Item
                //{
                //    Datum = DateTime.Now,
                //    Vlozil = activeUser,
                //};
                //db.Items.Add(i);
                //db.SaveChanges();

                //// i.ID - ID noveho zaznamu

                var p = new Pozadavek
                {
                    ItemId = pozadavekData.ItemId,
                    Popis = pozadavekData.Popis,
                    Jednotka = pozadavekData.Jednotka,
                    Mnozstvi = pozadavekData.Mnozstvi,
                    CenaZaJednotku = pozadavekData.CenaZaJednotku,
                    CelkovaCena = pozadavekData.CelkovaCena,
                    Mena = pozadavekData.Mena,
                    DatumObjednani = pozadavekData.DatumObjednani,
                    TerminDodani = pozadavekData.TerminDodani,
                    DodavatelId = pozadavekData.DodavatelId
                };

                db.Pozadavky.Add(p);
                db.SaveChanges();

            }
        }

        public static PozadavekDTO GetPozadavekById(int id)
        {
            using (var db = new PozContext())
            {
                var pozadavek = (from p in db.Pozadavky
                    // where p.Id == id
                    select new PozadavekDTO()
                    {
                        ID = (int?) p.Id ?? 0,
                        ItemId = p.ItemId,
                        Popis = p.Popis,
                        Mena = p.Mena,
                        CelkovaCena = p.CelkovaCena,
                        DodavatelId = p.DodavatelId,
                        Jednotka = p.Jednotka,
                        CenaZaJednotku = p.CenaZaJednotku,
                        DatumObjednani = p.DatumObjednani,
                        TerminDodani = p.TerminDodani,
                        Mnozstvi = p.Mnozstvi
                    }).SingleOrDefault(a => a.ID == id);

                return pozadavek;

            }
        }

        // zjednoduseni je AutoMapper

        public static void SavePozadavek(PozadavekDTO pozadavekData)
        {
            using (var db = new PozContext())
            {
                var pozadavek = db.Pozadavky.Find((pozadavekData.ID));

                pozadavek.Popis = pozadavekData.Popis;
                pozadavek.Mena = pozadavekData.Mena;
                pozadavek.DodavatelId = pozadavekData.DodavatelId;
                pozadavek.Jednotka = pozadavekData.Jednotka;
                pozadavek.CelkovaCena = pozadavekData.CelkovaCena;
                pozadavek.DodavatelId = pozadavekData.DodavatelId;
                pozadavek.Jednotka = pozadavekData.Jednotka;
                pozadavek.CenaZaJednotku = pozadavekData.CenaZaJednotku;
                pozadavek.DatumObjednani = pozadavekData.DatumObjednani;
                pozadavek.TerminDodani = pozadavekData.TerminDodani;
                pozadavek.Mnozstvi = pozadavekData.Mnozstvi;
                db.SaveChanges();
            }

        }
    }
}
