namespace Bonyan.BNB.Auditing;

public interface IHasModificationTime
{
    /// <summary>The last modified time for this entity.</summary>
    DateTime? LastModificationTime { get; }
}