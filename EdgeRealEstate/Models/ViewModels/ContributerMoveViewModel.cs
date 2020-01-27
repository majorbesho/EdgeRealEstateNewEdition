using System;
using System.Collections.Generic;
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
        public DateTime indateCredit { get; set; }
        public decimal paidCredit { get; set; }
        public int refTypeDebit { get; set; }
        public string RefnameDebit { get; set; }
        public DateTime indateDebit { get; set; }
        public decimal paidDebit { get; set; }
        public decimal TotalCredit { get; set; }
        public decimal TotalDebit { get; set; }
    }
}