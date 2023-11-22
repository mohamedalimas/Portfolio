using Core.Interfaces.UnitOfWork;
using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Web.ViewModels;

namespace Web.Controllers
{
    public class PortItemController : Controller
    {
        private readonly IUnitOfWork<PortItem> portItems;
        private readonly IWebHostEnvironment hosting;


        public PortItemController(IUnitOfWork<PortItem> portItems , IWebHostEnvironment hosting)
        {
            this.portItems = portItems;
            this.hosting = hosting;
        }
        // GET: PortItemController
        public ActionResult Index()
        {
            var items = portItems.Repository.GetAll().ToList();
            return View(items);
        }

        // GET: PortItemController/Details/5
        public ActionResult Details(Guid id)
        {
            var item = portItems.Repository.GetByID(id);
            return View(item);
        }

        // GET: PortItemController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PortItemController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PortItemViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "please fill all fields!");
                    return View(model);
                }
                var fileName = model.file.FileName;
                var uploadsPath = Path.Combine(hosting.WebRootPath, "img/portfolio");
                var saveLocation = Path.Combine(uploadsPath, fileName);
                var fileStream = new FileStream(saveLocation, FileMode.Create);
                model.file.CopyTo(fileStream);
                fileStream.Close();
                var portItem = new PortItem()
                {
                    Id=model.PortId,
                    name = model.name,
                    description = model.description,
                    ImageUrl = fileName,
                };
                portItems.Repository.Add(portItem);
                portItems.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PortItemController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var item = portItems.Repository.GetByID(id);
            var model = new PortItemViewModel()
            {
                PortId= item.Id,
                name=item.name,
                description=item.description,
                ImgUrl=item.ImageUrl
            };
            return View(model);
        }

        // POST: PortItemController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PortItemViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "please fill all fields!");
                    return View(model);
                }
                var uploadsPath = Path.Combine(hosting.WebRootPath, "img\\portfolio");
                var oldPath = Path.Combine(uploadsPath, model.ImgUrl);
                if (System.IO.File.Exists(oldPath))
                {
                    System.IO.File.Delete(oldPath);
                }
                var newName = model.file.FileName;
                var newPath = Path.Combine(uploadsPath, newName);
                model.file.CopyTo(new FileStream(newPath, FileMode.Create));
                var item = new PortItem()
                {
                    Id = model.PortId,
                    name = model.name,
                    description = model.description,
                    ImageUrl = newName,
                };
                portItems.Repository.Update(item);
                portItems.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PortItemController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var item = portItems.Repository.GetByID(id);
            return View(item);
        }

        // POST: PortItemController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(PortItem item)
        {
            try
            {
                portItems.Repository.Delete(item);
                var uploadsPath = Path.Combine(hosting.WebRootPath, "img\\portfolio");
                var oldPath = Path.Combine(uploadsPath,item.ImageUrl);
                if (System.IO.File.Exists(oldPath))
                {
                    System.IO.File.Delete(oldPath);
                }
                portItems.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
