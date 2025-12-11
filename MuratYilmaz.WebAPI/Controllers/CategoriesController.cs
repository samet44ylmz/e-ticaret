using MediatR;
using Microsoft.AspNetCore.Mvc;
using MuratYilmaz.Application.Features.Categories.CreateCategory;
using MuratYilmaz.Application.Features.Categories.DeleteCategory;
using MuratYilmaz.Application.Features.Categories.GetAllCategories;

using MuratYilmaz.Application.Features.Categories.UpdateCategory;
using MuratYilmaz.WebAPI.Abstractions;

namespace MuratYilmaz.WebAPI.Controllers;

public sealed class CategoriesController : ApiController
{
    public CategoriesController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> GetAll(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    

    [HttpPost]
    public async Task<IActionResult> Create(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteById(DeleteCategoryByIdCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}