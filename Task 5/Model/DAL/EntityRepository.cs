using Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAL
{
    public class EntityRepository<T> : IRepository<T>
        where T : class, IDomainObject, new()
    {
        private readonly DataContext _data = new DataContext();

        public void Add(T entity)
        {
            _data.Add(entity);
            _data.SaveChanges();
        }

        public void Delete(T entity)
        {
            _data.Remove(entity);
            _data.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return _data.Set<T>().ToList();
        }

        public void Update(IList<T> values)
        {
            foreach (T value in values)
            {
                foreach (var item in (IEnumerable<T>)_data)
                {
                    if (item.Id == value.Id)
                    {
                        _data.Remove(item);
                        break;
                    }
                }
                _data.Add(value);
                _data.SaveChanges();
            }            
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

    }
}
