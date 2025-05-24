using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMovie.Models;
[Table("HTPP")]
public class HTPP
{
    [Key]
    public string? MaHTPP { get; set; }
    public string? TenHTPP { get; set; }
   
}