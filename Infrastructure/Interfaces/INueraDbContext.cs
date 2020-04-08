﻿using Microsoft.EntityFrameworkCore;
using NueraVersion2.Infrastructure.Entities;

namespace NueraVersion2.Infrastructure.Interfaces
{
    // TODO - DB sets should be filtered
    public interface INueraDbContext
    {
        DbSet<Category> Categories { get; }
        DbSet<HouseholdItem> HouseholdItems { get; }
        DbSet<User> Users { get; }
    }
}