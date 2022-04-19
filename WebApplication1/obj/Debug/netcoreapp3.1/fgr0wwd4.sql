IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [KeyItems] (
    [Key] nvarchar(450) NOT NULL,
    [Value] nvarchar(max) NULL,
    CONSTRAINT [PK_KeyItems] PRIMARY KEY ([Key])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220419055523_WebApplication1.Models.KeyvalueContext', N'3.0.0');

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Key', N'Value') AND [object_id] = OBJECT_ID(N'[KeyItems]'))
    SET IDENTITY_INSERT [KeyItems] ON;
INSERT INTO [KeyItems] ([Key], [Value])
VALUES (N'temp_word', N'74');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Key', N'Value') AND [object_id] = OBJECT_ID(N'[KeyItems]'))
    SET IDENTITY_INSERT [KeyItems] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Key', N'Value') AND [object_id] = OBJECT_ID(N'[KeyItems]'))
    SET IDENTITY_INSERT [KeyItems] ON;
INSERT INTO [KeyItems] ([Key], [Value])
VALUES (N'temp_art', N'44');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Key', N'Value') AND [object_id] = OBJECT_ID(N'[KeyItems]'))
    SET IDENTITY_INSERT [KeyItems] OFF;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220419062059_WebApplication1.Models.KeyvalueContextSeed', N'3.0.0');

GO

