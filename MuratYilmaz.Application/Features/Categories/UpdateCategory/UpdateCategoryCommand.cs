using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace MuratYilmaz.Application.Features.Categories.UpdateCategory;

public sealed record UpdateCategoryCommand(
    Guid Id,
    string Name
) : IRequest<Result<string>>;