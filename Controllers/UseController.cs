using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test1.Models;

namespace Test1.Controllers
{
    public class UseController : Controller
    {
        //
        // GET: /Use/
        private TestDB db = new TestDB();


        public ActionResult Index()
        {
            ViewBag.als = new SelectList(db.als, "algorithmId", "name");
            ViewBag.datas = new SelectList(db.datas, "datasetId", "name");

            return View();
        }

        [HttpPost]
        public ActionResult StartUse(FormCollection formcollection)
        {
            string alsId = formcollection["als"].ToString();
            string datasId = formcollection["datas"].ToString();

            return Content(alsId + datasId);
        }

       
    }
}
