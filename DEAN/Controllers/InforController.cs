using DEAN.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace DEAN.Controllers
{
    public class InforController : Controller
    {
        private QuanLyEntities db = new QuanLyEntities();

        [Authorize]
        // GET: Infor
        public ActionResult Index()
        {
            var currentUser = Session["TtDangNhap"] as User;
            if (currentUser == null)
            {
                return RedirectToAction("Index", "Login");
            }

            return View(new HealthStat { Date = DateTime.Today });
        }

        [HttpPost]
        [Authorize]
        public ActionResult Index(HealthStat model)
        {
            var currentUser = Session["TtDangNhap"] as User;
            if (currentUser == null)
            {
                return RedirectToAction("Index", "Login");
            }

            if (ModelState.IsValid)
            {
                // Kiểm tra xem dữ liệu cho ngày cụ thể đã tồn tại chưa
                var existingData = db.HealthStats.FirstOrDefault(h => h.UserId == currentUser.UserId && h.Date == model.Date);
                if (existingData != null)
                {
                    // Thông báo rằng dữ liệu cho ngày này đã tồn tại
                    ModelState.AddModelError("", "Dữ liệu cho ngày này đã tồn tại.");
                    return View(model);
                }

                // Thêm thông tin mới mà không ghi đè dữ liệu cũ
                var healthStat = new HealthStat
                {
                    UserId = currentUser.UserId,
                    Date = model.Date.Date,
                    Steps = model.Steps,
                    WaterIntake = model.WaterIntake,
                    SleepDuration = model.SleepDuration
                };

                db.HealthStats.Add(healthStat);
                db.SaveChanges();

                // Thông báo cập nhật thành công
                ViewBag.Message = "Cập nhật thông tin thành công!";
            }

            return View(model);
        }
    }
}
