using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Context;
using Main.Domain.ClientCatalog.Models;
using Main.Domain.HouseholdItems.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Main.Domain.ClientCatalog.Queries.Handlers
{
    // TODO - Replace IRequestHandler with an abstraction layer (eg: IQueryHandler)
    public class ClientCatalogQueryHandler : IRequestHandler<ClientCatalogQuery, ClientCatalogModel>
    {
        private readonly NueraContext _context;

        public ClientCatalogQueryHandler(NueraContext context)
        {
            _context = context;
        }

        async Task<ClientCatalogModel> IRequestHandler<ClientCatalogQuery, ClientCatalogModel>.Handle(ClientCatalogQuery request, CancellationToken cancellationToken)
        {
            // Check performance since we are pulling all objects at once
            // If performance is bad then improve by:
            // 1. Using pagination
            // 2. Improve query performance by implementing a more complex LINQ query(ie. let x ... ) 
            // 3. Instead of the model calculating the total value, provide it from the query
            var groupedHouseholdItems = await _context.HouseholdItems
                .Select(h => new HouseholdItemModel
                { 
                    Category = h.Category,
                    Name = h.Name,
                    Value = h.Value
                })
                .OrderBy(h => h.Category)
                .GroupBy(h => h.Category)
                .ToListAsync(cancellationToken);

            var householdItemsModel = groupedHouseholdItems.Select(i => 
                    new HouseholdItemsModel
                    {
                        Category = i.First().Category,
                        Items = i.Select(s => s).ToList()
                    }).ToList();
            
            var catalog = new ClientCatalogModel
            {
                HouseholdItems = householdItemsModel
            };

            return catalog;
        }
    }
}