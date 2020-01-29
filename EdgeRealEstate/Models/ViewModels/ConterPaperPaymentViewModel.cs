using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdgeRealEstate.Models.ViewModels
{
    public class ConterPaperPaymentViewModel
    {
        public int ContributorId { get; set; }
        public string ContributorName { get; set; }
        public int refTypeDebit { get; set; }
        public string RefnameDebit { get; set; }
        public DateTime indateDebit { get; set; }
        public decimal paidDebit { get; set; }
    }
}