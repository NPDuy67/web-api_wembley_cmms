using System.Runtime.Serialization;

namespace WembleyCMMS.Api.Application.Commands.Persons
{
    [DataContract]
    public class UpdatePersonViewModel
    {
        public string PersonName { get; set; }

        public UpdatePersonViewModel(string personName)
        {
            PersonName = personName;
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private UpdatePersonViewModel() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}
