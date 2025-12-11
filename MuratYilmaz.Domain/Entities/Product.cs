using MuratYilmaz.Domain.Abstractions;
using System;

namespace MuratYilmaz.Domain.Entities;

public sealed class Product : Entity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public bool IsDeleted { get; set; }
    public string Gender { get; set; } = string.Empty;
}