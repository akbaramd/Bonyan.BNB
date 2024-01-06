using Bonyan.BNB.DDD.Application.Dtos;
using Bonyan.Bnb.Statics;
using JetBrains.Annotations;

namespace System.Linq;

public static class PagingQueryableExtensions
{
    public static IQueryable<T> PageBy<T>([NotNull] this IQueryable<T> query, IPagedResultRequest pagedResultRequest)
    {
        BnbCheck.NotNull(query, nameof(query));

        return query.PageBy(pagedResultRequest.Skip, pagedResultRequest.Take);
    }
}