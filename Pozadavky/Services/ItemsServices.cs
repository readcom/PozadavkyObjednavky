using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using DotVVM.Framework.Controls;
using Pozadavky.Data;
using Pozadavky.DTO;

namespace Pozadavky.Services
{
    public static class ItemsServices
    {
        public static int? LastItemId { get; set; } = null;

        internal static void DeleteItem(int id)
        {
            using (var db = new PozContext())
            {
                var item = db.Items.Find(id);

                item.Smazano = true;
                item.SmazalUzivatel = UserServices.GetActiveUser();
                item.SmazanoDne = DateTime.Now;
                //db.Pozadavky.Remove(pozadavek);
                db.SaveChanges();
            }
        }

        public static string GetItemPopisById(int itemId)
        {            
            using (var db = new PozContext())
            {
                var item = db.Items.Find(itemId);
                return item.CelkovyPopis;

            }
        }

        public static void FillGridViewItems(GridViewDataSet<ItemsDTO> dataSet, string name = "")
        {
            using (var db = new PozContext())
            {
                if (name != "")
                {
                    var query = (from i in db.Items
                                 where i.Vlozil == name & i.Smazano == false
                                 select new ItemsDTO()
                                 {
                                     ID = (int?)i.ID ?? 0,
                                     Vlozil = i.Vlozil,
                                     Datum = i.Datum,
                                     CelkovyPopis = i.CelkovyPopis
                                 });

                    // lepsi, bud rucne pres Items, ale pres LoadFromQ se o vse stara sam
                    dataSet.LoadFromQueryable(query);
                }
                else
                {
                    var query = (from i in db.Items
                                 where i.Smazano == false
                                 select new ItemsDTO()
                                 {
                                     ID = (int?)i.ID ?? 0,
                                     Vlozil = i.Vlozil,
                                     Datum = i.Datum,
                                     CelkovyPopis = i.CelkovyPopis
                                 });

                    // lepsi, bud rucne pres Items, ale pres LoadFromQ se o vse stara sam
                    dataSet.LoadFromQueryable(query);
                }
            }
        }

        internal static void EditItemPopis(string NewPopis, int id)
        {
            using (var db = new PozContext())
            {
                var item = db.Items.Find(id);
                item.CelkovyPopis = NewPopis;
                db.SaveChanges();
            }
        }

        public static void InsertItem(ItemsDTO item)
        {
            using (var db = new PozContext())
            {
                var i = new Item
                {
                    Datum = DateTime.Now,
                    Vlozil = UserServices.GetActiveUser(),
                    CelkovyPopis = item.CelkovyPopis
                };
                db.Items.Add(i);
                db.SaveChanges(); 
            }
        }



        // zjednoduseni je AutoMapper

        public static void SaveItem(ItemsDTO itemData)
        {
            using (var db = new PozContext())
            {
                var itemEdit = db.Items.Find((itemData.ID));

                itemEdit.CelkovyPopis = itemData.CelkovyPopis;

                db.SaveChanges();
            }

        }
    }
}