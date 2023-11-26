using System.ComponentModel.DataAnnotations;

namespace Lab6.Api.Abstractions;

public abstract class BaseEntity
{
    [Key]
    public string Id { get; protected set; }

    public BaseEntity(string id)
    {
        Id = id;
    }

    protected BaseEntity() { }
}
