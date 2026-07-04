using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsInternationalLicenseData
    {
        public static bool GetInternationalLicenseInfoByID(int internationalLicenseID, ref int applicationID,
            ref int driverID, ref int issuedUsingLocalLicenseID, ref DateTime issueDate,
            ref DateTime expirationDate, ref bool isActive, ref int createdByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string query = "SELECT * FROM InternationalLicenses WHERE InternationalLicenseID = @InternationalLicenseID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@InternationalLicenseID", internationalLicenseID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    applicationID = (int)reader["ApplicationID"];
                    driverID = (int)reader["DriverID"];
                    issuedUsingLocalLicenseID = (int)reader["IssuedUsingLocalLicenseID"];
                    issueDate = (DateTime)reader["IssueDate"];
                    expirationDate = (DateTime)reader["ExpirationDate"];
                    isActive = (bool)reader["IsActive"];
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
        public static bool GetInternationalLicenseInfoByLocalLicenseID(int issuedUsingLocalLicenseID, ref int internationalLicenseID,
            ref int applicationID, ref int driverID, ref DateTime issueDate, ref DateTime expirationDate,
            ref bool isActive, ref int createdByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string query = @"SELECT * FROM InternationalLicenses 
                            WHERE IssuedUsingLocalLicenseID = @IssuedUsingLocalLicenseID
                            and IsActive=1
                            order by InternationalLicenseID desc";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", issuedUsingLocalLicenseID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    internationalLicenseID = (int)reader["InternationalLicenseID"];
                    applicationID = (int)reader["ApplicationID"];
                    driverID = (int)reader["DriverID"];
                    issueDate = (DateTime)reader["IssueDate"];
                    expirationDate = (DateTime)reader["ExpirationDate"];
                    isActive = (bool)reader["IsActive"];
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
        public static bool GetInternationalLicenseInfoByDriverID(ref int issuedUsingLocalLicenseID, ref int internationalLicenseID,
            ref int applicationID, int driverID, ref DateTime issueDate, ref DateTime expirationDate,
            ref bool isActive, ref int createdByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string query = @"SELECT * FROM InternationalLicenses 
                            WHERE  DriverID = @DriverID
                            and IsActive=1
                            order by InternationalLicenseID desc";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DriverID", driverID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    internationalLicenseID = (int)reader["InternationalLicenseID"];
                    applicationID = (int)reader["ApplicationID"];
                    driverID = (int)reader["DriverID"];
                    issueDate = (DateTime)reader["IssueDate"];
                    expirationDate = (DateTime)reader["ExpirationDate"];
                    isActive = (bool)reader["IsActive"];
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
        public static int GetInternationalLicenseIDByDriverID(int driverID)
        {
            int InternationalID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string query = @"SELECT top 1 InternationalLicenseID FROM InternationalLicenses 
                            WHERE DriverID = @DriverID
                            and IsActive=1
							and GETDATE() between IssueDate and ExpirationDate
                            order by ExpirationDate desc";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DriverID", driverID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                    InternationalID= insertedID;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return InternationalID;
        }
        public static int AddNewInternationalLicense(int applicationID, int driverID, int issuedUsingLocalLicenseID,
            DateTime issueDate, DateTime expirationDate, bool isActive, int createdByUserID)
        {
            int internationalLicenseID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string query = @"update InternationalLicenses
                            set IsActive=0
                            where DriverID=@DriverID
-
                            INSERT INTO InternationalLicenses (ApplicationID, DriverID, IssuedUsingLocalLicenseID,
                            IssueDate, ExpirationDate, IsActive, CreatedByUserID)
                            VALUES (@ApplicationID, @DriverID, @IssuedUsingLocalLicenseID, @IssueDate, @ExpirationDate,
                            @IsActive, @CreatedByUserID);
                            SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", applicationID);
            command.Parameters.AddWithValue("@DriverID", driverID);
            command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", issuedUsingLocalLicenseID);
            command.Parameters.AddWithValue("@IssueDate", issueDate);
            command.Parameters.AddWithValue("@ExpirationDate", expirationDate);
            command.Parameters.AddWithValue("@IsActive", isActive);
            command.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                    internationalLicenseID = insertedID;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return internationalLicenseID;
        }

        public static bool UpdateInternationalLicense(int internationalLicenseID, int applicationID, int driverID,
            int issuedUsingLocalLicenseID, DateTime issueDate, DateTime expirationDate, bool isActive, int createdByUserID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string query = @"UPDATE InternationalLicenses 
                     SET ApplicationID = @ApplicationID, 
                         DriverID = @DriverID, 
                         IssuedUsingLocalLicenseID = @IssuedUsingLocalLicenseID, 
                         IssueDate = @IssueDate, 
                         ExpirationDate = @ExpirationDate, 
                         IsActive = @IsActive, 
                         CreatedByUserID = @CreatedByUserID
                     WHERE InternationalLicenseID = @InternationalLicenseID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@InternationalLicenseID", internationalLicenseID);
            command.Parameters.AddWithValue("@ApplicationID", applicationID);
            command.Parameters.AddWithValue("@DriverID", driverID);
            command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", issuedUsingLocalLicenseID);
            command.Parameters.AddWithValue("@IssueDate", issueDate);
            command.Parameters.AddWithValue("@ExpirationDate", expirationDate);
            command.Parameters.AddWithValue("@IsActive", isActive);
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
        public static bool DeleteInternationalLicense(int internationalLicenseID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string query = "DELETE FROM InternationalLicenses WHERE InternationalLicenseID = @InternationalLicenseID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@InternationalLicenseID", internationalLicenseID);

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

        public static DataTable GetAllInternationalLicensesByDriverID(int driverID)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string query = @"SELECT InternationalLicenseID, ApplicationID, DriverID, IssuedUsingLocalLicenseID,
                                   IssueDate, ExpirationDate, IsActive 
                            FROM InternationalLicenses 
	                        WHERE DriverID = @DriverID
	                        ORDER BY ExpirationDate DESC";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DriverID", driverID);

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
        public static DataTable GetAllInternationalLicenses()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"SELECT InternationalLicenseID, ApplicationID, DriverID, IssuedUsingLocalLicenseID,
                                   IssueDate, ExpirationDate, IsActive
                            FROM     InternationalLicenses
                            ORDER BY IsActive,ExpirationDate DESC";
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

    }
}
