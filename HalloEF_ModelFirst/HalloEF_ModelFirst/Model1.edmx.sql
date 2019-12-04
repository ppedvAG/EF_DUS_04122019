
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/04/2019 15:41:14
-- Generated from EDMX file: C:\Users\ar2\source\repos\ppedvAG\EF_DUS_04122019\HalloEF_ModelFirst\HalloEF_ModelFirst\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [EfModelFirst];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_KundeMitarbeiter]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonSet_Kunde] DROP CONSTRAINT [FK_KundeMitarbeiter];
GO
IF OBJECT_ID(N'[dbo].[FK_MitarbeiterAbteilung_Mitarbeiter]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MitarbeiterAbteilung] DROP CONSTRAINT [FK_MitarbeiterAbteilung_Mitarbeiter];
GO
IF OBJECT_ID(N'[dbo].[FK_MitarbeiterAbteilung_Abteilung]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MitarbeiterAbteilung] DROP CONSTRAINT [FK_MitarbeiterAbteilung_Abteilung];
GO
IF OBJECT_ID(N'[dbo].[FK_Kunde_inherits_Person]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonSet_Kunde] DROP CONSTRAINT [FK_Kunde_inherits_Person];
GO
IF OBJECT_ID(N'[dbo].[FK_Mitarbeiter_inherits_Person]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonSet_Mitarbeiter] DROP CONSTRAINT [FK_Mitarbeiter_inherits_Person];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[PersonSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PersonSet];
GO
IF OBJECT_ID(N'[dbo].[AbteilungSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AbteilungSet];
GO
IF OBJECT_ID(N'[dbo].[PersonSet_Kunde]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PersonSet_Kunde];
GO
IF OBJECT_ID(N'[dbo].[PersonSet_Mitarbeiter]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PersonSet_Mitarbeiter];
GO
IF OBJECT_ID(N'[dbo].[MitarbeiterAbteilung]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MitarbeiterAbteilung];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'PersonSet'
CREATE TABLE [dbo].[PersonSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [GebDatum] datetime  NOT NULL
);
GO

-- Creating table 'AbteilungSet'
CREATE TABLE [dbo].[AbteilungSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Bezeichnung] nvarchar(max)  NOT NULL,
    [Board_Länge] float  NOT NULL,
    [Board_Breite] float  NOT NULL,
    [Board_Farbe] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PersonSet_Kunde'
CREATE TABLE [dbo].[PersonSet_Kunde] (
    [Kundennummer] nvarchar(max)  NOT NULL,
    [MitarbeiterId] int  NULL,
    [Kopfform_Länge] float  NOT NULL,
    [Kopfform_Breite] float  NOT NULL,
    [Kopfform_Farbe] nvarchar(max)  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'PersonSet_Mitarbeiter'
CREATE TABLE [dbo].[PersonSet_Mitarbeiter] (
    [Beruf] nvarchar(max)  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'MitarbeiterAbteilung'
CREATE TABLE [dbo].[MitarbeiterAbteilung] (
    [Mitarbeiter_Id] int  NOT NULL,
    [Abteilungen_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'PersonSet'
ALTER TABLE [dbo].[PersonSet]
ADD CONSTRAINT [PK_PersonSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AbteilungSet'
ALTER TABLE [dbo].[AbteilungSet]
ADD CONSTRAINT [PK_AbteilungSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PersonSet_Kunde'
ALTER TABLE [dbo].[PersonSet_Kunde]
ADD CONSTRAINT [PK_PersonSet_Kunde]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PersonSet_Mitarbeiter'
ALTER TABLE [dbo].[PersonSet_Mitarbeiter]
ADD CONSTRAINT [PK_PersonSet_Mitarbeiter]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Mitarbeiter_Id], [Abteilungen_Id] in table 'MitarbeiterAbteilung'
ALTER TABLE [dbo].[MitarbeiterAbteilung]
ADD CONSTRAINT [PK_MitarbeiterAbteilung]
    PRIMARY KEY CLUSTERED ([Mitarbeiter_Id], [Abteilungen_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [MitarbeiterId] in table 'PersonSet_Kunde'
ALTER TABLE [dbo].[PersonSet_Kunde]
ADD CONSTRAINT [FK_KundeMitarbeiter]
    FOREIGN KEY ([MitarbeiterId])
    REFERENCES [dbo].[PersonSet_Mitarbeiter]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KundeMitarbeiter'
CREATE INDEX [IX_FK_KundeMitarbeiter]
ON [dbo].[PersonSet_Kunde]
    ([MitarbeiterId]);
GO

-- Creating foreign key on [Mitarbeiter_Id] in table 'MitarbeiterAbteilung'
ALTER TABLE [dbo].[MitarbeiterAbteilung]
ADD CONSTRAINT [FK_MitarbeiterAbteilung_Mitarbeiter]
    FOREIGN KEY ([Mitarbeiter_Id])
    REFERENCES [dbo].[PersonSet_Mitarbeiter]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Abteilungen_Id] in table 'MitarbeiterAbteilung'
ALTER TABLE [dbo].[MitarbeiterAbteilung]
ADD CONSTRAINT [FK_MitarbeiterAbteilung_Abteilung]
    FOREIGN KEY ([Abteilungen_Id])
    REFERENCES [dbo].[AbteilungSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MitarbeiterAbteilung_Abteilung'
CREATE INDEX [IX_FK_MitarbeiterAbteilung_Abteilung]
ON [dbo].[MitarbeiterAbteilung]
    ([Abteilungen_Id]);
GO

-- Creating foreign key on [Id] in table 'PersonSet_Kunde'
ALTER TABLE [dbo].[PersonSet_Kunde]
ADD CONSTRAINT [FK_Kunde_inherits_Person]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[PersonSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'PersonSet_Mitarbeiter'
ALTER TABLE [dbo].[PersonSet_Mitarbeiter]
ADD CONSTRAINT [FK_Mitarbeiter_inherits_Person]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[PersonSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------