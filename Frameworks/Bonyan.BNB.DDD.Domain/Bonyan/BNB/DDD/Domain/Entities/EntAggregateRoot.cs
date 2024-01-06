using Bonyan.BNB.Auditing;

namespace Bonyan.BNB.DDD.Domain.Entities;

[Serializable]
public abstract class AggregateRoot : BasicAggregateRoot,
    IHasConcurrencyStamp
{
     // public virtual BnbExtraPropertyDictionary ExtraProperties { get; protected set; }

    [DisableAuditing]
    public virtual string ConcurrencyStamp { get; set; }

    protected AggregateRoot()
    {
        ConcurrencyStamp = Guid.NewGuid().ToString("N");
        // EntExtraProperties = new EntExtraPropertyDictionary();
        // this.SetDefaultsForExtraProperties();
    }

    // public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    // {
    //     return ExtensibleObjectValidator.GetValidationErrors(
    //         this,
    //         validationContext
    //     );
    // }
}

[Serializable]
public abstract class AggregateRoot<TKey> : BasicAggregateRoot<TKey>,
     // IHasExtraProperties,
    IHasConcurrencyStamp
{
    // public virtual BnbExtraPropertyDictionary ExtraProperties { get; protected set; }

    [DisableAuditing]
    public virtual string ConcurrencyStamp { get; set; }

    protected AggregateRoot()
    {
        ConcurrencyStamp = Guid.NewGuid().ToString("N");
         // ExtraProperties = new BnbExtraPropertyDictionary();
         //this.SetDefaultsForExtraProperties();
    }

    protected AggregateRoot(TKey id)
        : base(id)
    {
        ConcurrencyStamp = Guid.NewGuid().ToString("N");
         // ExtraProperties = new BnbExtraPropertyDictionary();
         //this.SetDefaultsForExtraProperties();
    }

    // public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    // {
        // return ExtensibleObjectValidator.GetValidationErrors(
            // this,
            // validationContext
        // );
    // }
}
