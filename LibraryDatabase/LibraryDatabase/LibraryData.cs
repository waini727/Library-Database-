using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using MySql.Data.MySqlClient;

namespace LibraryDatabase
{
    public class LibBooks
    {
        private string _name;
        private string _author;
        private string _ID;
 
        public string BookName
        {
            get { return _name; }
            set { _name = value; }
        }

        public string BookAuthor
        {
            get { return _author; }
            set { _author = value; }
        }

        public string BookID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public List<LibBooks> GetBooks()
        {
            string connString = "server = localhost; User Id = root; password = 669paradiseway; database = library";
            MySqlConnection conn = new MySqlConnection(connString);

            conn.Open();

            //Create commands
            MySqlCommand cmd = new MySqlCommand("SELECT book_title, book_author, book_ID FROM library.books;");
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = conn;

            //Read From Database
            MySqlDataReader reader = cmd.ExecuteReader();

            List<LibBooks> results = new List<LibBooks>();

            while (reader.Read())
            {
                LibBooks newLibrary = new LibBooks();
                newLibrary.BookName = (string)reader["book_title"];
                newLibrary.BookAuthor = (string)reader["book_author"];
                newLibrary.BookID = (string)reader["book_ID"];
                results.Add(newLibrary);
            }

            conn.Close();
            return results;
        }

    }

    public class LibCustomers
    {
        private string customerName;
        private string customerID;

        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value; }
        }

        public string CustomerID
        {
            get { return customerID; }
            set { customerID = value; }
        }

        public List<LibCustomers> GetCustomers()
        {
            string connString = "server = localhost; User Id = root; password = 669paradiseway; database = library";
            MySqlConnection conn = new MySqlConnection(connString);

            conn.Open();

            //Create commands
            MySqlCommand cmd = new MySqlCommand("SELECT customer_name, customer_ID FROM library.customer;");
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = conn;

            //Read From Database
            MySqlDataReader reader = cmd.ExecuteReader();

            List<LibCustomers> results = new List<LibCustomers>();

            while (reader.Read())
            {
                LibCustomers newCustomer = new LibCustomers();
                newCustomer.CustomerName = (string)reader["customer_name"];
                newCustomer.CustomerID = (string)reader["customer_ID"];
                results.Add(newCustomer);
            }
            //close connection
            conn.Close();
            return results;
        }
    }
}

