//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarAppDBFirst
{
    using System;
    using System.Collections.Generic;
    
    public partial class Direction
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Direction()
        {
            this.Travels = new HashSet<Travel>();
        }
    
        public int DirectionId { get; set; }
        public string Name { get; set; }
        public int DepartureId { get; set; }
        public int DestinationId { get; set; }
        public int Distance { get; set; }
    
        public virtual Point Point { get; set; }
        public virtual Point Point1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Travel> Travels { get; set; }
    }
}
