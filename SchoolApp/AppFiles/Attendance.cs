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
    
    public partial class Attendance
    {
        public int Id { get; set; }
        public int IdStudent { get; set; }
        public int IdTeacher { get; set; }
        public int IdSubject { get; set; }
        public System.DateTime Date { get; set; }
        public string Attendance1 { get; set; }
    
        public virtual Students Students { get; set; }
        public virtual Subjects Subjects { get; set; }
        public virtual Teachers Teachers { get; set; }
    }
}
