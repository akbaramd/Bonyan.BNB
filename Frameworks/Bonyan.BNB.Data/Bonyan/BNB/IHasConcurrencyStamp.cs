namespace Bonyan.BNB;

public interface IHasConcurrencyStamp
{
    string ConcurrencyStamp { get; set; }
}