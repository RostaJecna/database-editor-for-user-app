using DatabaseEditorForUser.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseEditorForUser.Entities
{
    internal class AttachmentType : IBaseClass
    {
        private int id;
        private string typeName;

        public AttachmentType(int id, string typeName)
        {
            ID = id;
            TypeName = typeName;
        }

        public AttachmentType(string typeName)
        {
            TypeName = typeName;
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string TypeName
        {
            get { return typeName; }
            set { typeName = value; }
        }

        public override string ToString()
        {
            if(ID == default)
            {
                return $"{TypeName}";
            }

            return $"{ID}: {TypeName}";
        }
    }
}
