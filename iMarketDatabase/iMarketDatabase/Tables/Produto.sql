CREATE TABLE [dbo].[Produto]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [nome] VARCHAR(50) NOT NULL, 
    [marca] VARCHAR(50) NOT NULL, 
    [preco] FLOAT NOT NULL, 
    [imagem] VARCHAR(MAX) NULL, 
    [desconto] INT NULL, 
    [categoria_id] INT NOT NULL, 
    [fornecedor_id] INT NOT NULL, 
    CONSTRAINT [categoria_id] FOREIGN KEY (categoria_id) REFERENCES categoria(id), 
    CONSTRAINT [fornecedor_id] FOREIGN KEY (fornecedor_id) REFERENCES fornecedor(id)
)
