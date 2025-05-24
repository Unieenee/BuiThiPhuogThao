using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMovie.Models;
[Table("Daily")]
public class DaiLy
{
    [Key]
    public string? MaHTPP { get; set; }
    public string? MaDaiLy { get; set; }
    public string? TenDaiLy { get; set; }
    public string? Diachi { get; set; }
    public string? NguoiDaiDien { get; set; }
    public string? DienThoai { get; set; }
    public HTPP? HTPP {  get; set; }

}