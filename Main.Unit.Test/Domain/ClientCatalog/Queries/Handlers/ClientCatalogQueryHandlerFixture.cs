using Infrastructure.Context;
using Infrastructure.Entities;
using Main.Domain.ClientCatalog.Queries;
using Main.Domain.ClientCatalog.Queries.Handlers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Main.Main.Unit.Test.Domain.ClientCatalog.Queries.Handlers
{
    public class ClientCatalogQueryHandlerFixture
    {
        private ClientCatalogQueryHandler _handler;
        private Mock<IMediator> _mediator;

        public ClientCatalogQueryHandlerFixture()
        {            
            _mediator = new Mock<IMediator>();
        }

        // TODO
        // Add test for null item
        // Add test for mapping a HouseholdItem
        // Add test for total sum in the category
        // Add test for total sum of all items

        [Fact]
        public async Task ClientCatalogQuery_ShouldSortItemsByCategory()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<NueraContext>()
            .UseInMemoryDatabase(databaseName: "NueraDatabase")
            .Options;

            var dateAdded = DateTime.UtcNow.AddDays(-1);
            var expectedFirstType = CategoryType.Clothing.ToString();
            var expectedSecondType = CategoryType.Electronics.ToString();
            var expectedThirdType = CategoryType.Kitchen.ToString();

            var electronicItem = new HouseholdItem { Category = expectedSecondType, Name = expectedSecondType, Value = 1000, DateAdded = dateAdded};
            var clothingItem = new HouseholdItem { Category = expectedFirstType, Name = expectedFirstType, Value = 1000, DateAdded = dateAdded};
            var kitchenItem = new HouseholdItem { Category = expectedThirdType, Name = expectedThirdType, Value = 100, DateAdded = dateAdded};

            using (var context = new NueraContext(options))
            {
                await context.HouseholdItems.AddRangeAsync(kitchenItem, clothingItem, electronicItem);
                await context.SaveChangesAsync();
            }

            using (var context = new NueraContext(options))
            {
                _handler = new ClientCatalogQueryHandler(context);

                ClientCatalogQuery query = new ClientCatalogQuery();
                ClientCatalogQueryHandler handler = new ClientCatalogQueryHandler(context);

                //Act
                var catalog = await handler.Handle(query, new System.Threading.CancellationToken());

                //Assert
                Assert.Equal(catalog.HouseholdItems.ElementAt(0).Category, expectedFirstType);
                Assert.Equal(catalog.HouseholdItems.ElementAt(1).Category, expectedSecondType);
                Assert.Equal(catalog.HouseholdItems.ElementAt(2).Category, expectedThirdType);
            }
        }
    }
}
