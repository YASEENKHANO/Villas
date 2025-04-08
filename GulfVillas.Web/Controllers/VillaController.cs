using GulfVillas.Application.Common.Interfaces;
using GulfVillas.Domain.Entites;
using GulfVillas.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace GulfVillas.Web.Controllers
{
    public class VillaController : Controller
    {
        private readonly IVillaRepository _villaRepo;

        public VillaController(IVillaRepository villaRepo)
        {
            _villaRepo = villaRepo;
        }

        public IActionResult Index()
        {
            var villas = _villaRepo.GetAll();
            return View(villas);
        }

        public IActionResult Create()
        {
            return View();
        
        }

        [HttpPost]
        public IActionResult Create(Villa obj)
        {
           

            if (obj.Name == obj.Description) 
            {
                
                ModelState.AddModelError("name", " Description  can not be same as Villa Name");
            }

            if (ModelState.IsValid) 
            {
               _villaRepo.Add(obj);
                _villaRepo.Save();

                TempData["success"] = "Villa created successfully";
                return RedirectToAction("Index");

            }
            else
            {
                TempData["error"] = "Villa not created successfully";
                return View();
            }

        }

        public IActionResult Update(int villaId)
        {
            Villa? obj= _villaRepo.Get(u => u.Id== villaId);

            //var villalist = _db.Villas.Where(u => u.Price > 50 && u.Occupancy > 50);
            //var villa = _db.Villas.Where(u => u.Price > 50 && u.Occupancy > 50).FirstOrDefault(u => u.Id == villaId);
            //Villa? villaa= _db.Find(villaId);

            if (obj == null) {

                return RedirectToAction("Error","Home");
            }

            return View(obj);


        }



        [HttpPost]
        public IActionResult Update(Villa obj)
        {
             
            if (ModelState.IsValid && obj.Id>0)
            {
                _villaRepo.Update(obj);
                _villaRepo.Save();

                TempData["success"] = "Villa updated successfully";
                return RedirectToAction("Index");

            }
            else
            {
                TempData["error"] = "Villa not updated successfully";
                // return View(obj);
                return View();
            }

        }



        //Delete

        public IActionResult Delete(int villaId)
        {
            Villa? obj = _villaRepo.Get(u => u.Id == villaId);

            //var villalist = _db.Villas.Where(u => u.Price > 50 && u.Occupancy > 50);
            //var villa = _db.Villas.Where(u => u.Price > 50 && u.Occupancy > 50).FirstOrDefault(u => u.Id == villaId);
            //Villa? villaa= _db.Find(villaId);

            if (obj is null)
            {

                return RedirectToAction("Error", "Home");
            }

            return View(obj);


        }



        [HttpPost]
        public IActionResult Delete(Villa obj)
        {

            Villa? objFromDb= _villaRepo.Get(u=> u.Id== obj.Id);

            if (objFromDb is not null) 
            {
                _villaRepo.Remove(objFromDb);
                _villaRepo.Save();

                TempData["success"] = "Villa deleted successfully";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Villa not deleted successfully";
            return View(obj);
            
        }



    }
}
