using Microsoft.AspNetCore.Mvc;
using WebApplicationKitap.Data;
using WebApplicationKitap.Models;

namespace WebApplicationKitap.Controllers
{
	public class KitapController : Controller
	{
		private readonly AppDbContext _context;

		public KitapController(AppDbContext context)
        {
			_context = context;
		}
        public IActionResult Index()
		{
			return View();
		}
		public IActionResult CreateKitap()
		{
			return View();
		}
		[HttpPost]
		public IActionResult CreateKitap(Kitap kitap)
		{
			_context.Kitaps.Add(kitap);
			_context.SaveChanges();
			return RedirectToAction("GetAllKitaplar", "Kitap");
		}
		public IActionResult GetAllKitaplar()
		{
			var kitapList = _context.Kitaps.ToList();
			return View(kitapList);
		}
		[HttpPost]
		public IActionResult DeleteKitap(int id)
		{
			var kitap = _context.Kitaps.Find(id);
			if (kitap != null)
			{
				_context.Kitaps.Remove(kitap);
				_context.SaveChanges();
			}
			return RedirectToAction("GetAllKitaplar", "Kitap");
		}
		public IActionResult UpdateKitap(int id)
		{
			var kitap = _context.Kitaps.Find(id);
            if (kitap == null)
            {
				return NotFound();
            }
			return View(kitap);
        }
		[HttpPost]
        public IActionResult UpdateKitap(Kitap kitap)
        {
            _context.Kitaps.Update(kitap);
			_context.SaveChanges();
			return RedirectToAction("GetAllKitaplar", "Kitap");
        }
    }
}
