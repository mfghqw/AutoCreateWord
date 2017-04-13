namespace CABISP.Helper.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class zf_HelperContent
    {
        [Key]
        public int HelperContentId { get; set; }

        public int HelperTypeId { get; set; }

        [Required]
        [StringLength(50)]
        public string HelperTitle { get; set; }

        [Required]
        public string Content { get; set; }

        public bool IsDel { get; set; }

        public int Priority { get; set; }

        public DateTime AddDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        [StringLength(50)]
        public string Remark { get; set; }

        public virtual zf_HelperType zf_HelperType { get; set; }
    }
}
