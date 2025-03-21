using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace chise.Models
{
    public class Person
    {
        public string PersonId { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
    }
}
