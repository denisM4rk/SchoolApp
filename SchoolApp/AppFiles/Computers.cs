//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SchoolApp.AppFiles
{
    using System;
    using System.Collections.Generic;
    
    public partial class Computers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Computers()
        {
            this.Teachers = new HashSet<Teachers>();
        }
    
        public int Id { get; set; }
        public string Processor { get; set; }
        public string Memory { get; set; }
        public string Storage { get; set; }
        public string GraphicsCard { get; set; }
        public string PowerSupply { get; set; }
        public System.DateTime AntivirusLicenseStart { get; set; }
        public System.DateTime AntivirusLicenseEnd { get; set; }
        public string SerialNumber { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Teachers> Teachers { get; set; }
    }
}
