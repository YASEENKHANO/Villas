using GulfVillas.Domain.Entites;
using GulfVillas.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace GulfVillas.Web.Controllers
{
    public class VillaNumberController : Controller
    {
        private readonly ApplicationDbContext _db;

        public VillaNumberController( ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var villaNumbers = _db.VillaNumbers.ToList();
            return View(villaNumbers);
        }

        public IActionResult Create()
        {
            return View();
        
        }

        
        [HttpPost]
        public IActionResult Create(VillaNumber obj)
        {

            ModelState.Remove("villa");
            if (ModelState.IsValid) 
            {
                _db.VillaNumbers.Add(obj);
                _db.SaveChanges();

                TempData["success"] = "Villa Number created successfully";
                return RedirectToAction("Index","VillaNumber");


            }
            else
            {
                TempData["error"] = "Villa Number not created successfully";
                
                // return View(obj);
                return View();
            }

        }

        public IActionResult Update(int villaId)
        {
            Villa? obj= _db.Villas.FirstOrDefault(u => u.Id== villaId);

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
                _db.Villas.Update(obj);
                _db.SaveChanges();

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
            Villa? obj = _db.Villas.FirstOrDefault(u => u.Id == villaId);

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

            Villa? objFromDb= _db.Villas.FirstOrDefault(u=> u.Id== obj.Id);

            if (objFromDb is not null) 
            {
                _db.Villas.Remove(objFromDb);
                _db.SaveChanges();

                TempData["success"] = "Villa deleted successfully";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Villa not deleted successfully";
            return View(obj);
            
        }



    }
}
