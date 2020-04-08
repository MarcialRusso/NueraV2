using System;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Entities;
using Infrastructure.Interfaces;
using MediatR;

namespace Main.Domain.HouseholdItems.Commands.Handlers
{
    public class AddHouseholdItemForClientCommandHandler : AsyncRequestHandler<AddHouseholdItemForClientCommand>
    {
        private readonly IHouseholdItemRepository _householdItemRepository;

        public AddHouseholdItemForClientCommandHandler(IHouseholdItemRepository householdItemRepository)
        {
            _householdItemRepository = householdItemRepository;
        }

        // TODO - Implement ICommandValidator
        // TODO - Command uses uint for value so must check for overflow since DB is an int
        protected override Task Handle(AddHouseholdItemForClientCommand request, CancellationToken cancellationToken)
        {
            var categoryExist = Enum.IsDefined(typeof(CategoryType), request.Category);
            if (!categoryExist) throw new ArgumentException($"Category {request.Category} is invalid.") ;
            
            _householdItemRepository.Insert(new HouseholdItem
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Value = (int)request.Value,
                Category =  request.Category
            });
            
            return Task.CompletedTask;
        }
    }
}