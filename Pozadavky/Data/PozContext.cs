namespace Pozadavky.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using DTO;
    public partial class PozContext : DbContext
    {
        public PozContext()
            : base("name=SQLConnection")
        {
        }

        public virtual DbSet<Item> Items { get; set; }

        public virtual DbSet<Pozadavek> Pozadavky { get; set; }

        public virtual DbSet<Dodavatel> Dodavatele { get; set; }

        public virtual DbSet<File> Files { get; set; }
        
        
        
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Dodavatel>()
        //        .HasMany(e => e.Pozadavky)
        //        .WithOptional(e => e.Dodavatele)
        //        .HasForeignKey(e => e.DodavatelId);

        //    modelBuilder.Entity<File>()
        //        .Property(e => e.FileName)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<File>()
        //        .Property(e => e.FullPath)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<File>()
        //        .Property(e => e.Description)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<Item>()
        //        .Property(e => e.Vlozil)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<Item>()
        //        .HasMany(e => e.Pozadavkies)
        //        .WithRequired(e => e.Item)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<Pozadavek>()
        //        .Property(e => e.Mena)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<Pozadavek>()
        //        .Property(e => e.Cena)
        //        .HasPrecision(10, 2);
        //}
    }
}
