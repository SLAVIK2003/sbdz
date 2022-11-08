CREATE TABLE [dbo].[View] (
    [Id_car] INT           NOT NULL,
    [Brand]  NVARCHAR (50) NULL,
    [Model]  NVARCHAR (50) NOT NULL,
    [Trim]   NVARCHAR (50) NOT NULL,
    [Year]   INT           NOT NULL,
    [Price]  INT           NOT NULL,
    [Photos] IMAGE         NOT NULL,
    PRIMARY KEY CLUSTERED ([Id_car] ASC)
);

