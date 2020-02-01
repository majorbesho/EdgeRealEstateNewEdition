using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EdgeRealEstate.Models.ViewModels
{
    public class ContributerMoveViewModel
    {


        public int id { get; set; }
        public int ContributorId { get; set; }
        public string ContributorName { get; set; }
        public int refTypeCredit { get; set; }
        public string RefnameCredit { get; set; }
       // [DisplayFormat(DataFormatString = "{:dd MMM yyyy}")]
        public DateTime indateCredit { get; set; }
        public decimal paidCredit { get; set; }
        public int refTypeCreditID { get; set; }
        public int refTypeDebit { get; set; }
        public string RefnameDebit { get; set; }

     //   [DisplayFormat(DataFormatString = "{:dd MMM yyyy}")]
        public DateTime indateDebit { get; set; }
        public decimal paidDebit { get; set; }
        public decimal TotalCredit { get; set; }
        public decimal TotalDebit { get; set; }

        //public IEnumerable<ConterPaperPaymentViewModel> conterPaperPaymentViewModels { get; set; }
        //public IEnumerable<ConterPaperReceiptViewModel> conterPaperReceiptViewModels { get; set; }
    }


    class VmResult
    {
        //public IEnumerable<ConterPaperPaymentViewModel> conterPaperPaymentViewModels { get; set; }
        //public IEnumerable<ConterPaperReceiptViewModel> conterPaperReceiptViewModels { get; set; }
        //public List<ConterPaperPaymentViewModel> DebitVM { get; set; }
        //public List<ConterPaperReceiptViewModel> CreditVM { get; set; }

    }
}