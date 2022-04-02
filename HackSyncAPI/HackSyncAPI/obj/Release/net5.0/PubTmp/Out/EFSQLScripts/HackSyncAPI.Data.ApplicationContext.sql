IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402055119_HackSyncAPI.Data.ApplicationContext')
BEGIN
    CREATE TABLE [AspNetRoles] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402055119_HackSyncAPI.Data.ApplicationContext')
BEGIN
    CREATE TABLE [Tbl_Organization_Master] (
        [Id] int NOT NULL IDENTITY,
        [Organization_Name] nvarchar(255) NOT NULL,
        [Organization_Email] nvarchar(255) NOT NULL,
        [Organization_Password] nvarchar(255) NOT NULL,
        [Organization_EventName] nvarchar(255) NOT NULL,
        [Organization_EventDate] datetime2 NOT NULL,
        [Organization_EventKey] nvarchar(max) NULL,
        [Organization_PhoneNo] nvarchar(11) NOT NULL,
        [Organization_TelNo] nvarchar(11) NOT NULL,
        [Team_Size] int NOT NULL,
        [Is_Exist] bit NOT NULL,
        [Created_On] datetime2 NOT NULL,
        [Updated_On] datetime2 NOT NULL,
        [IsDeleted] bit NOT NULL,
        CONSTRAINT [PK_Tbl_Organization_Master] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402055119_HackSyncAPI.Data.ApplicationContext')
BEGIN
    CREATE TABLE [AspNetRoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402055119_HackSyncAPI.Data.ApplicationContext')
BEGIN
    CREATE TABLE [Tbl_Defination_Master] (
        [Id] int NOT NULL IDENTITY,
        [Defination_Name] nvarchar(max) NULL,
        [OrganizationId] int NOT NULL,
        [Created_On] datetime2 NOT NULL,
        [Updated_On] datetime2 NOT NULL,
        [IsDeleted] bit NOT NULL,
        CONSTRAINT [PK_Tbl_Defination_Master] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Tbl_Defination_Master_Tbl_Organization_Master_OrganizationId] FOREIGN KEY ([OrganizationId]) REFERENCES [Tbl_Organization_Master] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402055119_HackSyncAPI.Data.ApplicationContext')
BEGIN
    CREATE TABLE [Tbl_Stack_Master] (
        [Id] int NOT NULL IDENTITY,
        [Stack_Name] nvarchar(max) NULL,
        [OrganizationId] int NOT NULL,
        [Created_On] datetime2 NOT NULL,
        [Updated_On] datetime2 NOT NULL,
        [IsDeleted] bit NOT NULL,
        CONSTRAINT [PK_Tbl_Stack_Master] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Tbl_Stack_Master_Tbl_Organization_Master_OrganizationId] FOREIGN KEY ([OrganizationId]) REFERENCES [Tbl_Organization_Master] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402055119_HackSyncAPI.Data.ApplicationContext')
BEGIN
    CREATE TABLE [AspNetUsers] (
        [Id] nvarchar(450) NOT NULL,
        [FirstName] nvarchar(max) NULL,
        [LastName] nvarchar(max) NULL,
        [OrganizationId] int NOT NULL,
        [StackId] int NOT NULL,
        [Defination_Id] int NOT NULL,
        [IsAvailable] bit NOT NULL,
        [UserName] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [Email] nvarchar(256) NULL,
        [NormalizedEmail] nvarchar(256) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUsers_Tbl_Defination_Master_Defination_Id] FOREIGN KEY ([Defination_Id]) REFERENCES [Tbl_Defination_Master] ([Id]),
        CONSTRAINT [FK_AspNetUsers_Tbl_Organization_Master_OrganizationId] FOREIGN KEY ([OrganizationId]) REFERENCES [Tbl_Organization_Master] ([Id]),
        CONSTRAINT [FK_AspNetUsers_Tbl_Stack_Master_StackId] FOREIGN KEY ([StackId]) REFERENCES [Tbl_Stack_Master] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402055119_HackSyncAPI.Data.ApplicationContext')
BEGIN
    CREATE TABLE [AspNetUserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402055119_HackSyncAPI.Data.ApplicationContext')
BEGIN
    CREATE TABLE [AspNetUserLogins] (
        [LoginProvider] nvarchar(450) NOT NULL,
        [ProviderKey] nvarchar(450) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402055119_HackSyncAPI.Data.ApplicationContext')
BEGIN
    CREATE TABLE [AspNetUserRoles] (
        [UserId] nvarchar(450) NOT NULL,
        [RoleId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402055119_HackSyncAPI.Data.ApplicationContext')
BEGIN
    CREATE TABLE [AspNetUserTokens] (
        [UserId] nvarchar(450) NOT NULL,
        [LoginProvider] nvarchar(450) NOT NULL,
        [Name] nvarchar(450) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402055119_HackSyncAPI.Data.ApplicationContext')
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402055119_HackSyncAPI.Data.ApplicationContext')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402055119_HackSyncAPI.Data.ApplicationContext')
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402055119_HackSyncAPI.Data.ApplicationContext')
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402055119_HackSyncAPI.Data.ApplicationContext')
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402055119_HackSyncAPI.Data.ApplicationContext')
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402055119_HackSyncAPI.Data.ApplicationContext')
BEGIN
    CREATE INDEX [IX_AspNetUsers_Defination_Id] ON [AspNetUsers] ([Defination_Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402055119_HackSyncAPI.Data.ApplicationContext')
BEGIN
    CREATE INDEX [IX_AspNetUsers_OrganizationId] ON [AspNetUsers] ([OrganizationId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402055119_HackSyncAPI.Data.ApplicationContext')
BEGIN
    CREATE INDEX [IX_AspNetUsers_StackId] ON [AspNetUsers] ([StackId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402055119_HackSyncAPI.Data.ApplicationContext')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402055119_HackSyncAPI.Data.ApplicationContext')
BEGIN
    CREATE INDEX [IX_Tbl_Defination_Master_OrganizationId] ON [Tbl_Defination_Master] ([OrganizationId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402055119_HackSyncAPI.Data.ApplicationContext')
BEGIN
    CREATE INDEX [IX_Tbl_Stack_Master_OrganizationId] ON [Tbl_Stack_Master] ([OrganizationId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402055119_HackSyncAPI.Data.ApplicationContext')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220402055119_HackSyncAPI.Data.ApplicationContext', N'5.0.15');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402065008_Genrate_Tables')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220402065008_Genrate_Tables', N'5.0.15');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402065417_Genrate_All_Tables')
BEGIN
    CREATE TABLE [Tbl_TeamLeaderModels] (
        [Id] int NOT NULL IDENTITY,
        [userId] nvarchar(450) NULL,
        [OrganizationId] int NOT NULL,
        [Created_On] datetime2 NOT NULL,
        [Updated_On] datetime2 NOT NULL,
        [IsDeleted] bit NOT NULL,
        CONSTRAINT [PK_Tbl_TeamLeaderModels] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Tbl_TeamLeaderModels_AspNetUsers_userId] FOREIGN KEY ([userId]) REFERENCES [AspNetUsers] ([Id]),
        CONSTRAINT [FK_Tbl_TeamLeaderModels_Tbl_Organization_Master_OrganizationId] FOREIGN KEY ([OrganizationId]) REFERENCES [Tbl_Organization_Master] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402065417_Genrate_All_Tables')
BEGIN
    CREATE TABLE [Tbl_TeamMasterModels] (
        [Id] int NOT NULL IDENTITY,
        [Team_Name] nvarchar(max) NULL,
        [TeamLeader_Id] int NOT NULL,
        [OrganizationId] int NOT NULL,
        [Created_On] datetime2 NOT NULL,
        [Updated_On] datetime2 NOT NULL,
        [IsDeleted] bit NOT NULL,
        CONSTRAINT [PK_Tbl_TeamMasterModels] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Tbl_TeamMasterModels_Tbl_Organization_Master_OrganizationId] FOREIGN KEY ([OrganizationId]) REFERENCES [Tbl_Organization_Master] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Tbl_TeamMasterModels_Tbl_TeamLeaderModels_TeamLeader_Id] FOREIGN KEY ([TeamLeader_Id]) REFERENCES [Tbl_TeamLeaderModels] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402065417_Genrate_All_Tables')
BEGIN
    CREATE TABLE [Tbl_MyTeamAllocationModels] (
        [Id] int NOT NULL IDENTITY,
        [TeamId] int NOT NULL,
        [OrganizationId] int NOT NULL,
        [userId] nvarchar(450) NULL,
        [Created_On] datetime2 NOT NULL,
        [Updated_On] datetime2 NOT NULL,
        [IsDeleted] bit NOT NULL,
        CONSTRAINT [PK_Tbl_MyTeamAllocationModels] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Tbl_MyTeamAllocationModels_AspNetUsers_userId] FOREIGN KEY ([userId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Tbl_MyTeamAllocationModels_Tbl_Organization_Master_OrganizationId] FOREIGN KEY ([OrganizationId]) REFERENCES [Tbl_Organization_Master] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Tbl_MyTeamAllocationModels_Tbl_TeamMasterModels_TeamId] FOREIGN KEY ([TeamId]) REFERENCES [Tbl_TeamMasterModels] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402065417_Genrate_All_Tables')
BEGIN
    CREATE INDEX [IX_Tbl_MyTeamAllocationModels_OrganizationId] ON [Tbl_MyTeamAllocationModels] ([OrganizationId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402065417_Genrate_All_Tables')
BEGIN
    CREATE INDEX [IX_Tbl_MyTeamAllocationModels_TeamId] ON [Tbl_MyTeamAllocationModels] ([TeamId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402065417_Genrate_All_Tables')
BEGIN
    CREATE INDEX [IX_Tbl_MyTeamAllocationModels_userId] ON [Tbl_MyTeamAllocationModels] ([userId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402065417_Genrate_All_Tables')
BEGIN
    CREATE INDEX [IX_Tbl_TeamLeaderModels_OrganizationId] ON [Tbl_TeamLeaderModels] ([OrganizationId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402065417_Genrate_All_Tables')
BEGIN
    CREATE INDEX [IX_Tbl_TeamLeaderModels_userId] ON [Tbl_TeamLeaderModels] ([userId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402065417_Genrate_All_Tables')
BEGIN
    CREATE INDEX [IX_Tbl_TeamMasterModels_OrganizationId] ON [Tbl_TeamMasterModels] ([OrganizationId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402065417_Genrate_All_Tables')
BEGIN
    CREATE INDEX [IX_Tbl_TeamMasterModels_TeamLeader_Id] ON [Tbl_TeamMasterModels] ([TeamLeader_Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402065417_Genrate_All_Tables')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220402065417_Genrate_All_Tables', N'5.0.15');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402081318_updateFKinUsertable')
BEGIN
    ALTER TABLE [AspNetUsers] DROP CONSTRAINT [FK_AspNetUsers_Tbl_Defination_Master_Defination_Id];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402081318_updateFKinUsertable')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUsers]') AND [c].[name] = N'Defination_Id');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUsers] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [AspNetUsers] ALTER COLUMN [Defination_Id] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402081318_updateFKinUsertable')
BEGIN
    ALTER TABLE [AspNetUsers] ADD CONSTRAINT [FK_AspNetUsers_Tbl_Defination_Master_Defination_Id] FOREIGN KEY ([Defination_Id]) REFERENCES [Tbl_Defination_Master] ([Id]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402081318_updateFKinUsertable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220402081318_updateFKinUsertable', N'5.0.15');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402081722_RoleSeeds')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
        SET IDENTITY_INSERT [AspNetRoles] ON;
    EXEC(N'INSERT INTO [AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName])
    VALUES (N''094afa8c-69e3-4103-a542-8aee12940f9a'', N''e04c8f1d-b56f-4c40-a0b1-9a6507ba253d'', N''Organization'', N''ORGANIZATION''),
    (N''9f074bba-372c-474e-81a2-92e877a73075'', N''3a2174a6-da0d-4a99-af51-74f88b20bb68'', N''TeamMate'', N''TEAMMATE''),
    (N''24fee6f4-834d-4c45-a3e9-313a175b64b6'', N''603415a3-2ce5-4156-839b-e5b984c1ffa3'', N''TeamLeader'', N''TEAMLEADER'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
        SET IDENTITY_INSERT [AspNetRoles] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402081722_RoleSeeds')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AccessFailedCount', N'ConcurrencyStamp', N'Defination_Id', N'Email', N'EmailConfirmed', N'FirstName', N'IsAvailable', N'LastName', N'LockoutEnabled', N'LockoutEnd', N'NormalizedEmail', N'NormalizedUserName', N'OrganizationId', N'PasswordHash', N'PhoneNumber', N'PhoneNumberConfirmed', N'SecurityStamp', N'StackId', N'TwoFactorEnabled', N'UserName') AND [object_id] = OBJECT_ID(N'[AspNetUsers]'))
        SET IDENTITY_INSERT [AspNetUsers] ON;
    EXEC(N'INSERT INTO [AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Defination_Id], [Email], [EmailConfirmed], [FirstName], [IsAvailable], [LastName], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [OrganizationId], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [StackId], [TwoFactorEnabled], [UserName])
    VALUES (N''5b2546a3-3e7a-454e-ac18-52d4cae97b2f'', 0, N''885853bb-0320-42d0-a00a-6012ae23e270'', NULL, N''jariwaladhruvin@gmail.com'', CAST(1 AS bit), N''Dhruvin'', CAST(1 AS bit), N''Jariwala'', CAST(0 AS bit), NULL, N''JARIWALADHRUVIN@GMAIL.COM'', N''DHRUVIN'', 5, N''AQAAAAEAACcQAAAAEG2zK9t1PZ2X9KcBUH6v8ipytojF5Bg8M1u5ZcZNFwM45EmrwF9FvHEO8J+ZJb8kbg=='', NULL, CAST(0 AS bit), N''0f3a1c77-caed-4078-be29-23b6d58405d3'', 3, CAST(0 AS bit), N''Dhruvin''),
    (N''4b2546a3-3e7a-424e-ac18-52d4cae97b2f'', 0, N''429bdf20-e9cd-4a91-8387-479f9b111a26'', NULL, N''user@gmail.com'', CAST(1 AS bit), N''system'', CAST(1 AS bit), N''user'', CAST(0 AS bit), NULL, N''USER@GMAIL.COM'', N''SYSTEM'', 5, N''AQAAAAEAACcQAAAAEPbDhJT8VmUUlkExBl+O4V59mRFlucG4f9TZGV+9yBsdTFvHnwK89Hc5SEob6oSgZg=='', NULL, CAST(0 AS bit), N''0caf837a-e380-48f2-a0c9-22a91aa41b7c'', 3, CAST(0 AS bit), N''system'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AccessFailedCount', N'ConcurrencyStamp', N'Defination_Id', N'Email', N'EmailConfirmed', N'FirstName', N'IsAvailable', N'LastName', N'LockoutEnabled', N'LockoutEnd', N'NormalizedEmail', N'NormalizedUserName', N'OrganizationId', N'PasswordHash', N'PhoneNumber', N'PhoneNumberConfirmed', N'SecurityStamp', N'StackId', N'TwoFactorEnabled', N'UserName') AND [object_id] = OBJECT_ID(N'[AspNetUsers]'))
        SET IDENTITY_INSERT [AspNetUsers] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402081722_RoleSeeds')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'RoleId', N'UserId') AND [object_id] = OBJECT_ID(N'[AspNetUserRoles]'))
        SET IDENTITY_INSERT [AspNetUserRoles] ON;
    EXEC(N'INSERT INTO [AspNetUserRoles] ([RoleId], [UserId])
    VALUES (N''9f074bba-372c-474e-81a2-92e877a73075'', N''4b2546a3-3e7a-424e-ac18-52d4cae97b2f'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'RoleId', N'UserId') AND [object_id] = OBJECT_ID(N'[AspNetUserRoles]'))
        SET IDENTITY_INSERT [AspNetUserRoles] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402081722_RoleSeeds')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'RoleId', N'UserId') AND [object_id] = OBJECT_ID(N'[AspNetUserRoles]'))
        SET IDENTITY_INSERT [AspNetUserRoles] ON;
    EXEC(N'INSERT INTO [AspNetUserRoles] ([RoleId], [UserId])
    VALUES (N''24fee6f4-834d-4c45-a3e9-313a175b64b6'', N''5b2546a3-3e7a-454e-ac18-52d4cae97b2f'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'RoleId', N'UserId') AND [object_id] = OBJECT_ID(N'[AspNetUserRoles]'))
        SET IDENTITY_INSERT [AspNetUserRoles] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402081722_RoleSeeds')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220402081722_RoleSeeds', N'5.0.15');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402082353_Update_databaseField')
BEGIN
    ALTER TABLE [AspNetUsers] DROP CONSTRAINT [FK_AspNetUsers_Tbl_Defination_Master_Defination_Id];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402082353_Update_databaseField')
BEGIN
    DROP INDEX [IX_AspNetUsers_Defination_Id] ON [AspNetUsers];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402082353_Update_databaseField')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUsers]') AND [c].[name] = N'Defination_Id');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUsers] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [AspNetUsers] DROP COLUMN [Defination_Id];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402082353_Update_databaseField')
BEGIN
    ALTER TABLE [Tbl_TeamMasterModels] ADD [Defination_Id] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402082353_Update_databaseField')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''8068a4a1-80e6-4d36-aded-d2a28e700d6d''
    WHERE [Id] = N''094afa8c-69e3-4103-a542-8aee12940f9a'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402082353_Update_databaseField')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''d356de46-ff02-4a4a-973d-923d4f11c332''
    WHERE [Id] = N''24fee6f4-834d-4c45-a3e9-313a175b64b6'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402082353_Update_databaseField')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''df0cada7-2960-4a32-a11d-dbae4dc5ef1b''
    WHERE [Id] = N''9f074bba-372c-474e-81a2-92e877a73075'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402082353_Update_databaseField')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''52cc9c7d-7b9a-4f4b-aba6-501cbcffe255'', [PasswordHash] = N''AQAAAAEAACcQAAAAEP8/C+8oT/GQjjRZlHmZ454CzYbI3ijbvwrRP2GsUvqdjS3z6haT3JnrOzEFmRFwCQ=='', [SecurityStamp] = N''956c742f-648b-4237-afd0-29483e9bbc8e''
    WHERE [Id] = N''4b2546a3-3e7a-424e-ac18-52d4cae97b2f'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402082353_Update_databaseField')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''7a9bb71c-30db-4b87-a0b0-bd8e66914579'', [PasswordHash] = N''AQAAAAEAACcQAAAAEKYaohz/geUEiSty/0Ldor5/7Ox6cZAIRLAU84jRvyQ4nSnZLnkdCrtm0hlvtk8GmQ=='', [SecurityStamp] = N''22e418d7-bfba-45b5-8296-4870280ac7bf''
    WHERE [Id] = N''5b2546a3-3e7a-454e-ac18-52d4cae97b2f'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402082353_Update_databaseField')
BEGIN
    CREATE INDEX [IX_Tbl_TeamMasterModels_Defination_Id] ON [Tbl_TeamMasterModels] ([Defination_Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402082353_Update_databaseField')
BEGIN
    ALTER TABLE [Tbl_TeamMasterModels] ADD CONSTRAINT [FK_Tbl_TeamMasterModels_Tbl_Defination_Master_Defination_Id] FOREIGN KEY ([Defination_Id]) REFERENCES [Tbl_Defination_Master] ([Id]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402082353_Update_databaseField')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220402082353_Update_databaseField', N'5.0.15');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402103342_Update_IsLeaderId')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [IsLeader] bit NOT NULL DEFAULT CAST(0 AS bit);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402103342_Update_IsLeaderId')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''e44c7592-3ec7-4782-b2e4-738785162359''
    WHERE [Id] = N''094afa8c-69e3-4103-a542-8aee12940f9a'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402103342_Update_IsLeaderId')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''d63c3411-ea62-4ae0-8008-94136ca028c5''
    WHERE [Id] = N''24fee6f4-834d-4c45-a3e9-313a175b64b6'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402103342_Update_IsLeaderId')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''18705ccc-4764-4d29-ab3c-79339e8b8598''
    WHERE [Id] = N''9f074bba-372c-474e-81a2-92e877a73075'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402103342_Update_IsLeaderId')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''13647b1b-c439-4d83-98d1-654f677a277f'', [PasswordHash] = N''AQAAAAEAACcQAAAAEPoVDHqb1317lcFSUuvo4mwTV2A7jYGHmiexJaTkisy9JgBICF7qEiHdRofRAXmOcA=='', [SecurityStamp] = N''52315fe9-8526-4c16-8667-2e156c84893a''
    WHERE [Id] = N''4b2546a3-3e7a-424e-ac18-52d4cae97b2f'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402103342_Update_IsLeaderId')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''eaca6ef3-838b-4b79-b082-ccf1af895bad'', [PasswordHash] = N''AQAAAAEAACcQAAAAEItMSyy1BXsVbUDalcmLX3cxxz1gr/CZuRM2eBbJGpx8KBYjaYRCru8nGlfN2XaPTQ=='', [SecurityStamp] = N''f8af9b59-cc8e-441c-80e3-dbe82f003844''
    WHERE [Id] = N''5b2546a3-3e7a-454e-ac18-52d4cae97b2f'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402103342_Update_IsLeaderId')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220402103342_Update_IsLeaderId', N'5.0.15');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402111512_Update_status')
BEGIN
    ALTER TABLE [Tbl_TeamLeaderModels] ADD [status] bit NOT NULL DEFAULT CAST(0 AS bit);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402111512_Update_status')
BEGIN
    ALTER TABLE [Tbl_MyTeamAllocationModels] ADD [status] bit NOT NULL DEFAULT CAST(0 AS bit);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402111512_Update_status')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''fda95185-806a-4add-a737-54569989bcd6''
    WHERE [Id] = N''094afa8c-69e3-4103-a542-8aee12940f9a'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402111512_Update_status')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''2022b189-cb71-46a7-9091-58ef9ea05d82''
    WHERE [Id] = N''24fee6f4-834d-4c45-a3e9-313a175b64b6'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402111512_Update_status')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''cec09d84-8715-4939-8cd3-e38e8ef9ec88''
    WHERE [Id] = N''9f074bba-372c-474e-81a2-92e877a73075'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402111512_Update_status')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''ec846784-2561-43bc-b940-6830b180c36e'', [PasswordHash] = N''AQAAAAEAACcQAAAAEP49ZgQai9ndcWZ3EGxehQbv76eKDuJ+irFy/Yp1O7M8yujJ0Ij7TMIwSjy5kW6KMg=='', [SecurityStamp] = N''365188fc-05a8-420c-b9b6-28ac81e4d7fd''
    WHERE [Id] = N''4b2546a3-3e7a-424e-ac18-52d4cae97b2f'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402111512_Update_status')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''6184f2f3-d49d-4529-af2f-0c7d32f79131'', [PasswordHash] = N''AQAAAAEAACcQAAAAEGZ/YkQKloDq2psUoHgu5ArkEvfW2Yz75SBegCfU5HXxsTOhvoj2Aa3eroHIXSBSqw=='', [SecurityStamp] = N''88825d44-4492-46d8-a2aa-d00878dc04e7''
    WHERE [Id] = N''5b2546a3-3e7a-454e-ac18-52d4cae97b2f'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402111512_Update_status')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220402111512_Update_status', N'5.0.15');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402114322_Update_teamleaderidindeftable')
BEGIN
    ALTER TABLE [Tbl_Defination_Master] ADD [TeamLeader_Id] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402114322_Update_teamleaderidindeftable')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''e6e7f9c8-a0d6-4cd7-af3d-ac7027f7af1f''
    WHERE [Id] = N''094afa8c-69e3-4103-a542-8aee12940f9a'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402114322_Update_teamleaderidindeftable')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''1fed9dbe-a434-477e-b909-2caafbb98b8f''
    WHERE [Id] = N''24fee6f4-834d-4c45-a3e9-313a175b64b6'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402114322_Update_teamleaderidindeftable')
BEGIN
    EXEC(N'UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N''800c563e-d24a-449e-b012-dbfee94a5356''
    WHERE [Id] = N''9f074bba-372c-474e-81a2-92e877a73075'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402114322_Update_teamleaderidindeftable')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''a0c41754-e36d-42be-b063-7b0e7f8a48c7'', [PasswordHash] = N''AQAAAAEAACcQAAAAEItOet+B/wjN5Lm0U+Udwd3TzQO5cI46sOZKApOCq85CKS1tUB2h66Z/FfWyyHDfMg=='', [SecurityStamp] = N''c95b5a97-ea7a-431f-a3fe-ce1636323b91''
    WHERE [Id] = N''4b2546a3-3e7a-424e-ac18-52d4cae97b2f'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402114322_Update_teamleaderidindeftable')
BEGIN
    EXEC(N'UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N''f8e77b77-49e0-455c-8625-2b0b386d8311'', [PasswordHash] = N''AQAAAAEAACcQAAAAEBN2rPgUKUbvYvZGn5GOsC868vauZPUMxHUnEqF9GXrsDfJul30sYb0ZwQ0yNSwHcw=='', [SecurityStamp] = N''1f513eb2-f985-4cff-b599-f37b016fffe7''
    WHERE [Id] = N''5b2546a3-3e7a-454e-ac18-52d4cae97b2f'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402114322_Update_teamleaderidindeftable')
BEGIN
    CREATE INDEX [IX_Tbl_Defination_Master_TeamLeader_Id] ON [Tbl_Defination_Master] ([TeamLeader_Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402114322_Update_teamleaderidindeftable')
BEGIN
    ALTER TABLE [Tbl_Defination_Master] ADD CONSTRAINT [FK_Tbl_Defination_Master_Tbl_TeamLeaderModels_TeamLeader_Id] FOREIGN KEY ([TeamLeader_Id]) REFERENCES [Tbl_TeamLeaderModels] ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220402114322_Update_teamleaderidindeftable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220402114322_Update_teamleaderidindeftable', N'5.0.15');
END;
GO

COMMIT;
GO

