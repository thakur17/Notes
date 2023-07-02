using System;
using System.Data;
using System.Data.SqlClient;

namespace db
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string ConString = "data source=LAPTOP-0MLFR83M\\SQLEXPRESS; database=StudentDb; integrated security=SSPI";
                using (SqlConnection connection = new SqlConnection(ConString))
                {
                    connection.Open();

                    SqlCommand cmd1 = new SqlCommand("INSERT INTO Students (Name, RollNo, ClassName) " +
                        "VALUES('Tom B. Erichsen', 12, 'CSIT') ", connection);
                   
                    // Executing the SQL query  
                    cmd1.ExecuteNonQuery();
                    connection.Close();
                    // Creating the command object
                    SqlCommand cmd = new SqlCommand("select * from Students", connection);
                    // Opening Connection  
                    connection.Open();
                    // Executing the SQL query  
                    SqlDataReader sdr = cmd.ExecuteReader();
                    //Looping through each record
                    while (sdr.Read())
                    {
                        Console.WriteLine(sdr["Name"] + ",  " + sdr["RollNo"] + ",  " + sdr["ClassName"]);
                    }
                    connection.Close();

                    //Update operation
                    SqlCommand cmd2 = new SqlCommand("UPDATE Students set Name = 'Thakur' " +
                        "WHERE RollNo = 12", connection);
                    // Opening Connection  
                    connection.Open();
                    // Executing the SQL query  
                    cmd2.ExecuteNonQuery();
                    connection.Close();
                    
                    //Delete operation
                    SqlCommand cmd3 = new SqlCommand("DELETE FROM Students " +
                        "WHERE ClassName = 'CSIT'", connection);
                    // Opening Connection  
                    connection.Open();
                    // Executing the SQL query  
                    cmd3.ExecuteNonQuery();
                    connection.Close();


                    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong.\n" + e);
            }
            Console.ReadKey();
        }
    }
}
 
