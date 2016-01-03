/*
Script de implementación para TensorflexDatabase

Una herramienta generó este código.
Los cambios realizados en este archivo podrían generar un comportamiento incorrecto y se perderán si
se vuelve a generar el código.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "TensorflexDatabase"
:setvar DefaultFilePrefix "TensorflexDatabase"
:setvar DefaultDataPath "C:\Users\Salvador Rubio\AppData\Local\Microsoft\VisualStudio\SSDT\TensorflexDatabase\"
:setvar DefaultLogPath "C:\Users\Salvador Rubio\AppData\Local\Microsoft\VisualStudio\SSDT\TensorflexDatabase\"

GO
:on error exit
GO
/*
Detectar el modo SQLCMD y deshabilitar la ejecución del script si no se admite el modo SQLCMD.
Para volver a habilitar el script después de habilitar el modo SQLCMD, ejecute lo siguiente:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'El modo SQLCMD debe estar habilitado para ejecutar correctamente este script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
/*
Se está quitando la columna [dbo].[Albarán].[CodigoCliente]; puede que se pierdan datos.

Se está quitando la columna [dbo].[Albarán].[CodigoEmpresa]; puede que se pierdan datos.

Debe agregarse la columna [dbo].[Albarán].[ClienteId] de la tabla [dbo].[Albarán], pero esta columna no tiene un valor predeterminado y no admite valores NULL. Si la tabla contiene datos, el script ALTER no funcionará. Para evitar este problema, agregue un valor predeterminado a la columna, márquela de modo que permita valores NULL o habilite la generación de valores predeterminados inteligentes como opción de implementación.
*/

IF EXISTS (select top 1 1 from [dbo].[Albarán])
    RAISERROR (N'Se detectaron filas. La actualización del esquema va a terminar debido a una posible pérdida de datos.', 16, 127) WITH NOWAIT

GO
/*
La columna id de la tabla [dbo].[Articulos] debe cambiarse de NULL a NOT NULL. Si la tabla contiene datos, puede que no funcione el script ALTER. Para evitar este problema, debe agregar valores en todas las filas de esta columna, marcar la columna de modo que permita valores NULL o habilitar la generación de valores predeterminados inteligentes como opción de implementación.
*/

IF EXISTS (select top 1 1 from [dbo].[Articulos])
    RAISERROR (N'Se detectaron filas. La actualización del esquema va a terminar debido a una posible pérdida de datos.', 16, 127) WITH NOWAIT

GO
/*
La columna id de la tabla [dbo].[Clientes] debe cambiarse de NULL a NOT NULL. Si la tabla contiene datos, puede que no funcione el script ALTER. Para evitar este problema, debe agregar valores en todas las filas de esta columna, marcar la columna de modo que permita valores NULL o habilitar la generación de valores predeterminados inteligentes como opción de implementación.
*/

IF EXISTS (select top 1 1 from [dbo].[Clientes])
    RAISERROR (N'Se detectaron filas. La actualización del esquema va a terminar debido a una posible pérdida de datos.', 16, 127) WITH NOWAIT

GO
/*
Se está quitando la columna [dbo].[LineaAlbaran].[CodigoArticulo]; puede que se pierdan datos.

Se está quitando la columna [dbo].[LineaAlbaran].[CodigoEmpresa]; puede que se pierdan datos.

Debe agregarse la columna [dbo].[LineaAlbaran].[ArticuloId] de la tabla [dbo].[LineaAlbaran], pero esta columna no tiene un valor predeterminado y no admite valores NULL. Si la tabla contiene datos, el script ALTER no funcionará. Para evitar este problema, agregue un valor predeterminado a la columna, márquela de modo que permita valores NULL o habilite la generación de valores predeterminados inteligentes como opción de implementación.
*/

IF EXISTS (select top 1 1 from [dbo].[LineaAlbaran])
    RAISERROR (N'Se detectaron filas. La actualización del esquema va a terminar debido a una posible pérdida de datos.', 16, 127) WITH NOWAIT

GO
PRINT N'Quitando FK_dbo.Tensorflex_dbo.Clientes_CodigoCliente...';


GO
ALTER TABLE [dbo].[Albarán] DROP CONSTRAINT [FK_dbo.Tensorflex_dbo.Clientes_CodigoCliente];


GO
PRINT N'Quitando FK_Albaran...';


GO
ALTER TABLE [dbo].[LineaAlbaran] DROP CONSTRAINT [FK_Albaran];


GO
PRINT N'Quitando FK_dbo.Tensorflex_dbo.Articulos_CodigoArticulo...';


GO
ALTER TABLE [dbo].[LineaAlbaran] DROP CONSTRAINT [FK_dbo.Tensorflex_dbo.Articulos_CodigoArticulo];


GO
PRINT N'Quitando Articulos_Articulo...';


GO
ALTER TABLE [dbo].[Articulos] DROP CONSTRAINT [Articulos_Articulo];


GO
PRINT N'Iniciando recompilación de la tabla [dbo].[Albarán]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_Albarán] (
    [Id]        INT  IDENTITY (1, 1) NOT NULL,
    [ClienteId] INT  NOT NULL,
    [Fecha]     DATE NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[Albarán])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Albarán] ON;
        INSERT INTO [dbo].[tmp_ms_xx_Albarán] ([Id], [Fecha])
        SELECT   [Id],
                 [Fecha]
        FROM     [dbo].[Albarán]
        ORDER BY [Id] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Albarán] OFF;
    END

DROP TABLE [dbo].[Albarán];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Albarán]', N'Albarán';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Iniciando recompilación de la tabla [dbo].[Articulos]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_Articulos] (
    [CodigoEmpresa]        SMALLINT         NULL,
    [CodigoArticulo]       VARCHAR (20)     NULL,
    [DescripcionArticulo]  VARCHAR (50)     NOT NULL,
    [Descripcion2Articulo] VARCHAR (40)     NULL,
    [CodigoAlternativo]    VARCHAR (20)     NULL,
    [CodigoAlternativo2]   VARCHAR (20)     NULL,
    [FechaAlta]            DATETIME         NULL,
    [CodigoFamilia]        VARCHAR (10)     NULL,
    [CodigoSubfamilia]     VARCHAR (10)     NULL,
    [StockMinimo]          DECIMAL (28, 10) NULL,
    [StockMaximo]          DECIMAL (28, 10) NULL,
    [PuntoPedido]          DECIMAL (28, 10) NULL,
    [PrecioCompra]         DECIMAL (28, 10) NULL,
    [PrecioVenta]          DECIMAL (28, 10) NULL,
    [%Margen]              DECIMAL (28, 10) NULL,
    [id]                   INT              IDENTITY (2000, 1) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[Articulos])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Articulos] ON;
        INSERT INTO [dbo].[tmp_ms_xx_Articulos] ([id], [CodigoEmpresa], [CodigoArticulo], [DescripcionArticulo], [Descripcion2Articulo], [CodigoAlternativo], [CodigoAlternativo2], [FechaAlta], [CodigoFamilia], [CodigoSubfamilia], [StockMinimo], [StockMaximo], [PuntoPedido], [PrecioCompra], [PrecioVenta], [%Margen])
        SELECT   [id],
                 [CodigoEmpresa],
                 [CodigoArticulo],
                 [DescripcionArticulo],
                 [Descripcion2Articulo],
                 [CodigoAlternativo],
                 [CodigoAlternativo2],
                 [FechaAlta],
                 [CodigoFamilia],
                 [CodigoSubfamilia],
                 [StockMinimo],
                 [StockMaximo],
                 [PuntoPedido],
                 [PrecioCompra],
                 [PrecioVenta],
                 [%Margen]
        FROM     [dbo].[Articulos]
        ORDER BY [id] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Articulos] OFF;
    END

DROP TABLE [dbo].[Articulos];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Articulos]', N'Articulos';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Iniciando recompilación de la tabla [dbo].[Clientes]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_Clientes] (
    [CodigoEmpresa]        SMALLINT      NULL,
    [IdDelegacion]         VARCHAR (10)  NULL,
    [CodigoCliente]        VARCHAR (15)  NULL,
    [SiglaNacion]          VARCHAR (2)   NULL,
    [CifDni]               VARCHAR (13)  NULL,
    [CifEuropeo]           VARCHAR (15)  NULL,
    [FechaAlta]            DATETIME      NULL,
    [CodigoProveedor]      VARCHAR (15)  NULL,
    [CodigoContable]       VARCHAR (15)  NULL,
    [RazonSocial]          VARCHAR (40)  NOT NULL,
    [RazonSocial2]         VARCHAR (40)  NULL,
    [Nombre]               VARCHAR (35)  NOT NULL,
    [Domicilio]            VARCHAR (40)  NULL,
    [Domicilio2]           VARCHAR (40)  NULL,
    [Nombre1]              VARCHAR (30)  NULL,
    [FormadePago]          VARCHAR (35)  NULL,
    [CodigoBanco]          VARCHAR (10)  NULL,
    [CodigoAgencia]        VARCHAR (6)   NULL,
    [DC]                   VARCHAR (2)   NULL,
    [CCC]                  VARCHAR (15)  NULL,
    [IBAN]                 VARCHAR (34)  NULL,
    [CodigoZona]           INT           NULL,
    [CodigoRuta_]          VARCHAR (10)  NULL,
    [CodigoTransportista]  INT           NULL,
    [TipoPortes]           VARCHAR (1)   NULL,
    [ObservacionesCliente] VARCHAR (50)  NULL,
    [Comentarios]          TEXT          NULL,
    [CodigoSigla]          VARCHAR (2)   NULL,
    [ViaPublica]           VARCHAR (40)  NULL,
    [Numero1]              VARCHAR (4)   NULL,
    [Numero2]              VARCHAR (4)   NULL,
    [Escalera]             VARCHAR (2)   NULL,
    [Piso]                 VARCHAR (2)   NULL,
    [Puerta]               VARCHAR (2)   NULL,
    [Letra]                VARCHAR (2)   NULL,
    [CodigoPostal]         VARCHAR (8)   NULL,
    [CodigoMunicipio]      VARCHAR (7)   NULL,
    [Municipio]            VARCHAR (25)  NULL,
    [ColaMunicipio]        VARCHAR (15)  NULL,
    [CodigoProvincia]      VARCHAR (5)   NULL,
    [Provincia]            VARCHAR (20)  NULL,
    [CodigoNacion]         SMALLINT      NULL,
    [Nacion]               VARCHAR (25)  NULL,
    [Telefono]             VARCHAR (15)  NULL,
    [Telefono2]            VARCHAR (15)  NULL,
    [Telefono3]            VARCHAR (15)  NULL,
    [Fax]                  VARCHAR (15)  NULL,
    [Email1]               VARCHAR (250) NULL,
    [HorarioDomicilioLc]   VARCHAR (100) NULL,
    [id]                   INT           IDENTITY (7000, 1) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[Clientes])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Clientes] ON;
        INSERT INTO [dbo].[tmp_ms_xx_Clientes] ([id], [CodigoEmpresa], [IdDelegacion], [CodigoCliente], [SiglaNacion], [CifDni], [CifEuropeo], [FechaAlta], [CodigoProveedor], [CodigoContable], [RazonSocial], [RazonSocial2], [Nombre], [Domicilio], [Domicilio2], [Nombre1], [FormadePago], [CodigoBanco], [CodigoAgencia], [DC], [CCC], [IBAN], [CodigoZona], [CodigoRuta_], [CodigoTransportista], [TipoPortes], [ObservacionesCliente], [Comentarios], [CodigoSigla], [ViaPublica], [Numero1], [Numero2], [Escalera], [Piso], [Puerta], [Letra], [CodigoPostal], [CodigoMunicipio], [Municipio], [ColaMunicipio], [CodigoProvincia], [Provincia], [CodigoNacion], [Nacion], [Telefono], [Telefono2], [Telefono3], [Fax], [Email1], [HorarioDomicilioLc])
        SELECT   [id],
                 [CodigoEmpresa],
                 [IdDelegacion],
                 [CodigoCliente],
                 [SiglaNacion],
                 [CifDni],
                 [CifEuropeo],
                 [FechaAlta],
                 [CodigoProveedor],
                 [CodigoContable],
                 [RazonSocial],
                 [RazonSocial2],
                 [Nombre],
                 [Domicilio],
                 [Domicilio2],
                 [Nombre1],
                 [FormadePago],
                 [CodigoBanco],
                 [CodigoAgencia],
                 [DC],
                 [CCC],
                 [IBAN],
                 [CodigoZona],
                 [CodigoRuta_],
                 [CodigoTransportista],
                 [TipoPortes],
                 [ObservacionesCliente],
                 [Comentarios],
                 [CodigoSigla],
                 [ViaPublica],
                 [Numero1],
                 [Numero2],
                 [Escalera],
                 [Piso],
                 [Puerta],
                 [Letra],
                 [CodigoPostal],
                 [CodigoMunicipio],
                 [Municipio],
                 [ColaMunicipio],
                 [CodigoProvincia],
                 [Provincia],
                 [CodigoNacion],
                 [Nacion],
                 [Telefono],
                 [Telefono2],
                 [Telefono3],
                 [Fax],
                 [Email1],
                 [HorarioDomicilioLc]
        FROM     [dbo].[Clientes]
        ORDER BY [id] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Clientes] OFF;
    END

DROP TABLE [dbo].[Clientes];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Clientes]', N'Clientes';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Iniciando recompilación de la tabla [dbo].[LineaAlbaran]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_LineaAlbaran] (
    [Id]         INT          IDENTITY (1, 1) NOT NULL,
    [AlbaranId]  INT          NOT NULL,
    [ArticuloId] INT          NOT NULL,
    [Cantidad]   INT          NOT NULL,
    [Precio]     DECIMAL (18) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[LineaAlbaran])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_LineaAlbaran] ON;
        INSERT INTO [dbo].[tmp_ms_xx_LineaAlbaran] ([Id], [AlbaranId], [Cantidad], [Precio])
        SELECT   [Id],
                 [AlbaranId],
                 [Cantidad],
                 [Precio]
        FROM     [dbo].[LineaAlbaran]
        ORDER BY [Id] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_LineaAlbaran] OFF;
    END

DROP TABLE [dbo].[LineaAlbaran];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_LineaAlbaran]', N'LineaAlbaran';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Creando FK_Albaran...';


GO
ALTER TABLE [dbo].[LineaAlbaran] WITH NOCHECK
    ADD CONSTRAINT [FK_Albaran] FOREIGN KEY ([AlbaranId]) REFERENCES [dbo].[Albarán] ([Id]);


GO
PRINT N'Creando FK_dbo.Tensorflex_dbo.Clientes_ID...';


GO
ALTER TABLE [dbo].[Albarán] WITH NOCHECK
    ADD CONSTRAINT [FK_dbo.Tensorflex_dbo.Clientes_ID] FOREIGN KEY ([ClienteId]) REFERENCES [dbo].[Clientes] ([id]);


GO
PRINT N'Creando FK_dbo.Tensorflex_dbo.Articulos_ArticuloID...';


GO
ALTER TABLE [dbo].[LineaAlbaran] WITH NOCHECK
    ADD CONSTRAINT [FK_dbo.Tensorflex_dbo.Articulos_ArticuloID] FOREIGN KEY ([ArticuloId]) REFERENCES [dbo].[Articulos] ([id]);


GO
PRINT N'Comprobando los datos existentes con las restricciones recién creadas';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[LineaAlbaran] WITH CHECK CHECK CONSTRAINT [FK_Albaran];

ALTER TABLE [dbo].[Albarán] WITH CHECK CHECK CONSTRAINT [FK_dbo.Tensorflex_dbo.Clientes_ID];

ALTER TABLE [dbo].[LineaAlbaran] WITH CHECK CHECK CONSTRAINT [FK_dbo.Tensorflex_dbo.Articulos_ArticuloID];


GO
PRINT N'Actualización completada.';


GO
