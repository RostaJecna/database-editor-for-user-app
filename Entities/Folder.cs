using System;
using DatabaseEditorForUser.Interfaces;

namespace DatabaseEditorForUser.Entities
{
    internal class Folder : IBaseClass
    {
        private string name;

        public Folder(int id, string name, int colorId, bool isShared, DateTime createdAt)
        {
            Id = id;
            Name = name;
            ColorId = colorId;
            IsShared = isShared;
            CreatedAt = createdAt;
        }

        public Folder(string name, int colorId, bool isShared)
        {
            Name = name;
            ColorId = colorId;
            IsShared = isShared;
        }

        public int Id { get; set; }

        public string Name
        {
            get => name;
            private set => name = value ?? throw new ArgumentException("Name can't be null.");
        }

        public int ColorId { get; set; }

        public bool IsShared { get; set; }

        public DateTime CreatedAt { get; set; }

        public override string ToString()
        {
            return Id == default ? $"{Name}, {ColorId}, {IsShared}" : $"{Id}: {Name}, {ColorId}, {IsShared}";
        }
    }
}