﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public interface IDomainObject
    {
        int Id { get; }
    }

    public class Employee : IDomainObject
    {
        public int Id { get; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
