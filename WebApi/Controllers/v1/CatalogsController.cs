using Application.Features.Catalogs.Commands.CreateCatalogCommand;
using Application.Features.Catalogs.Commands.DeleteCatalogCommand;
using Application.Features.Catalogs.Commands.UpdateCatalogCommand;
using Application.Features.Catalogs.Queries.GetAllCatalogs;
using Application.Features.Catalogs.Queries.GetCatalogById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    [Authorize]
    public class CatalogsController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await Mediator.Send(new GetAllCatalogsQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetCatalogByIdQuery { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateCatalogCommand command)
        {
            var user = HttpContext.User;
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateCatalogCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteCatalogCommand { Id = id }));
        }
    }
}
