using WebApp.Data.Contexts;
using WebApp.Data.Entities;
using WebApp.Data.Interfaces;
using WebApp.Data.Repositories;
using WebApp.Data.Uow;
using WebApp.Mapping;
using WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Controllers
{
    public class BlogController : Controller //(MyContext myContext)
    {
        private readonly MyContext _myContext;// = myContext;
        private readonly IBlogRepository _blogRepository;
        private readonly IBlogMapper _blogMapper;
        private readonly IUow _uow;
        public BlogController(MyContext myContext, IBlogRepository blogRepository, IBlogMapper blogMapper, IUow uow)
        {
            _myContext = myContext;
            //blogRepository = new BlogRepository(_myContext);
            _blogRepository = blogRepository;
            _blogMapper = blogMapper;
            _uow = uow;
        }

        public IActionResult Index()
        {
            return View(_blogMapper.BlogListWithComment(_uow.GetRepository<Blog>().GetAllWithInclude()));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new BlogCreateModel());
        }

        [HttpPost]
        public IActionResult Create(BlogCreateModel model)
        {
            if (ModelState.IsValid)
            {
                _uow.GetRepository<Blog>().Create(_blogMapper.CreateToBlog(model));
                _uow.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int id)
        {           
            var rep = _uow.GetRepository<Blog>();
            var _blog = rep.GetById(id);
            if (_blog != null)
            {
                rep.Remove(_blog);
                _uow.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            return View(_blogMapper.BlogToUpdate(_uow.GetRepository<Blog>().GetById(id)));
        }

        [HttpPost]
        public IActionResult Update(BlogUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                _uow.GetRepository<Blog>().Update(_blogMapper.UpdateToBlog(model));
                _uow.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
