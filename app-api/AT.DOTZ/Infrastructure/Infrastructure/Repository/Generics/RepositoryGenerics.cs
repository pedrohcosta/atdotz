using Domain.Interfaces.Generics;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Generics
{
    public class RepositoryGenerics<T> : IGeneric<T>, IDisposable where T : class
    {

        protected readonly ContextBase _context;

        public RepositoryGenerics(ContextBase context)
        {
            _context = context;
        }

        public async Task Add(T Objeto)
        {
            await _context.Set<T>().AddAsync(Objeto);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(T Objeto)
        {
            
            _context.Set<T>().Remove(Objeto);
            await _context.SaveChangesAsync();
        }

        public async Task<T> GetEntityById(Guid Id)
        {
            return await _context.Set<T>().FindAsync(Id);
        }

       
        public async Task<List<T>> List()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task Update(T Objeto)
        {
            _context.Entry(Objeto).State = EntityState.Modified;
           // _context.Set<T>().Update(Objeto);
            await _context.SaveChangesAsync();
        }


        #region Disposed https://docs.microsoft.com/pt-br/dotnet/standard/garbage-collection/implementing-dispose
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);



        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                // Free any other managed objects here.
                //
            }

            disposed = true;
        }

       
        #endregion

    }
}
