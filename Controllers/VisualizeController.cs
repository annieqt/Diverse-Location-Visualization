using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test1.Models;


namespace Test1.Controllers
{
    public class VisualizeController : Controller
    {
        //
        // GET: /Visualize/

        public ActionResult Index()
        {
            return View();
        }

        public void Visualize(Algorithm al, Dataset data) 
        {
            string alPath = al.name;//算法已经编成dll 只需要知道名字就行
            //MWArray readDataset();

            //需要矩阵作为参数


        }
        //其实应该返回一个MWArray
        private void readDataset(Dataset data)
        {
            string dataPath = data.dir + data.name;
            //读取相应格式
        }
    
    }
}
