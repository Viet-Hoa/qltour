//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core.DTO
{
    using System;
    using System.Collections.Generic;
    
    public partial class DOAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DOAN()
        {
            this.DATTOURs = new HashSet<DATTOUR>();
            this.PHANCONGs = new HashSet<PHANCONG>();
            this.CTCHIPs = new HashSet<CTCHIP>();
        }
    
        public int ID { get; set; }
        public string TENDOAN { get; set; }
        public int IDTOUR { get; set; }
        public System.DateTime NGAYBD { get; set; }
        public System.DateTime NGAYKT { get; set; }
        public string CHITIET { get; set; }
        public int CHIPHI { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DATTOUR> DATTOURs { get; set; }
        public virtual TOUR TOUR { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHANCONG> PHANCONGs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTCHIP> CTCHIPs { get; set; }
    }
}
