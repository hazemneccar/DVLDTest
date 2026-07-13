using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsPersonData
    {
        public static bool GetPersonByPersonID(int personID,ref string nationalID, ref string firstName, ref string secondName,
            ref string thirdName, ref string lastName, ref DateTime dateOfBirth, ref byte gender,
            ref string address, ref string phone, ref string email, ref int nationalityCountryID, ref string imagePath)
        {
            bool isFound = false;
            SqlConnection connection =new SqlConnection(clsDataAccessSettings.connectionString);
            string query = "SELECT * FROM People WHERE PersonID = @PersonID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", personID);
            try
            {
                connection.Open();
                SqlDataReader Reader=command.ExecuteReader();
                if (Reader.Read())
                {
                    nationalID = (string)Reader["NationalNo"];
                    firstName = (string)Reader["FirstName"];
                    secondName = (string)Reader["SecondName"];
                    if (Reader["ThirdName"] != DBNull.Value)
                        thirdName = (string)Reader["ThirdName"];
                    lastName = (string)Reader["LastName"];
                    dateOfBirth = (DateTime)Reader["DateOfBirth"];
                    gender = Convert.ToByte(Reader["Gender"]);
                    address = (string)Reader["Address"];
                    phone = (string)Reader["Phone"];
                    if (Reader["Email"] != DBNull.Value)
                        email = (string)Reader["Email"];
                    nationalityCountryID = (int)Reader["NationalityCountryID"];
                    if (Reader["ImagePath"] != DBNull.Value)
                        imagePath = (string)Reader["ImagePath"];
                    isFound = true;
                }
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

        public static bool GetPersonByNationalNo(ref int personID, string nationalID, ref string firstName, ref string secondName,
            ref string thirdName, ref string lastName, ref DateTime dateOfBirth, ref byte gender,
            ref string address, ref string phone, ref string email, ref int nationalityCountryID, ref string imagePath)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = "SELECT * FROM People WHERE NationalNo = @NationalNo";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", nationalID);
            try
            {
                connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.Read())
                {
                    personID = (int)Reader["PersonID"];
                    firstName = (string)Reader["FirstName"];
                    secondName = (string)Reader["SecondName"];
                    if (Reader["ThirdName"] != DBNull.Value)
                        thirdName = (string)Reader["ThirdName"];
                    lastName = (string)Reader["LastName"];
                    dateOfBirth = (DateTime)Reader["DateOfBirth"];
                    gender = Convert.ToByte(Reader["Gender"]);
                    address = (string)Reader["Address"];
                    phone = (string)Reader["Phone"];
                    if (Reader["Email"] != DBNull.Value)
                        email = (string)Reader["Email"];
                    nationalityCountryID = (int)Reader["NationalityCountryID"];
                    if (Reader["ImagePath"] != DBNull.Value)
                        imagePath = (string)Reader["ImagePath"];
                    isFound = true;
                }
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

        public static int AddPerson(string nationalID, string firstName, string secondName,
            string thirdName, string lastName, DateTime dateOfBirth, byte gender,
            string address, string phone, string email, int nationalityCountryID, string imagePath)
        {
            int personID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string query = @"INSERT INTO People (NationalNo,FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gender, Address, Phone, Email, NationalityCountryID, ImagePath)
                     VALUES (@NationalNo,@FirstName, @SecondName, @ThirdName, @LastName, @DateOfBirth, @Gender, @Address, @Phone, @Email, @NationalityCountryID, @ImagePath);
                     SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalNo", nationalID);
            command.Parameters.AddWithValue("@FirstName", firstName);
            command.Parameters.AddWithValue("@SecondName", secondName);

            if (thirdName != "")
                command.Parameters.AddWithValue("@ThirdName", thirdName);
            else
                command.Parameters.AddWithValue("@ThirdName", DBNull.Value);

            command.Parameters.AddWithValue("@LastName", lastName);
            command.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
            command.Parameters.AddWithValue("@Gender", gender);
            command.Parameters.AddWithValue("@Address", address);
            command.Parameters.AddWithValue("@Phone", phone);

            if (email != "")
                command.Parameters.AddWithValue("@Email", email);
            else
                command.Parameters.AddWithValue("@Email", DBNull.Value);

            command.Parameters.AddWithValue("@NationalityCountryID", nationalityCountryID);

            if (imagePath != "")
                command.Parameters.AddWithValue("@ImagePath", imagePath);
            else
                command.Parameters.AddWithValue("@ImagePath", DBNull.Value);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    personID = insertedID;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return personID;
        }

        public static bool UpdatePerson(int personID, string nationalID, string firstName, string secondName,
            string thirdName, string lastName, DateTime dateOfBirth, byte gender,
            string address, string phone, string email, int nationalityCountryID, string imagePath)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string query = @"UPDATE People 
                     SET NationalNo = @NationalNo,
                         FirstName = @FirstName, 
                         SecondName = @SecondName, 
                         ThirdName = @ThirdName, 
                         LastName = @LastName, 
                         DateOfBirth = @DateOfBirth, 
                         Gender = @Gender, 
                         Address = @Address, 
                         Phone = @Phone, 
                         Email = @Email, 
                         NationalityCountryID = @NationalityCountryID, 
                         ImagePath = @ImagePath
                     WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", personID);
            command.Parameters.AddWithValue("@NationalNo", nationalID);
            command.Parameters.AddWithValue("@FirstName", firstName);
            command.Parameters.AddWithValue("@SecondName", secondName);

            if (thirdName != "")
                command.Parameters.AddWithValue("@ThirdName", thirdName);
            else
                command.Parameters.AddWithValue("@ThirdName", DBNull.Value);

            command.Parameters.AddWithValue("@LastName", lastName);
            command.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
            command.Parameters.AddWithValue("@Gender", gender);
            command.Parameters.AddWithValue("@Address", address);
            command.Parameters.AddWithValue("@Phone", phone);

            if (email != "")
                command.Parameters.AddWithValue("@Email", email);
            else
                command.Parameters.AddWithValue("@Email", DBNull.Value);

            command.Parameters.AddWithValue("@NationalityCountryID", nationalityCountryID);

            if (imagePath != "")
                command.Parameters.AddWithValue("@ImagePath", imagePath);
            else
                command.Parameters.AddWithValue("@ImagePath", DBNull.Value);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

        public static bool DeletePerson(int personID)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string query = "DELETE FROM People WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", personID);

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
        public static DataTable GetAllPersons()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string query = @"SELECT People.PersonID, People.NationalNo, People.FirstName, People.SecondName, People.ThirdName, People.LastName, People.DateOfBirth, 
                  GenderCaption=CASE WHEN Gender = 0 THEN 'Male' WHEN Gender = 1 THEN 'Female' ELSE 'Unknown' END
				  ,People.Phone, People.Email, Countries.CountryName
                    FROM     People INNER JOIN
                  Countries ON People.NationalityCountryID = Countries.CountryID
				  order by People.PersonID desc

";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
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

            return dt;
        }
        public static bool IsPersonExist(int personID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string query = "SELECT Found=1 FROM People WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", personID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null)
                {
                    isFound = true;
                }
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
        public static bool IsPersonExist(string NationalNo)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string query = "SELECT Found=1 FROM People WHERE NationalNo = @NationalNo";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null)
                {
                    isFound = true;
                }
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

    }
}
