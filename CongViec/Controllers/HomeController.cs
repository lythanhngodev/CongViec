using CongViec.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using WEB_DLL;

namespace CongViec.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult DMCongViec()
        {
            ViewBag.Message = "Đây là danh mục công việc.";

            return View();
        }

        public ActionResult LoadData()
        {
            try
            {
                var draw = Request.Form.GetValues("draw").FirstOrDefault();
                var start = Request.Form.GetValues("start").FirstOrDefault();
                var length = Request.Form.GetValues("length").FirstOrDefault();
                var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
                var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();
                var searchValue = Request.Form.GetValues("search[value]").FirstOrDefault();


                //Paging Size (10,20,50,100)    
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;

                // Getting all Customer data    
                //SqlParameter[] para = {
                //    new SqlParameter("@NhapKhoID", (data.Trim().Length==0) ? (object)DBNull.Value : Guid.Parse(data.ToString()))
                //};
                DataTable duLieu = SqlHelper.ExecuteDataset((string)Session[ntsEnumSessionName.ntsConnectionString2.ToString()], "Proc_GetCongViec", null).Tables[0];
                var customerData = duLieu.AsEnumerable();
                //Sorting    
                //if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
                //{
                //    customerData = customerData.OrderBy(sortColumn + " " + sortColumnDir);
                //}
                //Search    
                //if (!string.IsNullOrEmpty(searchValue))
                //{
                //    customerData = customerData.Where(m => m.CompanyName == searchValue);
                //}

                //total number of rows count     
                recordsTotal = customerData.Count();
                //Paging     
                var data = customerData.Skip(skip).Take(pageSize).ToList();
                //Returning Json Data    
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { data = ex.ToString()});
            }
        }

        public string LoadData4()
        {
            try
            {
                var draw = Request.Form.GetValues("draw").FirstOrDefault();
                var start = Request.Form.GetValues("start").FirstOrDefault();
                var length = Request.Form.GetValues("length").FirstOrDefault();
                var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
                var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();
                var searchValue = Request.Form.GetValues("search[value]").FirstOrDefault();


                //Paging Size (10,20,50,100)    
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;

                // Getting all Customer data    
                //SqlParameter[] para = {
                //    new SqlParameter("@NhapKhoID", (data.Trim().Length==0) ? (object)DBNull.Value : Guid.Parse(data.ToString()))
                //};
                DataTable duLieu = SqlHelper.ExecuteDataset((string)Session[ntsEnumSessionName.ntsConnectionString2.ToString()], "Proc_GetCongViec", null).Tables[0];
                var customerData = duLieu.AsEnumerable();
                //Sorting    
                //if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
                //{
                //    customerData = customerData.OrderBy(sortColumn + " " + sortColumnDir);
                //}
                //Search    
                //if (!string.IsNullOrEmpty(searchValue))
                //{
                //    customerData = customerData.Where(m => m.CompanyName == searchValue);
                //}

                //total number of rows count     
                recordsTotal = customerData.Count();
                //Paging     
                var data = customerData.Skip(skip).Take(pageSize).ToList();
                //Returning Json Data    
                return JSonHelper.ToJson(duLieu);

            }
            catch (Exception ex)
            {
                return JSonHelper.ToJson(ex.ToString());
            }
        }

        [HttpPost]
        public string LoadData2()
        {
            try
            {
                DataTable duLieu = SqlHelper.ExecuteDataset((string)Session[ntsEnumSessionName.ntsConnectionString2.ToString()], "Proc_GetCongViec", null).Tables[0];
                //Returning Json Data    
                return JSonHelper.ToJson(duLieu).ToString();

            }
            catch (Exception ex)
            {
                return Json(new { data = ex.ToString() }).ToString();
            }
        }

        [HttpPost]
        public JsonResult LoadData3()
        {
            try
            {
                DataTable duLieu = SqlHelper.ExecuteDataset((string)Session[ntsEnumSessionName.ntsConnectionString2.ToString()], "Proc_GetCongViec", null).Tables[0];
                //Returning Json Data    
                return Json(new { data = duLieu });

            }
            catch (Exception ex)
            {
                return Json(new { data = ex.ToString() });
            }
        }
    }
}