using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PowerZoneGym.Models;

namespace PowerZoneGym.Controllers
{
    public class FeeVoucherController : Controller
    {
        private readonly GymDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public FeeVoucherController(
            GymDbContext context,
            IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }


        // =========================================================
        // INDEX
        // =========================================================

        public IActionResult Index(string selected_rbt, string selectedDate)
        {
            // Default = All
            if (string.IsNullOrEmpty(selected_rbt))
            {
                selected_rbt = "list";
            }

            ViewBag.Selectedbutton = selected_rbt;
            ViewBag.SelectedDate = selectedDate;

            var result = GetGymTraineeFeeStatus(
                selected_rbt,
                selectedDate
            );

            return View(result);
        }


        // =========================================================
        // GET FEE STATUS
        // =========================================================

        private IEnumerable<FeeVoucherDetailsViewModel>
    GetGymTraineeFeeStatus(
        string selected_rbt,
        string selectedDate)
        {
            // =====================================================
            // ALL
            // =====================================================

            if (selected_rbt == "list")
            {
                return from t in _context.Trainees

                       join mfv in _context.MonthlyFeeVouchers
                       on t.TraineeId equals mfv.TraineeId
                       into MonthlyFeeStatus

                       from mfv in MonthlyFeeStatus.DefaultIfEmpty()

                       select new FeeVoucherDetailsViewModel
                       {
                           GymTraineeVM = t,
                           MonthlyFeeVoucherVM = mfv
                       };
            }


            // =====================================================
            // PAID
            // =====================================================

            if (selected_rbt == "Paid")
            {
                return from t in _context.Trainees

                       join mfv in _context.MonthlyFeeVouchers
                       on t.TraineeId equals mfv.TraineeId
                       into MonthlyFeeStatus

                       from mfv in MonthlyFeeStatus.DefaultIfEmpty()

                       where mfv != null &&
                             mfv.Status == "Paid"

                       select new FeeVoucherDetailsViewModel
                       {
                           GymTraineeVM = t,
                           MonthlyFeeVoucherVM = mfv
                       };
            }


            // =====================================================
            // UN-PAID
            // =====================================================

            if (selected_rbt == "Un-Paid")
            {
                return from t in _context.Trainees

                       join mfv in _context.MonthlyFeeVouchers
                       on t.TraineeId equals mfv.TraineeId
                       into MonthlyFeeStatus

                       from mfv in MonthlyFeeStatus.DefaultIfEmpty()

                       where mfv == null ||
                             mfv.Status == "Un-Paid"

                       select new FeeVoucherDetailsViewModel
                       {
                           GymTraineeVM = t,
                           MonthlyFeeVoucherVM = mfv
                       };
            }


            // Nothing found
            return Enumerable.Empty<FeeVoucherDetailsViewModel>();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var voucher = await _context.MonthlyFeeVouchers
                .FirstOrDefaultAsync(x => x.MonthlyFeeID == id);

            if (voucher == null)
            {
                return NotFound();
            }

            _context.MonthlyFeeVouchers.Remove(voucher);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // =========================================================
        // PAY MONTHLY FEE - GET
        // =========================================================

        [HttpGet]
        public async Task<IActionResult> PayMonthlyFee(int? Id)
        {
            // Check ID
            if (Id == null)
            {
                return NotFound();
            }


            // Create ViewModel
            FeeVoucherDetailsViewModel model =
                new FeeVoucherDetailsViewModel();


            // Get trainee
            model.GymTraineeVM =
                await _context.Trainees
                .FirstOrDefaultAsync(t =>
                    t.TraineeId == Id);


            // Trainee not found
            if (model.GymTraineeVM == null)
            {
                return NotFound();
            }


            // Create Monthly Fee Voucher
            model.MonthlyFeeVoucherVM =
                new MonthlyFeeVoucher
                {
                    TraineeId = model.GymTraineeVM.TraineeId,
                    FeeDate = DateTime.Today
                };


            // Open PayMonthlyFee.cshtml
            return View(model);
        }


        // =========================================================
        // PAY MONTHLY FEE - POST
        // =========================================================

        [HttpPost]
        [ActionName("PayMonthlyFee")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PayMonthlyFee_Post(
       FeeVoucherDetailsViewModel model)
        {
            if (model.MonthlyFeeVoucherVM == null)
            {
                return NotFound();
            }


            // Get trainee ID
            int traineeId =
                model.MonthlyFeeVoucherVM.TraineeId;


            // Get the fee date
            DateTime feeDate =
                model.MonthlyFeeVoucherVM.FeeDate;


            // Check if this trainee already has a fee record
            // for the same month and year
            var existingVoucher =
                await _context.MonthlyFeeVouchers
                .FirstOrDefaultAsync(x =>
                    x.TraineeId == traineeId &&
                    x.FeeDate.Month == feeDate.Month &&
                    x.FeeDate.Year == feeDate.Year);


            // =====================================================
            // IF RECORD ALREADY EXISTS → UPDATE
            // =====================================================

            if (existingVoucher != null)
            {
                existingVoucher.FeeDate =
                    feeDate;

                existingVoucher.Remarks =
                    model.MonthlyFeeVoucherVM.Remarks;

                existingVoucher.Status =
                    "Paid";
            }


            // =====================================================
            // IF RECORD DOES NOT EXIST → CREATE NEW
            // =====================================================

            else
            {
                MonthlyFeeVoucher monthlyFeeVoucher =
                    new MonthlyFeeVoucher();

                monthlyFeeVoucher.TraineeId =
                    traineeId;

                monthlyFeeVoucher.FeeDate =
                    feeDate;

                monthlyFeeVoucher.Remarks =
                    model.MonthlyFeeVoucherVM.Remarks;

                monthlyFeeVoucher.Status =
                    "Paid";

                _context.MonthlyFeeVouchers.Add(
                    monthlyFeeVoucher
                );
            }


            // Save changes
            await _context.SaveChangesAsync();


            // Go back to Index
            return RedirectToAction(nameof(Index));
        }


    }
}