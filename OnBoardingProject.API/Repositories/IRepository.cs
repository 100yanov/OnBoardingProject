using OnBoardingProject.Common.Models;

namespace OnBoardingProject.API.Repositories
{
    public interface IRepository<T> where T : BaseModel
    {
        IEnumerable<T> GetAll();

        T GetById(Guid id);

        Guid Add(T entity);

        void Update(T entity);

        void Delete(Guid id);

        void SaveChanges();
    }
}
