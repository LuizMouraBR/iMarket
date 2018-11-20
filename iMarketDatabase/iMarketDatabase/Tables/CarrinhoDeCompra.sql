CREATE TABLE [dbo].[CarrinhoDeCompra]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [produto_id] INT NOT NULL, 
    [usuario_id] INT NOT NULL, 
    CONSTRAINT [produto_id] FOREIGN KEY (produto_id) REFERENCES produto(id), 
    CONSTRAINT [usuario_id] FOREIGN KEY (usuario_id) REFERENCES usuario(id) 
)
