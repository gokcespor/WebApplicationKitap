using Microsoft.AspNetCore.Mvc;
using WebApplicationKitap.Data;
using WebApplicationKitap.Models;

namespace WebApplicationKitap.Controllers
{
    public class YazarController : Controller
    {
        private readonly AppDbContext _context;

        public YazarController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateYazar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateYazar(Yazar yazar)
        {
            if (ModelState.IsValid) // Gelen her şey düzgün bir şekilde kontrol edildi mi diye yazılır
            {
                _context.Yazars.Add(yazar);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(yazar);
        }
        public IActionResult GetAllYazarlar()
        {
            // toList() metodu gelen veriyi liste gibi göstermesi tek özelliği sanılsa da aslında aynı zamanda gelen nesneleri liste halinde getirir ve işlem bittikten sonra veri tabanı bağlantısını otomatik kapatı.
            var yazarList = _context.Yazars.ToList();
            return View(yazarList);
        }
        [HttpPost]
        public IActionResult DeleteYazar(int id)
        {
            var yazar = _context.Yazars.FirstOrDefault(x => x.Id == id);
            _context.Yazars.Remove(yazar);
            _context.SaveChanges();

            return RedirectToAction("GetAllYazarlar", "Yazar");
        }
        public IActionResult UpdateYazar(int id)
        {
            var yazar = _context.Yazars.FirstOrDefault(x => x.Id == id);
            return View(yazar);
        }
        [HttpPost]
        public IActionResult UpdateYazar(Yazar yazar)
        {
            _context.Yazars.Update(yazar);
            _context.SaveChanges();
            return RedirectToAction("GetAllYazarlar", "Yazar");
        }
    }
}
