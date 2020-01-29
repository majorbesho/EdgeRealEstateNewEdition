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
using System.Dynamic;

namespace EdgeRealEstate.Controllers
{
    public class ContributerMoveReportController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        private ContributerMoveReportService ContributerMoveReportService;
        // GET: ContributerMoveReport
     

        public ActionResult Index(int? FContributerID, int? ToContributerID)
        {
            ViewBag.ContributerFrom = new SelectList(db.Contributor, "Id", "ARName");
            ViewBag.ContributerTo = new SelectList(db.Contributor, "Id", "ARName");
            var FromContributerID = FContributerID;
            var ToToContributerID = ToContributerID;
            if (FromContributerID == null)
            {
                FromContributerID = db.Contributor.Select(c => c.id).First();
            }
            if (ToContributerID == null)
            {
                ToContributerID = db.Contributor.Select(c => c.id).First();//db.Contributor.OrderByDescending(c => c.id).First().id;
            }
            #region

            //var FromPro = db.Projectes.Select(c => c.id).First();


            //var result= (from crd in db.ContPaperReceipts 
            //             join i in db.Contributor on crd.ContributorId equals i.id

            //             where i.IsDeleted== false && i.id==FromContributerID
            //             select new 
            //             {
            //                 ContributorId = i.id,
            //                 ContributorName = i.ARName,
            //                 indateCredit = crd.indate,
            //                 paidCredit = crd.paid,
            //                 RefnameCredit = crd.RefType.Aname,

            //             }).Union(from dbt in db.ContPaperPayments 
            //                      join i in db.Contributor on )
            #endregion

            var ResultReceipt = (from i in db.Contributor
                          join crd in db.ContPaperReceipts on i.id equals crd.ContributorId
                           
                          //join dbt in db.ContPaperPayments on i.id equals dbt.ContributorId
                          where i.id >= FromContributerID && i.id<= ToContributerID
                          &&  i.IsDeleted == false
                          select new
                          {
                              ContributorId = i.id,
                              ContributorName = i.ARName,
                              indateCredit = crd.Crdindate,
                              paidCredit = crd.Crdpaid,
                              RefnameCredit = crd.RefType.Aname,
                              refTypeCreditID = crd.id
                          }).OrderBy(x=>x.refTypeCreditID).Union (from i in db.Contributor
                                                       // join crd in db.ContPaperReceipts on i.id equals crd.ContributorId
                                                        join dbt in db.ContPaperPayments on i.id equals dbt.ContributorId
                                                                  where i.id >= FromContributerID && i.id <= ToContributerID
                                                                  &&
                                                        i.IsDeleted == false
                                                        select new
                                                        {
                                                            ContributorId = i.id,
                                                           ContributorName = i.ARName,
                                                           indateCredit = dbt.Dbtindate,
                                                           paidCredit = dbt.Dbtpaid*(-1),
                                                           RefnameCredit = dbt.RefType.Aname,
                                                            refTypeCreditID = dbt.id

                                                        }).OrderBy(x => x.refTypeCreditID).ToList().Select(x => new ContributerMoveViewModel
                                                        {
                                                            ContributorId = x.ContributorId,
                                                            ContributorName =x.ContributorName,
                                                            indateCredit = x.indateCredit,
                                                            paidCredit = x.paidCredit,
                                                            RefnameCredit = x.RefnameCredit,
                                                            refTypeCreditID = x.refTypeCreditID

                                                        }).OrderBy(x=>x.ContributorId).ThenBy(x=>x.indateCredit).ThenBy(x=>x.refTypeCreditID).ToList();





            #region
            //List<ContributerMoveViewModel> contributerMoveViewModels = new List<ContributerMoveViewModel>();
            //contributerMoveViewModels = conterPaperReceiptViewModels.Concat(conterPaperPaymentViewModels).ToList();
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
            #endregion

            return View(ResultReceipt.ToList());
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
