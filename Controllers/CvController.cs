using Microsoft.AspNetCore.Mvc;
using CvApp.Models;

namespace CvApp.Controllers
{
    public class CvController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(CvModel model)
        {
            if (ModelState.IsValid)
            {
                return View("Result", model);
            }
            return View(model);
        }
        public IActionResult DownloadPdf()
        {
            if (TempData["CvData"] == null)
                return RedirectToAction("Index");

#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
            var model = System.Text.Json.JsonSerializer.Deserialize<CvModel>(
                TempData["CvData"].ToString()
            );
#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning restore CS8602 // Dereference of a possibly null reference.

            return new ViewAsPdf("Result", model)
            {
                FileName = "CV.pdf"
            };
        }
    }

    internal class ViewAsPdf(string v, CvModel? model) : IActionResult
    {
        private string v = v;
        private CvModel? model = model;

        public required string FileName { get; set; }

        public Task ExecuteResultAsync(ActionContext context)
        {
            throw new NotImplementedException();
        }
    }
}



