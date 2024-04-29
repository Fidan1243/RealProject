GO

/****** Object: Table [dbo].[AspNetRoleClaims] Script Date: 26/04/2024 22:24:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AspNetRoleClaims] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [RoleId]     NVARCHAR (450) NOT NULL,
    [ClaimType]  NVARCHAR (MAX) NULL,
    [ClaimValue] NVARCHAR (MAX) NULL
);


GO
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId]
    ON [dbo].[AspNetRoleClaims]([RoleId] ASC);


GO
ALTER TABLE [dbo].[AspNetRoleClaims]
    ADD CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED ([Id] ASC);


GO
ALTER TABLE [dbo].[AspNetRoleClaims]
    ADD CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[AspNetRoles] ([Id]) ON DELETE CASCADE;

CREATE TABLE [dbo].[AspNetRoles] (
    [Id]               NVARCHAR (450) NOT NULL,
    [Name]             NVARCHAR (256) NULL,
    [NormalizedName]   NVARCHAR (256) NULL,
    [ConcurrencyStamp] NVARCHAR (MAX) NULL
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex]
    ON [dbo].[AspNetRoles]([NormalizedName] ASC) WHERE ([NormalizedName] IS NOT NULL);


GO
ALTER TABLE [dbo].[AspNetRoles]
    ADD CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED ([Id] ASC);


CREATE TABLE [dbo].[AspNetUserClaims] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [UserId]     NVARCHAR (450) NOT NULL,
    [ClaimType]  NVARCHAR (MAX) NULL,
    [ClaimValue] NVARCHAR (MAX) NULL
);


GO
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId]
    ON [dbo].[AspNetUserClaims]([UserId] ASC);


GO
ALTER TABLE [dbo].[AspNetUserClaims]
    ADD CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED ([Id] ASC);


GO
ALTER TABLE [dbo].[AspNetUserClaims]
    ADD CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE;



CREATE TABLE [dbo].[AspNetUserLogins] (
    [LoginProvider]       NVARCHAR (450) NOT NULL,
    [ProviderKey]         NVARCHAR (450) NOT NULL,
    [ProviderDisplayName] NVARCHAR (MAX) NULL,
    [UserId]              NVARCHAR (450) NOT NULL
);


GO
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId]
    ON [dbo].[AspNetUserLogins]([UserId] ASC);


GO
ALTER TABLE [dbo].[AspNetUserLogins]
    ADD CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED ([LoginProvider] ASC, [ProviderKey] ASC);


GO
ALTER TABLE [dbo].[AspNetUserLogins]
    ADD CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE;



CREATE TABLE [dbo].[AspNetUserRoles] (
    [UserId] NVARCHAR (450) NOT NULL,
    [RoleId] NVARCHAR (450) NOT NULL
);


GO
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId]
    ON [dbo].[AspNetUserRoles]([RoleId] ASC);


GO
ALTER TABLE [dbo].[AspNetUserRoles]
    ADD CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED ([UserId] ASC, [RoleId] ASC);


GO
ALTER TABLE [dbo].[AspNetUserRoles]
    ADD CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[AspNetRoles] ([Id]) ON DELETE CASCADE;


GO
ALTER TABLE [dbo].[AspNetUserRoles]
    ADD CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE;

GO

CREATE TABLE [dbo].[AspNetUsers] (
    [Id]                   NVARCHAR (450)     NOT NULL,
    [UserName]             NVARCHAR (256)     NULL,
    [NormalizedUserName]   NVARCHAR (256)     NULL,
    [Email]                NVARCHAR (256)     NULL,
    [NormalizedEmail]      NVARCHAR (256)     NULL,
    [EmailConfirmed]       BIT                NOT NULL,
    [PasswordHash]         NVARCHAR (MAX)     NULL,
    [SecurityStamp]        NVARCHAR (MAX)     NULL,
    [ConcurrencyStamp]     NVARCHAR (MAX)     NULL,
    [PhoneNumber]          NVARCHAR (MAX)     NULL,
    [PhoneNumberConfirmed] BIT                NOT NULL,
    [TwoFactorEnabled]     BIT                NOT NULL,
    [LockoutEnd]           DATETIMEOFFSET (7) NULL,
    [LockoutEnabled]       BIT                NOT NULL,
    [AccessFailedCount]    INT                NOT NULL
);


GO
CREATE NONCLUSTERED INDEX [EmailIndex]
    ON [dbo].[AspNetUsers]([NormalizedEmail] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex]
    ON [dbo].[AspNetUsers]([NormalizedUserName] ASC) WHERE ([NormalizedUserName] IS NOT NULL);


GO
ALTER TABLE [dbo].[AspNetUsers]
    ADD CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED ([Id] ASC);



CREATE TABLE [dbo].[AspNetUserTokens] (
    [UserId]        NVARCHAR (450) NOT NULL,
    [LoginProvider] NVARCHAR (450) NOT NULL,
    [Name]          NVARCHAR (450) NOT NULL,
    [Value]         NVARCHAR (MAX) NULL
);


GO

CREATE TABLE [dbo].[LoginViewModel] (
    [Id]         UNIQUEIDENTIFIER NOT NULL,
    [Username]   NVARCHAR (MAX)   NOT NULL,
    [Password]   NVARCHAR (MAX)   NOT NULL,
    [RememberMe] BIT              NOT NULL
);


GO

CREATE TABLE [dbo].[RegisterViewModel] (
    [Id]       UNIQUEIDENTIFIER NOT NULL,
    [Username] NVARCHAR (MAX)   NOT NULL,
    [Name]     NVARCHAR (MAX)   NOT NULL,
    [Surname]  NVARCHAR (MAX)   NOT NULL,
    [Password] NVARCHAR (MAX)   NOT NULL,
    [Email]    NVARCHAR (MAX)   NOT NULL
);


CREATE TABLE [dbo].[OrderStatus] (
    [Id]     INT            IDENTITY (1, 1) NOT NULL,
    [Status] NVARCHAR (MAX) NOT NULL
);




CREATE TABLE [dbo].[__EFMigrationsHistory] (
    [MigrationId]    NVARCHAR (150) NOT NULL,
    [ProductVersion] NVARCHAR (32)  NOT NULL
);




CREATE TABLE [dbo].[Models] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (MAX) NOT NULL,
    [ImagePath] NVARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Materials] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (MAX) NOT NULL,
    [ImagePath] NVARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Products] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (MAX) NOT NULL,
    [Material_Id] INT            NOT NULL,
    [Model_Id]    INT            NOT NULL,
    [OrderCount]  INT            NOT NULL,
    [Quantity]    INT            NOT NULL,
    [Price]       FLOAT (53)     NOT NULL,
    [ImagePath]   NVARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([Material_Id]) REFERENCES [dbo].[Materials] ([Id]),
    FOREIGN KEY ([Model_Id]) REFERENCES [dbo].[Models] ([Id])
);

CREATE TABLE [dbo].[Combos] (
    [Id]                      INT            IDENTITY (1, 1) NOT NULL,
    [User_Id]                 INT            NOT NULL,
    [Mirror_Id]               INT            NULL,
    [Sink_Unit_Id]            INT            NULL,
    [Shower_Id]               INT            NULL,
    [Toilet_Id]               INT            NULL,
    [Decoration_Marble_Id]    INT            NULL,
    [Marble_Id]               INT            NULL,
    [Marble_Count]            INT            NOT NULL,
    [Decoration_Marble_Count] INT            NOT NULL,
    [Name]                    NVARCHAR (MAX) NOT NULL,
    [Total]                   FLOAT (53)     NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([User_Id]) REFERENCES [dbo].[Users] ([Id]),
    FOREIGN KEY ([Decoration_Marble_Id]) REFERENCES [dbo].[Products] ([Id]),
    FOREIGN KEY ([Marble_Id]) REFERENCES [dbo].[Products] ([Id]),
    FOREIGN KEY ([Mirror_Id]) REFERENCES [dbo].[Products] ([Id]),
    FOREIGN KEY ([Shower_Id]) REFERENCES [dbo].[Products] ([Id]),
    FOREIGN KEY ([Sink_Unit_Id]) REFERENCES [dbo].[Products] ([Id]),
    FOREIGN KEY ([Toilet_Id]) REFERENCES [dbo].[Products] ([Id])
);

CREATE TABLE [dbo].[Carts] (
    [Id]      INT IDENTITY (1, 1) NOT NULL,
    [User_Id] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([User_Id]) REFERENCES [dbo].[Users] ([Id])
);

CREATE TABLE [dbo].[CartItems] (
    [Id]         INT IDENTITY (1, 1) NOT NULL,
    [Cart_Id]    INT NOT NULL,
    [Product_Id] INT NOT NULL,
    [Quantity]   INT DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([Cart_Id]) REFERENCES [dbo].[Carts] ([Id]),
    FOREIGN KEY ([Product_Id]) REFERENCES [dbo].[Products] ([Id])
);

CREATE TABLE [dbo].[OrderStatuses] (
    [Id]     INT            IDENTITY (1, 1) NOT NULL,
    [Status] NVARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Orders] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [Quantity]   INT            DEFAULT ((0)) NOT NULL,
    [Product_Id] INT            NOT NULL,
    [Address]    NVARCHAR (MAX) NOT NULL,
    [City]       NVARCHAR (MAX) NOT NULL,
    [User_Id]    INT            NOT NULL,
    [Status_Id]  INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([Product_Id]) REFERENCES [dbo].[Products] ([Id]),
    FOREIGN KEY ([User_Id]) REFERENCES [dbo].[Users] ([Id]),
    FOREIGN KEY ([Status_Id]) REFERENCES [dbo].[OrderStatuses] ([Id])
);

CREATE TABLE [dbo].[Users] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [User_Id]   NVARCHAR (450) NOT NULL,
    [Name]      NVARCHAR (100) NOT NULL,
    [Surname]   NVARCHAR (100) NOT NULL,
    [Email]     NVARCHAR (100) NOT NULL,
    [Role]      NVARCHAR (450) NOT NULL,
    [UserName]  NVARCHAR (100) NOT NULL,
    [ImagePath] NVARCHAR (100) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    UNIQUE NONCLUSTERED ([Email] ASC),
    CHECK ([Name]<>'' AND [Surname]<>'')
);

