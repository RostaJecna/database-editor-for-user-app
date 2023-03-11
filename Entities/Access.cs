using DatabaseEditorForUser.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseEditorForUser.Entities
{
    internal class Access : IBaseClass
    {
        private int id;
        private int accountID;
        private int folderID;

        public Access(int id, int accountID, int folderID)
        {
            ID = id;
            AccountID = accountID;
            FolderID = folderID;
        }

        public Access(int accountID, int folderID)
        {
            AccountID = accountID;
            FolderID = folderID;
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public int AccountID
        {
            get { return accountID; }
            set { accountID = value; }
        }

        public int FolderID
        {
            set { folderID = value; }
            get { return folderID; }
        }

        public override string ToString()
        {
            if(ID == default)
            {
                return $"{AccountID}, {FolderID}";
            }

            return $"{ID}: {AccountID}, {FolderID}";
        }
    }
}
