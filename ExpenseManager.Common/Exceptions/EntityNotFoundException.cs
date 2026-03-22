namespace ExpenseManager.Common.Exceptions;

public class EntityNotFoundException : Exception
{
    public string EntityName { get; }
    public Guid EntityId { get; }
    public EntityNotFoundException() : base() { }
    public EntityNotFoundException(string message) : base(message) { }
    public EntityNotFoundException(string message, Exception inner) : base(message, inner) { }
    public  EntityNotFoundException(string entityName, Guid entityId) : base($"{entityName} with id {entityId} not found.")
    {
        EntityName = entityName;
        EntityId = entityId;
    }
    
}