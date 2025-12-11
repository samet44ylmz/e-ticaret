using MediatR;
using Microsoft.EntityFrameworkCore;
using MuratYilmaz.Application.Services;
using MuratYilmaz.Domain.Entities;
using MuratYilmaz.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace MuratYilmaz.Application.Features.Categories.GetAllCategories;

internal sealed class GetAllCategoriesQueryHandler(
    ICategoryRepository categoryRepository,
    ICacheService cacheService) : IRequestHandler<GetAllCategoriesQuery, Result<List<Category>>>
{
    public async Task<Result<List<Category>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        List<Category>? categories;

        categories = cacheService.Get<List<Category>>("categories");

        if (categories is null)
        {
            categories = await categoryRepository.GetAll().OrderBy(p => p.Name).ToListAsync(cancellationToken);

            cacheService.Set("categories", categories);
        }
        return categories;
    }
}