using System;
using System.Data.SqlClient;


class ADO_Program_Insert
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
    static void AddNewContact(stContact newContact)
    {
        try
        {
            SqlConnection connection = new SqlConnection("Server = .; DataBase = ContactsDB; User = sa; Password = AnyPass");
            connection.Open();
            string query = "insert into contacts (FirstName, LastName, Email, Phone, Address, CountryID) " +
                "values (@FirstName, @LastName, @Email, @Phone, @Address, @CountryID)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@FirstName", newContact.FirstName);
            command.Parameters.AddWithValue("@LastName", newContact.LastName);
            command.Parameters.AddWithValue("@Email", newContact.Email);
            command.Parameters.AddWithValue("@Phone", newContact.Phone);
            command.Parameters.AddWithValue("@Address", newContact.Address);
            command.Parameters.AddWithValue("@CountryID", newContact.CountryID);
            int rowsEffected = command.ExecuteNonQuery();
            Console.WriteLine(rowsEffected > 0 ? $"{rowsEffected} row(s) inserted successfully." : "No rows were inserted.");
            connection.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Error is: " + e.Message);
        }
    }
    static void Main()
    {
        stContact newContact = new stContact
        {
            FirstName = "FirstName",
            LastName = "LastName",
            Email = "Email@gmail.com",
            Phone = "+Phone",
            Address = "Address",
            CountryID = 1,
        };
        AddNewContact(newContact);
    }
}
