Here's a polished and professional README for your project:

---

# HRM Project

This project is a basic setup for an HRM (Human Resource Management) system that includes a contacts table for storing employee contact information. Follow the steps below to get started.

## Steps to Run the Project

### 1. Clone the Project

Clone the repository to your local machine:
```bash
git clone <repository-url>
```

### 2. Install NuGet Packages

Navigate to the project directory and restore the required NuGet packages:
```bash
dotnet restore
```

### 3. Set Up the Database

Create a new MSSQL Database, then run the following SQL script to set up the `Contacts` table:

```sql
CREATE DATABASE hrm;
USE [HRM];

CREATE TABLE [dbo].[Contacts](
	[ContactId] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[FirstName] [nvarchar](100) NOT NULL,
	[LastName] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](256) NOT NULL,
	[PhoneNumber] [varchar](10) NULL,
	[TimeInterval] [nvarchar](100) NULL,
	[Comments] [nvarchar](100) NULL,
	[LinkedIn] [nvarchar](200) NULL,
	[GitHub] [nvarchar](200) NULL,
	[CreatedOn] [datetime2](7) NOT NULL,
	[UpdatedOn] [datetime2](7) NULL,
	[CreatedById] [int] NOT NULL,
	[UpdatedById] [int] NULL
	)

```

### 4. Configure the Database Connection

Update the `appsettings.json` file with your `DatabaseConnectionString` to point to your newly created `hrm` database.

### 5. Authentication

For authentication, the application currently checks for a default Bearer token. Use the following token to make authenticated requests:
```
Bearer 28bd6087-6b23-4a6c-971b-490e014c2563
```
> **Note:** This token check is a placeholder and should be replaced with JWT or another authentication mechanism for production use.

### 6. Future Enhancements

The `Contacts` table currently stores all contact-related information. To improve performance and normalization, consider splitting the table into the following:

- `Contacts`: Store basic contact details.
- `ContactSocialInformation`: Store social media information.
- `ContactNotes`: Store additional notes and comments.

---

Feel free to contribute or report any issues!
