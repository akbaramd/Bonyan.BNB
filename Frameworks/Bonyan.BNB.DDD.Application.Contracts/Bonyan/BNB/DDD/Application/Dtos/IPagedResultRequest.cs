namespace Bonyan.BNB.DDD.Application.Dtos;

public interface IPagedResultRequest : ILimitedResultRequest
{
    /// <summary>
    /// Skip count (beginning of the page).
    /// </summary>
    int Skip { get; set; }
}