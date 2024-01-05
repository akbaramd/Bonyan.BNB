namespace Bonyan.BNB.DDD.Application.Dtos;

public interface IEntityDto
{

}

public interface IEntityDto<TKey> : IEntityDto
{
    TKey Id { get; set; }
}
