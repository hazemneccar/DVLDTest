using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsTestAppointmentData
    {
        public static bool GetTestAppointmentInfoByID( int TestAppointmentId,ref int TestTypeId,
            ref int LocalDrivingAppID,ref DateTime AppointmentDate,ref float PaidFees,
            ref int CreatedByUserID,ref bool isLocked,ref int RetakeTestApplicationID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = "SELECT * FROM TestAppointments WHERE TestAppointmentID = @TestAppointmentID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentId);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    TestTypeId = (int)reader["TestTypeID"];
                    LocalDrivingAppID = (int)reader["LocalDrivingAppID"];
                    AppointmentDate = (DateTime)reader["AppointmentDate"];
                    PaidFees = (float)reader["PaidFees"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    isLocked = (bool)reader["IsLocked"];

                    if (reader["RetakeTestApplicationID"] == DBNull.Value)
                        RetakeTestApplicationID = -1;
                    else
                        RetakeTestApplicationID = (int)reader["RetakeTestApplicationID"];
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
        public static bool GetLastTestAppointment(ref int TestAppointmentId,int LocalDrivingAppID,int TestTypeID,
            ref DateTime AppointmentDate, ref float PaidFees,
            ref int CreatedByUserID, ref bool isLocked, ref int RetakeTestApplicationID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"SELECT TOP (1) *
                            FROM     TestAppointments
	                            where LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID
	                            and TestTypeID=@TestTypeID
	                            order by TestAppointmentID desc";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingAppID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    LocalDrivingAppID = (int)reader["LocalDrivingAppID"];
                    AppointmentDate = (DateTime)reader["AppointmentDate"];
                    PaidFees = (float)reader["PaidFees"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    isLocked = (bool)reader["IsLocked"];

                    if (reader["RetakeTestApplicationID"] == DBNull.Value)
                        RetakeTestApplicationID = -1;
                    else
                        RetakeTestApplicationID = (int)reader["RetakeTestApplicationID"];
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
        public static DataTable GetAllTestAppointments()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string query = @"SELECT TestAppointments.TestAppointmentID, TestAppointments.LocalDrivingLicenseApplicationID, TestTypes.TestTypeTitle, LicenseClasses.ClassName, TestAppointments.AppointmentDate, TestAppointments.PaidFees, 
                                              People.FirstName + ' ' + People.SecondName + ' ' + ISNULL(People.ThirdName, '') + ' ' + People.LastName AS FullName, TestAppointments.IsLocked
                            FROM     TestAppointments INNER JOIN
                             TestTypes ON TestAppointments.TestTypeID = TestTypes.TestTypeID INNER JOIN
                             LocalDrivingLicenseApplications ON TestAppointments.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID INNER JOIN
                             LicenseClasses ON LocalDrivingLicenseApplications.LicenseClassID = LicenseClasses.LicenseClassID INNER JOIN
                             Applications ON LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID INNER JOIN
                             People ON Applications.ApplicantPersonID = People.PersonID";

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
        public static DataTable GetAppTestAppointmentsByTestType(int localDrivingAppID, short TestTypeID)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string query = @"SELECT TestAppointmentID, AppointmentDate, PaidFees, IsLocked
                            FROM     TestAppointments where LocalDrivingLicenseApplicationID=@localDrivingAppID
                            and TestTypeID=@TestTypeID order by TestTypeID desc";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@localDrivingAppID", localDrivingAppID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

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
        public static int AddNewTestAppointment(int testTypeID,int localDrivingAppID,
            DateTime appointmentDate,float paidFees, int createdByUserID,
            bool isLocked, int retakeTestApplicationID)
        {
            int testAppointmentID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string query = @"INSERT INTO TestAppointments
                    (
                    TestTypeID,LocalDrivingLicenseApplicationID,AppointmentDate,
                    PaidFees,CreatedByUserID,IsLocked,RetakeTestApplicationID
                    )
                    VALUES
                    (
                        @TestTypeID,
                        @LocalDrivingAppID,
                        @AppointmentDate,
                        @PaidFees,
                        @CreatedByUserID,
                        @IsLocked,
                        @RetakeTestApplicationID
                    );

                    SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestTypeID", testTypeID);
            command.Parameters.AddWithValue("@LocalDrivingAppID", localDrivingAppID);
            command.Parameters.AddWithValue("@AppointmentDate", appointmentDate);
            command.Parameters.AddWithValue("@PaidFees", paidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);
            command.Parameters.AddWithValue("@IsLocked", isLocked);

            if (retakeTestApplicationID != -1)
                command.Parameters.AddWithValue("@RetakeTestApplicationID", retakeTestApplicationID);
            else
                command.Parameters.AddWithValue("@RetakeTestApplicationID", DBNull.Value);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                    testAppointmentID = insertedID;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return testAppointmentID;
        }
        public static bool UpdateTestAppointment(int testAppointmentID,
            int testTypeID, int localDrivingAppID,
            DateTime appointmentDate, float paidFees,
            int createdByUserID, bool isLocked,
            int retakeTestApplicationID)
        {
            bool isUpdated = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string query = @"UPDATE TestAppointments
                     SET TestTypeID = @TestTypeID,
                         LocalDrivingLicenseApplicationID = @LocalDrivingAppID,
                         AppointmentDate = @AppointmentDate,
                         PaidFees = @PaidFees,
                         CreatedByUserID = @CreatedByUserID,
                         IsLocked = @IsLocked,
                         RetakeTestApplicationID = @RetakeTestApplicationID
                     WHERE TestAppointmentID = @TestAppointmentID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestAppointmentID", testAppointmentID);
            command.Parameters.AddWithValue("@TestTypeID", testTypeID);
            command.Parameters.AddWithValue("@LocalDrivingAppID", localDrivingAppID);
            command.Parameters.AddWithValue("@AppointmentDate", appointmentDate);
            command.Parameters.AddWithValue("@PaidFees", paidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);
            command.Parameters.AddWithValue("@IsLocked", isLocked);

            if (retakeTestApplicationID != -1)
                command.Parameters.AddWithValue("@RetakeTestApplicationID", retakeTestApplicationID);
            else
                command.Parameters.AddWithValue("@RetakeTestApplicationID", DBNull.Value);

            try
            {
                connection.Open();

                int rowsAffected = command.ExecuteNonQuery();

                isUpdated = (rowsAffected > 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return isUpdated;
        }
        public static bool DeleteTestAppointment(int localDrivingAppID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string query = "DELETE FROM TestAppointments WHERE TestAppointmentID = @TestAppointmentID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestAppointmentID", localDrivingAppID);

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
        public static short GetTestID(int TestAppointmentID)
        {
            short TestID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string query = @"SELECT TestID FROM Tests where TestAppointmentID=@TestAppointmentID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && short.TryParse(result.ToString(), out short foundTestAppointmentID))
                    TestID = foundTestAppointmentID;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return TestID;
        }

    }
}
