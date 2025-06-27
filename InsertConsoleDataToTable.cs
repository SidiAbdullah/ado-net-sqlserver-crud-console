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
    static void AddContactToDataBase(stContact newContact, bool GetScope_Identity = false)
    {
        if (GetScope_Identity == false)
        {
            try
            {
                SqlConnection connection = new SqlConnection("Server = .; DataBase = ContactsDB; User = sa; Password = 123456");
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
        AddContactToDataBase(newContact, true);
    }
}
