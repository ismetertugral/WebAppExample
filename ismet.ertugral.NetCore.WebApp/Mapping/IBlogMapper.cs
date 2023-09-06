using WebApp.Data.Entities;
using WebApp.Models;

namespace WebApp.Mapping
{
    public interface IBlogMapper
    {
        List<ListBlog> BlogList(List<Blog> blogs);
        List<ListBlogWithComment> BlogListWithComment(List<Blog> blogs);
        Blog CreateToBlog(BlogCreateModel model);
        BlogUpdateModel BlogToUpdate(Blog blog);
        Blog UpdateToBlog(BlogUpdateModel model);
    }
}
