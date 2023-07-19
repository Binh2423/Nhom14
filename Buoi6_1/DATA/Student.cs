namespace Buoi6_1.DATA
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Student")]
    public partial class Student
    {
        [Key]
        [StringLength(20)]
        public string StudenID { get; set; }

        [StringLength(200)]
        public string Fullname { get; set; }

        public double? AverageScore { get; set; }

        public int FacultyID { get; set; }
    }
}
