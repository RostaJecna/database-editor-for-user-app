using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DatabaseEditorForUser.Entities;
using DatabaseEditorForUser.Interfaces;

namespace DatabaseEditorForUser.DAOs
{
    internal class AttachmentTypeDao : IDao<AttachmentType>
    {
        public void Add(AttachmentType element)
        {
            if (HasDuplicate(element)) throw new Exception("Type must be unique.");

            const string query = "INSERT INTO AttachmentType (TypeName) VALUES" +
                                 "(@TypeName);";

            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@TypeName", element.TypeName);

                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            if (HasReferences(id))
                throw new InvalidOperationException("Can't delete Type with references in Attachment table.");

            const string query = "DELETE FROM AttachmentType WHERE ID = @ID;";

            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@ID", id);

                command.ExecuteNonQuery();
            }
        }

        public void Edit(AttachmentType element)
        {
            if (HasDuplicate(element)) throw new Exception("Duplicate type found. Please provide a unique type name.");

            const string query = "UPDATE AttachmentType SET TypeName = @TypeName WHERE ID = @ID;";

            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@ID", element.Id);
                command.Parameters.AddWithValue("@TypeName", element.TypeName);

                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<AttachmentType> GetAll()
        {
            const string query = "SELECT * FROM AttachmentType";

            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        AttachmentType attachmentType = new AttachmentType(
                            reader.GetInt32(0),
                            reader.GetString(1)
                        );

                        yield return attachmentType;
                    }
                }
            }
        }

        public AttachmentType GetById(int id)
        {
            const string query = "SELECT * FROM AttachmentType WHERE ID = @ID";

            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@ID", id);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (!reader.HasRows) throw new Exception("No rows found in database.");
                    reader.Read();

                    return new AttachmentType(
                        reader.GetInt32(0),
                        reader.GetString(1)
                    );

                }
            }
        }

        public bool HasDuplicate(AttachmentType element)
        {
            const string query = "SELECT 1 FROM AttachmentType WHERE TypeName = @TypeName";
            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@TypeName", element.TypeName);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    return reader.HasRows;
                }
            }
        }

        public bool HasReferences(int id)
        {
            const string query = "SELECT 1 FROM Attachment WHERE TypeID = @ID";
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
            const string query = "SELECT ID FROM AttachmentType WHERE TypeName = @TypeName";
            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@TypeName", name);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (!reader.HasRows)
                        throw new ArgumentException("Failed to get type ID in the database.", nameof(name));
                    reader.Read();
                    return reader.GetInt32(0);

                }
            }
        }

        public void ImportAll(IEnumerable<AttachmentType> rows)
        {
            string query = "SET IDENTITY_INSERT AttachmentType ON;";
            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.ExecuteNonQuery();
            }

            query = "INSERT INTO AttachmentType (ID, TypeName) VALUES" +
                    "(@ID, @TypeName);";

            foreach (AttachmentType element in rows)
                using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
                {
                    command.Parameters.AddWithValue("@ID", element.Id);
                    command.Parameters.AddWithValue("@TypeName", element.TypeName);

                    command.ExecuteNonQuery();
                }

            query = "SET IDENTITY_INSERT AttachmentType OFF;";
            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.ExecuteNonQuery();
            }
        }

        public void ClearTable()
        {
            const string query = "DELETE FROM AttachmentType;";
            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.ExecuteNonQuery();
            }
        }
    }
}