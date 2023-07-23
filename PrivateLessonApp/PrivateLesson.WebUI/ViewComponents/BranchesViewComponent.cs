using Microsoft.AspNetCore.Mvc;
using PrivateLesson.Business.Abstract;
using PrivateLesson.Entity.Concrete;
using PrivateLesson.WebUI.Models.ViewModels;

namespace PrivateLesson.WebUI.ViewComponents
{
    public class BranchesViewComponent : ViewComponent
    {
        private IBranchService _branchService;

        public BranchesViewComponent(IBranchService branchService)
        {
            _branchService = branchService;
        }



        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Branch> branches = await _branchService.GetBranchesAsync(true);
            List<BranchViewModel> branchViewModels = new List<BranchViewModel>();

            foreach (var branch in branches)
            {
                branchViewModels.Add(
                     new BranchViewModel
                     {
                         Id = branch.Id,
                         BranchName = branch.BranchName,
                         Description = branch.Description,
                         Url = branch.Url
                     });
            }
            if (RouteData.Values["branchurl"] != null)
            {
                ViewBag.SelectedBranchName = RouteData.Values["branchurl"];
            }
            return View(branchViewModels);
        }
    }
}
