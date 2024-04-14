using ChatbotNinja.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
 


namespace ChatbotNinja.DataAccess.Repositories;

public class BaseRepository<T, TKey> : IBaseRepository<T, TKey> where T : class
{
    #region CONSTRUCTOR
    private readonly ApplicationDbContext _contexto;
    protected BaseRepository(ApplicationDbContext contexto)
    {
        _contexto = contexto;
    }
    #endregion



    #region GET
    public T GetById(TKey id)
    {
        return _contexto.Set<T>().Find(id);
    }
    public List<T> List()
    {
        return _contexto.Set<T>().ToList();
    }
    #endregion

    #region SET
    public void Create(T entity)
    {
        _contexto.Set<T>().Add(entity);
        _contexto.SaveChanges();

    }
    public void CreateRange(IEnumerable<T> entities)
    {
        _contexto.Set<T>().AddRange(entities);
        _contexto.SaveChanges();
    }
    public T CreateReturn(T entity)
    {
        _contexto.Set<T>().Add(entity);
        _contexto.SaveChanges();
        return entity;
    }

    public void Update(T entity)
    {
        _contexto.Set<T>().Update(entity);
        _contexto.SaveChanges();
    }
    public void UpdateRange(IEnumerable<T> entities)
    {
        _contexto.Set<T>().UpdateRange(entities);
        _contexto.SaveChanges();
    }

    public void Delete(TKey id)
    {
        var item = _contexto.Set<T>().Find(id); ;
        Delete(item);
    }
    public void Delete(T entity)
    {
        _contexto.Set<T>().Remove(entity);
        _contexto.SaveChanges();
    }
    public void DeleteRange(IEnumerable<T> entities)
    {
        _contexto.Set<T>().RemoveRange(entities);
        _contexto.SaveChanges();
    }

    #endregion
}