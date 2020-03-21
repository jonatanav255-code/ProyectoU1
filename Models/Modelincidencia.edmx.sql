
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/18/2020 14:48:17
-- Generated from EDMX file: C:\Users\Jonatan\Documents\GitHub\RegistroIncidencias1\Models\Modelincidencia.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [incidencias];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_habilitadousuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[usuario] DROP CONSTRAINT [FK_habilitadousuario];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[habilitado]', 'U') IS NOT NULL
    DROP TABLE [dbo].[habilitado];
GO
IF OBJECT_ID(N'[dbo].[usuario]', 'U') IS NOT NULL
    DROP TABLE [dbo].[usuario];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'usuario'
CREATE TABLE [dbo].[usuario] (
    [Id_usuario] smallint IDENTITY(1,1) NOT NULL,
    [habilitado_id] smallint  NOT NULL,
    [nombre] nvarchar(50)  NOT NULL,
    [primer_apellido] nvarchar(50)  NOT NULL,
    [segundo_apellido] nvarchar(50)  NOT NULL,
    [correo_electronico] nvarchar(50)  NOT NULL,
    [contrasena] nvarchar(50)  NOT NULL,
    [direccion] nvarchar(50)  NOT NULL,
    [codigo_activacion] varchar(50)  NOT NULL
);
GO

-- Creating table 'habilitado'
CREATE TABLE [dbo].[habilitado] (
    [Id_habilitado] smallint IDENTITY(1,1) NOT NULL,
    [habilitar] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'provincia'
CREATE TABLE [dbo].[provincia] (
    [Id] smallint IDENTITY(1,1) NOT NULL,
    [nombre_provincia] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'canton'
CREATE TABLE [dbo].[canton] (
    [Id] smallint IDENTITY(1,1) NOT NULL,
    [nombre_canton] nvarchar(max)  NOT NULL,
    [provinciaId] smallint  NOT NULL
);
GO

-- Creating table 'distrito'
CREATE TABLE [dbo].[distrito] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [nombre_distrito] nvarchar(max)  NOT NULL,
    [cantonId] smallint  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id_usuario] in table 'usuario'
ALTER TABLE [dbo].[usuario]
ADD CONSTRAINT [PK_usuario]
    PRIMARY KEY CLUSTERED ([Id_usuario] ASC);
GO

-- Creating primary key on [Id_habilitado] in table 'habilitado'
ALTER TABLE [dbo].[habilitado]
ADD CONSTRAINT [PK_habilitado]
    PRIMARY KEY CLUSTERED ([Id_habilitado] ASC);
GO

-- Creating primary key on [Id] in table 'provincia'
ALTER TABLE [dbo].[provincia]
ADD CONSTRAINT [PK_provincia]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'canton'
ALTER TABLE [dbo].[canton]
ADD CONSTRAINT [PK_canton]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'distrito'
ALTER TABLE [dbo].[distrito]
ADD CONSTRAINT [PK_distrito]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [habilitado_id] in table 'usuario'
ALTER TABLE [dbo].[usuario]
ADD CONSTRAINT [FK_habilitadousuario]
    FOREIGN KEY ([habilitado_id])
    REFERENCES [dbo].[habilitado]
        ([Id_habilitado])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_habilitadousuario'
CREATE INDEX [IX_FK_habilitadousuario]
ON [dbo].[usuario]
    ([habilitado_id]);
GO

-- Creating foreign key on [provinciaId] in table 'canton'
ALTER TABLE [dbo].[canton]
ADD CONSTRAINT [FK_provincia_id]
    FOREIGN KEY ([provinciaId])
    REFERENCES [dbo].[provincia]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_provincia_id'
CREATE INDEX [IX_FK_provincia_id]
ON [dbo].[canton]
    ([provinciaId]);
GO

-- Creating foreign key on [cantonId] in table 'distrito'
ALTER TABLE [dbo].[distrito]
ADD CONSTRAINT [FK_cantondistrito]
    FOREIGN KEY ([cantonId])
    REFERENCES [dbo].[canton]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_cantondistrito'
CREATE INDEX [IX_FK_cantondistrito]
ON [dbo].[distrito]
    ([cantonId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------