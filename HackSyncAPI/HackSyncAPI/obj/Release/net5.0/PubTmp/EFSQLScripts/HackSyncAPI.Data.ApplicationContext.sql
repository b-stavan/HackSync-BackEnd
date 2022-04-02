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

