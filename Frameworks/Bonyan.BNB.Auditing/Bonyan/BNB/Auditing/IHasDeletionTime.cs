using Bonyan.Bnb;

namespace Bonyan.BNB.Auditing;
public interface IHasDeletionTime : IBnbSoftDelete
{
    /// <summary>Deletion time.</summary>
    DateTime? DeletionTime { get; }
}