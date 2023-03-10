using DatabaseEditorForUser.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseEditorForUser.Entities
{
    internal class Folder : IBaseClass
    {
        private int id;
        private string name;
        private int colorID;
        private bool isShared;
        private DateTime createdAt;

        public Folder(int id, string name, int colorID, bool isShared, DateTime createdAt)
        {
            ID = id;
            Name = name;
            ColorID = colorID;
            IsShared = isShared;
            CreatedAt = createdAt;
        }

        public Folder(string name, int colorID, bool isShared)
        {
            Name = name;
            ColorID = colorID;
            IsShared = isShared;
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
                if(value is null)
                {
                    throw new ArgumentException("Name can't be null.");
                }
                name = value;
            }
        }

        public int ColorID
        {
            get { return colorID; }
            set { colorID = value; }
        }

        public bool IsShared
        {
            get { return isShared; }
            set { isShared = value; }
        }

        public DateTime CreatedAt
        {
            get { return createdAt; }
            set { createdAt = value; }
        }

        public override string ToString()
        {
            if(ID == default)
            {
                return $"{Name}, {ColorID}, {IsShared}";
            }
            return $"{ID}: {Name}, {ColorID}, {IsShared}";
        }
    }
}
