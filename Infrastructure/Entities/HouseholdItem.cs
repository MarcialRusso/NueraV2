﻿using System;

namespace NueraVersion2.Infrastructure.Entities
{
    /// <summary>
    /// Describes the household item the insurance customer
    /// wants to insure. 
    /// </summary>
    /// TODO - From DDD point of view the HouseholdItem is not the same for
    /// a client persona and an insurer persona. These are completely different
    /// bounded contexts and should be separate. For now this will be shared.
    public class HouseholdItem
    {
        public Guid Id { get; set; }

        /// <summary>
        /// The client who created the household item
        /// </summary>
        // TODO - If a microservice is created use Client/Insurer instead
        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        /// <summary>
        /// Represents the item category
        /// </summary>
        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }

        /// <summary>
        /// Represents the item cost of replacement
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Represent the item date added
        /// </summary>
        public DateTime DateAdded { get; set; }
    }
}