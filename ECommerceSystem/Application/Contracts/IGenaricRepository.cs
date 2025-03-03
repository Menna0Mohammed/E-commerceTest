using Application.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IGenaricRepository <TEntity , TId> 
    {

        public Task< TEntity> Create(TEntity Entity);
        public Task<TEntity> Update(TEntity Entity);

        public Task<TEntity> Delete(TEntity Entity);
        public Task<IQueryable<TEntity>> GetAll();

        public ValueTask<TEntity> GetOne(TId id);
        public Task<int> SaveChanges();

    }
}
