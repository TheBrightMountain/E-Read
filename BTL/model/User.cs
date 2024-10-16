using System;

namespace BTL.model
{
    //    CREATE TABLE Users(
    //    Email VARCHAR(255) PRIMARY KEY,
    //    Password VARCHAR(255) NOT NULL,
    //    Name NVARCHAR(100),             
    //    DateOfBirth DATE,
    //    Phone VARCHAR(20),                      
    //    City NVARCHAR(100)
    //);

    public class User
    {
        public string Email { get; set; }
        public string Password{ get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
    }
}