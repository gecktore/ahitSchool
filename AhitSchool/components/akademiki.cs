//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AhitSchool.components
{
    using System;
    using System.Collections.Generic;
    
    public partial class akademiki
    {
        public int id { get; set; }
        public string nameAk { get; set; }
        public Nullable<System.DateTime> dateBorn { get; set; }
        public Nullable<int> idSpecial { get; set; }
        public Nullable<int> yearPrisv { get; set; }
    
        public virtual spec spec { get; set; }
    }
}
