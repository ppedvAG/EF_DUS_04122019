
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/04/2019 11:49:02
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


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


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
    [Bezeichnung] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PersonSet_Kunde'
CREATE TABLE [dbo].[PersonSet_Kunde] (
    [Kundennummer] nvarchar(max)  NOT NULL,
    [MitarbeiterId] int  NULL,
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