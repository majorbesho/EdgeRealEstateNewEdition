using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EdgeRealEstate.Entities
{
    public class ContPaperReceipt
    {
        public int id { get; set; }

        [ForeignKey("Contributor")]
        [DisplayName("الاسم")]

        public int ContributorId { get; set; }
        [DisplayName(" المبلغ")]

        public decimal Crdpaid { get; set; }
        [DisplayName("الملاحظات")]

        public string Crdnotes { get; set; }

        //public int refType { get; set; }
        public int refID { get; set; }
        [DisplayName("طريقة الدفع")]

        public string paidMethod { get; set; }

        public string ContPaperReceiptType { get; set; }

        //[ForeignKey("Employee1")]
        [DisplayName("مندوب المبيعات")]

        public int salesManId { get; set; }
        [DisplayName("التاريخ")]
        [DataType(DataType.Date)]

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]

        public DateTime Crdindate { get; set; }

        //[ForeignKey("Employee")]
        [DisplayName("الموظف")]
        public int empId { get; set; }
        public string hashCol { get; set; }
        public bool isDeleted { get; set; }
        [DisplayName("رقم ايصال الدفع")]
        public int  billId { get; set; }

        public virtual Contributor Contributor { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Employee Employee1 { get; set; }
        [ForeignKey("Project")]
        [DisplayName("المشروع")]
        public int? ProjectId { get; set; }
        public virtual Projects Project { get; set; }


        [ForeignKey("RefType")]
        public int CrdrefType { get; set; }
        public virtual LKRefTypes RefType { get; set; }

    }
}