
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/20/2020 23:05:20
-- Generated from EDMX file: C:\Users\Jonatan\Documents\GitHub\RegistroIncidencias1\Models\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [prueba1];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_canton_id]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[usuario] DROP CONSTRAINT [FK_canton_id];
GO
IF OBJECT_ID(N'[dbo].[FK_cantondistrito]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[distrito] DROP CONSTRAINT [FK_cantondistrito];
GO
IF OBJECT_ID(N'[dbo].[FK_distrito_id]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[usuario] DROP CONSTRAINT [FK_distrito_id];
GO
IF OBJECT_ID(N'[dbo].[FK_Empresa_Id]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Incendias] DROP CONSTRAINT [FK_Empresa_Id];
GO
IF OBJECT_ID(N'[dbo].[FK_Estado_Incidencia_Id]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Incendias] DROP CONSTRAINT [FK_Estado_Incidencia_Id];
GO
IF OBJECT_ID(N'[dbo].[FK_habilitadousuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[usuario] DROP CONSTRAINT [FK_habilitadousuario];
GO
IF OBJECT_ID(N'[dbo].[FK_provincia_id]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[canton] DROP CONSTRAINT [FK_provincia_id];
GO
IF OBJECT_ID(N'[dbo].[FK_provinciausuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[usuario] DROP CONSTRAINT [FK_provinciausuario];
GO
IF OBJECT_ID(N'[dbo].[FK_Tipo_IncidenciaIncidencias]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Incendias] DROP CONSTRAINT [FK_Tipo_IncidenciaIncidencias];
GO
IF OBJECT_ID(N'[dbo].[FK_Usuario_Id]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Incendias] DROP CONSTRAINT [FK_Usuario_Id];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[canton]', 'U') IS NOT NULL
    DROP TABLE [dbo].[canton];
GO
IF OBJECT_ID(N'[dbo].[cliente]', 'U') IS NOT NULL
    DROP TABLE [dbo].[cliente];
GO
IF OBJECT_ID(N'[dbo].[distrito]', 'U') IS NOT NULL
    DROP TABLE [dbo].[distrito];
GO
IF OBJECT_ID(N'[dbo].[Empresa]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Empresa];
GO
IF OBJECT_ID(N'[dbo].[Estado_Incidencias]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Estado_Incidencias];
GO
IF OBJECT_ID(N'[dbo].[habilitado]', 'U') IS NOT NULL
    DROP TABLE [dbo].[habilitado];
GO
IF OBJECT_ID(N'[dbo].[Incendias]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Incendias];
GO
IF OBJECT_ID(N'[dbo].[provincia]', 'U') IS NOT NULL
    DROP TABLE [dbo].[provincia];
GO
IF OBJECT_ID(N'[dbo].[Tipo_Incidencia]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tipo_Incidencia];
GO
IF OBJECT_ID(N'[dbo].[usuario]', 'U') IS NOT NULL
    DROP TABLE [dbo].[usuario];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'canton'
CREATE TABLE [dbo].[canton] (
    [Id] smallint IDENTITY(1,1) NOT NULL,
    [nombre_canton] nvarchar(max)  NOT NULL,
    [provinciaId] smallint  NOT NULL
);
GO

-- Creating table 'cliente'
CREATE TABLE [dbo].[cliente] (
    [id_perro] int  NOT NULL,
    [nombre] varchar(25)  NOT NULL
);
GO

-- Creating table 'distrito'
CREATE TABLE [dbo].[distrito] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [nombre_distrito] nvarchar(max)  NOT NULL,
    [cantonId] smallint  NOT NULL
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
    [codigo_activacion] varchar(50)  NOT NULL,
    [telefono] nvarchar(20)  NOT NULL,
    [cedula] nvarchar(20)  NOT NULL,
    [provinciaId] smallint  NOT NULL,
    [canton_id] smallint  NOT NULL,
    [distrito_Id] int  NOT NULL
);
GO

-- Creating table 'Incendias'
CREATE TABLE [dbo].[Incendias] (
    [Id_Incidencia] smallint IDENTITY(1,1) NOT NULL,
    [Latitud] nvarchar(max)  NOT NULL,
    [Longitud] nvarchar(max)  NOT NULL,
    [Dirrecion] nvarchar(max)  NOT NULL,
    [Detalle] nvarchar(max)  NOT NULL,
    [Tipo_Incidencia_Id] smallint  NOT NULL,
    [Empresa_Id] smallint  NOT NULL,
    [Estado_Incidencias_Id] smallint  NOT NULL,
    [usuario_id] smallint  NOT NULL,
    [Fotografia1] bit  NULL
);
GO

-- Creating table 'Empresa'
CREATE TABLE [dbo].[Empresa] (
    [Id_Empresa] smallint IDENTITY(1,1) NOT NULL,
    [Nombre_Empresa] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Tipo_Incidencia'
CREATE TABLE [dbo].[Tipo_Incidencia] (
    [Id_Tipo_Incidencia] smallint IDENTITY(1,1) NOT NULL,
    [Nombre_Problematica] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Estado_Incidencias'
CREATE TABLE [dbo].[Estado_Incidencias] (
    [Id_Estado_Incidencia] smallint IDENTITY(1,1) NOT NULL,
    [Estado] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'canton'
ALTER TABLE [dbo].[canton]
ADD CONSTRAINT [PK_canton]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [id_perro] in table 'cliente'
ALTER TABLE [dbo].[cliente]
ADD CONSTRAINT [PK_cliente]
    PRIMARY KEY CLUSTERED ([id_perro] ASC);
GO

-- Creating primary key on [Id] in table 'distrito'
ALTER TABLE [dbo].[distrito]
ADD CONSTRAINT [PK_distrito]
    PRIMARY KEY CLUSTERED ([Id] ASC);
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

-- Creating primary key on [Id_usuario] in table 'usuario'
ALTER TABLE [dbo].[usuario]
ADD CONSTRAINT [PK_usuario]
    PRIMARY KEY CLUSTERED ([Id_usuario] ASC);
GO

-- Creating primary key on [Id_Incidencia] in table 'Incendias'
ALTER TABLE [dbo].[Incendias]
ADD CONSTRAINT [PK_Incendias]
    PRIMARY KEY CLUSTERED ([Id_Incidencia] ASC);
GO

-- Creating primary key on [Id_Empresa] in table 'Empresa'
ALTER TABLE [dbo].[Empresa]
ADD CONSTRAINT [PK_Empresa]
    PRIMARY KEY CLUSTERED ([Id_Empresa] ASC);
GO

-- Creating primary key on [Id_Tipo_Incidencia] in table 'Tipo_Incidencia'
ALTER TABLE [dbo].[Tipo_Incidencia]
ADD CONSTRAINT [PK_Tipo_Incidencia]
    PRIMARY KEY CLUSTERED ([Id_Tipo_Incidencia] ASC);
GO

-- Creating primary key on [Id_Estado_Incidencia] in table 'Estado_Incidencias'
ALTER TABLE [dbo].[Estado_Incidencias]
ADD CONSTRAINT [PK_Estado_Incidencias]
    PRIMARY KEY CLUSTERED ([Id_Estado_Incidencia] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

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

-- Creating foreign key on [provinciaId] in table 'usuario'
ALTER TABLE [dbo].[usuario]
ADD CONSTRAINT [FK_provinciausuario]
    FOREIGN KEY ([provinciaId])
    REFERENCES [dbo].[provincia]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_provinciausuario'
CREATE INDEX [IX_FK_provinciausuario]
ON [dbo].[usuario]
    ([provinciaId]);
GO

-- Creating foreign key on [Tipo_Incidencia_Id] in table 'Incendias'
ALTER TABLE [dbo].[Incendias]
ADD CONSTRAINT [FK_Tipo_IncidenciaIncidencias]
    FOREIGN KEY ([Tipo_Incidencia_Id])
    REFERENCES [dbo].[Tipo_Incidencia]
        ([Id_Tipo_Incidencia])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Tipo_IncidenciaIncidencias'
CREATE INDEX [IX_FK_Tipo_IncidenciaIncidencias]
ON [dbo].[Incendias]
    ([Tipo_Incidencia_Id]);
GO

-- Creating foreign key on [Empresa_Id] in table 'Incendias'
ALTER TABLE [dbo].[Incendias]
ADD CONSTRAINT [FK_Empresa_Id]
    FOREIGN KEY ([Empresa_Id])
    REFERENCES [dbo].[Empresa]
        ([Id_Empresa])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Empresa_Id'
CREATE INDEX [IX_FK_Empresa_Id]
ON [dbo].[Incendias]
    ([Empresa_Id]);
GO

-- Creating foreign key on [Estado_Incidencias_Id] in table 'Incendias'
ALTER TABLE [dbo].[Incendias]
ADD CONSTRAINT [FK_Estado_Incidencia_Id]
    FOREIGN KEY ([Estado_Incidencias_Id])
    REFERENCES [dbo].[Estado_Incidencias]
        ([Id_Estado_Incidencia])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Estado_Incidencia_Id'
CREATE INDEX [IX_FK_Estado_Incidencia_Id]
ON [dbo].[Incendias]
    ([Estado_Incidencias_Id]);
GO

-- Creating foreign key on [usuario_id] in table 'Incendias'
ALTER TABLE [dbo].[Incendias]
ADD CONSTRAINT [FK_Usuario_Id]
    FOREIGN KEY ([usuario_id])
    REFERENCES [dbo].[usuario]
        ([Id_usuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Usuario_Id'
CREATE INDEX [IX_FK_Usuario_Id]
ON [dbo].[Incendias]
    ([usuario_id]);
GO

-- Creating foreign key on [canton_id] in table 'usuario'
ALTER TABLE [dbo].[usuario]
ADD CONSTRAINT [FK_canton_id]
    FOREIGN KEY ([canton_id])
    REFERENCES [dbo].[canton]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_canton_id'
CREATE INDEX [IX_FK_canton_id]
ON [dbo].[usuario]
    ([canton_id]);
GO

-- Creating foreign key on [distrito_Id] in table 'usuario'
ALTER TABLE [dbo].[usuario]
ADD CONSTRAINT [FK_distrito_id]
    FOREIGN KEY ([distrito_Id])
    REFERENCES [dbo].[distrito]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_distrito_id'
CREATE INDEX [IX_FK_distrito_id]
ON [dbo].[usuario]
    ([distrito_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------