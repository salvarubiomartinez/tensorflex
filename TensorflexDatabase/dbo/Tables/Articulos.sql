CREATE TABLE [dbo].[Articulos] (
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
    [id] INT IDENTITY (2000,1) NOT NULL, 
    PRIMARY KEY CLUSTERED ([ID] ASC)
);


