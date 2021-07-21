using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project.Data;
using project.Models;

namespace project.Controllers
{
    public class BackstageController : Controller
    {
        public  IDataAccess _dataAccess;
        
        public BackstageController(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
           
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Userlogin(string account, string password)
        {
            var a=_dataAccess.UserLogins(account);
            //a.Account

            if (ModelState.IsValid)
            {
                if (a == null)
                {
                    ViewBag.errMsg = "帳號或密碼輸入錯誤";
                    return View("Index"); //帳號若是錯誤 則回登入頁面
                }
                if(a.Account==account && a.Password==password) // &&=and 查詢帳號密碼是否正確
                {
                    //取得登入角色
                    //var RoleName = _context.Role.FirstOrDefault(x => x.Id == user.RoleId).RoleName;
                    //建立 Claim，也就是要寫到 Cookie 的內容
                    var claims = new[] {
                        new Claim("Account", a.Account.ToString()),
                        new Claim("userID", a.WID),
                        new Claim(ClaimTypes.Role,a.Authorize) };
                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    //將 ClaimsIdentity 設定給 ClaimsPrincipal (持有者) 
                    ClaimsPrincipal principal = new ClaimsPrincipal(claimsIdentity);

                    //登入動作
                    await HttpContext.SignInAsync(principal, new AuthenticationProperties()
                    {
                        
                        AllowRefresh = false,//是否可以被刷新
                        
                        IsPersistent = false, //瀏覽器關閉立馬登出  true=記憶我
                        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(15) //閒置多久登出
                    });
                    if (a.Authorize == "SuperAdmin")
                    {
                        return Redirect("/User/Index");//身份為SuperAdmin前往帳號管理
                    }
                    return Redirect("/Roommanagement/Index"); //正確前往後台網頁 
                }

            }
            ViewBag.errMsg = "帳號或密碼輸入錯誤";
            return View("Index"); //錯誤返回登入頁面
    
        }
        public async Task<IActionResult> Logout()//登出
        {
            await HttpContext.SignOutAsync();

            return Redirect("/Home/Index");//導至登入頁
        }
    }
}