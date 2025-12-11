using MuratYilmaz.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuratYilmaz.Domain.Entities;

public sealed class Category : Entity
{
    public string Name { get; set; } = string.Empty;
    public bool IsDeleted { get; set; }
}