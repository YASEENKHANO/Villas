using GulfVillas.Domain.Entites;
using GulfVillas.Infrastructure.Data;
using GulfVillas.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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
            //Include is used to load related data from the database. It is used to specify which related entities should be included in the query results.
            //
            var villaNumbers = _db.VillaNumbers.Include(u => u.Villa).ToList();
            return View(villaNumbers);
        }

        public IActionResult Create()
        {
            
            ////what is meant by projection in LINQ?
            ////Answer: Projection is the process of transforming data from one form to another. In LINQ, projection is typically done using the Select method, which allows you to create a new object or a new shape of data based on the original data source.
            ////In this case, we are projecting the Villa object into a SelectListItem object, which is used for populating dropdown lists in ASP.NET MVC.

            //IEnumerable<SelectListItem> villaList = _db.Villas.ToList().Select(u => new SelectListItem
            //{
            //    Text = u.Name,
            //    Value = u.Id.ToString()
            //});

            //View data is a Dictionary object that is used to pass data from the controller to the view. It is a way to transfer temporary data to the view.

            // ViewData["VillaList"] = villaList;

            //Other way to transfer temporary data to view is ViewBag,
            //here no need to convert the ViewData object to Ienumerable in the View.
            //ViewBag.VillaList = villaList;
            //return View();


            //AFTER Using ViewModel it is simple:

            VillaNumberVM villaNumberVM = new()
            {
                VillaList = _db.Villas.ToList().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
            };

            return View(villaNumberVM);
        
        }

        
        [HttpPost]
        public IActionResult Create(VillaNumberVM obj)
        {

            //ModelState.Remove("Villa"); //if we want to not validate  

            bool villaRoomNumberExist = _db.VillaNumbers.Any(u => u.Villa_Number == obj.VillaNumber.Villa_Number);

            if (!villaRoomNumberExist)
            {

                if (ModelState.IsValid)
                {

                    _db.VillaNumbers.Add(obj.VillaNumber);
                    _db.SaveChanges();

                    TempData["success"] = "Villa Number created successfully";
                    return RedirectToAction("Index", "VillaNumber");

                }
                else
                {
                    TempData["error"] = "Villa Number not created successfully";

                    // return View(obj);

                    return View();
                }
            }
            TempData["error"] = "Villa Number Already Exist!";

            //Populating the Villalist again 
            obj.VillaList = _db.Villas.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });

            return View(obj);


        }

        //Update Get Action/Endpoint
        public IActionResult Update(int villaNumberId)
        {

            //getting dropdown list of villas with VillasNumbers
            VillaNumberVM villaNumberVM = new()
            {
                VillaList = _db.Villas.ToList().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                VillaNumber = _db.VillaNumbers.FirstOrDefault(u => u.Villa_Number == villaNumberId)
            };


            if (villaNumberVM.VillaNumber is null)
            {

                return RedirectToAction("Error", "Home");
            }

            return View(villaNumberVM);

        }


        //Update Post
        [HttpPost]
        public IActionResult Update(VillaNumberVM villaNumberVM)
        {

             if (ModelState.IsValid)
             {
                    _db.VillaNumbers.Update(villaNumberVM.VillaNumber);
                    _db.SaveChanges();

                    TempData["success"] = "Villa Number updated successfully";
                    return RedirectToAction("Index", "VillaNumber");
             }
          
            //populating the villa list again
            villaNumberVM.VillaList = _db.Villas.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });

            return View(villaNumberVM);

        }



        //Delete

        public IActionResult Delete(int villaNumberId)
        {

            //getting dropdown list of villas with VillasNumbers
            VillaNumberVM villaNumberVM = new()
            {
                VillaList = _db.Villas.ToList().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                VillaNumber = _db.VillaNumbers.FirstOrDefault(u => u.Villa_Number == villaNumberId)
            };
            if (villaNumberVM.VillaNumber is null)
            {

                return RedirectToAction("Error", "Home");
            }

            return View(villaNumberVM);

        }


        //Delete Post
        [HttpPost]
        public IActionResult Delete(VillaNumberVM villaNumberVM)
        {

            VillaNumber? objFromDb= _db.VillaNumbers.FirstOrDefault(u=> u.Villa_Number == villaNumberVM.VillaNumber.Villa_Number);

            if (objFromDb is not null) 
            {
                _db.VillaNumbers.Remove(objFromDb);
                _db.SaveChanges();

                TempData["success"] = "Villa Number deleted successfully";
                return RedirectToAction(nameof(Index));
            }
            TempData["error"] = "Villa not deleted successfully";
            return View(villaNumberVM);
            
        }



    }
}
