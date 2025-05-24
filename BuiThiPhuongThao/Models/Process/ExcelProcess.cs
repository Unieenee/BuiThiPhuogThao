using OfficeOpenXml;
using System.Data;
using System.IO;

public class ExcelProcess
{
    public DataTable ExcelToDataTable(string path)
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        var dt = new DataTable();

        // Định nghĩa 3 cột đúng yêu cầu
        dt.Columns.Add("PersonId", typeof(string));
        dt.Columns.Add("FullName", typeof(string));
        dt.Columns.Add("Address", typeof(string));

        using (var package = new ExcelPackage(new FileInfo(path)))
        {
            var worksheet = package.Workbook.Worksheets[0]; // Lấy sheet đầu tiên

            int rowCount = worksheet.Dimension.Rows;

            // Bỏ qua hàng đầu tiên nếu đó là header
            for (int row = 2; row <= rowCount; row++)
            {
                var personId = worksheet.Cells[row, 1].Text;
                var fullName = worksheet.Cells[row, 2].Text;
                var address = worksheet.Cells[row, 3].Text;

                dt.Rows.Add(personId, fullName, address);
            }
        }

        return dt;
    }
}