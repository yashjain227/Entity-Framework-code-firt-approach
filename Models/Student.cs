using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace codefirst.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Column("student name",TypeName ="varchar(20)")]
        public String Name { get; set; }


        [Column("student gender", TypeName = "varchar(20)")]
        public String Gender { get; set; }
        public int Age { get; set; }


    }
}
