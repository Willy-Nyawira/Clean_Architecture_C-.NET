using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchWithCQRSandMediator.Application.Blogs.Queries.GetBlogs;
using CleanArchWithCQRSandMediator.Domain.Repository;
using MediatR;

namespace CleanArchWithCQRSandMediator.Application.Blogs.Queries.GetBlogById
{
    public class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, BlogVm>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;

        public GetBlogByIdQueryHandler(IBlogRepository blogRepository, IMapper mapper) //calling the repository from domain layer using a constructor
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }
    
        public async Task<BlogVm> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken) //in the Handle call the repository
        {
          var blog= await _blogRepository.GetByIdAsync(request.BlogId);
           return _mapper.Map<BlogVm>(blog);
        }
    }
}
