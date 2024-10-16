CREATE TABLE Users (
    Email VARCHAR(255) PRIMARY KEY,          
    PasswordHash VARCHAR(255) NOT NULL,     
    Name NVARCHAR(100),             
    DateOfBirth DATE,              
    Phone VARCHAR(20),                      
    City NVARCHAR(100)                      
);
