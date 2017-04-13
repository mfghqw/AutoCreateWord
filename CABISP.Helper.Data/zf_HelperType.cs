namespace CABISP.Helper.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class zf_HelperType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public zf_HelperType()
        {
            zf_HelperContent = new HashSet<zf_HelperContent>();
        }

        [Key]
        public int HelperTypeId { get; set; }

        [Required]
        [StringLength(50)]
        public string HelperTypeName { get; set; }

        public int PId { get; set; }

        public int ApplicationScope { get; set; }

        public int Priority { get; set; }

        public bool IsDel { get; set; }

        [StringLength(50)]
        public string Remark { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<zf_HelperContent> zf_HelperContent { get; set; }
    }
}
