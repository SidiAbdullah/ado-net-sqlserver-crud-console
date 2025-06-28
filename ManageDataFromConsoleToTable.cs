using System;
using System.Data.SqlClient;


class ADO_ManageDataFromConsoleToDB
{
    struct stContact
    {
        public int ContactID { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string Email { set; get; }
        public string Phone { set; get; }
        public string Address { set; get; }
        public int CountryID { set; get; }
    }
    static void AddContactParameters(SqlCommand command, stContact contact)
    {
        command.Parameters.AddWithValue("@FirstName", contact.FirstName);
        command.Parameters.AddWithValue("@LastName", contact.LastName);
        command.Parameters.AddWithValue("@Email", contact.Email);
        command.Parameters.AddWithValue("@Phone", contact.Phone);
        command.Parameters.AddWithValue("@Address", contact.Address);
        command.Parameters.AddWithValue("@CountryID", contact.CountryID);
    }
    static void AddContact(stContact newContact, bool GetScope_Identity = false)
    {
        if (GetScope_Identity == false)
        {
            try
            {
                SqlConnection connection = new SqlConnection("Server = .; DataBase = ContactsDB; User = sa; Password = AnyPass");
                connection.Open();
                string query = @"insert into contacts (FirstName, LastName, Email, Phone, Address, CountryID) values 
                                (@FirstName, @LastName, @Email, @Phone, @Address, @CountryID)";
                SqlCommand command = new SqlCommand(query, connection);
                AddContactParameters(command, newContact);
                int rowsEffected = command.ExecuteNonQuery();
                Console.WriteLine($"{rowsEffected} rows(s) inserted succesfully");
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error is: " + e.Message);
            }

        }
        else
        {
            try
            {
                SqlConnection connection = new SqlConnection("Server = .; DataBase = ContactsDB; User = sa; Password = AnyPass");
                connection.Open();
                string query = @"insert into contacts (FirstName, LastName, Email, Phone, Address, CountryID) values 
                                (@FirstName, @LastName, @Email, @Phone, @Address, @CountryID);
                                select Scope_Identity()";
                SqlCommand command = new SqlCommand(query, connection);
                AddContactParameters(command, newContact);
                object Scope_Identity = command.ExecuteScalar();
                Console.WriteLine("1 row inserted succusfully");
                Console.WriteLine("Scope Identity is: " + Scope_Identity.ToString());
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error is: " + e.Message);
            }
        }
    }
    static void UpdateContactByID(int ContactID, stContact newContact)
    {
        try
        {
            SqlConnection connection = new SqlConnection("Server = .; DataBase = ContactsDB; User = sa; Password = AnyPass");
            connection.Open();
            string query = @"update contacts set FirstName = @FirstName, LastName = @LastName
                            , Email = @Email, Phone = @Phone, Address = @Address, CountryID = @CountryID
                            where ContactID = @ContactID";
            SqlCommand command = new SqlCommand(query, connection);
            AddContactParameters(command, newContact);
            command.Parameters.AddWithValue("@ContactID", ContactID);
            int rowsEffected = command.ExecuteNonQuery();
            Console.WriteLine($"{rowsEffected} rows(s) Updated succesfully");
            connection.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Error is: " + e.Message);
        }
    }
    static void DeleteContactByID(int ContactID)
    {
        try
        {
            SqlConnection connection = new SqlConnection("Server = .; DataBase = ContactsDB; User = sa; Password = AnyPass");
            connection.Open();
            string query = @"delete from contacts where ContactID = @ContactID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ContactID", ContactID);
            int rowsEffected = command.ExecuteNonQuery();

            Console.WriteLine($"{rowsEffected} rows(s) Updated succesfully");
            connection.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Error is: " + e.Message);
        }
    }
    static void DeleteContactsByIDs(string IDs)
    {
        try
        {
            SqlConnection connection = new SqlConnection("Server = .; DataBase = ContactsDB; User = sa; Password = AnyPass");
            connection.Open();
            string query = @"delete from contacts where ContactID in (" + IDs + ")";
            SqlCommand command = new SqlCommand(query, connection);
            int rowsEffected = command.ExecuteNonQuery();

            Console.WriteLine($"{rowsEffected} rows(s) Deleted succesfully");
            connection.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Error is: " + e.Message);
        }
    }
    //solution 1
    static void testFindContact(int contactID)
    {
        SqlConnection connection = new SqlConnection("Server = .; DataBase = ContactsDB; User = sa; Password = AnyPass");
        connection.Open();
        try
        {
            SqlCommand command = new SqlCommand("select * from contacts", connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (reader["ContactID"] != DBNull.Value && contactID == (int)reader["ContactID"])
                {
                    Console.WriteLine("Contact [" + contactID.ToString() + "] is found");
                    return;
                }
            }
            Console.WriteLine("Contact [" + contactID.ToString() + "] is not found");
        } catch(Exception e)
        {
            Console.WriteLine("Error : " + e.Message);
        }
        connection.Close();
    }
    //solution 2
    static void testFindContact2(int contactID)
    {
        SqlConnection connection = new SqlConnection("Server = .; DataBase = ContactsDB; User = sa; Password = AnyPass");
        connection.Open();
        try
        {
            SqlCommand command = new SqlCommand("select * from contacts where contactID = @contactID", connection);
            command.Parameters.AddWithValue("@contactID", contactID);
            object result = command.ExecuteScalar();
            if (result != null && contactID == (int)result)
            {
                Console.WriteLine("Contact [" + contactID.ToString() + "] is found");
                return;
            }
            Console.WriteLine("Contact [" + contactID.ToString() + "] is not found");
        }
        catch (Exception e)
        {
            Console.WriteLine("Error : " + e.Message);
        }
        connection.Close();
    }
    static void Main()
    {
        stContact newContact = new stContact
        {
            FirstName = "FirstName",
            LastName = "LastName",
            Email = "Email@gmail.com",
            Phone = "Phone",
            Address = "Address",
            CountryID = 1,
        };
        //AddContactToDB(newContact);
        //UpdateDB_ContactByID(7, newContact);
        //DeleteDB_ContactByID(2);
        //DeleteContactsByIDs("6, 7, 8");
        //testFindContact(3);
        //testFindContact2(3);
    }
}
