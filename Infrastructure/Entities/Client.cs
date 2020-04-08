﻿using System.Collections.Generic;

namespace NueraVersion2.Infrastructure.Entities
{
    /// <summary>
    /// Represents a client who may submit a contents limit insurance
    /// </summary>
    public class Client : User
    {
        public Client()
        {
            Contents = new List<HouseholdItem>();
        }

        public List<HouseholdItem> Contents { get; set; }
    }
}