using WembleyCMMS.Domain.AggregateModels.CauseAggregate;

namespace WembleyCMMS.Api.Application.Mapping.Converters;

public class CauseToStringConverter : ITypeConverter<Cause, string>
{
    public string Convert(Cause source, string destination, ResolutionContext context)
    {
        return source.CauseName;
    }
}
