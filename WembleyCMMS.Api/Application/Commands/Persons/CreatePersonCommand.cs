using System.Runtime.Serialization;

namespace WembleyCMMS.Api.Application.Commands.Persons
{
    [DataContract]
    public class CreatePersonCommand : IRequest<bool>
    {
        public string PersonName { get; set; }

        public CreatePersonCommand(string personName)
        {
            PersonName = personName;
        }
    }
}
