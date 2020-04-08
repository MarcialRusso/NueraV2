using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Interfaces;
using MediatR;

namespace Main.Domain.HouseholdItems.Commands.Handlers
{
    public class RemoveClientHouseholdItemCommandHandler : AsyncRequestHandler<RemoveClientHouseholdItemCommand>
    {
        private readonly IHouseholdItemRepository _householdItemRepository;

        public RemoveClientHouseholdItemCommandHandler(IHouseholdItemRepository householdItemRepository)
        {
            _householdItemRepository = householdItemRepository;
        }

        protected override Task Handle(RemoveClientHouseholdItemCommand request, CancellationToken cancellationToken)
        {
            return _householdItemRepository.DeleteAsync(request.HouseholdItemId);
        }
    }
}