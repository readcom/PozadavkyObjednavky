namespace Pozadavky.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class File
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public File()
        //{
        //    Pozadavky = new HashSet<Pozadavek>();
        //}

        [Key]
        public int ID { get; set; }

   
        public int PozadavekID { get; set; }

        [Required, StringLength(50)]
        public string FileName { get; set; }

        [Required, StringLength(100)]
        public string FullPath { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        public virtual Pozadavek Pozadavek { get; set; }

    }
}
