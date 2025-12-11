using AutoMapper;
using GenericRepository;
using MediatR;
using MuratYilmaz.Application.Services;
using MuratYilmaz.Domain.Entities;
using MuratYilmaz.Domain.Repositories;
using TS.Result;

namespace MuratYilmaz.Application.Features.Products.CreateProduct;

internal sealed class CreateProductCommandHandler(
    IProductRepository productRepository,
    IUnitOfWork unitOfWork,
    ICacheService cacheService,
    IMapper mapper) : IRequestHandler<CreateProductCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        bool isNameExists = await productRepository.AnyAsync(p => p.Name == request.Name, cancellationToken);

        if (isNameExists)
        {
            return Result<string>.Failure("Ürün adı daha önce kullanılmış");
        }

        Product product = mapper.Map<Product>(request);

        await productRepository.AddAsync(product, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        cacheService.Remove("products");

        return "Ürün kaydı başarıyla tamamlandı";
    }
}