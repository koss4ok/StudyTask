//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Komputers
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Processor { get; set; }
        public int Motherboard { get; set; }
        public int Ram { get; set; }
        public int Hard_drive { get; set; }
        public int Delivery { get; set; }
        public Nullable<int> Order { get; set; }
        public byte[] image { get; set; }
    
        public virtual Deliveries Deliveries { get; set; }
        public virtual Hard_disks Hard_disks { get; set; }
        public virtual Motherboards Motherboards { get; set; }
        public virtual Orders Orders { get; set; }
        public virtual Processors Processors { get; set; }
        public virtual Rams Rams { get; set; }
    }
}
