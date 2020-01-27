using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EdgeRealEstate.Models;
using EdgeRealEstate.Models.ViewModels;
using EdgeRealEstate.Models.Services;

namespace EdgeRealEstate.Controllers
{
    public class ContributerMoveReportController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        private ContributerMoveReportService ContributerMoveReportService;
        // GET: ContributerMoveReport
     

        public ActionResult Index(int? ContributerID)
        {
            ViewBag.Contributer = new SelectList(db.Contributor, "Id", "Aname");
          //  ViewBag.ProjectsTo = new SelectList(db.Projectes, "Id", "Aname");
            var FromContributerID = ContributerID;
            //var ToPro = ToProID;
            if (FromContributerID == null)
            {
                FromContributerID = db.Contributor.Select(c => c.id).First();
            }
            //if (ToPro == null)
            //{
            //    ToPro = db.Projectes.OrderByDescending(c => c.id).First().id;
            //}
            //var FromPro = db.Projectes.Select(c => c.id).First();

           var result = (from i in db.Contributor
                      join crd in db.ContPaperReceipts.DefaultIfEmpty() on i.id equals crd.ContributorId
                      join dbt in db.ContPaperPayments.DefaultIfEmpty() on i.id equals dbt.ContributorId

                      //SELECT dbo.Contributors.ARName, dbo.ContPaperReceipts.paid AS credit, dbo.ContPaperReceipts.refType AS credittype, dbo.ContPaperReceipts.indate, dbo.ContPaperPayments.paid AS debit, dbo.ContPaperPayments.refType AS Expr1,
                      //                          dbo.ContPaperPayments.indate AS Expr2

                      where i.id == FromContributerID
                      &&
                      i.IsDeleted == false
                      select new 
                      {
                          ContributorId = i.id,
                          ContributorName = i.ARName,
                          //refTypeCredit =()
                          //RefnameCredit = crd.LK,

                          indateCredit = crd.indate,
                           paidCredit = crd.paid,
                          RefnameDebit = dbt.RefType.Aname,
                          indateDebit = dbt.indate,
                          paidDebit = dbt.paid
                          //TotalCredit 
                          //TotalDebit 
                      }).ToList().Select(x=> new ContributerMoveViewModel
                      {
                          ContributorId= x.ContributorId,
                          ContributorName = x.ContributorName,
                         // RefnameCredit = x.RefnameCredit,
                          indateCredit = x.indateCredit,
                         paidCredit =x.paidCredit,
                          RefnameDebit = x.RefnameDebit,
                          indateDebit= x.indateDebit,
                          paidDebit = x.paidDebit
                      }).ToList();



            //var result = (from i in db.Projectes
            //              where i.id <= FromPro && i.id >= ToPro
            //              select new
            //              {
            //                  ProjectName = i.Aname,
            //                  BeginDateAcutely = (DateTime)i.BeginDateAcutely,
            //                  EndDateAcutely = (DateTime)i.EndDateAcutely,
            //                  TotalFlatNO = i.FlatNO,
            //                  UnderpreparingFlat = i.Flats.Where(c => c.FlatTypeId == 2).Count(),
            //                  BookedFlat = i.Flats.Where(c => c.FlatTypeId == 4).Count(),
            //                  ReadyFlat = i.Flats.Where(c => c.FlatTypeId == 3).Count(),
            //                  SoledFlat = i.Flats.Where(c => c.FlatTypeId == 5).Count()
            //              }).ToList().Select(x => new ProjectsFlatViewModel
            //              {
            //                  ProjectName = x.ProjectName,
            //                  BeginDateAcutely = x.BeginDateAcutely,
            //                  EndDateAcutely = x.EndDateAcutely,
            //                  TotalFlatNO = x.TotalFlatNO,
            //                  UnderpreparingFlat = x.UnderpreparingFlat,
            //                  BookedFlat = x.BookedFlat,
            //                  ReadyFlat = x.ReadyFlat,
            //                  SoledFlat = x.SoledFlat
            //              }).ToList();
      
            return View(result.ToList());
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
