using GulfVillas.Application.Common.Interfaces;
using GulfVillas.Domain.Entites;
using GulfVillas.Infrastructure.Data;
using GulfVillas.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GulfVillas.Web.Controllers
{
    public class AmenityController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AmenityController( IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            //Include is used to load related data from the database. It is used to specify which related entities should be included in the query results.
            //
            var Amenities = _unitOfWork.Amenity.GetAll(includeProperties: "Villa");
            return View(Amenities);
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

            AmenityVM amenityVM = new()
            {
                VillaList = _unitOfWork.Villa.GetAll().ToList().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
            };

            return View(amenityVM);
        
        }

        
        [HttpPost]
        public IActionResult Create(AmenityVM obj)
        {

                if (ModelState.IsValid)
                {

                    _unitOfWork.Amenity.Add(obj.Amenity);
                   _unitOfWork.Save();

                    TempData["success"] = "Amenity created successfully";
                    return RedirectToAction("Index", "Amenity");

                }

            //Issue here
            //Populating the Villalist again 
            obj.VillaList = _unitOfWork.Villa.GetAll().ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });

            return View(obj);


        }

        //Update Get Action/Endpoint
        public IActionResult Update(int amenityId)
        {

            //getting dropdown list of villas with VillasNumbers
            AmenityVM amenityVM = new()
            {
                VillaList = _unitOfWork.Villa.GetAll().ToList().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                Amenity = _unitOfWork.Amenity.Get(u => u.Id == amenityId)
            };


            if (amenityVM.Amenity is null)
            {

                return RedirectToAction("Error", "Home");
            }

            return View(amenityVM);

        }


        //Update Post
        [HttpPost]
        public IActionResult Update(AmenityVM amenityVM)
        {

             if (ModelState.IsValid)
             {
                    _unitOfWork.Amenity.Update(amenityVM.Amenity);
                    _unitOfWork.Save();

                    TempData["success"] = "Amenity updated successfully";
                    return RedirectToAction("Index", "Amenity");
             }
          
            //populating the villa list again
            amenityVM.VillaList = _unitOfWork.Villa.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });

            return View(amenityVM);

        }



        // Get Delete

        public IActionResult Delete(int amenityId)
        {

            //getting dropdown list of villas with VillasNumbers
            AmenityVM amenityVM = new()
            {
                VillaList = _unitOfWork.Villa.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                Amenity = _unitOfWork.Amenity.Get(u => u.Id == amenityId)
            };
            if (amenityVM.Amenity is null)
            {

                return RedirectToAction("Error", "Home");
            }

            return View(amenityVM);

        }


        //Delete Post
        [HttpPost]
        public IActionResult Delete(AmenityVM amenityVM)
        {

            Amenity? objFromDb= _unitOfWork.Amenity.Get(u=> u.Id == amenityVM.Amenity.Id);

            if (objFromDb is not null) 
            {
                _unitOfWork.Amenity.Remove(objFromDb);
                _unitOfWork.Save();

                TempData["success"] = "Amenity deleted successfully";
                return RedirectToAction(nameof(Index));
            }
            TempData["error"] = "Amenity not deleted successfully";
            return View(amenityVM);
            
        }



    }
}
