using DatabaseEditorForUser.Interfaces;
using DatabaseEditorForUser.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DatabaseEditorForUser.DAOs
{
    internal class FolderColorDAO : IDAO<FolderColor>
    {
        public void Add(FolderColor element)
        {
            if (HasDuplicate(element))
            {
                throw new Exception("Color must be unique.");
            }

            string query = "INSERT INTO FolderColor (ColorName) VALUES" +
                                "(@ColorName);";

            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@ColorName", element.Name);

                command.ExecuteNonQuery();
            }
        }

        public void Delete(int ID)
        {
            if (HasReferences(ID))
            {
                throw new InvalidOperationException("Can't delete Color with references in Folder table.");
            }

            string query = "DELETE FROM FolderColor WHERE ID = @ID;";

            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@ID", ID);

                command.ExecuteNonQuery();
            }
        }

        public void Edit(FolderColor element)
        {
            if (HasDuplicate(element))
            {
                throw new Exception("Duplicate color found. Please provide a unique color name.");
            }

            string query = "UPDATE FolderColor SET ColorName = @ColorName WHERE ID = @ID;";

            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@ID", element.ID);
                command.Parameters.AddWithValue("@ColorName", element.Name);

                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<FolderColor> GetAll()
        {
            string query = "SELECT * FROM FolderColor";

            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        FolderColor folderColor = new FolderColor(
                            reader.GetInt32(0),
                            reader.GetString(1)
                        );

                        yield return folderColor;
                    }
                }
            }
        }

        public FolderColor GetByID(int ID)
        {
            string query = "SELECT * FROM FolderColor WHERE ID = @ID";

            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@ID", ID);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();

                        return new FolderColor(
                            reader.GetInt32(0),
                            reader.GetString(1)
                        );
                    }
                    throw new Exception("No rows found in database.");
                }
            }
        }

        public bool HasDuplicate(FolderColor element)
        {
            string query = "SELECT ID FROM FolderColor WHERE ColorName = @ColorName";
            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@ColorName", element.Name);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        return element.ID != reader.GetInt32(0);
                    }

                    return false;
                }
            }
        }

        public bool HasReferences(int ID)
        {
            string query = "SELECT 1 FROM Folder WHERE ColorID = @ID";
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
