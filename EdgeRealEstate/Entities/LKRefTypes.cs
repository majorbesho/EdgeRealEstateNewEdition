using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdgeRealEstate.Entities
{
    public class LKRefTypes
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public int CridetDebit { get; set; }
        public string Aname { get; set; }
        public string Ename { get; set; }
        public bool IsDeleted { get; set; }
        public string HashCol { get; set; }
        public string Description { get; set; }
    }
}