﻿using GulfVillas.Domain.Entites;
using GulfVillas.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace GulfVillas.Web.Controllers
{
    public class VillaController : Controller
    {
        private readonly ApplicationDbContext _db;

        public VillaController( ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var villas = _db.Villas.ToList();
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
                _db.Villas.Add(obj);
                _db.SaveChanges();

                //TempData["success"] = "Villa created successfully";
                return RedirectToAction("Index");


            }
            else
            {
               // return View(obj);
                return View();
            }

        

            

        }






    }
}
