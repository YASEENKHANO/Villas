﻿using GulfVillas.Infrastructure.Data;
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
    }
}
