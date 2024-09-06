using WembleyCMMS.Domain.AggregateModels.PersonAggregate;

namespace WembleyCMMS.Api.Application.Commands.Persons
{
    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, bool>
    {
        private readonly IPersonRepository _personRepository;

        public CreatePersonCommandHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<bool> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var personId = Guid.NewGuid().ToString();
            var person = new Person(personId: personId,
                                    personName: request.PersonName);
            _personRepository.Add(person);

            return await _personRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
