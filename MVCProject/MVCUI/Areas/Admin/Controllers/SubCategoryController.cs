using SERVICE.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCUI.Areas.Admin.Controllers
{
    public class SubCategoryController : Controller
    {
        SubCategoryService _subCategoryService = new SubCategoryService();
        public ActionResult Index()
        {
            return View(_subCategoryService.GetDefault(x=>x.Status==CORE.CoreEntity.Enums.Status.Active));
        }
        
    }
}