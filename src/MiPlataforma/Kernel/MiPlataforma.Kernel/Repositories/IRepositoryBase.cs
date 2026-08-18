using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MiPlataforma.Kernel.Repositories;

public interface IRepositoryBase<T>
    where T : EntityBase
{
    ValueTask<T?> Get(int id);
    Task<PagedList<T>> GetAll(Expression<Func<T, bool>>? filter = null, Expression<Func<T, int>>? order = null, bool orderDescending = false, int page = 1, int count = int.MaxValue);
    Task Add(T item);
    Task Delete(int id);
    Task Update(T item, int id);
}
