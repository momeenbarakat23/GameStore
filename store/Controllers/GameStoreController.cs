using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using store.Models;

namespace store.Controllers
{
    [Authorize/*(Roles ="Admin")*/]
    public class GameStoreController : Controller
    {
        private AppDbcontext dbcontext;
        public GameStoreController(AppDbcontext appDbcontext)
        {
            this.dbcontext = appDbcontext;
            
        }
        [AllowAnonymous]
        public IActionResult Index(string search)
        {
            if (search == null)
            {
                var data = dbcontext.GameStores.ToList();
                return View(data);
            }
            else 
            {
                var data = dbcontext.GameStores.Where(x=>x.Name==search).ToList();
                TempData["key"] = search;
                return View(data);
                
            }

        }
        [AllowAnonymous]
        public IActionResult viewall() 
        { 
            var data = dbcontext.GameStores.ToList();
            return View(data);
        }
        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult CreatSave(GameStore gameStore)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    dbcontext.GameStores.AddRange(gameStore);
                    dbcontext.SaveChanges();
                    return RedirectToAction("viewall");
                }

            }
            catch (Exception ex)
            {

                ModelState.AddModelError(string.Empty, ex.Message);
            }
            
        return View("create",gameStore);
        }

        public IActionResult delete(int id) 
        {
            var data = dbcontext.GameStores.SingleOrDefault(x => x.Id == id);
            dbcontext.RemoveRange(data);
            dbcontext.SaveChanges();
            return RedirectToAction("viewall");
        
        }

        public IActionResult Edit(int id)
        {
            var data =dbcontext.GameStores.SingleOrDefault(x=>x.Id == id);
            return View(data);
        }
        public IActionResult EditSave(GameStore gameStore)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    dbcontext.UpdateRange(gameStore);
                    dbcontext.SaveChanges();
                    return RedirectToAction("viewall");
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(string.Empty,ex.Message);
            }
            
            return View("Edit",gameStore);
            
        
        }
        [AllowAnonymous]
        public IActionResult Details(int id)
        {
            var data = dbcontext.GameStores.SingleOrDefault(x=>x.Id==id);
            return View(data);
        
        }
    }
    
}
