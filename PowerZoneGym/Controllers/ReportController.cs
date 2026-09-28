using Microsoft.AspNetCore.Mvc;
using Microsoft.Reporting.NETCore;
using PowerZoneGym.Models;

namespace PowerZoneGym.Controllers
{
    public class ReportController : Controller
    {
        private readonly GymDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ReportController(
            GymDbContext context,
            IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult EmployeeReport(int Id)
        {
            // Get voucher and trainee
            var voucher =
                (from v in _context.MonthlyFeeVouchers
                 where v.MonthlyFeeID == Id

                 join t in _context.Trainees
                     on v.TraineeId equals t.TraineeId
                     into trainees

                 from t in trainees.DefaultIfEmpty()

                 select new TraineeDetailViewModel
                 {
                     MonthlyFeeVoucherVM = v,
                     GymTraineeVM = t
                 })
                .FirstOrDefault();

            if (voucher == null || voucher.GymTraineeVM == null)
                return NotFound("Voucher or trainee not found.");


            // Get trainee image path
            string imagePath = GetImagePath(
                voucher.GymTraineeVM.ImageName
            );


            // Report parameters
            var parameters = new[]
            {
                new ReportParameter(
                    "first_name",
                    voucher.GymTraineeVM.FirstName ?? ""
                ),

                new ReportParameter(
                    "last_name",
                    voucher.GymTraineeVM.LastName ?? ""
                ),

                new ReportParameter(
                    "gender",
                    voucher.GymTraineeVM.Gender ?? ""
                ),

                new ReportParameter(
                    "age",
                    voucher.GymTraineeVM.Age.ToString()
                ),

                new ReportParameter(
                    "contact_no",
                    voucher.GymTraineeVM.ContactNo ?? ""
                ),

                new ReportParameter(
                    "address",
                    voucher.GymTraineeVM.Address ?? ""
                ),

                new ReportParameter(
                    "monthly_fee",
                    voucher.GymTraineeVM.MonthlyFee.ToString()
                ),

                new ReportParameter(
                    "image",
                    imagePath
                )
            };


            // Load RDLC
            string reportPath = Path.Combine(
                _env.WebRootPath,
                "Reports",
                "GymTrainee_FeeReport.rdlc"
            );

            var report = new LocalReport();

            // Required because RDLC uses External image
            report.EnableExternalImages = true;

            using var stream =
                System.IO.File.OpenRead(reportPath);

            report.LoadReportDefinition(stream);

            report.SetParameters(parameters);


            // Generate PDF
            byte[] pdf = report.Render("PDF");

            return File(
                pdf,
                "application/pdf",
                "GymTrainee_FeeReport.pdf"
            );
        }


        // Creates the file URI used by RDLC
        private string GetImagePath(string? imageName)
        {
            if (string.IsNullOrWhiteSpace(imageName))
                return "";

            string path = Path.Combine(
                _env.WebRootPath,
                "Images",
                imageName
            );

            if (!System.IO.File.Exists(path))
                return "";

            return new Uri(path).AbsoluteUri;
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}