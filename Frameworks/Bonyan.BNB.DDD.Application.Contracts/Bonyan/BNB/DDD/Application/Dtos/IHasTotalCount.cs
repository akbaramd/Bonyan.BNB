namespace Bonyan.BNB.DDD.Application.Dtos;

public interface IHasTotalCount
{
    /// <summary>
    /// Total count of Items.
    /// </summary>
    long TotalCount { get; set; }
}