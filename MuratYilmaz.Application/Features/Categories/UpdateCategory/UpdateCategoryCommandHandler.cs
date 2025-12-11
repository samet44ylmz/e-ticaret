using AutoMapper;
using GenericRepository;
using MediatR;
using MuratYilmaz.Application.Services;
using MuratYilmaz.Domain.Entities;
using MuratYilmaz.Domain.Repositories;
using TS.Result;

namespace MuratYilmaz.Application.Features.Categories.UpdateCategory;

internal sealed class UpdateCategoryCommandHandler(
    ICategoryRepository categoryRepository,
    IUnitOfWork unitOfWork,
    ICacheService cacheService,
    IMapper mapper) : IRequestHandler<UpdateCategoryCommand, Result<string>>
{

    public async Task<Result<string>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
  
        Category? category = await categoryRepository.GetByExpressionWithTrackingAsync(p => p.Id == request.Id, cancellationToken);

        if (category is null)
        {
            return Result<string>.Failure("Kategori bulunamadı"); // "Ürün" -> "Kategori" olarak düzeltildi
        }

 
        if (category.Name != request.Name)
        {
            bool isNameExists = await categoryRepository.AnyAsync(p => p.Name == request.Name, cancellationToken);

            if (isNameExists)
            {
                return Result<string>.Failure("Bu kategori adı daha önce kullanılmış");
            }
        }

   
        mapper.Map(request, category);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        cacheService.Remove("categories");

        return "Kategori başarıyla güncellendi";
    }
}