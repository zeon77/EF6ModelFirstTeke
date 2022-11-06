
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/06/2022 21:25:16
-- Generated from EDMX file: D:\ZeoN\Downloads\EF6ModelFirstTeke\EF6ModelFirstTeke\TekeDbModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [TekeDb];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[EgyesuletSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EgyesuletSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Egyesuletek'
CREATE TABLE [dbo].[Egyesuletek] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nev] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Versenyzok'
CREATE TABLE [dbo].[Versenyzok] (
    [Rajtszam] int IDENTITY(1,1) NOT NULL,
    [Nev] nvarchar(max)  NOT NULL,
    [Korcsop] nvarchar(max)  NOT NULL,
    [EgyesuletId] int  NOT NULL
);
GO

-- Creating table 'Eredmenyek'
CREATE TABLE [dbo].[Eredmenyek] (
    [Sorsz] int IDENTITY(1,1) NOT NULL,
    [Teli] int  NOT NULL,
    [Tarolas] int  NOT NULL,
    [Ures] int  NOT NULL,
    [VersenyzoRajtszam] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Egyesuletek'
ALTER TABLE [dbo].[Egyesuletek]
ADD CONSTRAINT [PK_Egyesuletek]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Rajtszam] in table 'Versenyzok'
ALTER TABLE [dbo].[Versenyzok]
ADD CONSTRAINT [PK_Versenyzok]
    PRIMARY KEY CLUSTERED ([Rajtszam] ASC);
GO

-- Creating primary key on [Sorsz] in table 'Eredmenyek'
ALTER TABLE [dbo].[Eredmenyek]
ADD CONSTRAINT [PK_Eredmenyek]
    PRIMARY KEY CLUSTERED ([Sorsz] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [EgyesuletId] in table 'Versenyzok'
ALTER TABLE [dbo].[Versenyzok]
ADD CONSTRAINT [FK_EgyesuletVersenyzo]
    FOREIGN KEY ([EgyesuletId])
    REFERENCES [dbo].[Egyesuletek]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EgyesuletVersenyzo'
CREATE INDEX [IX_FK_EgyesuletVersenyzo]
ON [dbo].[Versenyzok]
    ([EgyesuletId]);
GO

-- Creating foreign key on [VersenyzoRajtszam] in table 'Eredmenyek'
ALTER TABLE [dbo].[Eredmenyek]
ADD CONSTRAINT [FK_VersenyzoEredmeny]
    FOREIGN KEY ([VersenyzoRajtszam])
    REFERENCES [dbo].[Versenyzok]
        ([Rajtszam])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VersenyzoEredmeny'
CREATE INDEX [IX_FK_VersenyzoEredmeny]
ON [dbo].[Eredmenyek]
    ([VersenyzoRajtszam]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------