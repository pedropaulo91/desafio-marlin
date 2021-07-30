using DesafioMarlin.Domain.Entities;
using FluentValidation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioMarlin.Domain.Interfaces
{
    public interface IBaseService<TEntity> where TEntity : BaseEntity
    {
        Task Insert(TEntity obj);
        Task Update(TEntity obj); 
        Task<List<TEntity>> Get();
        Task Delete(TEntity obj);

    }
}
