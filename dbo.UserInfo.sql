CREATE TABLE [dbo].[UserInfo] (
    [Id]        INT        NOT NULL  IDENTITY(1, 1),
    [FirstName] NCHAR (25) NOT NULL,
    [LastName]  NCHAR (25) NOT NULL,
    [Username]  NCHAR (25) NOT NULL,
    [Email]     NCHAR (50) NOT NULL,
    [Password]  NCHAR (25) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

