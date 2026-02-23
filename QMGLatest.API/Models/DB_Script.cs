//namespace QMGLatest.API.Models
//{
//    public class DB_Script
//    {
//        use[LatestQMGDB]
 
//--select* from[dbo].[Employee]
 
//--CREATE TABLE Otps(
//--    OtpId INT IDENTITY PRIMARY KEY,
//--    Username VARCHAR(50),
//--    OtpCode VARCHAR(10),
//--    ExpiryTime DATETIME,
//--    IsUsed BIT,
//--    CreatedDate DATETIME
//--);
 
//--CREATE TABLE Users(
//--    UserId INT IDENTITY PRIMARY KEY,
//--    Username VARCHAR(50) UNIQUE NOT NULL,
//--    Password VARCHAR(200) NOT NULL,
//--    Email VARCHAR(100),
//--    RoleName VARCHAR(20),       -- Admin / User
//--    RoleNumber INT,             -- 1 = Admin, 2 = User
//--    IsActive BIT,
//--    CreatedDate DATETIME,
//--    LastLogin DATETIME,
//--    FailedAttempts INT,
//--	  UpdatedDate DATETIME
//--);
 
 
//--CREATE TABLE Employees(
//--    EmployeeId INT IDENTITY PRIMARY KEY,
//--    Name VARCHAR(100),
//--    Email VARCHAR(100),
//--    Phone VARCHAR(20),
//--    Department VARCHAR(50),
//--    Designation VARCHAR(50),
//--    Salary DECIMAL(10,2),
//--    Address VARCHAR(200),
//--    JoiningDate DATETIME,
//--    IsActive BIT
//--);
 
 
//--CREATE TABLE Tokens(
//--    TokenId INT IDENTITY PRIMARY KEY,
//--    Username VARCHAR(50),
//--    JwtToken VARCHAR(MAX),
//--    RoleName VARCHAR(20),
//--    RoleNumber INT,
//--    ExpiryTime DATETIME,
//--    CreatedDate DATETIME
//--);
 
 
//--INSERT INTO Users VALUES
//--('admin', 'Admin@123', 'admin@qmg.com', 'Admin', 1, 1, GETDATE(), NULL, 0),
//--('user1', 'User@123', 'user1@qmg.com', 'User', 2, 1, GETDATE(), NULL, 0),
//--('user2', 'User@123', 'user2@qmg.com', 'User', 2, 1, GETDATE(), NULL, 0);
 
 
//--INSERT INTO Employees VALUES
//--('Ravi Kumar', 'ravi@qmg.com', '9999999991', 'IT', 'Developer', 60000, 'Hyderabad', GETDATE(), 1),
//--('Sita Rao', 'sita@qmg.com', '9999999992', 'HR', 'HR Manager', 50000, 'Bangalore', GETDATE(), 1),
//--('John David', 'john@qmg.com', '9999999993', 'Finance', 'Accountant', 55000, 'Chennai', GETDATE(), 1);
 
 
//select* from Users where userid = 19
//select* from Users where userid = 20
//select* from Users
//--update Users set IsActive = 1 where userid = 16;
//--update Users set IsActive = 1 where userid = 19;
//--update Users set IsActive = 1 where userid = 20;
//        select top 3 * from Otps  order by OtpId desc;
//        select* from Tokens order by tokenid desc;
//select* from Employees
//select* from Doctors
//select* from Treatments
//select* from Appointments
//select  FirstName, LastName, * from Users
 
//--ALTER TABLE Users
//--ADD LastName VARCHAR(100);

//        exec sp_help 'Doctors'
 
//--ALTER TABLE Appointments
//--ADD Disease VARCHAR(100);
 
 
//--CREATE TABLE Doctors(
//--    DoctorId INT IDENTITY PRIMARY KEY,
//--    Name VARCHAR(100),
//--    Specialization VARCHAR(100),
//--    Email VARCHAR(100),
//--    IsAvailable BIT,
//--    CreatedDate DATETIME
//--);
//--INSERT INTO Doctors VALUES
//--('TejaDoctor', 'MultiSpeciality', 'tejadoctor@qmg.com',1, GETDATE())
 
//--INSERT INTO Doctors
//--(Name, Specialization, Email, IsAvailable, CreatedDate)
//--VALUES
//--('Dr. Ramesh', 'Cardiology', 'ramesh@hospital.com', 1, GETDATE()),
//--('Dr. Sita', 'Neurology', 'sita@hospital.com', 1, GETDATE());
 
//--CREATE TABLE Appointments(
//--    AppointmentId INT IDENTITY PRIMARY KEY,
//--    UserId INT,
//--    DoctorId INT,
//--    AppointmentDate DATETIME,
//--    Status VARCHAR(20),
//--    CreatedDate DATETIME
//--);
 
 
//--CREATE TABLE Treatments(
//--    TreatmentId INT IDENTITY PRIMARY KEY,
//--    AppointmentId INT,
//--    UserId INT,
//--    DoctorId INT,
//--    Disease VARCHAR(100),
//--    Diagnosis VARCHAR(200),
//--    Medicines VARCHAR(200),
//--    TreatmentNotes VARCHAR(300),
//--    Status VARCHAR(20), -- Active, Completed
//--    StartedDate DATETIME,
//--    CompletedDate DATETIME
//--);
 
 
//--ALTER TABLE Tokens
//--ADD IsActive BIT NOT NULL DEFAULT 1;
//    }
//}
