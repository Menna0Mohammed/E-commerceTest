using Application.Contracts;
using Domain.Models;
using Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositiries.Product
{
    public class GenaricRepository<TEntity, TId> : IGenaricRepository<TEntity, TId> where TEntity : BaseEntity<TId>
    {
        private readonly productDb Dbcontext;
        private readonly DbSet<TEntity> dbset;
        public GenaricRepository( productDb _dbcontext)
        {
            Dbcontext= _dbcontext;
            dbset = Dbcontext.Set<TEntity>();

        }
        public async Task<TEntity> Create(TEntity Entity)
        {
            var addPrd = dbset.Add(Entity);
            await Dbcontext.SaveChangesAsync();
            return addPrd.Entity;
        }

        public async Task<TEntity> Delete(TEntity Entity)
        {
            dbset.Remove(Entity);
            await Dbcontext.SaveChangesAsync();
            return Entity;
        }


        public Task<IQueryable<TEntity>> GetAll()
        {
            return Task.FromResult(dbset.Select(p => p));
        }

        public async ValueTask<TEntity> GetOne(TId id)
        {
            return await dbset.FindAsync(id);
        }

        public async Task<int> SaveChanges()
        {
            return await Dbcontext.SaveChangesAsync();
        }

        public async Task<TEntity> Update(TEntity updatedPrd)
        {
            dbset.Update(updatedPrd);
            await Dbcontext.SaveChangesAsync();
            return updatedPrd;
        }
    }
}
