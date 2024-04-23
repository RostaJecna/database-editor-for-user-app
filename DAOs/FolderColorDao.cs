using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DatabaseEditorForUser.Entities;
using DatabaseEditorForUser.Interfaces;

namespace DatabaseEditorForUser.DAOs
{
    internal class FolderColorDao : IDao<FolderColor>
    {
        public void Add(FolderColor element)
        {
            if (HasDuplicate(element)) throw new Exception("Color must be unique.");

            const string query = "INSERT INTO FolderColor (ColorName) VALUES" +
                                 "(@ColorName);";

            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@ColorName", element.Name);

                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            if (HasReferences(id))
                throw new InvalidOperationException("Can't delete Color with references in Folder table.");

            const string query = "DELETE FROM FolderColor WHERE ID = @ID;";

            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@ID", id);

                command.ExecuteNonQuery();
            }
        }

        public void Edit(FolderColor element)
        {
            if (HasDuplicate(element))
                throw new Exception("Duplicate color found. Please provide a unique color name.");

            const string query = "UPDATE FolderColor SET ColorName = @ColorName WHERE ID = @ID;";

            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@ID", element.Id);
                command.Parameters.AddWithValue("@ColorName", element.Name);

                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<FolderColor> GetAll()
        {
            const string query = "SELECT * FROM FolderColor";

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

        public FolderColor GetById(int id)
        {
            const string query = "SELECT * FROM FolderColor WHERE ID = @ID";

            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@ID", id);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (!reader.HasRows) throw new Exception("No rows found in database.");
                    reader.Read();

                    return new FolderColor(
                        reader.GetInt32(0),
                        reader.GetString(1)
                    );

                }
            }
        }

        public bool HasDuplicate(FolderColor element)
        {
            const string query = "SELECT 1 FROM FolderColor WHERE ColorName = @ColorName";
            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@ColorName", element.Name);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    return reader.HasRows;
                }
            }
        }

        public bool HasReferences(int id)
        {
            const string query = "SELECT 1 FROM Folder WHERE ColorID = @ID";
            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@ID", id);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    return reader.HasRows;
                }
            }
        }

        public static int GetIdByName(string name)
        {
            const string query = "SELECT ID FROM FolderColor WHERE ColorName = @ColorName";
            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@ColorName", name);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (!reader.HasRows)
                        throw new ArgumentException("Failed to get color ID in the database.", nameof(name));
                    reader.Read();
                    return reader.GetInt32(0);

                }
            }
        }

        public void ImportAll(IEnumerable<FolderColor> rows)
        {
            string query = "SET IDENTITY_INSERT FolderColor ON;";
            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.ExecuteNonQuery();
            }

            query = "INSERT INTO FolderColor (ID, ColorName) VALUES" +
                    "(@ID, @ColorName);";

            foreach (FolderColor element in rows)
                using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
                {
                    command.Parameters.AddWithValue("@ID", element.Id);
                    command.Parameters.AddWithValue("@ColorName", element.Name);

                    command.ExecuteNonQuery();
                }

            query = "SET IDENTITY_INSERT FolderColor OFF;";
            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.ExecuteNonQuery();
            }
        }

        public void ClearTable()
        {
            const string query = "DELETE FROM FolderColor;";
            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.ExecuteNonQuery();
            }
        }
    }
}