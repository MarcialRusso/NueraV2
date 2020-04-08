using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Context;
using Main.Domain.HouseholdItems.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Main.Domain.HouseholdItems.Queries.Handlers
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
            // If bad may want to use pagination         
            var householdItems = await _context.HouseholdItems
                .Select(h => new HouseholdItemModel
                { 
                    Category = h.Category,
                    Name = h.Name,
                    Value = h.Value
                })
                .OrderBy(h => h.Category)
                .GroupBy(h => h.Category)
                .ToListAsync(cancellationToken);

            var model = householdItems.Select(i => 
                    new HouseholdItemsModel
                    {
                        Category = i.First().Category,
                        Items = i.Select(s => s).ToList()
                    }).ToList();
            
            var catalog = new ClientCatalogModel
            {
                HouseholdItems = model
            };

            return catalog;
        }
    }
}