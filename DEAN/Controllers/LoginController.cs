using System;
using System.Linq;
using System.Web.Mvc;
using DEAN.Models;
using System.Web.Security; // Thêm namespace này để sử dụng FormsAuthentication

namespace DEAN.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            // Nếu đã đăng nhập, chuyển hướng người dùng đến trang chính
            if (Session["TtDangNhap"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string Acc, string Pass)
        {
            using (QuanLyEntities db = new QuanLyEntities())
            {
                // Kiểm tra thông tin đăng nhập
                User ttdn = db.Users.FirstOrDefault(x => x.Username.Equals(Acc.ToLower().Trim()) && x.Password.Equals(Pass));
                bool isAuthentic = ttdn != null;

                if (isAuthentic)
                {
                    // Lưu thông tin đăng nhập vào session
                    Session["TtDangNhap"] = ttdn;

                    // Xác thực và lưu trạng thái đăng nhập
                    FormsAuthentication.SetAuthCookie(ttdn.Username, false);

                    // Điều hướng đến trang phù hợp dựa trên tên người dùng
                    if (ttdn.Username.Equals("user10", StringComparison.OrdinalIgnoreCase))
                    {
                        return RedirectToAction("Index", "ThongTin", new { Area = "Private" });
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }

                // Nếu thông tin đăng nhập không đúng, hiển thị lại trang đăng nhập với thông báo lỗi
                ViewBag.ErrorMessage = "Sai tên đăng nhập hoặc mật khẩu.";
                return View();
            }
        }

        public ActionResult Logout()
        {
            // Xóa thông tin đăng nhập khỏi session
            Session["TtDangNhap"] = null;

            // Đăng xuất và xóa cookie
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Login");
        }
    }
}
