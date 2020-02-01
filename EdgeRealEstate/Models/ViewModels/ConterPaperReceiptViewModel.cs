using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdgeRealEstate.Models.ViewModels
{
    public class ConterPaperReceiptViewModel
    {
        public int refTypeCreditID { get; set; }
        public int ContributorId { get; set; }
        public string ContributorName { get; set; }
        public int refTypeCredit { get; set; }
        public string RefnameCredit { get; set; }
        public DateTime indateCredit { get; set; }
        public decimal paidCredit { get; set; }
    }
}