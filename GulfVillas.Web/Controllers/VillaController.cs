using GulfVillas.Application.Common.Interfaces;
using GulfVillas.Domain.Entites;
using GulfVillas.Infrastructure.Data;
using GulfVillas.Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GulfVillas.Web.Controllers
{
    public class VillaController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IWebHostEnvironment _iWebHostEnvironment;

        public VillaController(IUnitOfWork unitOfWork, IWebHostEnvironment iWebHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _iWebHostEnvironment = iWebHostEnvironment;
        }

        public IActionResult Index()
        {
            var villas = _unitOfWork.Villa.GetAll();
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
                if(obj.Image is not null)
                {
                    string fileName= Guid.NewGuid().ToString() + Path.GetExtension(obj.Image.FileName);
                    string imagePath = Path.Combine(_iWebHostEnvironment.WebRootPath,@"images\VillaImage");

                    using var fileStream = new FileStream(Path.Combine(imagePath, fileName), FileMode.Create);
                    
                     obj.Image.CopyTo(fileStream);


                    obj.ImageURL = @"\images\VillaImage\" + fileName;


                }
                else
                 
                {
                    obj.ImageURL = "https://placehold.co/600x400";

                   // obj.ImageURL = "https://www.google.com/images/branding/googlelogo/1x/googlelogo_color_272x92dp.png";
                }


                _unitOfWork.Villa.Add(obj);
                _unitOfWork.Save();

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
            Villa? obj= _unitOfWork.Villa.Get(u => u.Id== villaId);

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
                //image update
                if (obj.Image is not null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(obj.Image.FileName);
                    string imagePath = Path.Combine(_iWebHostEnvironment.WebRootPath, @"images\VillaImage");

                    //if it has image we need to delete that
                    if (!string.IsNullOrEmpty(obj.ImageURL))
                    {
                        var oldImagePath = Path.Combine(_iWebHostEnvironment.WebRootPath, obj.ImageURL.TrimStart('\\')); //here we are triming the first slash from path

                        //delete the image
                        if (System.IO.Path.Exists(oldImagePath)) 
                        {
                          System.IO.File.Delete(oldImagePath);
                        }


                    }


                    using var fileStream = new FileStream(Path.Combine(imagePath, fileName), FileMode.Create);

                    obj.Image.CopyTo(fileStream);


                    obj.ImageURL = @"\images\VillaImage\" + fileName;


                }
               



                _unitOfWork.Villa.Update(obj);
                _unitOfWork.Save();

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
            Villa? obj = _unitOfWork.Villa.Get(u => u.Id == villaId);

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

            Villa? objFromDb= _unitOfWork.Villa.Get(u=> u.Id== obj.Id);

            if (objFromDb is not null) 
            {
                //if it has image we need to delete that
                if (!string.IsNullOrEmpty(objFromDb.ImageURL))
                {
                    var oldImagePath = Path.Combine(_iWebHostEnvironment.WebRootPath, objFromDb.ImageURL.TrimStart('\\')); //here we are triming the first slash from path

                    //delete the image
                    if (System.IO.Path.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }


                }




                _unitOfWork.Villa.Remove(objFromDb);
                _unitOfWork.Save();

                TempData["success"] = "Villa deleted successfully";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Villa not deleted successfully";
            return View(obj);
            
        }



    }
}
