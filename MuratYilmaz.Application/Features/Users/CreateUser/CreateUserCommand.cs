using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace MuratYilmaz.Application.Features.Users.CreateUser;

public sealed record CreateUserCommand(
    string FirstName,
    string LastName,
    string UserName,
    string Email,
    string Password) : IRequest<Result<string>>;
