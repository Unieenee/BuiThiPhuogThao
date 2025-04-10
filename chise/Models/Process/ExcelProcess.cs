using System.Data;
using OfficeOpenXml;

namespace chise.Models.Process
{
    public class ExcelProcess
    {
        /// <summary>
        /// Reads data from an Excel file path and converts it to a DataTable.
        /// </summary>
        /// <param name="filePath">The file path of the Excel file.</param>
        /// <returns>A DataTable containing the extracted data.</returns>
        public DataTable ExcelToDataTable(string strPath)
        {
            FileInfo fi = new FileInfo(strPath);
            ExcelPackage excelPackage = new ExcelPackage(fi);
            DataTable dt = new DataTable();
            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[0];
            //check if the worksheet is completely empty
            if (worksheet.Dimension == null)
            {
                return dt;
            }
            //create a list to hold the column names
            List<string> columnNames = new List<string>();
            //needed to keep track of empty column headers
            int currentColumn = 1;
            //loop all columns in the sheet and add them to the DataTable
            foreach (var cell in worksheet.Cells[1, 1, 1, worksheet.Dimension.End.Column])
            {
                string columnName = cell.Text.Trim();
                //check if the previous header was empty and add it if it was
                if (cell.Start.Column != currentColumn)
                {
                    columnNames.Add("Header_" + currentColumn);
                    dt.Columns.Add("Header_" + currentColumn);
                    currentColumn++;
                }
                //add the column name to the list to count the duplicates
                columnNames.Add(columnName);
                //count the duplicate column names and make them unique to avoid the exception
                //A column named 'Name' already belongs to this DataTable
                int occurrences = columnNames.Count(x => x.Equals(columnName));
                if (occurrences > 1)
                {
                    columnName = columnName + "_" + occurrences;
                }
                //add the column to the DataTable
                dt.Columns.Add(columnName);
                currentColumn++;
            }

            //start adding the contents of the excel file to the DataTable
            for (int i = 2; i <= worksheet.Dimension.End.Row; i++)
            {
                var row = worksheet.Cells[i, 1, i, worksheet.Dimension.End.Column];
                DataRow newRow = dt.NewRow();
                //loop all cells in the row
                foreach (var cell in row)
                {
                    newRow[cell.Start.Column - 1] = cell.Text;
                }
                dt.Rows.Add(newRow);
            }
            return dt;
        }
        /// <summary>
        /// Reads data from an ExcelPackage and converts it to a DataTable.
        /// </summary>
        /// <param name="package">The ExcelPackage containing the workbook data.</param>
        /// <returns>A DataTable containing the extracted data.</returns>
        public DataTable ExcelToDataTable(ExcelPackage excelPackage)
        {
            DataTable dt = new DataTable();
            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[0];
            //check if the worksheet is completely empty
            if (worksheet.Dimension == null)
            {
                return dt;
            }
            //create a list to hold the column names
            List<string> columnNames = new List<string>();
            //needed to keep track of empty column headers
            int currentColumn = 1;
            //loop all columns in the sheet and add them to the DataTable
            foreach (var cell in worksheet.Cells[1, 1, 1, worksheet.Dimension.End.Column])
            {
                string columnName = cell.Text.Trim();
                //check if the previous header was empty and add it if it was
                if (cell.Start.Column != currentColumn)
                {
                    columnNames.Add("Header_" + currentColumn);
                    dt.Columns.Add("Header_" + currentColumn);
                    currentColumn++;
                }
                //add the column name to the list to count the duplicates
                columnNames.Add(columnName);
                //count the duplicate column names and make them unique to avoid the exception
                //A column named 'Name' already belongs to this DataTable
                int occurrences = columnNames.Count(x => x.Equals(columnName));
                if (occurrences > 1)
                {
                    columnName = columnName + "_" + occurrences;
                }
                //add the column to the DataTable
                dt.Columns.Add(columnName);
                currentColumn++;
            }

            //start adding the contents of the excel file to the DataTable
            for (int i = 2; i <= worksheet.Dimension.End.Row; i++)
            {
                var row = worksheet.Cells[i, 1, i, worksheet.Dimension.End.Column];
                DataRow newRow = dt.NewRow();
                //loop all cells in the row
                foreach (var cell in row)
                {
                    newRow[cell.Start.Column - 1] = cell.Text;
                }
                dt.Rows.Add(newRow);
            }
            return dt;
        }
    }
}