using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Wellmeadows_Hospital.DAL
{
    public class SuppliersRepository
    {
        public void CreateSupplier()
        {
            SqlConnection sqlConnection = new SqlConnection();
            string connectionString = ConfigurationManager.ConnectionStrings["Wellmeadows_Hospital"].ConnectionString;

            sqlConnection.ConnectionString = connectionString;

            try
            {
                sqlCommand command = sqlConnection.CreateCommand();

                command.CommandText = "INSERT INTO Suppliers (SupplierNumber, SupplierName, Address, Email, PhoneNumber, FaxNumber) " +
                    "VALUES (@SupplierNumber, @SupplierName, @Address, @Email, @PhoneNumber, @FaxNumber)";

                command.Parameters.AddWithValues("@SupplierNumber", "d5f245");
                command.Parameters.AddWithValues("@SupplierName", "Novo Nordisk");
                command.Parameters.AddWithValues("@Address", "Novo Allé 2880 Bagsværd");
                command.Parameters.AddWithValues("@PhoneNumber", "+45 44448888");
                command.Parameters.AddWithValues("@Email", "test@mail.com");
                command.Parameters.AddWithValues("@FaxNumber", "21654654");

                sqlConnection.Open();
                command.ExecuteNonQuery();

            }
            catch(Exception ex)
            {

            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public void UpdateSupplier()
        {
            SqlConnection sqlConnection = new SqlConnection();
            string connectionString = ConfigurationManager.ConnectionStrings["Wellmeadows_Hospital"].ConnectionString;

            sqlConnection.ConnectionString = connectionString;

            try
            {
                sqlCommand command = sqlConnection.CreateCommand();
                command.CommandText = "UPDATE Suppliers SET SupplierName = @SupplierName WHERE SupplierNumber = @SupplierNumber";
                command.Parameters.AddWithValues("@SupplierName", "Novo");
                command.Parameters.AddWithValues("@SupplierNumber", "d5f245");

                sqlConnection.Open();
                command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {

            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public void GetSupplier()
        {
            SqlConnection sqlConnection = new SqlConnection();
            string connectionString = ConfigurationManager.ConnectionStrings["Wellmeadows_Hospital"].ConnectionString;

            sqlConnection.ConnectionString = connectionString;

            try
            {
                sqlCommand command = sqlConnection.CreateCommand();
                command.CommandText = "SELECT * FROM Suppliers";

                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();

                HttpContext.Current.Response.Write(reader.GetString(0) + "<br/>");
                HttpContext.Current.Response.Write(reader.GetString(1) + "<br/>");
                HttpContext.Current.Response.Write(reader.GetString(2) + "<br/>");
                HttpContext.Current.Response.Write(reader.GetString(3) + "<br/>");
                HttpContext.Current.Response.Write(reader.GetString(4) + "<br/>");
                HttpContext.Current.Response.Write(reader.GetString(5) + "<br/>");
            }
            catch
            {

            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public void DeleteSupplier()
        {
            SqlConnection sqlConnection = new SqlConnection();
            string connectionString = ConfigurationManager.ConnectionStrings["Wellmeadows_Hospital"].ConnectionString;

            sqlConnection.ConnectionString = connectionString;

            try
            {
                sqlCommand command = sqlConnection.CreateCommand();
                command.CommandText = "DELETE FROM Supplier WHERE SupplierNumber = 'd5f245'";

                sqlConnection.Open();
                command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {

            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}