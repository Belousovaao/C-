using Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAL
{
    public class FakeRepository<T> : IRepository<T>
        where T : IDomainObject, new()
    {
        private List<T> _data = new List<T>() { new T() };

        public void Add(T entity)
        {
            _data.Add(entity);
        }

        public void Delete(T entity)
        {
            _data.Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _data;
        }

        public void Update(IList<T> values)
        {
            foreach (T value in values)
            {
                foreach (var item in _data)
                {
                    if (item.Id == value.Id)
                    {
                        _data.Remove(item);
                        break;
                    }
                }
                _data.Add(value);
            }            
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

    }
}
