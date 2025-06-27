using System;
using System.Data.SqlClient;


class ADO_ManageDataFromDB_ToConsole
{
    static void PrintAllContacts()
    {
        SqlConnection connection = new SqlConnection("Server = .; DataBase = ContactsDB; User = sa; Password = 123456");
        connection.Open();
        SqlCommand command = new SqlCommand("select * from contacts", connection);

        try
        {
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int contactID = (int)reader["ContactID"];
                string firstName = (string)reader["FirstName"];
                string lastName = (string)reader["lastName"];
                string email = (string)reader["email"];
                string phone = (string)reader["phone"];
                string address = (reader["address"] == DBNull.Value) ? null : (string)reader["address"];
                int countryID = (int)reader["CountryID"];
                Console.WriteLine("contactID: " + contactID);
                Console.WriteLine("firstName: " + firstName);
                Console.WriteLine("lastName: " + lastName);
                Console.WriteLine("email: " + email);
                Console.WriteLine("phone: " + phone);
                Console.WriteLine("address: " + address);
                Console.WriteLine("CountryID: " + countryID);
                Console.WriteLine("####################################");

            }
            reader.Close();
            connection.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Error : " + e.Message);
        }
    }
    static void PrintAllContactsByFirstName(string FirstName)
    {
        SqlConnection connection = new SqlConnection("Server = .; DataBase = ContactsDB; User = sa; Password = 123456");
        connection.Open();
        SqlCommand command = new SqlCommand("Select * from Contacts where FirstName = @FirstName", connection);
        command.Parameters.AddWithValue("@FirstName", FirstName);

        try
        {
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int contactID = (int)reader["ContactID"];
                string firstName = (string)reader["FirstName"];
                string lastName = (string)reader["lastName"];
                string email = (string)reader["email"];
                string phone = (string)reader["phone"];
                string address = (reader["address"] == DBNull.Value) ? null : (string)reader["address"];
                int countryID = (int)reader["CountryID"];
                Console.WriteLine("contactID: " + contactID);
                Console.WriteLine("firstName: " + firstName);
                Console.WriteLine("lastName: " + lastName);
                Console.WriteLine("email: " + email);
                Console.WriteLine("phone: " + phone);
                Console.WriteLine("address: " + address);
                Console.WriteLine("CountryID: " + countryID);
                Console.WriteLine("####################################");

            }
            reader.Close();
            connection.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Error : " + e.Message);
        }
    }
    static void PrintAllContactsByFirstNameAndCountry(string FirstName, int CountryID)
    {
        SqlConnection connection = new SqlConnection("Server = .; DataBase = ContactsDB; User = sa; Password = 123456");
        connection.Open();
        SqlCommand command = new SqlCommand("select * from contacts where FirstName = @FirstName and CountryID = @CountryID", connection);
        command.Parameters.AddWithValue("@FirstName", FirstName);
        command.Parameters.AddWithValue("@CountryID", CountryID);

        try
        {
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int contactID = (int)reader["ContactID"];
                string firstName = (string)reader["FirstName"];
                string lastName = (string)reader["lastName"];
                string email = (string)reader["email"];
                string phone = (string)reader["phone"];
                string address = (reader["address"] == DBNull.Value) ? null : (string)reader["address"];
                int countryID = (int)reader["CountryID"];
                Console.WriteLine("contactID: " + contactID);
                Console.WriteLine("firstName: " + firstName);
                Console.WriteLine("lastName: " + lastName);
                Console.WriteLine("email: " + email);
                Console.WriteLine("phone: " + phone);
                Console.WriteLine("address: " + address);
                Console.WriteLine("CountryID: " + countryID);
                Console.WriteLine("####################################");

            }
            reader.Close();
            connection.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Error : " + e.Message);
        }
    }
    static void PrintAllContactsStartsWith(string likePattern)
    {
        SqlConnection connection = new SqlConnection("Server = .; DataBase = ContactsDB; User = sa; Password = 123456");
        connection.Open();
        SqlCommand command = new SqlCommand("select * from contacts where firstName like @likePattern", connection);
        command.Parameters.AddWithValue("@likePattern", likePattern);

        try
        {
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int contactID = (int)reader["ContactID"];
                string firstName = (string)reader["FirstName"];
                string lastName = (string)reader["lastName"];
                string email = (string)reader["email"];
                string phone = (string)reader["phone"];
                string address = (reader["address"] == DBNull.Value) ? null : (string)reader["address"];
                int countryID = (int)reader["CountryID"];
                Console.WriteLine("contactID: " + contactID);
                Console.WriteLine("firstName: " + firstName);
                Console.WriteLine("lastName: " + lastName);
                Console.WriteLine("email: " + email);
                Console.WriteLine("phone: " + phone);
                Console.WriteLine("address: " + address);
                Console.WriteLine("CountryID: " + countryID);
                Console.WriteLine("####################################");

            }
            reader.Close();
            connection.Close();
        } catch(Exception e)
        {
            Console.WriteLine("Error : " + e.Message);
        }
    }
    static void GetFirstNameByContactID(int ContactID)
    {
        SqlConnection connection = new SqlConnection("Server = .; DataBase = ContactsDB; User = sa; Password = 123456");
        connection.Open();
        SqlCommand command = new SqlCommand("select FirstName from contacts where ContactID = @ContactID", connection);
        command.Parameters.AddWithValue("@ContactID", ContactID);
        string FirstName = "";
        try
        {
            object OneColumneader = command.ExecuteScalar();
            if (OneColumneader != null)
            {
                FirstName = OneColumneader.ToString();
                Console.WriteLine("firstName: " + FirstName);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error : " + e.Message);
        }
        connection.Close();
    }
    static void GetContactInfosByContactID(int ContactID)
    {
        SqlConnection connection = new SqlConnection("Server = .; DataBase = ContactsDB; User = sa; Password = 123456");
        connection.Open();
        SqlCommand command = new SqlCommand("select * from contacts where ContactID = @ContactID", connection);
        command.Parameters.AddWithValue("@ContactID", ContactID);

        try
        {
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int contactID = (int)reader["ContactID"];
                string firstName = (string)reader["FirstName"];
                string lastName = (string)reader["lastName"];
                string email = (string)reader["email"];
                string phone = (string)reader["phone"];
                string address = (reader["address"] == DBNull.Value) ? null : (string)reader["address"];
                int countryID = (int)reader["CountryID"];
                Console.WriteLine("contactID: " + contactID);
                Console.WriteLine("firstName: " + firstName);
                Console.WriteLine("lastName: " + lastName);
                Console.WriteLine("email: " + email);
                Console.WriteLine("phone: " + phone);
                Console.WriteLine("address: " + address);
                Console.WriteLine("CountryID: " + countryID);
                Console.WriteLine("####################################");

            }
            reader.Close();
            connection.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Error : " + e.Message);
        }
    }

    //static void Main()
    //{
    //    //PrintAllContacts();
    //    //PrintAllContactsWithFirstName("name");
    //    //PrintAllContactsWithFirstNameAndCountry("name", 4);
    //    //PrintAllContactsStartsWith("%i");
    //    //GetFirstNameByContactID(9);
    //    //GetContactInfosByContactID(9);
    //}
}
