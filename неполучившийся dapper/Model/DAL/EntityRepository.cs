using Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAL
{
    public abstract class EntityRepository<T> : IRepository<T>
        where T : class, IDomainObject, new()
    {
        protected string _connectionString;
        private readonly List<T> _added = new List<T>();
        protected List<T> Added { get { return _added; } }

        private readonly List<T> _deleted = new List<T>();
        protected List<T> Deleted { get { return _deleted; } }

        public abstract IEnumerable<T> GetAll();
        public abstract string GetUpdateScript();

        public void Add(T entity)
        {
            if (_deleted.Contains(entity))
                _deleted.Remove(entity);
            else if (!_deleted.Contains(entity))
                _added.Add(entity);
        }

        public void Delete(T entity)
        {
            if (_added.Contains(entity))
                _added.Remove(entity);
            else if (!_deleted.Contains(entity))
                _deleted.Add(entity);
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        protected IEnumerable<int> DeletedIds
        {
            get {   return Deleted.Select(o => o.Id).Distinct(); }
        }

        public void Discard()
        {
            Added.Clear();
            Deleted.Clear();
        }

    }
}
