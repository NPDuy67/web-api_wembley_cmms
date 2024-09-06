using System.Runtime.Serialization;

namespace WembleyCMMS.Api.Application.Commands.Equipments
{
    [DataContract]
    public class CreateEquipmentCommand : IRequest<bool>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string EquipmentClass { get; set; }

        public CreateEquipmentCommand(string code, string name, string equipmentClass)
        {
            Code = code;
            Name = name;
            EquipmentClass = equipmentClass;
        }
    }

}
