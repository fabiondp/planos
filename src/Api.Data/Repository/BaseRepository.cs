using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly MyContext _context;
        private DbSet<T> _dataSet;
        public BaseRepository(MyContext context)
        {
            _context = context;
            _dataSet = context.Set<T>(); // para não precisar ficar pesquisando abaixo
        }

        public async Task<bool> ExistAsync(Guid id){
            return await _dataSet.AnyAsync(p=> p.Uid.Equals(id));
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
           try
           {
               var result = await _dataSet.SingleOrDefaultAsync(p=> p.Uid.Equals(id));
               if(result == null) return false;

               _dataSet.Remove(result);
               await _context.SaveChangesAsync();
               return true;
           }
           catch (Exception ex)
           {
               
               throw ex;
           }
        }

        public async Task<T> InsertAsync(T item)
        {
            try{
                if(item.Uid == Guid.Empty)
                    item.Uid = Guid.NewGuid();
                
                item.DataCriacao = DateTime.UtcNow;
                item.DataAlteracao = DateTime.UtcNow;

                _dataSet.Add(item);
                
                await _context.SaveChangesAsync();

            } catch(Exception ex){
                throw ex;
            }

            return item;
        }

        public async Task<T> SelectAsync(Guid id)
        {
            try
            {
                return await _dataSet.SingleOrDefaultAsync(p=> p.Uid.Equals(id));
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public async Task<IEnumerable<T>> SelectAsync()
        {
            try
            {
                return await _dataSet.ToListAsync();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public async Task<T> UpdateAsync(T item)
        {
            try
            {
                var result = await _dataSet.SingleOrDefaultAsync(p=> p.Uid.Equals(item.Uid));
                
                if(result == null) return null;

                item.DataAlteracao = DateTime.UtcNow;
                item.DataCriacao = result.DataCriacao; // sempre vai permanecer a que foi criado, caso o usuario tente mandar

                _context.Entry(result).CurrentValues.SetValues(item);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }

            return item;
        }
    }
}