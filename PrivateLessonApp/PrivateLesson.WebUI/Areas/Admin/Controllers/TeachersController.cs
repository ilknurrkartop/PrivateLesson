using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PrivateLesson.Business.Abstract;
using PrivateLesson.Core;
using PrivateLesson.Entity.Concrete;
using PrivateLesson.Entity.Concrete.Identity;
using PrivateLesson.WebUI.Areas.Admin.Models.ViewModels;

namespace PrivateLesson.WebUI.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize]
    public class TeachersController : Controller
    {
        private ITeacherService _teacherService;
        private IBranchService _branchService;
        private IImageService _imageService;
        private UserManager<User> _userManager;

        public TeachersController(ITeacherService teacherService, IBranchService branchService, IImageService imageService, UserManager<User> userManager)
        {
            _teacherService = teacherService;
            _branchService = branchService;
            _imageService = imageService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(TeacherListViewModel teacherListViewModel)
        {
            List<Teacher> teacherList;
            if (teacherListViewModel.Teachers == null)
            {
                teacherList = await _teacherService.GetAllTeachersFullDataAsync(teacherListViewModel.ApprovedStatus);
                List<TeacherViewModel> teachers = new List<TeacherViewModel>();
                foreach (var teacher in teacherList)
                {
                    teachers.Add(new TeacherViewModel
                    {
                        Id = teacher.Id,
                        FirstName = teacher.User.FirstName,
                        LastName = teacher.User.LastName,
                        Gender = teacher.User.Gender,
                        DateOfBirth = teacher.User.DateOfBirth,
                        City = teacher.User.City,
                        Phone = teacher.User.Phone,
                        CreatedDate = teacher.CreatedDate,
                        UpdatedDate = teacher.UpdatedDate,
                        IsApproved = teacher.IsApproved,
                        Url = teacher.Url,
                        Graduation = teacher.Graduation,
                        UserId = teacher.UserId,
                        User = teacher.User,
                        Students = teacher.TeacherStudents.Select(ts => new StudentViewModel
                        {
                            Id = ts.Student.Id,
                            UserId = ts.Student.UserId,
                            User = ts.Student.User,
                            FirstName = ts.Student.User.FirstName,
                            LastName = ts.Student.User.LastName,
                            Url = ts.Student.Url
                        }).ToList(),
                        Branches = teacher.TeacherBranches.Select(tb => new BranchViewModel
                        {
                            Id = tb.Branch.Id,
                            BranchName = tb.Branch.BranchName,
                            Description = tb.Branch.Description,
                            Url = tb.Branch.Url
                        }).ToList(),
                        Image = teacher.User.Image
                    });
                }
                teacherListViewModel.Teachers = teachers;
            }
            return View(teacherListViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            TeacherAddViewModel teacherAddViewModel = new TeacherAddViewModel()
            {
                Branches = await _branchService.GetBranchesAsync(true)
            };
            return View(teacherAddViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TeacherAddViewModel teacherAddViewModel)
        {
            if (ModelState.IsValid)
            {
                Teacher teacher = new Teacher()
                {
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsApproved = true,
                    Url = Jobs.GetUrl(teacherAddViewModel.FirstName + teacherAddViewModel.LastName),
                    Graduation = teacherAddViewModel.Graduation,

                };
                User user = new User()
                {
                    FirstName = teacherAddViewModel.FirstName,
                    LastName = teacherAddViewModel.LastName,
                    Gender = teacherAddViewModel.Gender,
                    DateOfBirth = teacherAddViewModel.DateOfBirth,
                    City = teacherAddViewModel.City,
                    Phone = teacherAddViewModel.Phone,
                    UserName = teacherAddViewModel.UserName,
                    Email = teacherAddViewModel.Email,
                    Image = new Image
                    {
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now,
                        IsApproved = true,
                        Url = Jobs.UploadImage(teacherAddViewModel.Image)
                    }
                };
                await _userManager.CreateAsync(user, teacherAddViewModel.Password);
                teacher.User = user;
                await _teacherService.CreateTeacher(teacher, teacherAddViewModel.SelectedBranches);
                return RedirectToAction("Index");
            }
            teacherAddViewModel.Branches = await _branchService.GetBranchesAsync(true);
            return View(teacherAddViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Teacher teacher = await _teacherService.GetTeacherFullDataAsync(id);
            TeacherUpdateViewModel teacherUpdateViewModel = new TeacherUpdateViewModel()
            {
                Id = teacher.Id,
                FirstName = teacher.User.FirstName,
                LastName = teacher.User.LastName,
                Gender = teacher.User.Gender,
                DateOfBirth = teacher.User.DateOfBirth,
                Phone = teacher.User.Phone,
                City = teacher.User.City,
                IsApproved = teacher.IsApproved,
                UserName = teacher.User.UserName,
                Email = teacher.User.Email,
                Graduation = teacher.Graduation,
                Image = teacher.User.Image,
                SelectedBranches = teacher.TeacherBranches.Select(i => i.Branch.Id).ToArray()
            };
            teacherUpdateViewModel.Branches = await _branchService.GetBranchesAsync(true);
            return View(teacherUpdateViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TeacherUpdateViewModel teacherUpdateViewModel)
        {
            if (ModelState.IsValid)
            {
                Teacher teacher = await _teacherService.GetTeacherFullDataAsync(teacherUpdateViewModel.Id);
                teacher.User.FirstName = teacherUpdateViewModel.FirstName;
                teacher.User.LastName = teacherUpdateViewModel.LastName;
                teacher.User.DateOfBirth = teacherUpdateViewModel.DateOfBirth;
                teacher.User.Gender = teacherUpdateViewModel.Gender;
                teacher.User.City = teacherUpdateViewModel.City;
                teacher.User.Phone = teacherUpdateViewModel.Phone;
                teacher.IsApproved = teacherUpdateViewModel.IsApproved;
                teacher.UpdatedDate = DateTime.Now;
                teacher.Graduation = teacherUpdateViewModel.Graduation;
                teacher.User.UserName = teacherUpdateViewModel.UserName;
                teacher.User.Email = teacherUpdateViewModel.Email;

                if (teacherUpdateViewModel.ImageFile != null)
                {
                    teacher.User.Image = new Image
                    {
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now,
                        IsApproved = true,
                        Url = Jobs.UploadImage(teacherUpdateViewModel.ImageFile)
                    };
                    await _imageService.CreateAsync(teacher.User.Image);
                }

                await _teacherService.UpdateTeacher(teacher, teacherUpdateViewModel.SelectedBranches);
                return RedirectToAction("Index");
            }
            teacherUpdateViewModel.Branches = await _branchService.GetBranchesAsync(true);

            return View(teacherUpdateViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Teacher deletedTeacher = await _teacherService.GetTeacherFullDataAsync(id);
            TeacherViewModel teacherViewModel = new TeacherViewModel()
            {
                Id = deletedTeacher.Id,
                FirstName = deletedTeacher.User.FirstName,
                LastName = deletedTeacher.User.LastName,
                Gender = deletedTeacher.User.Gender,
                DateOfBirth = deletedTeacher.User.DateOfBirth,
                City = deletedTeacher.User.City,
                Graduation = deletedTeacher.Graduation,
                Phone = deletedTeacher.User.Phone,
                UserId = deletedTeacher.User.Id,
                CreatedDate = deletedTeacher.CreatedDate,
                UpdatedDate = deletedTeacher.UpdatedDate,
                IsApproved = deletedTeacher.IsApproved,
                Image = deletedTeacher.User.Image,
                Url = deletedTeacher.Url,
                User = deletedTeacher.User

            };
            List<Branch> branchList = deletedTeacher.TeacherBranches.Select(x => x.Branch).ToList();
            teacherViewModel.Branches = branchList.Select(b => new BranchViewModel { BranchName = b.BranchName }).ToList();
            return View(teacherViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(TeacherViewModel teacherViewModel)
        {
            //Teacher deletedTeacher = await _teacherService.GetByIdAsync(teacherViewModel.Id);
            User deletedTeacherByUser = await _userManager.FindByIdAsync(teacherViewModel.User.Id);
            if (deletedTeacherByUser != null)
            {
                //_teacherService.Delete(deletedTeacher);

                await _userManager.DeleteAsync(deletedTeacherByUser);



            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateIsApproved(int id, bool ApprovedStatus)
        {
            Teacher teacher = await _teacherService.GetByIdAsync(id);
            if (teacher != null)
            {
                teacher.IsApproved = !teacher.IsApproved;
                _teacherService.Update(teacher);
            }
            TeacherListViewModel teacherListViewModel = new TeacherListViewModel()
            {
                ApprovedStatus = ApprovedStatus
            };
            return RedirectToAction("Index", teacherListViewModel);
        }

        public async Task<IActionResult> GetTeachersByStudent(int id)
        {
            List<Teacher> teacherList = await _teacherService.GetTeachersByStudent(id);
            List<TeacherViewModel> teachers = new List<TeacherViewModel>();

            foreach (var teacher in teacherList)
            {
                teachers.Add(new TeacherViewModel
                {
                    Id = teacher.Id,
                    FirstName = teacher.User.FirstName,
                    LastName = teacher.User.LastName,
                    Gender = teacher.User.Gender,
                    DateOfBirth = teacher.User.DateOfBirth,
                    City = teacher.User.City,
                    Phone = teacher.User.Phone,
                    CreatedDate = teacher.CreatedDate,
                    UpdatedDate = teacher.UpdatedDate,
                    IsApproved = teacher.IsApproved,
                    Url = teacher.Url,
                    Graduation = teacher.Graduation,
                    UserId = teacher.UserId,
                    User = teacher.User,
                    Students = teacher.TeacherStudents.Select(ts => new StudentViewModel
                    {
                        Id = ts.Student.Id,
                        UserId = ts.Student.UserId,
                        User = ts.Student.User,
                        FirstName = ts.Student.User.FirstName,
                        LastName = ts.Student.User.LastName,
                        Url = ts.Student.Url
                    }).ToList(),
                    Branches = teacher.TeacherBranches.Select(tb => new BranchViewModel
                    {
                        Id = tb.Branch.Id,
                        BranchName = tb.Branch.BranchName,
                        Description = tb.Branch.Description,
                        Url = tb.Branch.Url
                    }).ToList(),
                    Image = teacher.User.Image
                });
            }
            TeacherListViewModel teacherListViewModel = new TeacherListViewModel()
            {
                Teachers = teachers,
                ApprovedStatus = true
            };
            return View("Index", teacherListViewModel);
        }

        public async Task<IActionResult> GetTeachersByBranch(int id)
        {
            List<Teacher> teacherList = await _teacherService.GetTeachersByBranch(id);
            List<TeacherViewModel> teachers = new List<TeacherViewModel>();

            foreach (var teacher in teacherList)
            {
                teachers.Add(new TeacherViewModel
                {
                    Id = teacher.Id,
                    FirstName = teacher.User.FirstName,
                    LastName = teacher.User.LastName,
                    Gender = teacher.User.Gender,
                    DateOfBirth = teacher.User.DateOfBirth,
                    City = teacher.User.City,
                    Phone = teacher.User.Phone,
                    CreatedDate = teacher.CreatedDate,
                    UpdatedDate = teacher.UpdatedDate,
                    IsApproved = teacher.IsApproved,
                    Url = teacher.Url,
                    Graduation = teacher.Graduation,
                    UserId = teacher.UserId,
                    User = teacher.User,
                    Students = teacher.TeacherStudents.Select(ts => new StudentViewModel
                    {
                        Id = ts.Student.Id,
                        UserId = ts.Student.UserId,
                        User = ts.Student.User,
                        FirstName = ts.Student.User.FirstName,
                        LastName = ts.Student.User.LastName,
                        Url = ts.Student.Url
                    }).ToList(),
                    Branches = teacher.TeacherBranches.Select(tb => new BranchViewModel
                    {
                        Id = tb.Branch.Id,
                        BranchName = tb.Branch.BranchName,
                        Description = tb.Branch.Description,
                        Url = tb.Branch.Url
                    }).ToList(),
                    Image = teacher.User.Image
                });
            }
            TeacherListViewModel teacherListViewModel = new TeacherListViewModel()
            {
                Teachers = teachers,
                ApprovedStatus = true
            };
            return View("Index", teacherListViewModel);
        }
    }
}
