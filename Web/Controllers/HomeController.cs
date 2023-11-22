using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Web.ViewModels;
using Core.Interfaces.UnitOfWork;
namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork<Owner> owner;
        private readonly IUnitOfWork<PortItem> item;

        public HomeController(IUnitOfWork<Owner> owner , IUnitOfWork<PortItem> item)
        {
            this.owner = owner;
            this.item = item;
        }
        public IActionResult Index()
        {
            var model = new HomeViewModel()
            {
                Owner = owner.Repository.GetAll().First() ,
                PortItems = item.Repository.GetAll().ToList() ,
            };
            return View(model);
        }
    }
}
