using BillsApplication.Models;
using BillsApplicationDomain;
using BillsApplicationDomain.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BillsApplication.Controllers
{
    public class BillController : Controller
    {
        private IBillService _service;

        public BillController(IBillService service)
        {
            _service = service;
        }

        //
        // GET: /Bills/
        public ActionResult Index()
        {
            return View(_service.GetBills());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new Bill()); 
        }

        [HttpPost]
        public ActionResult Create(Bill model)
        {
            if (ModelState.IsValid)
            {
                _service.Add(model);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var bill = _service.GetBillById(id);
            if (bill == null) throw new Exception("Could not find Bill");

            return View("Edit", bill);
        }

        [HttpPost]
        public ActionResult Edit(Bill model)
        {
            
            if (ModelState.IsValid)
            {
                _service.Update(model);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var bill = _service.GetBillById(id);
            if (bill == null) throw new Exception("Bill not found");

            return View(bill);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            _service.DeleteBillById(id);
            
            return RedirectToAction("Index");
        }
	}
}