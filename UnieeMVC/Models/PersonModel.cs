using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace UnieeMVC.Models
{
    public class Person
    {
        public string PersonId { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
    }
}