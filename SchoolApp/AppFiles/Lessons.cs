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
    
    public partial class Lessons
    {
        public int IdStudent { get; set; }
        public int IdSubject { get; set; }
        public System.DateTime GradeDate { get; set; }
        public int IdGrade { get; set; }
        public int Id { get; set; }
        public Nullable<int> IdClass { get; set; }
    
        public virtual Classes Classes { get; set; }
        public virtual Grades Grades { get; set; }
        public virtual Students Students { get; set; }
        public virtual Subjects Subjects { get; set; }
    }
}
