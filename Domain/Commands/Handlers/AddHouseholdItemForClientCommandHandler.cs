using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Main.Domain.Commands.Handlers
{
    public class AddHouseholdItemForClientCommandHandler : AsyncRequestHandler<AddHouseholdItemForClientCommand>
    {
        // TODO - Implement ICommandValidator
        // TODO - Command uses uint for value so must check for overflow since DB is an int
        protected override Task Handle(AddHouseholdItemForClientCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}