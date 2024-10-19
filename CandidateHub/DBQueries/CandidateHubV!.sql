---Scaffold-DbContext "Server=(localdb)\MSSQLLocalDB;Database=CandidateHubDb;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir "Entities" -force -context "CandidateContext" -NoOnConfiguring

CREATE TABLE CandidateDetail(
    CandidateId INT PRIMARY KEY IDENTITY(1,1),  -- Primary key with auto-increment
    FirstName NVARCHAR(100) NOT NULL,           -- Required
    LastName NVARCHAR(100) NOT NULL,            -- Required
    PhoneNumber NVARCHAR(15),                   -- Optional
    Email NVARCHAR(255) NOT NULL UNIQUE,        -- Required and unique
    CallTimeInterval NVARCHAR(50),              -- Optional (Time interval for better call)
    LinkedInProfileUrl NVARCHAR(255),           -- Optional
    GitHubProfileUrl NVARCHAR(255),             -- Optional
    FreeTextComment NVARCHAR(MAX) NOT NULL      -- Required
);
