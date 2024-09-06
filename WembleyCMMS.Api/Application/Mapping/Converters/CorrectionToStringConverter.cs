using WembleyCMMS.Domain.AggregateModels.CorrectionAggregate;

namespace WembleyCMMS.Api.Application.Mapping.Converters;

public class CorrectionToStringConverter : ITypeConverter<Correction, string>
{
    public string Convert(Correction source, string destination, ResolutionContext context)
    {
        return source.CorrectionName;
    }
}
