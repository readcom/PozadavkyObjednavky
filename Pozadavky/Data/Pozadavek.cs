namespace Pozadavky.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Pozadavky")]
    public partial class Pozadavek
    {
        [Key]
        public int Id { get; set; }

        
        public int ItemId { get; set; }

        public virtual Item Item { get; set; }


        [StringLength(100)]
        public string Popis { get; set; }

        [StringLength(10)]
        public string Jednotka { get; set; }

        public int Mnozstvi { get; set; }

        public float CenaZaJednotku { get; set; }

        public float CelkovaCena { get; set; }

        public DateTime DatumObjednani { get; set; }

        public DateTime TerminDodani { get; set; }

        public bool Smazano { get; set; }

        public string SmazalUzivatel { get; set; }

        public DateTime? SmazanoDne { get; set; }

        //[ForeignKey("Id")]
        //    public virtual Dodavatel Dodavatel { get; set; }

        [StringLength(3)]
        public string Mena { get; set; }

        //[ForeignKey("Id")]
        public int? DodavatelId { get; set; }

        // public virtual File File { get; set; }
        public virtual ICollection<File> Files { get; private set; }


    }
}
