CREATE TABLE [dbo].[Fornecedor]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [nomeFantasia] VARCHAR(100) NOT NULL, 
    [razaoSocial] VARCHAR(100) NULL, 
    [cnpj] VARCHAR(50) NOT NULL, 
    [endereco] VARCHAR(MAX) NOT NULL, 
    [reputacao] FLOAT NOT NULL DEFAULT 5
)
