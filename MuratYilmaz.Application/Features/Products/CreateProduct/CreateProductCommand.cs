using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace MuratYilmaz.Application.Features.Products.CreateProduct;

public sealed record CreateProductCommand(
    string Name,
    string Description,
    string Price,
    string ImageUrl,
    string Gender
    ) : IRequest<Result<string>>;