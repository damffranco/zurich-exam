using Zurich.Insurance.Application.Interfaces;

namespace Zurich.Insurance.Infrastructure
{
    public sealed class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationContext _context;
        private bool _disposed;

        public UnitOfWork(ApplicationContext context) => this._context = context;

        public void Dispose() => this.Dispose(true);

        public async Task<int> Save()
        {
            int affectedRows = await this._context
                .SaveChangesAsync()
                .ConfigureAwait(false);
            return affectedRows;
        }

        private void Dispose(bool disposing)
        {
            if (!this._disposed && disposing)
            {
                this._context.Dispose();
            }

            this._disposed = true;
        }
    }
}