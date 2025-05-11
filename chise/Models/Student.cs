using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace chise.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string SchoolName { get; set; }
    }
}