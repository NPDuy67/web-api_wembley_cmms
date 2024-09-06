using System.Runtime.Serialization;

namespace WembleyCMMS.Api.Application.Commands.Equipments
{
    [DataContract]
    public class UpdateEquipmentViewModel
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string EquipmentClass { get; set; }

        public UpdateEquipmentViewModel(string? code, string? name, string equipmentClass)
        {
            Code = code;
            Name = name;
            EquipmentClass = equipmentClass;
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private UpdateEquipmentViewModel()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {

        }
    }
}
