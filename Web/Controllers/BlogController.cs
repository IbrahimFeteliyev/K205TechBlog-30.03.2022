using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Web.ViewModels;

namespace Web.Controllers
{
    public class BlogController : Controller

    {
        private readonly IBlogManager _blogManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<K205User> _usermanager;

        public BlogController(IBlogManager blogManager, IHttpContextAccessor httpContextAccessor, UserManager<K205User> usermanager)
        {
            _blogManager = blogManager;
            _httpContextAccessor = httpContextAccessor;
            _usermanager = usermanager;
        }

        public IActionResult Detail(int? id)
        {
            var blog = _blogManager.GetById(id);
           var selectedUser= _usermanager.FindByIdAsync(blog.K205UserId);
            BlogSingleVM vm = new()
            {
                BlogSingle = blog,
                User = selectedUser.Result,
            };
            return View(vm);
        }
    }
}
