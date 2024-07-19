/// <summary>Unit Of Work Interface</summary>
namespace HospitalManagement.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<T> GenericRepository<T>() where T : class;
        void Save();
    }
}
