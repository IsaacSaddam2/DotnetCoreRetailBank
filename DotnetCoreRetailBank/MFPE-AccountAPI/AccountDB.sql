IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210416054210_initial')
BEGIN
    CREATE TABLE [Accounts] (
        [AccountId] int NOT NULL IDENTITY,
        [AccountType] int NOT NULL,
        [Balance] float NOT NULL,
        [CustomerId] int NOT NULL,
        CONSTRAINT [PK_Accounts] PRIMARY KEY ([AccountId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210416054210_initial')
BEGIN
    CREATE TABLE [Statements] (
        [Id] int NOT NULL IDENTITY,
        [AccountId] int NOT NULL,
        [Date] datetime2 NOT NULL,
        [Narration] nvarchar(max) NULL,
        [RefNo] nvarchar(max) NOT NULL,
        [ValueDate] datetime2 NOT NULL,
        [Withdrawal] float NOT NULL,
        [Deposit] float NOT NULL,
        [ClosingBalance] float NOT NULL,
        CONSTRAINT [PK_Statements] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Statements_Accounts_AccountId] FOREIGN KEY ([AccountId]) REFERENCES [Accounts] ([AccountId]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210416054210_initial')
BEGIN
    CREATE TABLE [TransactionStatuses] (
        [TransactionId] int NOT NULL IDENTITY,
        [AccountId] int NOT NULL,
        [Message] nvarchar(100) NOT NULL,
        [SourceBalance] float NOT NULL,
        [DestinationBalance] float NOT NULL,
        [currentBalance] float NOT NULL,
        CONSTRAINT [PK_TransactionStatuses] PRIMARY KEY ([TransactionId]),
        CONSTRAINT [FK_TransactionStatuses_Accounts_AccountId] FOREIGN KEY ([AccountId]) REFERENCES [Accounts] ([AccountId]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210416054210_initial')
BEGIN
    CREATE INDEX [IX_Statements_AccountId] ON [Statements] ([AccountId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210416054210_initial')
BEGIN
    CREATE INDEX [IX_TransactionStatuses_AccountId] ON [TransactionStatuses] ([AccountId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210416054210_initial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210416054210_initial', N'3.1.13');
END;

GO

