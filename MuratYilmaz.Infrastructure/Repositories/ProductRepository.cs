using GenericRepository;
using MuratYilmaz.Domain.Entities;
using MuratYilmaz.Domain.Repositories;
using MuratYilmaz.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuratYilmaz.Infrastructure.Repositories;

internal sealed class ProductRepository : Repository<Product, ApplicationDbContext>, IProductRepository
{
    public ProductRepository(ApplicationDbContext context) : base(context)
    {
    }
}