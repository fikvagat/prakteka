//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace prakteka
{
    using System;
    using System.Collections.Generic;
    
    public partial class Requests
    {
        public int id { get; set; }
        public int product { get; set; }
        public int provider { get; set; }
        public int productCount { get; set; }
        public int priority { get; set; }
        public int status { get; set; }
    
        public virtual Providers Providers { get; set; }
        public virtual Statuses Statuses { get; set; }
    }
}