CREATE TABLE [dbo].[Cars] (
    [Id]    INT        NOT NULL,
    [Brand] NCHAR (20) NOT NULL,
    [Model] NCHAR (40) NOT NULL,
    [Trim]  NCHAR (40) NOT NULL,
    [Year]  INT        NOT NULL,
    [Price] INT        NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

