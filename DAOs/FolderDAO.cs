using DatabaseEditorForUser.Entities;
using DatabaseEditorForUser.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseEditorForUser.DAOs
{
    internal class FolderDAO : IDAO<Folder>
    {
        public void Add(Folder element)
        {
            string query = "INSERT INTO Folder (FolderName, ColorID, IsShared) VALUES" +
                                "(@FolderName, @ColorID, @IsShared);";

            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@FolderName", element.Name);
                command.Parameters.AddWithValue("@ColorID", element.ColorID);
                command.Parameters.AddWithValue("@IsShared", element.IsShared ? 1 : 0);

                command.ExecuteNonQuery();
            }
        }

        public void Delete(int ID)
        {
            if (HasReferences(ID))
            {
                throw new InvalidOperationException("Can't delete Folder with references in Access or Attachment table.");
            }

            string query = "DELETE FROM Folder WHERE ID = @ID;";

            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@ID", ID);

                command.ExecuteNonQuery();
            }
        }

        public void Edit(Folder element)
        {
            string query = "UPDATE Folder SET FolderName = @FolderName, " +
                                              "ColorID = @ColorID," +
                                              "IsShared = @IsShared" +
                                          " WHERE ID = @ID;";

            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@ID", element.ID);
                command.Parameters.AddWithValue("@FolderName", element.Name);
                command.Parameters.AddWithValue("@ColorID", element.ColorID);
                command.Parameters.AddWithValue("@IsShared", element.IsShared ? 1 : 0);

                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<Folder> GetAll()
        {
            string query = "SELECT * FROM Folder";

            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Folder folder = new Folder(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetInt32(2),
                            reader.GetBoolean(3),
                            reader.GetDateTime(4)
                        );

                        yield return folder;
                    }
                }
            }
        }

        public Folder GetByID(int ID)
        {
            string query = "SELECT * FROM Folder WHERE ID = @ID";

            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@ID", ID);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();

                        return new Folder(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetInt32(2),
                            reader.GetBoolean(3),
                            reader.GetDateTime(4)
                        );
                    }
                    throw new Exception("No rows found in database.");
                }
            }
        }

        public bool HasDuplicate(Folder element)
        {
            throw new NotImplementedException();
        }

        public bool HasReferences(int ID)
        {
            string query = "SELECT 1 FROM Access WHERE FolderID = @ID";
            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@ID", ID);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if(reader.HasRows)
                    {
                        return true;
                    }
                    
                }
            }

            query = "SELECT 1 FROM Attachment WHERE FolderID = @ID";
            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@ID", ID);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    return reader.HasRows;
                }
            }
        }

        public static bool Exist(int ID)
        {
            string query = "SELECT 1 FROM Folder WHERE ID = @ID";

            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@ID", ID);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    return reader.HasRows;
                }
            }
        }
    }
}
