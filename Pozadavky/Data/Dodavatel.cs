namespace Pozadavky.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Dodavatele")]
    public partial class Dodavatel
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public Dodavatel()
        //{
        //    Pozadavky = new HashSet<Pozadavek>();
        //}

        [Key]
        public int ID { get; set; }

        [Required, StringLength(100)]
        public string Nazev { get; set; }

        [StringLength(100)]
        public string Adresa { get; set; }

        [StringLength(10)]
        public string IC { get; set; }

        [StringLength(12)]
        public string DIC { get; set; }

   
        public virtual ICollection<Pozadavek> Pozadavky { get; private set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Pozadavek> Pozadavky { get; set; }
    }
}
