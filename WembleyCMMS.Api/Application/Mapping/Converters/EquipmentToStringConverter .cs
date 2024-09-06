namespace WembleyCMMS.Api.Application.Mapping.Converters;

public class EquipmentToStringConverter : ITypeConverter<Equipment?, string>
{
    public string Convert(Equipment? source, string destination, ResolutionContext context)
    {
        if (source is null)
        {
            return string.Empty;
        }
        return source.Name;
    }
}
