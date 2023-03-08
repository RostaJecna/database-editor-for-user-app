using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseEditorForUser.Interfaces
{
    internal interface IDAO<T> where T : IBaseClass
    {
        IEnumerable<T> GetAll();
        void Add(T element);
        void Edit(T element);
        void Delete(int ID);
        T GetByID(int ID);
        bool HasReferences(int ID);
        bool HasDuplicate(T element);
    }
}
