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
    internal class AttachmentTypeDAO : IDAO<AttachmentType>
    {
        public void Add(AttachmentType element)
        {
            if (HasDuplicate(element))
            {
                throw new Exception("Type must be unique.");
            }

            string query = "INSERT INTO AttachmentType (TypeName) VALUES" +
                                "(@TypeName);";

            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@TypeName", element.TypeName);

                command.ExecuteNonQuery();
            }
        }

        public void Delete(int ID)
        {
            if (HasReferences(ID))
            {
                throw new InvalidOperationException("Can't delete Type with references in Attachment table.");
            }

            string query = "DELETE FROM AttachmentType WHERE ID = @ID;";

            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@ID", ID);

                command.ExecuteNonQuery();
            }
        }

        public void Edit(AttachmentType element)
        {
            if (HasDuplicate(element))
            {
                throw new Exception("Duplicate type found. Please provide a unique type name.");
            }

            string query = "UPDATE AttachmentType SET TypeName = @TypeName WHERE ID = @ID;";

            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@ID", element.ID);
                command.Parameters.AddWithValue("@TypeName", element.TypeName);

                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<AttachmentType> GetAll()
        {
            string query = "SELECT * FROM AttachmentType";

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

        public AttachmentType GetByID(int ID)
        {
            string query = "SELECT * FROM AttachmentType WHERE ID = @ID";

            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@ID", ID);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();

                        return new AttachmentType(
                            reader.GetInt32(0),
                            reader.GetString(1)
                        );
                    }
                    throw new Exception("No rows found in database.");
                }
            }
        }

        public bool HasDuplicate(AttachmentType element)
        {
            string query = "SELECT 1 FROM AttachmentType WHERE TypeName = @TypeName";
            using (SqlCommand command = new SqlCommand(query, DatabaseSingleton.Instance()))
            {
                command.Parameters.AddWithValue("@TypeName", element.TypeName);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    return reader.HasRows;
                }
            }
        }

        public bool HasReferences(int ID)
        {
            string query = "SELECT 1 FROM Attachment WHERE TypeID = @ID";
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
