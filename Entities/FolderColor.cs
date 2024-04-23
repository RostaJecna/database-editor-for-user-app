using System;
using DatabaseEditorForUser.Interfaces;

namespace DatabaseEditorForUser.Entities
{
    internal class FolderColor : IBaseClass
    {
        private string name;

        public FolderColor(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public FolderColor(string name)
        {
            Name = name;
        }

        public int Id { get; set; }

        public string Name
        {
            get => name;
            private set => name = value ?? throw new ArgumentException("Name can't be null.");
        }

        public override string ToString()
        {
            return Id == default ? $"{Name}" : $"{Id}, {Name}";
        }
    }
}