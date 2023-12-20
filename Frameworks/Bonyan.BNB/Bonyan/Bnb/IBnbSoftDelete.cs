namespace Bonyan.Bnb;

public interface IBnbSoftDelete
{
    /// <summary>
    /// Used to mark an Bnbity as 'Deleted'.
    /// </summary>
    bool IsDeleted { get; }
}
