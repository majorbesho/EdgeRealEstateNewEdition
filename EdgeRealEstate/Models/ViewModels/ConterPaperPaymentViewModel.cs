using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EdgeRealEstate.Models.ViewModels
{
    public class ConterPaperPaymentViewModel
    {
        public int refTypeDebitID { get; set; }
        public int ContributorId { get; set; }
        public string ContributorName { get; set; }
        public int refTypeDebit { get; set; }
        public string RefnameDebit { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/mm/yyyy}",ApplyFormatInEditMode =true)]
        public DateTime indateDebit { get; set; }
        public decimal paidDebit { get; set; }
       
    }
}