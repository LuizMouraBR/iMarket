CREATE TABLE [dbo].[Usuario] (
    [Id]          INT          IDENTITY (1, 1) NOT NULL,
    [nome]        VARCHAR (70) NOT NULL,
    [email]       VARCHAR (70) NOT NULL,
    [senha]       VARCHAR (16) NOT NULL,
    [saldo]       FLOAT (53)   DEFAULT ((0.0)) NOT NULL,
    [nivelAcesso] INT          NOT NULL,
    [fornecedor_id] INT NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC), 
    CONSTRAINT [FK_FornecedorId] FOREIGN KEY (fornecedor_id) REFERENCES Fornecedor(Id)
);

