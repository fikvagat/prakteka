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
    
    public partial class SalesHistory
    {
        public int id { get; set; }
        public string product { get; set; }
        public int count { get; set; }
        public System.DateTime Date { get; set; }
    
        public virtual Products Products { get; set; }
    }
}
