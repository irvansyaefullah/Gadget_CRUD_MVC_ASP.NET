using Gadget.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Gadget.Data
{
    public class GadgetDAO
    {
        private string connectionString = "Server=LAPTOP-I439BFVU\\SQLEXPRESS;Database=GadgetDB;Trusted_Connection=True;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
        //performs all operation on the database. get all, create, delete, get one, search etc.

       public List<GadgetModel> FetchAll()
        {
            List<GadgetModel> returnList = new List<GadgetModel>();

            //access the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * from dbo.Gadgets";
                
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //create a new gadget object. Add it to the list to return.
                        GadgetModel gadget = new GadgetModel();
                        gadget.Id = reader.GetInt32(0);
                        gadget.Name = reader.GetString(1);
                        gadget.Description = reader.GetString(2);
                        gadget.Appearsln = reader.GetString(3);
                        gadget.WithThisActor = reader.GetString(4);

                        returnList.Add(gadget);
                    }
                }
            }
            return returnList;
        }



        public GadgetModel FetchOne(int id)
        {
            //access the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * from dbo.Gadgets WHERE Id =@id";

                // associate @id with Id Parameter

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                GadgetModel gadget = new GadgetModel();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //create a new gadget object. Add it to the list to return.
                        
                        gadget.Id = reader.GetInt32(0);
                        gadget.Name = reader.GetString(1);
                        gadget.Description = reader.GetString(2);
                        gadget.Appearsln = reader.GetString(3);
                        gadget.WithThisActor = reader.GetString(4);

                    }
                }
                return gadget;
            }
        }




        //create
        public int CreateOrUpdate(GadgetModel gadgetModel)
        {
            //access the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "";
                if(gadgetModel.Id <= 0)
                {
                    //CREATE
                    sqlQuery = "INSERT INTO dbo.Gadgets VALUES (@Name, @Description, @Appearsln, @WithThisActor)";
                }
                else
                {
                    //UPDATE
                    sqlQuery = "UPDATE dbo.Gadgets SET Name = @Name, Description = @Description, Appearsln = @Appearsln, WithThisActor = @WithThisActor WHERE Id = @Id";
                }

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                command.Parameters.Add("@Id", System.Data.SqlDbType.VarChar, 1000).Value = gadgetModel.Id;
                command.Parameters.Add("@Name", System.Data.SqlDbType.VarChar, 1000).Value = gadgetModel.Name;
                command.Parameters.Add("@Description", System.Data.SqlDbType.VarChar, 1000).Value = gadgetModel.Description;
                command.Parameters.Add("@Appearsln", System.Data.SqlDbType.VarChar, 1000).Value = gadgetModel.Appearsln;
                command.Parameters.Add("@WithThisActor", System.Data.SqlDbType.VarChar, 1000).Value = gadgetModel.WithThisActor;

                connection.Open();

                int newID = command.ExecuteNonQuery();
                
                return newID;
            }
        }



        internal int Delete(int id)
        {
            //access the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "DELETE FROM dbo.Gadgets WHERE Id = @Id";
                

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                command.Parameters.Add("@Id", System.Data.SqlDbType.VarChar, 1000).Value = id;
                
                connection.Open();

                int deleteID = command.ExecuteNonQuery();

                return deleteID;
            }
        }

    }
}