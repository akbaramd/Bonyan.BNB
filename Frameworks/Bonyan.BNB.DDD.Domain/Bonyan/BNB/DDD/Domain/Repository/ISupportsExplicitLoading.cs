﻿using System.Linq.Expressions;
using Bonyan.BNB.Domain.Entities;

namespace Bonyan.BNB.Domain.Repository;

public interface ISupportsExplicitLoading<TEntity>
    where TEntity : class, IBnbEntity
{
    Task EnsureCollectionLoadedAsync<TProperty>(
        TEntity entity,
        Expression<Func<TEntity, IEnumerable<TProperty>>> propertyExpression,
        CancellationToken cancellationToken)
        where TProperty : class;

    Task EnsurePropertyLoadedAsync<TProperty>(
        TEntity entity,
        Expression<Func<TEntity, TProperty?>> propertyExpression,
        CancellationToken cancellationToken)
        where TProperty : class;
}
