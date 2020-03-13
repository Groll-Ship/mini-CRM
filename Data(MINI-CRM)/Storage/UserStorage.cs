using Data_MINI_CRM_.DataModels;
using Data_MINI_CRM_.sp;
using Statuses;
using Statuses.Exception;
using Statuses.ModelStatus;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Data_MINI_CRM_.Storage
{
    public class UserStorage
    {
        
        IStatus dataStatuses;
        SqlConnection connection = null;
        public UserStorage(SqlConnection _connection)
        {
            if (connection == null)
            {
                connection = _connection;
            }
            dataStatuses = new DataStatuses();
        }
        public List<IDataModels> GetUsers()
        {
            List<IDataModels> models = new List<IDataModels>();
            SqlCommand command = new SqlCommand(Procedures.GetUsers, connection);
            command.CommandType = CommandType.StoredProcedure;
            var reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    models.Add(new UserDataModel()
                    {
                        Id = reader.GetInt32(0),
                        Login = reader.GetString(1),
                        Role = reader.GetString(2),
                        UserId = reader.GetInt32(3),
                        Password = reader.GetString(4)
                    });
                }
            }
            return models;
        }

        public ModelStatusDelete DeleteUser(int id)
        {
            SqlTransaction transaction = connection.BeginTransaction();
            SqlCommand command = new SqlCommand(Procedures.DeleteUser, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", id);
            command.Transaction = transaction;
            try
            {
                command.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (SqlException ex)
            {
                transaction.Rollback();
                return dataStatuses.DeleteRecord(false, ex.Message);
            }

            return dataStatuses.DeleteRecord(true, null);
        }

        public ModelStatusInsert InsertUser(UserDataModel model)
        {
            SqlTransaction transaction = connection.BeginTransaction();
            decimal id;
            SqlCommand command = new SqlCommand(Procedures.InsertUser, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@login", model.Login);
            command.Parameters.AddWithValue("@role", model.Role);
            command.Parameters.AddWithValue("@userId", model.UserId);
            command.Parameters.AddWithValue("@password", model.Password);
            command.Transaction = transaction;
            try
            {
                id = (decimal)command.ExecuteScalar();
                transaction.Commit();
            }
            catch (SqlException ex)
            {
                transaction.Rollback();
                return dataStatuses.InsertRecord(0, false, ex.Message);
            }
            return dataStatuses.InsertRecord(Decimal.ToInt32(id), true, null);
        }
    }
}
