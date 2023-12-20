namespace Bonyan.BNB.Domain.Entities;

[Serializable]
public abstract class BnbEntity : IBnbEntity
{
    protected BnbEntity()
    {
    }

    /// <inheritdoc/>
    public override string ToString()
    {
        return $"[ENTITY: {GetType().Name}] Keys = {string.Join(',',GetKeys())}";
    }

    public abstract object?[] GetKeys();

    public bool EntityEquals(IBnbEntity other)
    {
        return EntityHelper.EntityEquals(this, other);
    }
    
}

/// <inheritdoc cref="IEntity{TKey}" />
[Serializable]
public abstract class BnbEntity<TKey> : BnbEntity, IBnbEntity<TKey>
{
    /// <inheritdoc/>
    public virtual TKey Id { get; protected set; } = default!;

    protected BnbEntity()
    {
    }

    protected BnbEntity(TKey id)
    {
        Id = id;
    }

    public override object?[] GetKeys()
    {
        return new object?[] { Id };
    }

    /// <inheritdoc/>
    public override string ToString()
    {
        return $"[ENTITY: {GetType().Name}] Id = {Id}";
    }
}