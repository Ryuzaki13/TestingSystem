//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class TestQuestion
    {
        public long ID { get; set; }
        public long TestID { get; set; }
        public long QuestionID { get; set; }
    
        public virtual Question Question { get; set; }
        public virtual Test Test { get; set; }
    }
}
