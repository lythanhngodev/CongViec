using CongViec.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using CongViec.DataConnect;
using WEB_DLL;

namespace CongViec
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

        }
        protected void Session_Start(object sender, EventArgs e)
        {
            ntsDataConnect._mCreateFileConnectString(@".\sqlexpress", "USERSQLCV", "QLCV_laptrinh2020");
            //ntsSqlFunctions ntsSQLServerFunctions = new ntsSqlFunctions(ntsSqlRunType.Web);
            Session.SetConnectionString1(@"Data Source=.\SQLEXPRESS;Initial Catalog=USERSQLCV;Integrated Security=True");
            Session.SetConnectionString2(@"Data Source=.\SQLEXPRESS;Initial Catalog=QLCV_laptrinh2020;Integrated Security=True");
            //SqlFunction sqlFun = new SqlFunction(Session.GetConnectionString1());
            //UsersDataContext db = new UsersDataContext();
            //IQueryable<tblDMDonvi> tblDMDonVi = from tdbDvi in db.tblDMDonvis
            //                                    where tdbDvi.maDonVi.ToLower() == sqlFun.GetOneStringField(@"SELECT CONVERT(nvarchar(18), maDonVipr_sd) 
            //                                    FROM dbo.tblUsers WHERE tenDangNhap=N'banqldathoibinh'") //"94000083"//"94000087" // tmmkieu ĐT
            //                                    select tdbDvi;
            //tblDMDonvi _vdbDonVi = tblDMDonVi.FirstOrDefault();
            //Session.SetDonVi(_vdbDonVi);
            //Session.SetTenDonVi(_vdbDonVi.tenDonVi);
            //Session.SetMaQHNS(_vdbDonVi.maNgansachpr);
            //Session.SetHienNgayInBC(true);
            //Session.SetNgayInBC("01/01/" + DateTime.Now.Year);
            //Session.SetMaChuong("1");
            //Session.SetDiaDanh("Vĩnh Long");
            //tblUser _vuser = new tblUser();
            //_vuser.ngayThaotac = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            //_vuser.nguoiThaoTac = sqlFun.GetOneDecimalField("SELECT CONVERT(dec(18,0), maNguoidungpr) FROM tblUsers WHERE tenDangNhap=N'banqldathoibinh'");
            //_vuser.maNguoidungpr = sqlFun.GetOneDecimalField("SELECT CONVERT(dec(18,0), maNguoidungpr) FROM tblUsers WHERE tenDangNhap=N'banqldathoibinh'");
            //_vuser.tenDangNhap = sqlFun.GetOneStringField("SELECT CONVERT(dec(18,0), tenDangNhap) FROM tblUsers WHERE tenDangNhap=N'banqldathoibinh'");
            //_vuser.idGrouppr_sd = "admin";
            //Session.setNamSudung("2019");
            //Session.SetCurrentUser(_vuser);
            //Session.SetNgayDauKy("01/01/2020");
            //Session.SetNgayCuoiKy("31/12/2020");
            //Session.SetCurrentDatetime(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day));
            //Session.Add("ntsSTTDuAn", "1705");
            //Session.Add("CurrentPermiss", "false;true;true;true;true;true;true;true;true");
        }
    }
}
