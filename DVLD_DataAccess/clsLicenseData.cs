using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_DataAccess
{
    public class clsLicenseData
    {
        public static bool GetLicenseInfoByID(int licenseID, ref int applicationID, ref int driverID, ref int licenseClass,
            ref DateTime issueDate, ref DateTime expirationDate, ref string notes, ref float paidFees,
            ref bool isActive, ref byte issueReason, ref int createdByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string query = "SELECT * FROM Licenses WHERE LicenseID = @LicenseID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", licenseID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    applicationID = (int)reader["ApplicationID"];
                    driverID = (int)reader["DriverID"];
                    licenseClass = (int)reader["LicenseClass"];
                    issueDate = (DateTime)reader["IssueDate"];
                    expirationDate = (DateTime)reader["ExpirationDate"];

                    if (reader["Notes"] != DBNull.Value)
                        notes = reader["Notes"].ToString().TrimStart();
                    else
                        notes = "";

                    paidFees = Convert.ToSingle(reader["PaidFees"]);
                    isActive = (bool)reader["IsActive"];
                    issueReason = (byte)reader["IssueReason"];
                    createdByUserID = (int)reader["CreatedByUserID"];
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }
        public static bool GetLicenseInfoByPersonID(int personID,int LicenseClass, ref int licenseID, ref int applicationID, ref int driverID,
            ref int licenseClass, ref DateTime issueDate, ref DateTime expirationDate, ref string notes,
            ref float paidFees, ref bool isActive, ref byte issueReason, ref int createdByUserID)
        {
        bool isFound = false;

        SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

        string query = @"SELECT TOP 1 Licenses.* 
                     FROM Licenses 
                     INNER JOIN Applications ON Licenses.ApplicationID = Applications.ApplicationID
                     WHERE Applications.ApplicantPersonID = @PersonID
                     AND Licenses.LicenseClass=@LicenseClass
                     ORDER BY Licenses.LicenseID DESC";

        SqlCommand command = new SqlCommand(query, connection);

        command.Parameters.AddWithValue("@PersonID", personID);

        try
        {
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                isFound = true;
                licenseID = (int)reader["LicenseID"];
                applicationID = (int)reader["ApplicationID"];
                driverID = (int)reader["DriverID"];
                licenseClass = (int)reader["LicenseClass"];
                issueDate = (DateTime)reader["IssueDate"];
                expirationDate = (DateTime)reader["ExpirationDate"];

                if (reader["Notes"] != DBNull.Value)
                    notes = reader["Notes"].ToString().TrimStart();
                else
                    notes = "";

                paidFees = Convert.ToSingle(reader["PaidFees"]);
                isActive = (bool)reader["IsActive"];
                issueReason = (byte)reader["IssueReason"];
                createdByUserID = (int)reader["CreatedByUserID"];
            }

            reader.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            connection.Close();
        }

        return isFound;
    }
        public static int GetActiveLicenseIDByPersonID(int personID, int LicenseClass)
        {
            int licenseID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string query = @"SELECT TOP 1 Licenses.LicenseID
                     FROM Licenses 
                     INNER JOIN Applications ON Licenses.ApplicationID = Applications.ApplicationID
                     WHERE Applications.ApplicantPersonID = @PersonID
                     AND Licenses.LicenseClass=@LicenseClass
                     ORDER BY Licenses.LicenseID DESC";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", personID);
            command.Parameters.AddWithValue("@LicenseClass", LicenseClass);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                    licenseID = insertedID;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return licenseID;
        }
        public static int AddNewLicense(int applicationID, int driverID, int licenseClass,
            DateTime issueDate, DateTime expirationDate, string notes, float paidFees,
            bool isActive, byte issueReason, int createdByUserID)
        {
            int licenseID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string query = @"INSERT INTO Licenses (ApplicationID, DriverID, LicenseClass, IssueDate, ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID)
                     VALUES (@ApplicationID, @DriverID, @LicenseClass, @IssueDate, @ExpirationDate, @Notes, @PaidFees, @IsActive, @IssueReason, @CreatedByUserID);
                     SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", applicationID);
            command.Parameters.AddWithValue("@DriverID", driverID);
            command.Parameters.AddWithValue("@LicenseClass", licenseClass);
            command.Parameters.AddWithValue("@IssueDate", issueDate);
            command.Parameters.AddWithValue("@ExpirationDate", expirationDate);

            if (notes != "")
                command.Parameters.AddWithValue("@Notes", notes);
            else
                command.Parameters.AddWithValue("@Notes", DBNull.Value);

            command.Parameters.AddWithValue("@PaidFees", paidFees);
            command.Parameters.AddWithValue("@IsActive", isActive);
            command.Parameters.AddWithValue("@IssueReason", issueReason);
            command.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                    licenseID = insertedID;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return licenseID;
        }
        public static bool UpdateLicense(int licenseID, int applicationID, int driverID, int licenseClass,
            DateTime issueDate, DateTime expirationDate, string notes, float paidFees,
            bool isActive, byte issueReason, int createdByUserID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string query = @"UPDATE Licenses 
                     SET ApplicationID = @ApplicationID, 
                         DriverID = @DriverID, 
                         LicenseClass = @LicenseClass, 
                         IssueDate = @IssueDate, 
                         ExpirationDate = @ExpirationDate, 
                         Notes = @Notes, 
                         PaidFees = @PaidFees, 
                         IsActive = @IsActive, 
                         IssueReason = @IssueReason, 
                         CreatedByUserID = @CreatedByUserID
                     WHERE LicenseID = @LicenseID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", licenseID);
            command.Parameters.AddWithValue("@ApplicationID", applicationID);
            command.Parameters.AddWithValue("@DriverID", driverID);
            command.Parameters.AddWithValue("@LicenseClass", licenseClass);
            command.Parameters.AddWithValue("@IssueDate", issueDate);
            command.Parameters.AddWithValue("@ExpirationDate", expirationDate);

            if (notes != "")
                command.Parameters.AddWithValue("@Notes", notes);
            else
                command.Parameters.AddWithValue("@Notes", DBNull.Value);

            command.Parameters.AddWithValue("@PaidFees", paidFees);
            command.Parameters.AddWithValue("@IsActive", isActive);
            command.Parameters.AddWithValue("@IssueReason", issueReason);
            command.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }
        public static bool DeleteLicense(int licenseID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string query = "DELETE FROM Licenses WHERE LicenseID = @LicenseID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", licenseID);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }
        public static DataTable GetAllLicenses()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string query = @"select * from MyLicenses_View";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                    dt.Load(reader);

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }
        public static DataTable GetDriverLicenses(int DriverID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"select * from MyLicenses_View where DriverID=@DriverID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                    dt.Load(reader);

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }
        public static bool DeactivateLicense(int licenseID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string query = @"UPDATE Licenses 
                     SET IsActive = 0
                     WHERE LicenseID = @LicenseID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", licenseID);
            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }
    }
}
