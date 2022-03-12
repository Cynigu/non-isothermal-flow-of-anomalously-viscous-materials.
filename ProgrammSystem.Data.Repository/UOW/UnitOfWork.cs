using ProgramSystem.Data.Repository.Interfaces;
using ProgramSystem.Data.Repository.Repositories;

namespace ProgramSystem.Data.Repository.UOW
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        protected readonly RepositoryContext _repositoryContext;
        public UnitOfWork(RepositoryContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            _repositoryContext = context;
            CanalRepository = new CanalRepository(_repositoryContext);
            MaterialRepository = new MaterialRepository(_repositoryContext);
            ParameterCanalMaterialRepository = new ParameterCanalMaterialRepository(_repositoryContext);
            ParameterRepository = new ParameterRepository(_repositoryContext);
            UnitOfMeasRepository = new UnitOfMeasRepository(_repositoryContext);
            UserRepository = new UserRepository(_repositoryContext);
        }

        public ICanalRepository CanalRepository { get; }
        public IMaterialRepository MaterialRepository { get; }
        public IParameterCanalMaterialRepository ParameterCanalMaterialRepository { get; }
        public IParameterRepository ParameterRepository { get; }
        public IUnitOfMeasRepository UnitOfMeasRepository { get; }
        public IUserRepository UserRepository { get; }

        private bool disposed = false;
        public void Save()
        {
            _repositoryContext.SaveChanges();
        }
        public async Task SaveAsync()
        {
            await _repositoryContext.SaveChangesAsync();
        }
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _repositoryContext.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
