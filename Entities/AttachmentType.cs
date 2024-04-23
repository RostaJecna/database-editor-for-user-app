using DatabaseEditorForUser.Interfaces;

namespace DatabaseEditorForUser.Entities
{
    internal class AttachmentType : IBaseClass
    {
        public AttachmentType(int id, string typeName)
        {
            Id = id;
            TypeName = typeName;
        }

        public AttachmentType(string typeName)
        {
            TypeName = typeName;
        }

        public int Id { get; set; }

        public string TypeName { get; set; }

        public override string ToString()
        {
            return Id == default ? $"{TypeName}" : $"{Id}: {TypeName}";
        }
    }
}