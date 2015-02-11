using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExportSalesOrderDetailsServerSideTelerikControl.Models
{
    public class SalesOrderDetailViewModel
    {
        public int SalesOrderDetailID { get; set; }
        public int SalesOrderID { get; set; }
        public string CarrierTrackingNumber { get; set; }
        public short OrderQty { get; set; }
        public int ProductID { get; set; }
        public int SpecialOfferID { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal UnitPriceDiscount { get; set; }
        public decimal LineTotal { get; set; }
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}