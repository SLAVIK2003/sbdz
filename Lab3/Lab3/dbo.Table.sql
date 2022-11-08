CREATE TABLE [dbo].[Users] (
    [User_Name] NVARCHAR (50) NOT NULL,
    [Password]  NCHAR (10)    NULL,
    [Level]     INT           NULL,
    PRIMARY KEY CLUSTERED ([User_Name] ASC)
);

