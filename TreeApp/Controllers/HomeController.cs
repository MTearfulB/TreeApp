using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using TreeApp.Data;
using TreeApp.Models;
using TreeApp.ViewModels;

namespace TreeApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly BranchDataContext context;

        public HomeController(BranchDataContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var branches = this.context.Branches
                .Select(branch => new BranchViewModel
                {
                    Id = branch.Id,
                    Name = branch.Name,
                    ParentId = branch.ParentId
                });
            return View(branches);
        }
        [HttpPost]
        public IActionResult CreatePost(int Id, string Name, int ParentId)
        {
            var newBranch = new Branch
            {
                Name = Name,
                ParentId = ParentId
            };
            this.context.Branches.Add(newBranch);
            this.context.SaveChanges();
            return Index();
        }
        public IActionResult Create()
        {
            var branches = this.context.Branches
                .Select(branch => new BranchViewModel
                {
                    Id = branch.Id,
                    Name = branch.Name,
                    ParentId = branch.ParentId
                });
            return View(branches);
        }
        [HttpPost]
        public IActionResult DeletePost(int Id)
        {
            var branch = this.context.Branches
                .FirstOrDefault(c => c.Id == Id);

            if (branch != null) {
                this.context.Branches.Remove(branch);
            }
            var childBranches = this.context.Branches
                .Where(d => d.ParentId == Id).ToList();
            foreach (var childBranch in childBranches)
            {
                this.context.Branches.Remove(childBranch);
            }
            this.context.SaveChanges();
            return Index();
        }
        public IActionResult Delete()
        {
            var branches = this.context.Branches
                .Select(branch => new BranchViewModel
                {
                    Id = branch.Id,
                    Name = branch.Name,
                    ParentId = branch.ParentId
                });
            return View(branches);
        }
        [HttpPost]
        public IActionResult EditPost(int Id, string newName, int newParentId)
        {
            var branch = this.context.Branches
                .FirstOrDefault(c => c.Id == Id);
            if (branch != null)
            {
                branch.Name = newName;
                branch.ParentId = newParentId;
                this.context.Branches.Update(branch);
                this.context.SaveChanges();
            }
            return Index();
        }
        public IActionResult Edit()
        {
            var branches = this.context.Branches
                .Select(branch => new BranchViewModel
                {
                    Id = branch.Id,
                    Name = branch.Name,
                    ParentId = branch.ParentId
                });
            return View(branches);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}