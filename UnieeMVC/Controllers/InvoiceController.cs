using Microsoft.AspNetCore.Mvc;
using Microsoft.JSInterop.Infrastructure;
using UnieeMVC.Models;

namespace UnieeMVC.using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace UnieeMVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        public InvoiceController()
        {
        }

        [HttpGet("")]
        public ActionResult<IEnumerable<TModel>> GetTModels()
        {
            return new List<TModel> { };
        }

        [HttpGet("{id}")]
        public ActionResult<TModel> GetTModelById(int id)
        {
            return null;
        }

        [HttpPost("")]
        public ActionResult<TModel> PostTModel(TModel model)
        {
            return null;
        }

        [HttpPut("{id}")]
        public IActionResult PutTModel(int id, TModel model)
        {
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<TModel> DeleteTModelById(int id)
        {
            return null;
        }
    }
}
{
    public class InvoiceController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(InvoiceModel model)
        {
            ViewBag.TotalPrice = model.CalculateTotal();
            return View(model);
        }
    }
}