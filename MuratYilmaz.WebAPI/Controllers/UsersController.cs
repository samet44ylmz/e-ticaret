using MediatR;
using Microsoft.AspNetCore.Mvc;
using MuratYilmaz.Application.Features.Users.CreateUser;
using MuratYilmaz.Application.Features.Users.DeleteUser;
using MuratYilmaz.Application.Features.Users.GetAllUsersQuery;
using MuratYilmaz.Application.Features.Users.UpdateUser;
using MuratYilmaz.WebAPI.Abstractions;

namespace MuratYilmaz.WebAPI.Controllers;

public sealed class UsersController : ApiController
{
    public UsersController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> GetAll(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteById(DeleteUserByIdCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}