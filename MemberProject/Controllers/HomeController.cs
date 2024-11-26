using System.Diagnostics;
using MemberProject.Models;
using MemberProject.Models.DBModel;
using MemberProject.Models.ViewModel;
using MemberProject.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MemberProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public MemberService _memberService;
        public HomeController(ILogger<HomeController> logger, MemberService memberService)
        {
            _logger = logger;
            _memberService = memberService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Applic()
        {
            return View();
        }

        public IActionResult Add(ApplicViewModel applicViewModel)
        {
            return View();
        }
        public async Task<Dictionary<string, object>> Save(ApplicViewModel applicViewModel)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            List<Member> members = await _memberService.GetEntitiesQ().Where(c => c.memberAccount == applicViewModel.memberAcc || c.email == applicViewModel.email).ToListAsync();

            try
            {
                if (members.Count > 0)
                {
                    result.Add("success", false);
                    result.Add("message", "資料庫已有相同帳號或email");
                }
                else
                {
                    await _memberService.Save(applicViewModel);
                    result.Add("success", true);
                    result.Add("message", "建立成功");
                }
                return result;
            }
            catch (Exception ex)
            {
                return result;
            }
            finally
            {
                result=new Dictionary<string, object>();
            }

        }
    }
}
