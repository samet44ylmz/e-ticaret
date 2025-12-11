using MediatR;
using MuratYilmaz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace MuratYilmaz.Application.Features.Users.GetAllUsersQuery;

public sealed record GetAllUsersQuery() : IRequest<Result<List<AppUser>>>;
