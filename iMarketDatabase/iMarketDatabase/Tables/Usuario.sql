﻿CREATE TABLE [dbo].[Usuario]
(
	[Id] INT NOT NULL PRIMARY KEY  IDENTITY, 
    [nome] VARCHAR(70) NOT NULL, 
    [email] VARCHAR(70) NOT NULL, 
    [senha] VARCHAR(16) NOT NULL, 
    [saldo] FLOAT NOT NULL DEFAULT 0.0
)
