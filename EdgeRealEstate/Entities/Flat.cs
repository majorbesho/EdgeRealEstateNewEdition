using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using EdgeRealEstate.Models;

namespace EdgeRealEstate.Entities
{[Table("Flat")]
    public class Flat
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       // [ForeignKey("DegreeOfExcellence")]
        public int id { get; set; }
        [Required]
        [MaxLength(50)]
        [DisplayName("الاسم عربى ")]
        public string Aname { get; set; }
        [DisplayName("الاسم لاتيني ")]
        public string Ename { get; set; }
        [DisplayName("الكود")]
        public string code { get; set; }
        [DisplayName("مساحه الشقه")]
        public int FlotSize { get; set; }
        [DisplayName("تاريخ البدايه الفعلي")]
        public DateTime BeginDateAcutely { get; set; }
        [DisplayName("تاريخ البدايه المتوقع")]
        public DateTime BeginDateExpected { get; set; }
        [DisplayName("تاريخ النهايه الفعلي")]
        public DateTime EndDateAcutely { get; set; }
        [DisplayName("تاريخ النهايه المتوقع")]
        public DateTime EndDateExpected { get; set; }
        public string ImgUrl { get; set; }
        public string AttachedId { get; set; }
        [DisplayName("الدور")]
        public int Level { get; set; }
        [DisplayName("عدد غرف النوم")]
        public int BedroomNo { get; set; }
        [DisplayName("عدد غرف الاسنقبال")]
        public int resptionNo { get; set; }
        [DisplayName("ملاحظات")]
        public string Nots { get; set; }
        [DisplayName("النوع")]
        public string  NewType { get; set; }

        //////////Start Relations///////////////
        [DisplayName("حاله الشقه")]
        public int FlatTypeId { get; set; }


        public FlatType FlatTypes { get; set; }

        [DisplayName("كود العمارة ")]

        public int BuildingId { get; set; }

        [ForeignKey(nameof(BuildingId))]
        public Buildings Building { get; set; }
        [DisplayName("كود المشروع")]
        public int ProjectsId { get; set; }

        [ForeignKey(nameof(ProjectsId))]
        public Projects Projects { get; set; }
        public virtual DegreeOfExcellence DegreeOfExcellence { get; set; }
        [DisplayName(" درجة التميز ")]
        public int DegreeOfExcellenceId { get; set; }
        public virtual ICollection<EmployeeSales> EmployeeSales { get; set; }
        public virtual ICollection<FlatAttachment> FlatAttachments { get; set; }

    }
}