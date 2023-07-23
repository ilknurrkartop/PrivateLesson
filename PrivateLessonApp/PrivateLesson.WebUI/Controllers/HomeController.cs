using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PrivateLesson.Business.Abstract;
using PrivateLesson.Entity.Concrete;
using PrivateLesson.Entity.Concrete.Identity;
using PrivateLesson.WebUI.Models;
using PrivateLesson.WebUI.Models.ViewModels;
using PrivateLesson.WebUI.Models.ViewModels.AdvertModels;
using System.Diagnostics;

namespace PrivateLesson.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private ITeacherService _teacherService;
        private IBranchService _branchService;
        private IAdvertService _advertService;

        public HomeController(ITeacherService teacherService, IBranchService branchService, IAdvertService advertService)
        {
            _teacherService = teacherService;
            _branchService = branchService;
            _advertService = advertService;
        }

        public async Task<IActionResult> Index(string branchurl)
        {
            List<Teacher> teachers = await _teacherService.GetAllTeachersFullDataAsync(true, branchurl);
            List<TeacherModel> teacherModelList = new List<TeacherModel>();
            teacherModelList = teachers.Select(t => new TeacherModel
            {
                Id = t.Id,
                FirstName = t.User.FirstName,
                LastName = t.User.LastName,
                CreatedDate = t.CreatedDate,
                UpdatedDate = t.UpdatedDate,
                IsApproved = t.IsApproved,
                Url = t.Url,
                Graduation = t.Graduation,
                UserId = t.UserId,
                ImageUrl = t.User.Image.Url,
                TeacherBranches = t.TeacherBranches.Select(tb => tb.Branch).ToList(),
                TeacherStudents = t.TeacherStudents.Select(ts => ts.Student).ToList()

            }).ToList();
            if (RouteData.Values["branchurl"] != null)
            {
                ViewBag.SelectedBranchName = await _branchService.GetBranchNameByUrlAsync(RouteData.Values["branchurl"].ToString());
            }

            return View(teacherModelList);
        }


        [HttpGet]
        public async Task<IActionResult> GetAllAdverts(AdvertListViewModel advertListViewModel)
        {
            List<Advert> advertList;
            if (advertListViewModel.Adverts == null)
            {
                advertList = await _advertService.GetAllAdvertsAsync(advertListViewModel.ApprovedStatus);
                List<AdvertViewModel> adverts = new List<AdvertViewModel>();
                foreach (var advert in advertList)
                {
                    adverts.Add(new AdvertViewModel
                    {
                        Id = advert.Id,
                        FirstName = advert.Teacher.User.FirstName,
                        LastName = advert.Teacher.User.LastName,
                        CreatedDate = advert.CreatedDate,
                        UpdatedDate = advert.UpdatedDate,
                        IsApproved = advert.IsApproved,
                        Graduation = advert.Teacher.Graduation,
                        Price = advert.Price,
                        Description = advert.Description,
                        Url = advert.Url,
                        Image = advert.Teacher.User.Image,
                        BranchName = advert.Branch.BranchName
                        //Branches=advert.Teacher.TeacherBranches.Select(tb=>tb.Branch).ToList()
                        //Teacher=advert.Teacher
                    });
                }
                advertListViewModel.Adverts = adverts;
            }
            return View(advertListViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> AdvertDetails(string url)
        {
            var advertId = await _advertService.GetByUrlAsync(url);
            Advert advert = await _advertService.GetAdvertFullDataAsync(advertId);
            AdvertViewModel advertViewModel = new AdvertViewModel()
            {
                Id = advert.Id,
                FirstName = advert.Teacher.User.FirstName,
                LastName = advert.Teacher.User.LastName,
                Graduation = advert.Teacher.Graduation,
                Image = advert.Teacher.User.Image,
                Description = advert.Description,
                Price = advert.Price,
                UpdatedDate = advert.UpdatedDate,
                CreatedDate = advert.CreatedDate,
                IsApproved = advert.IsApproved,
                BranchName = advert.Branch.BranchName,
                Url = advert.Url,
            };
            return View(advertViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> TeacherDetails(int id)
        {
            Teacher teacher = await _teacherService.GetTeacherFullDataAsync(id);
            TeacherModel teacherModel = new TeacherModel()
            {
                Id = teacher.Id,
                FirstName = teacher.User.FirstName,
                LastName = teacher.User.LastName,
                Graduation = teacher.Graduation,
                ImageUrl = teacher.User.Image.Url,
                UpdatedDate = teacher.UpdatedDate,
                CreatedDate = teacher.CreatedDate,
                IsApproved = teacher.IsApproved,
                Url = teacher.Url,
                TeacherBranches = teacher.TeacherBranches.Select(tb => tb.Branch).ToList()
            };
            return View(teacherModel);
        }



    }
}