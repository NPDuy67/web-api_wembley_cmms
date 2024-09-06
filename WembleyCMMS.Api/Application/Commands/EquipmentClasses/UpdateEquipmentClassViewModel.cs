using System.Runtime.Serialization;

namespace WembleyCMMS.Api.Application.Commands.EquipmentClasses
{
    [DataContract]
    public class UpdateEquipmentClassViewModel
    {
        public string Name { get; set; }

        public UpdateEquipmentClassViewModel(string name)
        {
            Name = name;
        }
    }
}
