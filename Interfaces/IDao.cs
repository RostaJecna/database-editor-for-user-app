using System.Collections.Generic;

namespace DatabaseEditorForUser.Interfaces
{
    internal interface IDao<T> where T : IBaseClass
    {
        IEnumerable<T> GetAll();
        void Add(T element);
        void Edit(T element);
        void Delete(int id);
        T GetById(int id);
        bool HasReferences(int id);
        bool HasDuplicate(T element);
        void ImportAll(IEnumerable<T> rows);
        void ClearTable();
    }
}