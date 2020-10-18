using MODEL.Entities;
using SERVICE.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCUI.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Admin/Product
        ProductService _productService = new ProductService();
        public ActionResult Index()
        {
            return View(_productService.GetDefault(x => x.Status == CORE.CoreEntity.Enums.Status.Active));
        }

        public ActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(Product model)
        {
            if (ModelState.IsValid)
                _productService.Add(model);

            return View();
        }

        public ActionResult UpdateProduct(Guid id)
        {
            var updated = _productService.GetById(id);

            return View(updated);

        }
        [HttpPost]
        public ActionResult UpdateProduct(Product model)
        {
            _productService.Update(model);

            return RedirectToAction("Index");
        }

        public ActionResult DeleteCategory(Guid id)
        {
            _productService.Remove(id);
            return RedirectToAction("Index");
        }
    }
}