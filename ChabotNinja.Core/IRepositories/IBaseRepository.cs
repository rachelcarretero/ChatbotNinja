using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ChatbotNinja.Core;
 
public interface IBaseRepository<TEntity, TKey>  where TEntity : class
{
    TEntity GetById(TKey id);
    List<TEntity> List();
    void Create(TEntity entity);
    TEntity CreateReturn(TEntity entity);
    void CreateRange(IEnumerable<TEntity> entities);
    void Update(TEntity entity);
    void UpdateRange(IEnumerable<TEntity> entities);
    void Delete(TKey id);
    void Delete(TEntity entity);
    void DeleteRange(IEnumerable<TEntity> entities);

}

