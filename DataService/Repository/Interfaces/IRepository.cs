using Models.Model.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Repository.Interfaces
{
    public interface IRepository<T> where T :class
    {
        T Get(int id);
        void Add(T item);
        ICollection<T> GetList();
        void Update(T item);
        void Remove(int id);
    }
}
