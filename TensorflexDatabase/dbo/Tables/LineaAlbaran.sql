CREATE TABLE [dbo].[LineaAlbaran] (
    [Id]             INT          IDENTITY (1, 1) NOT NULL,
    [AlbaranId]      INT          NOT NULL,
	[ArticuloId]	INT	NOT NULL,
    [Cantidad]       INT          NOT NULL,
    [Precio]         DECIMAL (18) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Albaran] FOREIGN KEY ([AlbaranId]) REFERENCES [dbo].[Albarán] ([Id]),
    CONSTRAINT [FK_dbo.Tensorflex_dbo.Articulos_ArticuloID] FOREIGN KEY ([ArticuloId]) REFERENCES [dbo].[Articulos] ([id])
);


