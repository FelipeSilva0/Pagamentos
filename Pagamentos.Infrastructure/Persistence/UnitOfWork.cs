using Microsoft.EntityFrameworkCore.Storage;
using Pagamentos.Core.Repositories;
using System;
using System.Threading.Tasks;

namespace Pagamentos.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbContextTransaction _transaction;
        private readonly PagamentosDbContext _context;
        public UnitOfWork(
            PagamentosDbContext context,
            IPrestadorRepository prestadores,
            IUsuarioRepository usuarios,
            IServicoRepository servicos)
        {
            _context = context;
            Prestadores = prestadores;
            Usuarios = usuarios;
            Servicos = servicos;
        }

        public IPrestadorRepository Prestadores { get; }
        public IUsuarioRepository Usuarios { get; }
        public IServicoRepository Servicos { get; }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            try
            {
                await _transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await _transaction.RollbackAsync();
                throw ex;
            }
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
