using System.Runtime.Serialization;

namespace WembleyCMMS.Api.Application.Exceptions;

[Serializable]
public class EntityAlreadyExistsException : Exception
{
    public string ResourceType { get; } = "";
    public string ResourceId { get; } = "";
    public string InnerResourceType { get; } = "";
    public string InnerResourceTypeId { get; } = "";

    public EntityAlreadyExistsException() : base()
    {
    }

    public EntityAlreadyExistsException(string? message) : base(message)
    {
    }

    public EntityAlreadyExistsException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected EntityAlreadyExistsException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(serializationInfo, streamingContext)
    {
    }

    public EntityAlreadyExistsException(string resourceType, string resourceId, string innerResourceType, string innerResourceTypeId) : base($"The entity of type '{resourceType}' with ID '{resourceId}' have already existed '{innerResourceType}' with ID '{innerResourceTypeId}'")
    {
        ResourceType = resourceType;
        ResourceId = resourceId;
        InnerResourceType = innerResourceType;
        InnerResourceTypeId = innerResourceTypeId;
    }
}
