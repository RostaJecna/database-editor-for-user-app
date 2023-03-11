using DatabaseEditorForUser.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseEditorForUser.Entities
{
    internal class FolderColor : IBaseClass
    {
        private int id;
        private string name;

        public FolderColor(int id, string name)
        {
            ID = id;
            Name = name;
        }

        public FolderColor(string name)
        {
            Name = name;
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set
            {
                if(value is null) {
                    throw new ArgumentException("Name can't be null.");
                }
                name = value;
            }
        }

        public override string ToString()
        {
            if (ID == default)
            {
                return $"{Name}";
            }
            return $"{ID}, {Name}";
        }
    }
}
