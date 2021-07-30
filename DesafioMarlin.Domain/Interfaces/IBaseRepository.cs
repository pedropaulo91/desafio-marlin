using DesafioMarlin.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioMarlin.Domain.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity: BaseEntity
    {
        Task Update(TEntity obj);
        Task Insert(TEntity obj);
        Task Delete(TEntity obj);
        Task<List<TEntity>> Get();

    }
}
