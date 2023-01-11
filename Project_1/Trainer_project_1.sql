
CREATE TABLE Users
(
    [User_ID] INT,
    [Email_ID] VARCHAR(50) NOT NULL,
    [Password] VARCHAR(20) NOT NULL,
    [Firstname] VARCHAR(50),
    [Lastname] VARCHAR(50),
    [Age] TINYINT,
    [Gender] VARCHAR(15),
    [Phone_Number] BIGINT,
    [City] VARCHAR(50),
    CONSTRAINT [PK_User] PRIMARY KEY(User_ID)
);
GO

CREATE TABLE Education
(
    [User_ID] INT,
    [Ug_collage] VARCHAR(200) NOT NULL,
    [Ug_stream] VARCHAR(200) NOT NULL,
    [Ug_Percentage] TINYINT NOT NULL,
    [Ug_year] INT NOT NULL,
    [Pg_collage] VARCHAR(200),
    [Pg_stream] VARCHAR(200),
    [Pg_Percentage] TINYINT,
    [Pg_year] INT,
    CONSTRAINT [PK_Education] PRIMARY KEY(User_ID),
    CONSTRAINT [FK_Education] FOREIGN KEY(User_ID) REFERENCES Users(User_ID) ON DELETE CASCADE ON UPDATE CASCADE
);
GO


CREATE TABLE Skill
(
    [User_ID] INT,
    [Skill_1] VARCHAR(50) Not null,
    [Skill_2] VARCHAR(50) Not null,
    [Skill_3] VARCHAR(50),
    CONSTRAINT [PK_Skill] PRIMARY KEY(User_ID),
    CONSTRAINT [FK_Skill] FOREIGN KEY(User_ID) REFERENCES Users(User_ID) ON DELETE CASCADE ON UPDATE CASCADE
);
GO


CREATE TABLE Company
(
    [User_ID] INT,
    [Company_Name] VARCHAR(100),
    [Field] VARCHAR(100),
    [Overall_Experience] VARCHAR(50)
    CONSTRAINT [PK_Company] PRIMARY KEY(User_ID),
    CONSTRAINT [FK_Company] FOREIGN KEY(User_ID) REFERENCES Users(User_ID) ON DELETE CASCADE ON UPDATE CASCADE
);
GO

