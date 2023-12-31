﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TestMvc.Models;

namespace TestMvc.Controllers
{

    public class HomeController : Controller
    {
        ProductDbContext db = new ProductDbContext();
        // GET: Home
        public ActionResult Index(int page = 1)
        {
            ViewBag.TotalPage = (int)Math.Ceiling((double)db.produks.Count() / 5);
            ViewBag.CurrentPage = page;
            return View(db.produks.OrderBy(x => x.id).Skip((page - 1) * 5).Take(5).ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Produk p)
        {
            if (ModelState.IsValid)
            {
                db.produks.Add(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(p);
        }
        public ActionResult Edit(int id)
        {
            var product = db.produks.First(x => x.id == id);
            return View(product);
        }
        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Update(Produk p)
        {
            if (ModelState.IsValid)
            {
                db.Entry(p).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(p);
        }
        public ActionResult Delete(int ProductId)
        {

            if (ProductId > 0)
            {
                var studentbyid = db.produks.Where(x => x.id == ProductId).FirstOrDefault();
                if (studentbyid != null)
                {
                    db.Entry(studentbyid).State = EntityState.Deleted;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
            //var res = db.Products.Where(x => x.ProductId == ProductId).First();
            //db.Products.Remove(res);
            //db.SaveChanges();
            //var list = db.Products.ToList();
            //return View("Index",list);
        }
    }
}