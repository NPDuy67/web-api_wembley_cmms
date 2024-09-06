using WembleyCMMS.Domain.AggregateModels.PersonAggregate;

namespace WembleyCMMS.Api.Application.Commands.Persons
{
    public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand, bool>
    {
        private readonly IPersonRepository _personRepository;

        public UpdatePersonCommandHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<bool> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            var person = await _personRepository.GetById(request.PersonId) ?? throw new ResourceNotFoundException(nameof(Person), request.PersonId);
            person.Update(personName: request.PersonName);
            _personRepository.Update(person);

            return await _personRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
