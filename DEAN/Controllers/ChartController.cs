using System;
using System.Linq;
using System.Web.Mvc;
using DEAN.Models;

namespace DEAN.Controllers
{
    public class ChartController : Controller
    {
        private QuanLyEntities db = new QuanLyEntities();

        // GET: Chart
        public ActionResult Index()
        {
            var currentUser = Session["TtDangNhap"] as User;
            if (currentUser == null)
            {
                return RedirectToAction("Index", "Login");
            }

            // Lấy dữ liệu cho tuần hiện tại
            var startOfWeek = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);
            var endOfWeek = startOfWeek.AddDays(7);

            var weeklyData = db.HealthStats
                .Where(h => h.UserId == currentUser.UserId && h.Date >= startOfWeek && h.Date < endOfWeek)
                .GroupBy(h => h.Date)
                .Select(g => new
                {
                    Date = g.Key,
                    Steps = g.Sum(h => h.Steps),
                    WaterIntake = g.Sum(h => h.WaterIntake),
                    SleepDuration = g.Sum(h => h.SleepDuration)
                })
                .ToList();

            ViewBag.WeeklyData = weeklyData;

            return View();
        }
    }
}
