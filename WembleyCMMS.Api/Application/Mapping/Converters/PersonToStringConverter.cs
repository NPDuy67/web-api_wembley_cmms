using WembleyCMMS.Domain.AggregateModels.PersonAggregate;

namespace WembleyCMMS.Api.Application.Mapping.Converters;

public class PersonToStringConverter : ITypeConverter<Person?, string>
{
    public string Convert(Person? source, string destination, ResolutionContext context)
    {
        if (source is null)
        {
            return string.Empty;
        }
        return source.PersonName;
    }
}
