namespace WembleyCMMS.Api.Application.Commands.Persons
{
    public class UpdatePersonCommand : IRequest<bool>
    {
        public string PersonId { get; set; }
        public string PersonName { get; set; }

        public UpdatePersonCommand(string personId, string personName)
        {
            PersonId = personId;
            PersonName = personName;
        }
    }
}
