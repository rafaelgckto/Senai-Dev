IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'Senai_Hroads_Manha')
BEGIN
	CREATE DATABASE Senai_Hroads_Manha;
END

GO

/*
IF( SELECT * FROM sys.schemas WHERE name = '[name_schema]' )
BEGIN
	CREATE SCHEMA [name_schema] [AUTHORIZATION owner_name];
END

GO
*/

USE Senai_Hroads_Manha;

IF NOT EXISTS(SELECT * FROM sys.objects WHERE name = 'TipoHabilidade' AND type = 'U')
BEGIN
	CREATE TABLE dbo.TipoHabilidade(
		idTipoHabilidade	INT IDENTITY(1, 1),
		tipo				VARCHAR(25),
		CONSTRAINT PK_TipoHabilidade PRIMARY KEY(idTipoHabilidade)
	);
END

GO

IF NOT EXISTS(SELECT * FROM sys.objects WHERE name = 'Habilidade' AND type = 'U')
BEGIN
	CREATE TABLE dbo.Habilidade(
		idHabilidade		INT IDENTITY(1, 1),
		nome				VARCHAR(30),
		idTipoHabilidade	INT,
		CONSTRAINT PK_Habilidade PRIMARY KEY (idHabilidade),
		CONSTRAINT FK_TipoHabilidade_Habilidade FOREIGN KEY(idTipoHabilidade) REFERENCES TipoHabilidade(idTipoHabilidade)
	);
END

GO

IF NOT EXISTS(SELECT * FROM sys.objects WHERE name = 'Classe' AND type = 'U')
BEGIN
	CREATE TABLE dbo.Classe(
		idClasse	INT IDENTITY(1, 1),
		nome		VARCHAR(35),
		CONSTRAINT PK_Classe PRIMARY KEY(idClasse)
	);
END

GO

IF NOT EXISTS(SELECT * FROM sys.objects WHERE name = 'Classe_Habilidade' AND type = 'U')
BEGIN
	CREATE TABLE dbo.Classe_Habilidade(
		idClasseHabilidade	INT IDENTITY(1, 1),
		idClasse			INT,
		idHabilidade		INT,
		CONSTRAINT PK_ClasseHabilidade PRIMARY KEY(idClasseHabilidade),
		CONSTRAINT FK_Classe FOREIGN KEY(idClasse) REFERENCES Classe(idClasse),
		CONSTRAINT FK_Habilidade FOREIGN KEY(idHabilidade) REFERENCES Habilidade(idHabilidade)
	);
END

GO

IF NOT EXISTS(SELECT * FROM sys.objects WHERE name = 'Personagem' AND type = 'U')
BEGIN
	CREATE TABLE dbo.Personagem(
		idPersonagem	INT IDENTITY(1, 1),
		nome			VARCHAR(50),
		idClasse		INT,
		vida			DECIMAL(5, 2),
		mana			DECIMAL(5, 2),
		dtAtualizacao	DATE,
		dtCricao		DATE,
		CONSTRAINT PK_Personagem PRIMARY KEY(idPersonagem),
		CONSTRAINT FK_Classe_Personagem FOREIGN KEY(idClasse) REFERENCES Classe(idClasse)
	);
END

GO

IF NOT EXISTS(SELECT * FROM sys.objects WHERE name = 'TipoUsuario' AND type = 'U')
BEGIN
	CREATE TABLE dbo.TipoUsuario(
		idTipoUsuario	INT IDENTITY(1, 1),
		tipo			VARCHAR(25),
		CONSTRAINT PK_TipoUsuario PRIMARY KEY(idTipoUsuario)
	);
END

GO

IF NOT EXISTS(SELECT * FROM sys.objects WHERE name = 'Usuario' AND type = 'U')
BEGIN
	CREATE TABLE dbo.Usuario(
		idUsuario		INT IDENTITY(1, 1),
		email			VARCHAR(50),
		senha			VARCHAR(255),
		idTipoUsuario	INT,
		CONSTRAINT PK_Usuario PRIMARY KEY(idUsuario),
		CONSTRAINT FK_TipoUsuario_PK_Usuario FOREIGN KEY(idTipoUsuario) REFERENCES TipoUsuario(idTipoUsuario)
	);
END

GO
