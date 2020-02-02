using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EdgeRealEstate.Entities
{
    public class contractorPaperReceipt
    {
        public int id { get; set; }

        [ForeignKey("contractor")]
        [Display(Name="الاسم")]
        public int contractorId { get; set; }
        [Display(Name = "ةالمبلغ")]
        public decimal paid { get; set; }
        [Display(Name = "ملاحظات")]
        public string notes { get; set; }
        public string refType { get; set; }
        public int refID { get; set; }
        [Display(Name = "طريقه الدفع")]
        public string paidMethod { get; set; }

        [ForeignKey("Employee1")]
        public int salesManId { get; set; }
        public DateTime indate { get; set; }

        [ForeignKey("Employee")]
        public int empId { get; set; }
        public string hashCol { get; set; }
        public bool isDeleted { get; set; }
        [Display(Name = "رقم الفاتورة")]
        public int billId { get; set; }

        public virtual contractor contractor { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Employee Employee1 { get; set; }
    }
}