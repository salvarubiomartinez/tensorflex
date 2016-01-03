CREATE TABLE [dbo].[Albarán] (
    [Id]            INT          IDENTITY (1, 1) NOT NULL,
	[ClienteId] INT NOT NULL,
    [Fecha]         DATE         NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Tensorflex_dbo.Clientes_ID] FOREIGN KEY ([ClienteId]) REFERENCES [dbo].[Clientes] ([id])
);


