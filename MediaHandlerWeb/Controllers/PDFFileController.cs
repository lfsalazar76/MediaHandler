using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MFileCL.BL;

namespace MediaHandlerWeb.Controllers
{
    public class PDFFileController : Controller
    {
        // GET: PDFFileController
        public ActionResult Index()
        {
            var data = MFLogic.ListFile();

            List<Models.PDFFileModelView> pdfs = new List<Models.PDFFileModelView>();
            foreach(var row in data)
            {
                pdfs.Add(new Models.PDFFileModelView
                {
                    ID = row.ID,
                    Name = row.Name,
                    Location = row.Location,
                    Filesize = row.Filesize

                });
            }

            
            return View(pdfs);
        }

        // GET: PDFFileController/Details/5
        public ActionResult Details(int id)
        {
            MFileCL.Models.PDFFile PdffileDB = MFLogic.GetPDFFile(id);
            MediaHandlerWeb.Models.PDFFileModelView pdfweb = new Models.PDFFileModelView
            {
                ID = PdffileDB.ID,
                Filesize = PdffileDB.Filesize,
                Location = PdffileDB.Location,
                Name = PdffileDB.Name
            };
            return View(pdfweb);
        }

        // GET: PDFFileController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PDFFileController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                int temp = int.Parse(collection["Filesize"]);
                
                MFileCL.BL.MFLogic.AddFile(collection["Name"], collection["Location"], temp);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PDFFileController/Edit/5
        public ActionResult Edit(int id)
        {
            MFileCL.Models.PDFFile PdffileDB = MFLogic.GetPDFFile(id);
            MediaHandlerWeb.Models.PDFFileModelView pdfweb = new Models.PDFFileModelView
            {
                ID = PdffileDB.ID,
                Filesize = PdffileDB.Filesize,
                Location = PdffileDB.Location,
                Name = PdffileDB.Name
            };
            return View(pdfweb);
        }

        // POST: PDFFileController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                MFileCL.BL.MFLogic.EditFile(id, collection["Name"], collection["Location"], int.Parse(collection["FileSize"]));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PDFFileController/Delete/5
        public ActionResult Delete(int id)
        {
            MFileCL.Models.PDFFile PdffileDB = MFLogic.GetPDFFile(id);
            MediaHandlerWeb.Models.PDFFileModelView pdfweb = new Models.PDFFileModelView
            {
                ID = PdffileDB.ID,
                Filesize = PdffileDB.Filesize,
                Location = PdffileDB.Location,
                Name = PdffileDB.Name
            };
            return View(pdfweb);
        }

        // POST: PDFFileController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                MFileCL.BL.MFLogic.DeleteFile(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
