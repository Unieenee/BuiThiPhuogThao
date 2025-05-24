
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models;
using OfficeOpenXml;
using X.PagedList;  


using X.PagedList.Extensions;

namespace MvcMovie.Controllers
{
   
    public class PersonController : Controller
    {
        private ExcelProcess _excelProcess = new ExcelProcess();
        private readonly ApplicationDbContext _context;
        public PersonController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int? page, int? PageSize)
        {
            ViewBag.PageSize = new List<SelectListItem>()
            {
                new SelectListItem() { Value="3", Text="3" },
                new SelectListItem() { Value="5", Text="5" },
                new SelectListItem() { Value="10", Text="10" },
                new SelectListItem() { Value="15", Text="15" },
                new SelectListItem() { Value="25", Text="25" },
                new SelectListItem() { Value="50", Text="50" },
            };
            int pagesize = (PageSize ?? 3);
            ViewBag.psize = pagesize;
            var model =  _context.Person.ToList().ToPagedList(page ?? 1, pagesize);
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonID,FullName,Address")] Person person)
        {
            if (ModelState.IsValid) { 
                _context.Add(person);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Person == null)
            {
                return NotFound();
            }    
            var person = await _context.Person.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("PersonID,FullName,Address")] Person person)
        {
            if(id != person.PersonId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(person);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonExists(person.PersonId))    
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));

            } 
            return View(person);
                
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Person == null)
            {
                return NotFound();
            }
            var person = await _context.Person.FirstOrDefaultAsync(m => m.PersonId == id);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Person == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Person' is null.");
            }
            var person = await _context.Person.FindAsync(id);
            if (person != null)
            {
                _context.Person.Remove(person);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Upload()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file != null)
            {
                string fileExtension = Path.GetExtension(file.FileName);
                if (fileExtension != ".xls" && fileExtension != ".xlsx")
                {
                    ModelState.AddModelError("", "Please choose excel file to upload!");
                }
                else
                {
                    //rename file when upload to server
                    var fileName = DateTime.Now.ToShortTimeString() + fileExtension;
                    var filePath = Path.Combine(Directory.GetCurrentDirectory() + "/Uploads/Excels", fileName);
                    var fileLocation = new FileInfo(filePath).ToString();
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        //save file to server
                        await file.CopyToAsync(stream);
                        var dt = _excelProcess.ExcelToDataTable(fileLocation);
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            var ps = new Person();
                            ps.PersonId = dt.Rows[i][0].ToString();
                            ps.FullName = dt.Rows[i][1].ToString();
                            ps.Address = dt.Rows[i][2].ToString();
                            _context.Add(ps);

                        }
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));

                    }
                }
            }
            return View();
        }
        public IActionResult Download()
        {

            var fileName = "Persons_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx";

            using (var excelPackage = new ExcelPackage())
            {
                var worksheet = excelPackage.Workbook.Worksheets.Add("Sheet1");

                // Header
                worksheet.Cells[1, 1].Value = "PersonId";
                worksheet.Cells[1, 2].Value = "FullName";
                worksheet.Cells[1, 3].Value = "Address";

                // Lấy dữ liệu từ DB
                var personList = _context.Person.ToList();

                // Thêm dữ liệu từ dòng 2
                int rowIndex = 2;
                foreach (var person in personList)
                {
                    worksheet.Cells[rowIndex, 1].Value = person.PersonId;
                    worksheet.Cells[rowIndex, 2].Value = person.FullName;
                    worksheet.Cells[rowIndex, 3].Value = person.Address;
                    rowIndex++;
                }

                // Tự động fit cột cho đẹp
                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                var fileBytes = excelPackage.GetAsByteArray();

                return File(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
            }
        }

        private bool PersonExists(string id)
        {
            return (_context.Person?.Any(e => e.PersonId == id)).GetValueOrDefault();
        }
    }
}