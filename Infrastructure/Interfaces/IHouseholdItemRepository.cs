﻿using System.Collections.Generic;
using NueraVersion2.Infrastructure.Entities;

namespace NueraVersion2.Infrastructure.Interfaces
{
    public interface IHouseholdItemRepository
    {
        IEnumerable<HouseholdItem> GetAll();
        HouseholdItem GetById(int householdItemId);
        void Insert(HouseholdItem householdItem);
        void Update(HouseholdItem householdItem);
        void Delete(int householdItemId);
        void Save();
    }
}