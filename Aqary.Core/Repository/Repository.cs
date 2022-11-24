using Aqary.Core.Repository.Interface;
using Aqary.DataAccessLayer.Models;
using Aqary.DataAccessLayer.Models.Interface;
using AutoMapper;
using examBaraaDb.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Aqary.Core.Repository
{
    public class Repository<T, TCreateRequestDTO, TUpdateRequestDTO, TResponseDTO>
        : IRepository<T, TCreateRequestDTO, TUpdateRequestDTO, TResponseDTO>
        where T : class, IBaseEntity, new()
    {

        private readonly AqaryDataBaseContext _context;
        private readonly IMapper _map;

        public Repository(AqaryDataBaseContext context, IMapper mapper)
        {
            _context = context;
            _map = mapper;
        }
         
        public virtual async Task<TResponseDTO> CeateAsync(TCreateRequestDTO entity)
        {
            var currentT = _map.Map<T>(entity);
            await _context.Set<T>().AddAsync(currentT);
            await _context.SaveChangesAsync();
            return _map.Map<TResponseDTO>(currentT);
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await _context.Set<T>().SingleOrDefaultAsync(t => t.Id == id)
                ??
            throw new ServiceValidationException("Un Defind");
            entity.DeletedAt = DateTime.Now;
            EntityEntry entityEntry = _context.Entry<T>(
               entity
                );
            entityEntry.State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<TResponseDTO>> GetAllAsync()
        => _map.Map<List<TResponseDTO>>(
           await _context.Set<T>().ToListAsync()
            );

        public virtual async Task<IEnumerable<TResponseDTO>> GetAllAsync(params Expression<Func<T, TResponseDTO>>[] expressions)
        {
            
            IQueryable<T> queryable = _context.Set<T>();
            
            queryable = expressions.
                Aggregate(queryable, (current, include) =>
                current.Include(include));

            return _map.Map<List<TResponseDTO>>
                (await queryable.ToListAsync());
        }

        public virtual async Task<TResponseDTO> GetbyIdAsync(int id)
        => _map.Map<TResponseDTO>(
            await _context.Set<T>().SingleOrDefaultAsync(
                t => t.Id == id
                ) ??
            throw new ServiceValidationException("Un Defind")
            );

        public virtual async Task<TResponseDTO> GetbyIdAsync(int id, params Expression<Func<T, TResponseDTO>>[] expressions)
        {
            IQueryable<T> queryable = _context.Set<T>();

            queryable = expressions.
                Aggregate(queryable, (current, include) =>
                current.Include(include));
            return _map.Map<TResponseDTO>(
                await queryable.SingleOrDefaultAsync(
                    t=> t.Id == id) ??
            throw new ServiceValidationException("Un Defind")
                );
        }

        public virtual async Task<TResponseDTO> UpdateAsync(int id, TUpdateRequestDTO entity)
        {
            
            T currentEntity = _map.Map<T>(entity);
            EntityEntry entityEntry = _context.
                                               Entry<T>(currentEntity);

            entityEntry.State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return _map.Map<TResponseDTO>(currentEntity);
        }
    }
}
