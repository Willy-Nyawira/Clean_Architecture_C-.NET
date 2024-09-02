using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchWithCQRSandMediator.Application.Blogs.Queries.GetBlogs;
using CleanArchWithCQRSandMediator.Domain.Entity;
using CleanArchWithCQRSandMediator.Domain.Repository;
using MediatR;

namespace CleanArchWithCQRSandMediator.Application.Blogs.Commands.UpdateBlog
{
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand, int>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;

        public UpdateBlogCommandHandler(IBlogRepository blogRepository,IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var UpdateBlogEntity = new Blog()
            {
                Id = request.Id,
                Author=request.Author,
                Description=request.Description,
                Name=request.Name
            };
            return await _blogRepository.UpdateASync(request.Id, UpdateBlogEntity);
            
        }
    }
}
