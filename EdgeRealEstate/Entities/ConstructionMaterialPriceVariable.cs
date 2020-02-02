using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EdgeRealEstate.Entities
{
    public class ConstructionMaterialPriceVariable
    {
        [Key]

        public int ID { get; set; }
        [DisplayName("اخر سعر  ")]
        public string lastPrice { get; set; }
        [DisplayName("اخر مورد")]

        public string lastSupplier { get; set; }
        [DisplayName(" التنفيذ ")]
        public string ExecutiveEngineerPrice { get; set; }
        [DisplayName("سعر السوق ")]
        public string Marketprice { get; set; }

        ///
        /// Start Relations
        ///

        public int ConstructionMaterialId { get; set; }
        //public ConstructionMaterial ConstructionMaterial { get; set; }
    }
}