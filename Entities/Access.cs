using DatabaseEditorForUser.Interfaces;

namespace DatabaseEditorForUser.Entities
{
    internal class Access : IBaseClass
    {
        public Access(int id, int accountId, int folderId)
        {
            Id = id;
            AccountId = accountId;
            FolderId = folderId;
        }

        public Access(int accountId, int folderId)
        {
            AccountId = accountId;
            FolderId = folderId;
        }

        public int Id { get; set; }

        public int AccountId { get; set; }

        public int FolderId { set; get; }

        public override string ToString()
        {
            return Id == default ? $"{AccountId}, {FolderId}" : $"{Id}: {AccountId}, {FolderId}";
        }
    }
}