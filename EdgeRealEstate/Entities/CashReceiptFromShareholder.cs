using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdgeRealEstate.Entities
{
    public class CashReceiptFromShareholder
    {
        public int ID { get; set; }
        [DisplayName("الاسم")]
        public string Name { get; set; }
        [DisplayName("التكلفه")]
        public string Cost { get; set; }
        [DisplayName("التاريخ")]
        [DataType(DataType.Date)]

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Date { get; set; }
        //جارى – مخصص لمشروع التوجيه
        public bool Guiding { get; set; }
      

        public string Statement { get; set; }
    }
}