using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public interface IDomainObject
    {
        int Id { get; set; }
    }

    public abstract class NewId : IDomainObject
    {
        private static int nextNumber = 1;

        public int Id { get; set; }

        public NewId() => Id = nextNumber++;
    }

    public class Employee : NewId
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
