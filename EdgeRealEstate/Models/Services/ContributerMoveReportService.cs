using EdgeRealEstate.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdgeRealEstate.Models.Services
{
    public class ContributerMoveReportService
    {
        private ApplicationDbContext db;
        public ContributerMoveReportService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IList<ContributerMoveViewModel> GetAll(int? FContributerID, int? ToContributerID)
        {
            var result = HttpContext.Current.Session["Contributer"] as IList<ContributerMoveViewModel>;

            var ResultReceipt = (from i in db.Contributor
                                 join crd in db.ContPaperReceipts on i.id equals crd.ContributorId

                                 //join dbt in db.ContPaperPayments on i.id equals dbt.ContributorId
                                 where i.id >= FContributerID && i.id <= ToContributerID
                                 && i.IsDeleted == false
                                 select new
                                 {
                                     ContributorId = i.id,
                                     ContributorName = i.ARName,
                                     indateCredit = crd.Crdindate,
                                     paidCredit = crd.Crdpaid,
                                     RefnameCredit = crd.RefType.Aname,
                                     refTypeCreditID = crd.id
                                     //  indateDebit = dbt.indate,
                                     // paidDebit= dbt.paid,
                                     // RefnameDebit = dbt.RefType.Aname

                                 }).OrderByDescending(x => x.refTypeCreditID).Union(from i in db.Contributor
                                                                                        // join crd in db.ContPaperReceipts on i.id equals crd.ContributorId
                                                                                    join dbt in db.ContPaperPayments on i.id equals dbt.ContributorId
                                                                                    where i.id >= FContributerID && i.id<= ToContributerID
                                                                                    &&
                                                                                    i.IsDeleted == false
                                                                                    select new
                                                                                    {
                                                                                        ContributorId = i.id,
                                                                                        ContributorName = i.ARName,
                                                                                        indateCredit = dbt.Dbtindate,
                                                                                        paidCredit = dbt.Dbtpaid,
                                                                                        RefnameCredit = dbt.RefType.Aname,
                                                                                        refTypeCreditID = dbt.id
                                                                                        //indateDebit = dbt.Dbtindate,
                                                                                        //paidDebit= dbt.Dbtpaid//,
                                                                                        // RefnameDebit = dbt.RefType.Aname

                                                                                    }).OrderByDescending(x => x.refTypeCreditID).ToList().Select(x => new ContributerMoveViewModel
                                                                                    {
                                                                                        ContributorId = x.ContributorId,
                                                                                        ContributorName = x.ContributorName,
                                                                                        indateCredit = x.indateCredit,
                                                                                        paidCredit = x.paidCredit,
                                                                                        RefnameCredit = x.RefnameCredit,
                                                                                        refTypeCreditID = x.refTypeCreditID
                                                                                        // indateDebit = x.indateDebit,
                                                                                        // paidDebit = x.paidDebit//,
                                                                                        //  RefnameDebit = x.RefnameDebit
                                                                                    }).OrderBy(x => x.indateCredit).ToList();
            //result = (from i in db.Projectes
            //          where i.id <= FromProID && i.id >= ToProID
            //          select new ContributerMoveViewModel
            //          {
            //              ProjectName = i.Aname,
            //              BeginDateAcutely = (DateTime)i.BeginDateAcutely,
            //              EndDateAcutely = (DateTime)i.EndDateAcutely,
            //              TotalFlatNO = i.FlatNO,
            //              UnderpreparingFlat = i.Flats.Where(c => c.FlatTypeId == 2).Count(),
            //              BookedFlat = i.Flats.Where(c => c.FlatTypeId == 4).Count(),
            //              ReadyFlat = i.Flats.Where(c => c.FlatTypeId == 3).Count(),
            //              SoledFlat = i.Flats.Where(c => c.FlatTypeId == 5).Count()
            //          }).ToList();
            return result;
        }


        public IEnumerable<ContributerMoveViewModel> Read(int? FContributerID, int? ToContributerID)
        {
            return GetAll(FContributerID, ToContributerID);
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}