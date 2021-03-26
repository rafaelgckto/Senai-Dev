CREATE DATABASE Peoples;
GO

USE Peoples;

CREATE TABLE Funcionario (
	idFuncionario	INT IDENTITY,
	nome			VARCHAR(30) NOT NULL,
	sobrenome		VARCHAR(25) NOT NULL,
	CONSTRAINT PK_idFuncionario PRIMARY KEY (idFuncionario)
);
GO