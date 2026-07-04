using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsLicenseClassData
    {
        public static bool GetLicenseClassInfoByID(int licenseClassID, ref string className, ref string classDescription,
            ref short minimumAllowedAge, ref short defaultValidityLength, ref float classFees)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string query = "SELECT * FROM LicenseClasses WHERE LicenseClassID = @LicenseClassID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseClassID", licenseClassID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    className = reader["ClassName"].ToString().TrimStart();

                    if (reader["ClassDescription"] != DBNull.Value)
                        classDescription = reader["ClassDescription"].ToString().TrimStart();
                    else
                        classDescription = "";

                    minimumAllowedAge = Convert.ToInt16(reader["MinimumAllowedAge"]);
                    defaultValidityLength = Convert.ToInt16(reader["DefaultValidityLength"]);
                    classFees = Convert.ToSingle(reader["ClassFees"]);
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
        public static bool GetLicenseClassName(ref int licenseClassID, string className, ref string classDescription,
            ref short minimumAllowedAge, ref short defaultValidityLength, ref float classFees)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string query = "SELECT * FROM LicenseClasses WHERE ClassName = @ClassName";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ClassName", className);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    licenseClassID = (int)reader["licenseClassID"];

                    classDescription = reader["ClassDescription"].ToString().TrimStart();
                    minimumAllowedAge = Convert.ToInt16(reader["MinimumAllowedAge"]);
                    defaultValidityLength = Convert.ToInt16(reader["DefaultValidityLength"]);
                    classFees = Convert.ToSingle(reader["ClassFees"]);
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
        public static int AddNewLicenseClass(string className, string classDescription,
            short minimumAllowedAge, short defaultValidityLength, float classFees)
        {
            int licenseClassID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string query = @"INSERT INTO LicenseClasses (ClassName, ClassDescription, MinimumAllowedAge, DefaultValidityLength, ClassFees)
                     VALUES (@ClassName, @ClassDescription, @MinimumAllowedAge, @DefaultValidityLength, @ClassFees);
                     SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ClassName", className);
            command.Parameters.AddWithValue("@ClassDescription", classDescription);
            command.Parameters.AddWithValue("@MinimumAllowedAge", minimumAllowedAge);
            command.Parameters.AddWithValue("@DefaultValidityLength", defaultValidityLength);
            command.Parameters.AddWithValue("@ClassFees", classFees);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                    licenseClassID = insertedID;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return licenseClassID;
        }
        public static bool UpdateLicenseClass(int licenseClassID, string className, string classDescription,
            short minimumAllowedAge, short defaultValidityLength, float classFees)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string query = @"UPDATE LicenseClasses 
                     SET ClassName = @ClassName, 
                         ClassDescription = @ClassDescription, 
                         MinimumAllowedAge = @MinimumAllowedAge, 
                         DefaultValidityLength = @DefaultValidityLength, 
                         ClassFees = @ClassFees
                     WHERE LicenseClassID = @LicenseClassID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseClassID", licenseClassID);
            command.Parameters.AddWithValue("@ClassName", className);

            if (classDescription != "")
                command.Parameters.AddWithValue("@ClassDescription", classDescription);
            else
                command.Parameters.AddWithValue("@ClassDescription", DBNull.Value);

            command.Parameters.AddWithValue("@MinimumAllowedAge", minimumAllowedAge);
            command.Parameters.AddWithValue("@DefaultValidityLength", defaultValidityLength);
            command.Parameters.AddWithValue("@ClassFees", classFees);

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
        public static DataTable GetAllLicenseClasses()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string query = @"select * from LicensesClasses";

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
