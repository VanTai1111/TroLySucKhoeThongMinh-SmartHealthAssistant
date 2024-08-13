using DEAN.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace DEAN.Controllers
{
    public class HomeController : Controller
    {
        private QuanLyEntities db = new QuanLyEntities();

        [Authorize]
        public ActionResult Index()
        {
            var currentUser = Session["TtDangNhap"] as User;

            if (currentUser == null)
            {
                return RedirectToAction("Index", "Login");
            }

            // Ngày hiện tại
            var today = DateTime.Today;

            // Kết thúc ngày hiện tại (23:59:59)
            var endOfDay = today.AddDays(1).AddTicks(-1);

            // Truy vấn dữ liệu cho ngày hiện tại
            var userMetrics = db.HealthStats
                                .Where(h => h.UserId == currentUser.UserId
                                            && h.Date >= today
                                            && h.Date <= endOfDay)
                                .FirstOrDefault();

            if (userMetrics == null)
            {
                // Nếu không có dữ liệu cho ngày hiện tại, gán các thông số bằng 0
                userMetrics = new HealthStat
                {
                    Steps = 0,
                    WaterIntake = 0,
                    SleepDuration = 0
                };
            }

            return View(userMetrics);
        }

    }
}
