using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class Employee
    {
        public int Id { set; get; }
        public string Name { set; get; }

        public Employee(int id, string name) {
            this.Id = id;
            this.Name = name;
        }
    }
}
