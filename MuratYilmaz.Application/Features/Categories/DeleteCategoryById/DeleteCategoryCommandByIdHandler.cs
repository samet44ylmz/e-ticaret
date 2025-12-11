using GenericRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MuratYilmaz.Application.Features.Categories.DeleteCategory;
using MuratYilmaz.Application.Services;
using MuratYilmaz.Domain.Entities;
using MuratYilmaz.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace MuratYilmaz.Application.Features.Categories.DeleteCategoryById;

internal sealed class DeleteCategoryByIdHandler(
    ICategoryRepository categoryRepository,
    IUnitOfWork unitOfWork,
    ICacheService cacheService) : IRequestHandler<DeleteCategoryByIdCommand, Result<string>>
{
    public async Task<Result<string>> Handle(DeleteCategoryByIdCommand request, CancellationToken cancellationToken)
    {
        Category? category = await categoryRepository.GetByExpressionWithTrackingAsync(p => p.Id == request.Id, cancellationToken);

        if (category is null)
        {
            return Result<string>.Failure("Kategori bulunamadı");
        }

        category.IsDeleted = true;

        await unitOfWork.SaveChangesAsync(cancellationToken);

        cacheService.Remove("categories");

        return "Kategori kaydı başarıyla silindi";
    }
}
