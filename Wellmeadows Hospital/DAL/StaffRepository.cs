using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Wellmeadows_Hospital.DAL
{
    public class StaffRepository
    {
        public void CreateStaff()
        {
            SqlConnection sqlConnection = new SqlConnection();
            string connectionString = ConfigurationManager.ConnectionStrings["Wellmeadows_Hospital"].ConnectionString;

            sqlConnection.ConnectionString = connectionString;

            try
            {
                SqlCommand command = sqlConnection.CreateCommand();

                command.CommandText = "INSERT INTO Staff (StaffNumber, FirstName, LastName, Address, Gender, DateOfBirth, TlfNumber, InsuranceNumber, " +
                    "Position, CurrentSalary, WhenPaid, AllocatedToWard, HoursPerWeek, PermanentOrTemporary, SalaryScale) " +
                    "VALUES (@StaffNumber, @FirstName, @LastName, @Address, @Gender, @DateOfBirth, @TlfNumber, @InsuranceNumber, " +
                    "@Position, @CurrentSalary, @WhenPaid, @AllocatedToWard, @HoursPerWeek, @PermanentOrTemporary, @SalaryScale)";

                command.Parameters.AddWithValue("@StaffNumber", "777f");
                command.Parameters.AddWithValue("@FirstName", "John");
                command.Parameters.AddWithValue("@LastName", "Hansen");
                command.Parameters.AddWithValue("@Address", "Bornholmsgade 2 9000 Aalborg");
                command.Parameters.AddWithValue("@Gender", "M");

                DateTime date = new DateTime(1978, 4, 19);

                command.Parameters.AddWithValue("@DateOfBirth", date);
                command.Parameters.AddWithValue("@TlfNumber", "+45 987654321");
                command.Parameters.AddWithValue("@InsuranceNumber", "YYn7534j");
                command.Parameters.AddWithValue("@Position", "Portør");
                command.Parameters.AddWithValue("@CurrentSalary", 22500);
                command.Parameters.AddWithValue("@WhenPaid", "M");
                command.Parameters.AddWithValue("@AllocatedToWard", 1);
                command.Parameters.AddWithValue("@HoursPerWeek", 37.5);
                command.Parameters.AddWithValue("@PermanentOrTemporary", "P");
                command.Parameters.AddWithValue("@SalaryScale", "B4");

                sqlConnection.Open();

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public void UpdateStaff()
        {
            SqlConnection sqlConnection = new SqlConnection();
            string connectionString = ConfigurationManager.ConnectionStrings["Wellmeadows_Hospital"].ConnectionString;

            sqlConnection.ConnectionString = connectionString;

            try
            {
                SqlCommand command = sqlConnection.CreateCommand();

                command.CommandText = "UPDATE Staff SET Address = @Address WHERE StaffNumber = @StaffNumber";
                command.Parameters.AddWithValue("@Address", "Øster Uttrup Vej 2 9000 Aalborg");
                command.Parameters.AddWithValue("@StaffNumber", "777f");

                sqlConnection.Open();
                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public void GetStaff()
        {
            SqlConnection sqlConnection = new SqlConnection();
            string connectionString = ConfigurationManager.ConnectionStrings["Wellmeadows_Hospital"].ConnectionString;

            sqlConnection.ConnectionString = connectionString;

            try
            {
                SqlCommand command = sqlConnection.CreateCommand();

                command.CommandText = "SELECT * FROM Staff";

                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();

                HttpContext.Current.Response.Write(reader.GetString(0) + "<br/>");
                HttpContext.Current.Response.Write(reader.GetString(1) + "<br/>");
                HttpContext.Current.Response.Write(reader.GetString(2) + "<br/>");
                HttpContext.Current.Response.Write(reader.GetString(3) + "<br/>");
                HttpContext.Current.Response.Write(reader.GetString(4) + "<br/>");
                HttpContext.Current.Response.Write(reader.GetDateTime(5) + "<br/>");
                HttpContext.Current.Response.Write(reader.GetString(6) + "<br/>");
                HttpContext.Current.Response.Write(reader.GetString(7) + "<br/>");
                HttpContext.Current.Response.Write(reader.GetString(8) + "<br/>");
                HttpContext.Current.Response.Write(reader.GetDecimal(9) + "<br/>");
                HttpContext.Current.Response.Write(reader.GetString(10) + "<br/>");
                HttpContext.Current.Response.Write(reader.GetInt32(11) + "<br/>");
                HttpContext.Current.Response.Write(reader.GetDecimal(12) + "<br/>");
                HttpContext.Current.Response.Write(reader.GetString(13) + "<br/>");
                HttpContext.Current.Response.Write(reader.GetString(14) + "<br/>");
            }
            catch (Exception ex)
            {

            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public void DeleteStaff()
        {
            SqlConnection sqlConnection = new SqlConnection();
            string connectionString = ConfigurationManager.ConnectionStrings["Wellmeadows_Hospital"].ConnectionString;

            sqlConnection.ConnectionString = connectionString;

            try
            {
                SqlCommand command = sqlConnection.CreateCommand();

                command.CommandText = "DELETE FROM Staff WHERE StaffNumber = '777f'";

                sqlConnection.Open();
                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}