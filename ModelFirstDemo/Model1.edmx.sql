
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/08/2022 09:31:02
-- Generated from EDMX file: C:\Users\Admin stagiaire.DESKTOP-8967908\Desktop\MiseEnPratique\formationEntityFramework_07112022\FormationEntityFramework\ModelFirstDemo\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [modelfirstdemo_db];
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

-- Creating table 'Villes'
CREATE TABLE [dbo].[Villes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [NomVille] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Clients'
CREATE TABLE [dbo].[Clients] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nom] nvarchar(max)  NOT NULL,
    [Prenom] nvarchar(max)  NOT NULL,
    [DateNaissance] datetime  NOT NULL,
    [VilleId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Villes'
ALTER TABLE [dbo].[Villes]
ADD CONSTRAINT [PK_Villes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Clients'
ALTER TABLE [dbo].[Clients]
ADD CONSTRAINT [PK_Clients]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [VilleId] in table 'Clients'
ALTER TABLE [dbo].[Clients]
ADD CONSTRAINT [FK_VilleClient]
    FOREIGN KEY ([VilleId])
    REFERENCES [dbo].[Villes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VilleClient'
CREATE INDEX [IX_FK_VilleClient]
ON [dbo].[Clients]
    ([VilleId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------