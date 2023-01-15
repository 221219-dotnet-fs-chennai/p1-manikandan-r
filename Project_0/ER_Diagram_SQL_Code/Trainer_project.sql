

CREATE TABLE TrainerDetails
(
    [User_ID] VARCHAR(50),
    [Email_ID] VARCHAR(50) NOT NULL,
    [Password] VARCHAR(20) NOT NULL,
    [Firstname] VARCHAR(50),
    [Lastname] VARCHAR(50),
    [Age] INT,
    [Gender] VARCHAR(15),
    [Phone_Number] VARCHAR(15),
    [City] VARCHAR(50),
    CONSTRAINT [PK_User] PRIMARY KEY(User_ID)
);
GO

CREATE TABLE Education
(
    [User_ID] VARCHAR(50),
    [Ug_collage] VARCHAR(200) NOT NULL,
    [Ug_stream] VARCHAR(200) NOT NULL,
    [Ug_Percentage] VARCHAR(10) NOT NULL,
    [Ug_year] VARCHAR(10) NOT NULL,
    [Pg_collage] VARCHAR(200),
    [Pg_stream] VARCHAR(200),
    [Pg_Percentage] VARCHAR(10),
    [Pg_year] VARCHAR(10),
    CONSTRAINT [PK_Education] PRIMARY KEY(User_ID),
    CONSTRAINT [FK_Education] FOREIGN KEY(User_ID) REFERENCES TrainerDetails(User_ID) ON DELETE CASCADE ON UPDATE CASCADE
);
GO


CREATE TABLE Skill
(
    [User_ID] VARCHAR(50),
    [Skill_1] VARCHAR(50) Not null,
    [Skill_2] VARCHAR(50) Not null,
    [Skill_3] VARCHAR(50),
    CONSTRAINT [PK_Skill] PRIMARY KEY(User_ID),
    CONSTRAINT [FK_Skill] FOREIGN KEY(User_ID) REFERENCES TrainerDetails(User_ID) ON DELETE CASCADE ON UPDATE CASCADE
);
GO


CREATE TABLE Company
(
    [User_ID] VARCHAR(50),
    [Company_Name] VARCHAR(100),
    [Field] VARCHAR(100),
    [Overall_Experience] VARCHAR(50)
    CONSTRAINT [PK_Company] PRIMARY KEY(User_ID),
    CONSTRAINT [FK_Company] FOREIGN KEY(User_ID) REFERENCES TrainerDetails(User_ID) ON DELETE CASCADE ON UPDATE CASCADE
);
GO

create table userTable(
	userEmail varchar(50),
	[password] varchar(15)
);
