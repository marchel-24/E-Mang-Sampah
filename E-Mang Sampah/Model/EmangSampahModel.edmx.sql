
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/27/2023 08:37:32
-- Generated from EDMX file: C:\Users\ASUS\source\repos\E-Mang-Sampah\E-Mang Sampah\Model\EmangSampahModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [EmangSampah];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_AccountPosts]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Posts] DROP CONSTRAINT [FK_AccountPosts];
GO
IF OBJECT_ID(N'[dbo].[FK_UserAccount_inherits_Account]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Accounts_UserAccount] DROP CONSTRAINT [FK_UserAccount_inherits_Account];
GO
IF OBJECT_ID(N'[dbo].[FK_PartnerAccount_inherits_Account]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Accounts_PartnerAccount] DROP CONSTRAINT [FK_PartnerAccount_inherits_Account];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Accounts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Accounts];
GO
IF OBJECT_ID(N'[dbo].[Posts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Posts];
GO
IF OBJECT_ID(N'[dbo].[Accounts_UserAccount]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Accounts_UserAccount];
GO
IF OBJECT_ID(N'[dbo].[Accounts_PartnerAccount]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Accounts_PartnerAccount];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Accounts'
CREATE TABLE [dbo].[Accounts] (
    [AccountId] int IDENTITY(1,1) NOT NULL,
    [Username] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Posts'
CREATE TABLE [dbo].[Posts] (
    [PostsId] int IDENTITY(1,1) NOT NULL,
    [Content] int  NOT NULL,
    [LikesCount] nvarchar(max)  NOT NULL,
    [UploadTime] datetime  NOT NULL,
    [AccountId] int  NOT NULL
);
GO

-- Creating table 'Orders'
CREATE TABLE [dbo].[Orders] (
    [OrderId] int IDENTITY(1,1) NOT NULL,
    [UserAccountId] int  NOT NULL,
    [PartnerAccountId] int  NOT NULL,
    [OrderReqTime] datetime  NOT NULL
);
GO

-- Creating table 'Accounts_UserAccount'
CREATE TABLE [dbo].[Accounts_UserAccount] (
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [AccountId] int  NOT NULL
);
GO

-- Creating table 'Accounts_PartnerAccount'
CREATE TABLE [dbo].[Accounts_PartnerAccount] (
    [CompanyName] nvarchar(max)  NOT NULL,
    [AccountId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [AccountId] in table 'Accounts'
ALTER TABLE [dbo].[Accounts]
ADD CONSTRAINT [PK_Accounts]
    PRIMARY KEY CLUSTERED ([AccountId] ASC);
GO

-- Creating primary key on [PostsId] in table 'Posts'
ALTER TABLE [dbo].[Posts]
ADD CONSTRAINT [PK_Posts]
    PRIMARY KEY CLUSTERED ([PostsId] ASC);
GO

-- Creating primary key on [OrderId] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [PK_Orders]
    PRIMARY KEY CLUSTERED ([OrderId] ASC);
GO

-- Creating primary key on [AccountId] in table 'Accounts_UserAccount'
ALTER TABLE [dbo].[Accounts_UserAccount]
ADD CONSTRAINT [PK_Accounts_UserAccount]
    PRIMARY KEY CLUSTERED ([AccountId] ASC);
GO

-- Creating primary key on [AccountId] in table 'Accounts_PartnerAccount'
ALTER TABLE [dbo].[Accounts_PartnerAccount]
ADD CONSTRAINT [PK_Accounts_PartnerAccount]
    PRIMARY KEY CLUSTERED ([AccountId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [AccountId] in table 'Posts'
ALTER TABLE [dbo].[Posts]
ADD CONSTRAINT [FK_AccountPosts]
    FOREIGN KEY ([AccountId])
    REFERENCES [dbo].[Accounts]
        ([AccountId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AccountPosts'
CREATE INDEX [IX_FK_AccountPosts]
ON [dbo].[Posts]
    ([AccountId]);
GO

-- Creating foreign key on [UserAccountId] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK_UserAccountOrder]
    FOREIGN KEY ([UserAccountId])
    REFERENCES [dbo].[Accounts_UserAccount]
        ([AccountId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserAccountOrder'
CREATE INDEX [IX_FK_UserAccountOrder]
ON [dbo].[Orders]
    ([UserAccountId]);
GO

-- Creating foreign key on [PartnerAccountId] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK_PartnerAccountOrder]
    FOREIGN KEY ([PartnerAccountId])
    REFERENCES [dbo].[Accounts_PartnerAccount]
        ([AccountId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PartnerAccountOrder'
CREATE INDEX [IX_FK_PartnerAccountOrder]
ON [dbo].[Orders]
    ([PartnerAccountId]);
GO

-- Creating foreign key on [AccountId] in table 'Accounts_UserAccount'
ALTER TABLE [dbo].[Accounts_UserAccount]
ADD CONSTRAINT [FK_UserAccount_inherits_Account]
    FOREIGN KEY ([AccountId])
    REFERENCES [dbo].[Accounts]
        ([AccountId])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [AccountId] in table 'Accounts_PartnerAccount'
ALTER TABLE [dbo].[Accounts_PartnerAccount]
ADD CONSTRAINT [FK_PartnerAccount_inherits_Account]
    FOREIGN KEY ([AccountId])
    REFERENCES [dbo].[Accounts]
        ([AccountId])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------