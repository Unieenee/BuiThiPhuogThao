using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMovie.Models;
[Table("Employee")]
public class Employee : Person
{
    public string? EmployeeId { get; set; }
    public int Age { get; set; }

}