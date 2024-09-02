using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchWithCQRSandMediator.Domain.Entity;

namespace CleanArchWithCQRSandMediator.Domain.Repository
{
    public interface IBlogRepository
    {
        Task<List<Blog>> GetAllBlogsAsync();
        Task<Blog> GetByIdAsync(int Id);
        Task<Blog> CreateAsync(Blog blog);
        Task<int> UpdateASync(int Id, Blog blog);
        Task<int> DeleteAsync(int Id);
    }
}
