using System.Collections.Generic;
using Main.Domain.HouseholdItems.Models;
using MediatR;

namespace Main.Domain.HouseholdItems.Queries
{
    /// <summary>
    /// Retrieves a client insurable household items catalog.
    /// </summary>
    public class ClientCatalogQuery : IRequest<ClientCatalogModel>
    {
    }
}