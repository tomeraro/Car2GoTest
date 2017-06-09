using ASPTest.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPTest.Controllers
{
    public class BackOfficeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            IData _DataRepository = new DataRepository();
            Models.BackOfficeModel model = new Models.BackOfficeModel();
            model.ItemsAndCount = _DataRepository.GetItemsAndCount();
            DateTime fromDate = DateTime.Now.AddDays(-7); //get data from week ago 
            model.ItemsAndCountFromDate = _DataRepository.GetItemsAccroding(fromDate);
            return View(model);
        }
    }
}