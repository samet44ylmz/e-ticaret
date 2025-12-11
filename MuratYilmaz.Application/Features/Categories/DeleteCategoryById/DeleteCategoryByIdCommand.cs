using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace MuratYilmaz.Application.Features.Categories.DeleteCategory;

public sealed record DeleteCategoryByIdCommand(Guid Id) : IRequest<Result<string>>;