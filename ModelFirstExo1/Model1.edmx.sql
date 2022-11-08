
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/08/2022 10:44:34
-- Generated from EDMX file: C:\Users\Admin stagiaire.DESKTOP-8967908\Desktop\MiseEnPratique\formationEntityFramework_07112022\FormationEntityFramework\ModelFirstExo1\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [modelfirstexo_db];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Posts'
CREATE TABLE [dbo].[Posts] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [contenu] nvarchar(max)  NOT NULL,
    [Blog_Id] int  NOT NULL
);
GO

-- Creating table 'Blogs'
CREATE TABLE [dbo].[Blogs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Posts'
ALTER TABLE [dbo].[Posts]
ADD CONSTRAINT [PK_Posts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Blogs'
ALTER TABLE [dbo].[Blogs]
ADD CONSTRAINT [PK_Blogs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Blog_Id] in table 'Posts'
ALTER TABLE [dbo].[Posts]
ADD CONSTRAINT [FK_PostBlog]
    FOREIGN KEY ([Blog_Id])
    REFERENCES [dbo].[Blogs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PostBlog'
CREATE INDEX [IX_FK_PostBlog]
ON [dbo].[Posts]
    ([Blog_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------