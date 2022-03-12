IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210416054448_initial')
BEGIN
    CREATE TABLE [Counterparties] (
        [Counterparty_ID] int NOT NULL IDENTITY,
        [Other_Details] nvarchar(max) NULL,
        CONSTRAINT [PK_Counterparties] PRIMARY KEY ([Counterparty_ID])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210416054448_initial')
BEGIN
    CREATE TABLE [Ref_Payment_Methods] (
        [Payment_Method_Code] int NOT NULL IDENTITY,
        [Payment_Method_Name] int NOT NULL,
        CONSTRAINT [PK_Ref_Payment_Methods] PRIMARY KEY ([Payment_Method_Code])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210416054448_initial')
BEGIN
    CREATE TABLE [Ref_Transaction_Status] (
        [Trans_Status_Code] int NOT NULL IDENTITY,
        [Trans_Status_Description] int NOT NULL,
        CONSTRAINT [PK_Ref_Transaction_Status] PRIMARY KEY ([Trans_Status_Code])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210416054448_initial')
BEGIN
    CREATE TABLE [Ref_Transaction_Types] (
        [Trans_Type_Code] int NOT NULL IDENTITY,
        [Trans_Type_Description] int NOT NULL,
        CONSTRAINT [PK_Ref_Transaction_Types] PRIMARY KEY ([Trans_Type_Code])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210416054448_initial')
BEGIN
    CREATE TABLE [Services] (
        [Service_ID] int NOT NULL IDENTITY,
        [Date_Service_Provided] datetime2 NOT NULL,
        [Other_Details] nvarchar(max) NULL,
        CONSTRAINT [PK_Services] PRIMARY KEY ([Service_ID])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210416054448_initial')
BEGIN
    CREATE TABLE [Financial_Transactions] (
        [Transaction_ID] int NOT NULL IDENTITY,
        [Account_ID] int NOT NULL,
        [Counterparty_ID] int NOT NULL,
        [Date_of_Transaction] datetime2 NOT NULL,
        [Amount_of_Transaction] float NOT NULL,
        [Other_Details] nvarchar(max) NULL,
        [Payment_Method_Code] int NOT NULL,
        [Trans_Type_Code] int NOT NULL,
        [Trans_Status_Code] int NOT NULL,
        [Service_ID] int NOT NULL,
        CONSTRAINT [PK_Financial_Transactions] PRIMARY KEY ([Transaction_ID]),
        CONSTRAINT [FK_Financial_Transactions_Counterparties_Counterparty_ID] FOREIGN KEY ([Counterparty_ID]) REFERENCES [Counterparties] ([Counterparty_ID]) ON DELETE CASCADE,
        CONSTRAINT [FK_Financial_Transactions_Ref_Payment_Methods_Payment_Method_Code] FOREIGN KEY ([Payment_Method_Code]) REFERENCES [Ref_Payment_Methods] ([Payment_Method_Code]) ON DELETE CASCADE,
        CONSTRAINT [FK_Financial_Transactions_Services_Service_ID] FOREIGN KEY ([Service_ID]) REFERENCES [Services] ([Service_ID]) ON DELETE CASCADE,
        CONSTRAINT [FK_Financial_Transactions_Ref_Transaction_Status_Trans_Status_Code] FOREIGN KEY ([Trans_Status_Code]) REFERENCES [Ref_Transaction_Status] ([Trans_Status_Code]) ON DELETE CASCADE,
        CONSTRAINT [FK_Financial_Transactions_Ref_Transaction_Types_Trans_Type_Code] FOREIGN KEY ([Trans_Type_Code]) REFERENCES [Ref_Transaction_Types] ([Trans_Type_Code]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210416054448_initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Counterparty_ID', N'Other_Details') AND [object_id] = OBJECT_ID(N'[Counterparties]'))
        SET IDENTITY_INSERT [Counterparties] ON;
    INSERT INTO [Counterparties] ([Counterparty_ID], [Other_Details])
    VALUES (1, N'Other Details 1'),
    (2, N'Other Details 2'),
    (3, N'Other Details 3');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Counterparty_ID', N'Other_Details') AND [object_id] = OBJECT_ID(N'[Counterparties]'))
        SET IDENTITY_INSERT [Counterparties] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210416054448_initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Payment_Method_Code', N'Payment_Method_Name') AND [object_id] = OBJECT_ID(N'[Ref_Payment_Methods]'))
        SET IDENTITY_INSERT [Ref_Payment_Methods] ON;
    INSERT INTO [Ref_Payment_Methods] ([Payment_Method_Code], [Payment_Method_Name])
    VALUES (5, 4),
    (4, 3),
    (6, 5),
    (2, 1),
    (1, 0),
    (3, 2);
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Payment_Method_Code', N'Payment_Method_Name') AND [object_id] = OBJECT_ID(N'[Ref_Payment_Methods]'))
        SET IDENTITY_INSERT [Ref_Payment_Methods] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210416054448_initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Trans_Status_Code', N'Trans_Status_Description') AND [object_id] = OBJECT_ID(N'[Ref_Transaction_Status]'))
        SET IDENTITY_INSERT [Ref_Transaction_Status] ON;
    INSERT INTO [Ref_Transaction_Status] ([Trans_Status_Code], [Trans_Status_Description])
    VALUES (1, 1),
    (2, 0),
    (3, 2);
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Trans_Status_Code', N'Trans_Status_Description') AND [object_id] = OBJECT_ID(N'[Ref_Transaction_Status]'))
        SET IDENTITY_INSERT [Ref_Transaction_Status] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210416054448_initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Trans_Type_Code', N'Trans_Type_Description') AND [object_id] = OBJECT_ID(N'[Ref_Transaction_Types]'))
        SET IDENTITY_INSERT [Ref_Transaction_Types] ON;
    INSERT INTO [Ref_Transaction_Types] ([Trans_Type_Code], [Trans_Type_Description])
    VALUES (1, 0),
    (2, 1),
    (3, 2);
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Trans_Type_Code', N'Trans_Type_Description') AND [object_id] = OBJECT_ID(N'[Ref_Transaction_Types]'))
        SET IDENTITY_INSERT [Ref_Transaction_Types] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210416054448_initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Service_ID', N'Date_Service_Provided', N'Other_Details') AND [object_id] = OBJECT_ID(N'[Services]'))
        SET IDENTITY_INSERT [Services] ON;
    INSERT INTO [Services] ([Service_ID], [Date_Service_Provided], [Other_Details])
    VALUES (2, '2021-04-16T11:14:48.3611388+05:30', N'Other Details 1'),
    (1, '2021-04-16T11:14:48.3610103+05:30', N'Other Details 1'),
    (3, '2021-04-16T11:14:48.3611414+05:30', N'Other Details 1');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Service_ID', N'Date_Service_Provided', N'Other_Details') AND [object_id] = OBJECT_ID(N'[Services]'))
        SET IDENTITY_INSERT [Services] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210416054448_initial')
BEGIN
    CREATE INDEX [IX_Financial_Transactions_Counterparty_ID] ON [Financial_Transactions] ([Counterparty_ID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210416054448_initial')
BEGIN
    CREATE INDEX [IX_Financial_Transactions_Payment_Method_Code] ON [Financial_Transactions] ([Payment_Method_Code]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210416054448_initial')
BEGIN
    CREATE INDEX [IX_Financial_Transactions_Service_ID] ON [Financial_Transactions] ([Service_ID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210416054448_initial')
BEGIN
    CREATE INDEX [IX_Financial_Transactions_Trans_Status_Code] ON [Financial_Transactions] ([Trans_Status_Code]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210416054448_initial')
BEGIN
    CREATE INDEX [IX_Financial_Transactions_Trans_Type_Code] ON [Financial_Transactions] ([Trans_Type_Code]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210416054448_initial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210416054448_initial', N'3.1.13');
END;

GO

