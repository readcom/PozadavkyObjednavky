namespace Pozadavky.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Items")]
    public partial class Item
    {
    

        [Key]
        public int ID { get; set; }

        //[Required]
        //public int PozadavekID { get; set; }

        [Required, StringLength(60)]
        public string Vlozil { get; set; }

        public DateTime? Datum { get; set; }

        [StringLength(500)]
        public string CelkovyPopis { get; set; }

        public bool Smazano { get; set; }

        public string SmazalUzivatel { get; set; }

        public DateTime? SmazanoDne { get; set; }

        // public virtual ICollection<Pozadavek> Pozadavky { get; private set; }


        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public Item()
        //{
        //    Pozadavky = new HashSet<Pozadavek>();
        //}

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    }
}
