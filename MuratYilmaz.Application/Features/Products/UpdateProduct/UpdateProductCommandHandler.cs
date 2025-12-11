using AutoMapper;
using GenericRepository;
using MediatR;
using MuratYilmaz.Application.Services;
using MuratYilmaz.Domain.Entities;
using MuratYilmaz.Domain.Repositories;
using TS.Result;

namespace MuratYilmaz.Application.Features.Products.UpdateProduct;

internal sealed class UpdateProductCommandHandler(
    IProductRepository productRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper,
    ICacheService cacheService) : IRequestHandler<UpdateProductCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        Product? product = await productRepository.GetByExpressionWithTrackingAsync(p => p.Id == request.Id, cancellationToken);

        if (product is null)
        {
            return Result<string>.Failure("Ürün bulunamadı");
        }

        if (product.Name != request.Name)
        {
            bool isNameExists = await productRepository.AnyAsync(p => p.Name == request.Name, cancellationToken);

            if (isNameExists)
            {
                return Result<string>.Failure("Ürün adı daha önce kullanılmış");
            }
        }

        mapper.Map(request, product);
        product.Gender = request.Gender;

        await unitOfWork.SaveChangesAsync(cancellationToken);

        cacheService.Remove("products");

        return "Ürün kaydı başarıyla güncellendi";
    }
}