using Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAL
{
    public interface IRepository<T> where T : IDomainObject, new()
    {
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Delete(T entity);
    }
}
