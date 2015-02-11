
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

using AdventureWorks;
using ExportSalesOrderDetailsServerSideTelerikControl.Models;

using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace ExportSalesOrderDetailsServerSideTelerikControl.Controllers
{
    public class HomeController : Controller
    {

        #region public ActionResult Index()
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }
        #endregion

        #region public ActionResult GetEmployeesForDataGrid([DataSourceRequest] DataSourceRequest request)
        public ActionResult GetSalesOrderDetailsForDataGrid([DataSourceRequest] DataSourceRequest request)
        {
            return Json(GetSalesOrderDetails().ToDataSourceResult(request));
            
            //return Json(GetSalesOrderDetails().Where(s => s.SalesOrderDetailID < 1000).ToDataSourceResult(request));

            //return Json(GetSalesOrderDetails().ToDataSourceResult(request));

        }
        #endregion

        #region private static IEnumerable<SalesOrderDetailViewModel> GetSalesOrderDetails()
        private static IEnumerable<SalesOrderDetailViewModel> GetSalesOrderDetails()
        {
            AdventureWorksContext context = new AdventureWorksContext();

            var sales = context.SalesOrderDetails.Select(sales_order_detail => new SalesOrderDetailViewModel
            {
                SalesOrderID = sales_order_detail.SalesOrderID,
                SalesOrderDetailID = sales_order_detail.SalesOrderDetailID,
                CarrierTrackingNumber = sales_order_detail.CarrierTrackingNumber,
                OrderQty = sales_order_detail.OrderQty,
                ProductID = sales_order_detail.ProductID,
                SpecialOfferID = sales_order_detail.SpecialOfferID,
                UnitPrice = sales_order_detail.UnitPrice,
                UnitPriceDiscount = sales_order_detail.UnitPriceDiscount,
                LineTotal = sales_order_detail.LineTotal,
                rowguid = sales_order_detail.rowguid,
                ModifiedDate = sales_order_detail.ModifiedDate
            });

            return sales;
        }
        #endregion

        #region public ActionResult ExportExcel(string contentType, string base64, string fileName)
        public ActionResult ExportExcel(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }
        #endregion
    
    }
}
