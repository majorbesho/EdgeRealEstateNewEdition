using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EdgeRealEstate.Entities
{
    public class ContPaperPayment
    {
        public int id { get; set; }

        [ForeignKey("Contributor")]
        public int ContributorId { get; set; }
        public decimal Dbtpaid { get; set; }
        public string Dbtnotes { get; set; }
        
        public int? refID { get; set; }
        public int paidMethod { get; set; }
        public string ContPaperPaymentType { get; set; }

        //[ForeignKey("Employee1")]
        public int salesManId { get; set; }
        public DateTime Dbtindate { get; set; }

        //[ForeignKey("Employee")]
        public int empId { get; set; }
        public string hashCol { get; set; }
        public bool isDeleted { get; set; }
        public int billId { get; set; }
        public virtual Contributor Contributor { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Employee Employee1 { get; set; }
        [ForeignKey("Project")]
        public int? ProjectId { get; set; }
        public virtual Projects Project { get; set; }

        [ForeignKey("RefType")]
        public int? DbtrefType { get; set; }
        public virtual LKRefTypes RefType { get; set; }
    }
}