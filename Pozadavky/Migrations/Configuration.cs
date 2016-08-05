namespace Pozadavky.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Pozadavky.Data;

    internal sealed class Configuration : DbMigrationsConfiguration<Pozadavky.Data.PozContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Pozadavky.Data.PozContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Items.AddOrUpdate(i => i.ID,
                new Item { ID = 1, Datum = DateTime.Now, Vlozil = "marek.novak" },
                new Item { ID = 2, Datum = DateTime.Now, Vlozil = "marek.novak" },
                new Item { ID = 3, Datum = DateTime.Now, Vlozil = "marek.novak" }
                );

            context.Pozadavky.AddOrUpdate(p => p.Id,
                new Pozadavek
                {
                    Id = 1,
                    Popis = "Nakup tiskaren",
                    Jednotka = "ks",
                    CenaZaJednotku = 2000,
                    Mnozstvi = 4,
                    CelkovaCena = 8000,
                    DatumObjednani = DateTime.Now,
                    DodavatelId = 1,
                    ItemId = 1, //context.Items.Find(1),
                    Mena = "CZK",
                    TerminDodani = (DateTime.Now.AddDays(7)),
                    Smazano = false,
                    SmazalUzivatel = null,
                    SmazanoDne = null 
                    
                },
                new Pozadavek
                {
                    Id = 2,
                    Popis = "Klavesnice",
                    Jednotka = "ks",
                    CenaZaJednotku = 100,
                    Mnozstvi = 8,
                    CelkovaCena = 800,
                    DatumObjednani = DateTime.Now,
                    DodavatelId = 1,
                    ItemId = 2,
                    Mena = "CZK",
                    TerminDodani = (DateTime.Now.AddDays(7)),
                    Smazano = false,
                    SmazalUzivatel = null,
                    SmazanoDne = null
                },
                new Pozadavek
                {
                    Id = 3,
                    Popis = "Monitory",
                    Jednotka = "ks",
                    CenaZaJednotku = 4000,
                    Mnozstvi = 3,
                    CelkovaCena = 12000,
                    DatumObjednani = DateTime.Now,
                    DodavatelId = 2,
                    ItemId = 2,
                    Mena = "CZK",
                    TerminDodani = (DateTime.Now.AddDays(7)),
                    Smazano = false,
                    SmazalUzivatel = null,
                    SmazanoDne = null
                });

            context.Dodavatele.AddOrUpdate(d => d.ID,
                new Dodavatel { ID = 1, Nazev = "TSBohemia", Adresa = "Herspicka, Brno", IC = "13540313"},
                new Dodavatel { ID = 2, Nazev = "AlfaComp", Adresa = "Herspicka, Brno", IC = "145210302" },
                new Dodavatel { ID = 3, Nazev = "Gopas a.s.", Adresa = "Trnita, Brno", IC = "1214552" }
            );

            context.Files.AddOrUpdate(f => f.ID,
             new File { ID = 1, FileName = "3d.jpg", FullPath = @"\\juli-file\Pozadavky$\2016\P201600001\3d.jpg", Description = "Logo 3D", PozadavekID = 1 },
             new File { ID = 2, FileName = "Nyarlathotep.jpg", FullPath = @"\\juli-file\Pozadavky$\2016\P201600001\Nyarlathotep.jpg ", Description = "Nyarlathotep", PozadavekID = 2 },
             new File { ID = 3, FileName = "3d.jpg", FullPath = @"\\juli-file\Pozadavky$\2016\P201600001\3d.jpg ", Description = "Logo 3D znovu", PozadavekID = 2}
             );

        }
    }
}
