using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test1.Models;


namespace Test1.Controllers
{
    public class UploadFileController : Controller
    {
        private TestDB db = new TestDB();
       
        //
        // GET: /UploadFile/

        public ActionResult Index()
        {
            var als = db.als;
            return View(als);
        }

        [HttpPost]
        public ActionResult UploadAlgorithm(HttpPostedFileBase up) 
        {
                var file = Request.Files[0];
                if (file != null && file.ContentLength > 0) 
                {
                    string path = Constants.serverPath;
                    string filename = Request.Files[0].FileName;
                    file.SaveAs(path +  filename);
                    Algorithm a = new Algorithm {name = file.FileName, dir = path};
                    if(SaveAlgorithm(a))
                        return Content("successfully uploaded. ");
                 }            
            
            return Content("upload failed. ");
        }

        //保存到数据库
        private bool SaveAlgorithm(Algorithm a) 
        {
            bool success = false;

            if (ModelState.IsValid)
            {
                db.als.Add(a);
                db.SaveChanges();
                success = true;
            }
        
            return success;
        }

        private bool SaveDataset(Dataset d)
        {
            bool success = false;

            if (ModelState.IsValid)
            {
                db.datas.Add(d);
                db.SaveChanges();
                success = true;
            }

            return success;
        }


        [HttpPost]
        public ActionResult UploadDataset(HttpPostedFileBase up)
        {
            var file = Request.Files[0];
            if (file != null && file.ContentLength > 0)
            {
                string path = Constants.serverPath;
                string filename = Request.Files[0].FileName;
                file.SaveAs(path + filename);
                Dataset d = new Dataset { name = file.FileName, dir = path };

                if (SaveDataset(d))
                    return Content("successfully uploaded. ");
            }

            return Content("upload failed. ");
        }

        public ActionResult Details(int id)
        {
            var al = db.als.Find(id);
            IEnumerable<Dataset> datas = al.datas;
            IEnumerable<Dataset> allDatas = db.datas.ToList();
            if(datas != null)
            {
                IEnumerable<Dataset> unmatchedDatas = new List<Dataset>();

                unmatchedDatas = allDatas.Except(datas).ToList();// 除了以上data的其他data ????
                ViewBag.UnmatchedDatas = new SelectList(unmatchedDatas, "datasetId", "name");
                ViewBag.algorithmId = id;

                return View(datas);
            }
            else
                return Content( "no matching algorithm for No." + id);
        }

        public ActionResult Match(FormCollection formcollection, int algorithmId)
        {
            bool success = false;
            int dataId = int.Parse(formcollection["UnmatchedDatas"].ToString());

            Console.Write(algorithmId +"\n" + dataId);// testcase

            if (ModelState.IsValid)
            {
                Dataset d = db.datas.Find(dataId);
                db.als.Find(algorithmId).datas.Add(d);

                db.SaveChanges();
                success = true;
            }
            return Content("" + success);        
        }
       

    }
}
