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
    
    public partial class ProductsInOrder
    {
        public int id { get; set; }
        public string productArticle { get; set; }
        public int orderID { get; set; }
        public int count { get; set; }
    
        public virtual Orders Orders { get; set; }
        public virtual Products Products { get; set; }
    }
}