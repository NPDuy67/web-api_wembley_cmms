using System.Runtime.Serialization;

namespace WembleyCMMS.Api.Application.Commands.EquipmentClasses
{
    [DataContract]
    public class CreateEquipmentClassCommand : IRequest<bool>
    {
        public string Name { get; set; }

        public CreateEquipmentClassCommand(string name)
        {
            Name = name;
        }
    }
}
