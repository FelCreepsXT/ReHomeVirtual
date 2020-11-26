using System.Threading.Tasks;

namespace ReHomeVirtualBackEnd.General.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
