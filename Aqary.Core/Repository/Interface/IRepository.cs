using Aqary.DataAccessLayer.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Aqary.Core.Repository.Interface
{
    public interface IRepository<T, TCreateRequestDTO, TUpdateRequestDTO, TResponseDTO> where T : class, IBaseEntity, new()
    {
        Task<TResponseDTO> GetbyIdAsync(int id);
        Task<TResponseDTO> GetbyIdAsync(int id, params Expression<Func<T, TResponseDTO>>[] expressions);
        Task<IEnumerable<TResponseDTO>> GetAllAsync();
        Task<IEnumerable<TResponseDTO>> GetAllAsync(params Expression<Func<T, TResponseDTO>>[] expressions);
        Task<TResponseDTO> CeateAsync(TCreateRequestDTO entity);
        Task<TResponseDTO> UpdateAsync(int id, TUpdateRequestDTO entity);
        Task DeleteAsync(int id);
    }
}

//  x=> x.Id  lambda
