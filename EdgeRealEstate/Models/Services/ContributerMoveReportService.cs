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

        public IList<ContributerMoveViewModel> GetAll(int? ContributerID)
        {
            var result = HttpContext.Current.Session["Contributer"] as IList<ContributerMoveViewModel>;

            result = (from i in db.Contributor
                      join crd in db.ContPaperReceipts.DefaultIfEmpty() on i.id equals crd.ContributorId
                      join dbt in db.ContPaperPayments.DefaultIfEmpty() on i.id equals dbt.ContributorId

                      //SELECT dbo.Contributors.ARName, dbo.ContPaperReceipts.paid AS credit, dbo.ContPaperReceipts.refType AS credittype, dbo.ContPaperReceipts.indate, dbo.ContPaperPayments.paid AS debit, dbo.ContPaperPayments.refType AS Expr1,
                      //                          dbo.ContPaperPayments.indate AS Expr2

                      where i.id == ContributerID
                      &&
                      i.IsDeleted == false
                      select new ContributerMoveViewModel
                      {
                          ContributorId = i.id,
                          ContributorName = i.ARName,
                          //refTypeCredit =()
                          RefnameCredit = (from Credit in db.ContPaperReceipts
                                           join reft in db.LKRefTypes on Credit.refType equals reft.Code
                                           where reft.CridetDebit == 2
                                           select reft.Aname).SingleOrDefault(),
                          //              where LocalDebit.GlJournalID == glJournals.GlJournalID
                          //               && LocalDebit.LocalCredit == 0
                          //              orderby LocalDebit.GlJournalDetailID
                          //              select LocalDebit.LocalDebit).FirstOrDefault(),
                          //RefnameCredit =
                          indateCredit = crd.indate,
                          paidCredit = crd.paid,
                          //refTypeDebit 
                          RefnameDebit = (from Debit in db.ContPaperPayments
                                         join reft in db.LKRefTypes on Debit.refType equals reft.Code
                                         where reft.CridetDebit == 1
                                         select reft.Aname).SingleOrDefault(),
                          indateDebit = dbt.indate,
                          paidDebit = dbt.paid
                          //TotalCredit 
                          //TotalDebit 
                      }).ToList();

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


        public IEnumerable<ContributerMoveViewModel> Read(int? ContributerID)
        {
            return GetAll(ContributerID);
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}