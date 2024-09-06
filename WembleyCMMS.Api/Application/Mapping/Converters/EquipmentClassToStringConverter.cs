using WembleyCMMS.Domain.AggregateModels.EquipmentClassAggregate;

namespace WembleyCMMS.Api.Application.Mapping.Converters;

public class EquipmentClassToStringConverter : ITypeConverter<EquipmentClass, string>
{
    public string Convert(EquipmentClass source, string destination, ResolutionContext context)
    {
        return source.Name;
    }
}
