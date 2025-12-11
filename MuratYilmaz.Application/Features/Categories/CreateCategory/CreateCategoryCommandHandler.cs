using AutoMapper;
using GenericRepository;
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

namespace MuratYilmaz.Application.Features.Categories.CreateCategory;

internal sealed class CreateCategoryCommandHandler(
    ICategoryRepository categoryRepository,
    IUnitOfWork unitOfWork,
    ICacheService cacheService,
    IMapper mapper) : IRequestHandler<CreateCategoryCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        bool isNameExists = await categoryRepository.AnyAsync(p => p.Name == request.Name, cancellationToken);

        if (isNameExists)
        {
            return Result<string>.Failure("Kategori adı daha önce kullanılmış");
        }

        Category category = mapper.Map<Category>(request);

        await categoryRepository.AddAsync(category, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        cacheService.Remove("categories");

        return "Kategori kaydı başarıyla tamamlandı";
    }
}
