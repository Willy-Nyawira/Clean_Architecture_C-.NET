using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchWithCQRSandMediator.Domain.Entity;
using CleanArchWithCQRSandMediator.Domain.Repository;
using CleanArchWithCQRSandMediator.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace CleanArchWithCQRSandMediator.Infra.Repository
{
    public class BlogRepository : IBlogRepository
    {
        private readonly BlogDbContext _blogDbContext;

        //create constructor so you can inject the DbContext
        public BlogRepository(BlogDbContext blogDbContext)
        {
            _blogDbContext = blogDbContext;
        }
        public async Task<Blog> CreateAsync(Blog blog)
        {
            await _blogDbContext.Blogs.AddAsync(blog);
            await _blogDbContext.SaveChangesAsync();
            return blog;
        }

        public async Task<int> DeleteAsync(int Id)
        {
            return await _blogDbContext.Blogs.
                Where(model => model.Id == Id)
                .ExecuteDeleteAsync();
        }

        public async Task<List<Blog>> GetAllBlogsAsync()
        {
            return await _blogDbContext.Blogs.ToListAsync();
        }

        public async Task<Blog> GetByIdAsync(int Id)
        {
            return await _blogDbContext.Blogs.AsNoTracking()
                .FirstOrDefaultAsync(b => b.Id == Id);
        }

        public async Task<int> UpdateASync(int Id, Blog blog)
        {
            return await _blogDbContext.Blogs.
                Where(model => model.Id == Id)
                .ExecuteUpdateAsync(setters => setters
                .SetProperty(m => m.Id, blog.Id)
                .SetProperty(m => m.Name, blog.Name)
                .SetProperty(m => m.Description, blog.Description)
                .SetProperty(m => m.Author, blog.Author)
                );
        }
    }
}
