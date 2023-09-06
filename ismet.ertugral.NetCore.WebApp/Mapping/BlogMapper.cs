using WebApp.Data.Entities;
using WebApp.Models;

namespace WebApp.Mapping
{
    public class BlogMapper : IBlogMapper
    {
        public Blog CreateToBlog(BlogCreateModel model)
        {
            return new Blog { Name = model.Name, Description = model.Description };
        }

        public BlogUpdateModel BlogToUpdate(Blog blog)
        {
            return new BlogUpdateModel { Id = blog.Id, Name = blog.Name, Description = blog.Description };
        }

        public Blog UpdateToBlog(BlogUpdateModel model)
        {
            return new Blog { Id = model.Id, Name = model.Name, Description = model.Description };
        }

        public List<ListBlog> BlogList(List<Blog> blogs)
        {
            return blogs.Select(x => new ListBlog { Id = x.Id, Description = x.Description, Name = x.Name }).ToList();
        }

        public List<ListBlogWithComment> BlogListWithComment(List<Blog> blogs)
        {
            return blogs.Select(x => new ListBlogWithComment { Id = x.Id, Description = x.Description, Name = x.Name, Comments = x.Comments }).ToList();
        }


    }
}
