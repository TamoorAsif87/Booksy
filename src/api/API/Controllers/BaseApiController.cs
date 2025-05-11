using API.Helpers;
using Core.Entities;
using Core.interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        protected async Task<Pagination<T>> GetPaginationAsync<T>(IGenericRepository<T> repo,BaseSpecification<T> specs,int pageSize, int page) where T:BaseEntity
        {
            
            var entities = await repo.GetEntitiesWithSpec(specs);
            var count = await repo.CountAsync(specs);
            var pages = (int)Math.Ceiling((double)count / pageSize);

            var result = new Pagination<T>(data:entities, pageSize: pageSize, pages: pages, pageIndex:page,count:count);

            return result;
        }
    }
}
