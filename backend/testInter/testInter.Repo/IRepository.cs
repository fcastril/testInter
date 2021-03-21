using System.Collections.Generic;
using testInter.Data;

namespace testInter.Repo
{
    public interface IRepository<T> where T: BaseEntity
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Insert(T reg);
        void Update(T reg);
        void Delete(T reg);
        void Remove(T reg);
        void SaveChanges();
    }
}
