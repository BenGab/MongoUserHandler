using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace UserHandler.Repository
{
    public interface IRepository<TEntitiy>  where TEntitiy : class 
    {
        ICollection<TEntitiy> GetAll();

        TEntitiy GetById(int id);

        ICollection<TEntitiy> GetBy(Expression<Func<TEntitiy, bool>> filter);

        TEntitiy Create(TEntitiy entitiy);

        ReplaceOneResult Update(TEntitiy entitiy);

        DeleteResult Remove(TEntitiy entiy);

        DeleteResult Remove(int id);
    }
}
