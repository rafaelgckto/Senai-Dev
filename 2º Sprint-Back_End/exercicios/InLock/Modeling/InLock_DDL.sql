CREATE DATABASE InLock_Games;
GO

USE InLock_Games;

CREATE TABLE Estudios(
	idEstudio	INT IDENTITY(1, 1),
	nome		VARCHAR(50),
	CONSTRAINT PK_Estudios PRIMARY KEY (idEstudio)
);
GO

CREATE TABLE Jogos(
	idJogo			INT IDENTITY(1, 1),
	nome			VARCHAR(50),
	descricao		VARCHAR(150),
	dtLancamento	DATE,
	valor			DECIMAL(5, 2),
	idEstudio		INT,
	CONSTRAINT PK_Jogos PRIMARY KEY (idJogo),
	CONSTRAINT FK_Estudios_Jogos FOREIGN KEY (idEstudio) REFERENCES Estudios (idEstudio)
);
GO

CREATE TABLE TipoUsuario(
	idTipoUsuario	INT IDENTITY(1, 1),
	titulo			VARCHAR(50),
	CONSTRAINT PK_TipoUsuario PRIMARY KEY (idTipoUsuario)
);
GO

CREATE TABLE Usuario(
	idUsuario		INT IDENTITY(1, 1),
	email			VARCHAR(50),
	senha			VARCHAR(255),
	idTipoUsuario	INT,
	CONSTRAINT PK_Usuario PRIMARY KEY (idUsuario),
	CONSTRAINT FK_TipoUsuario_Usuario FOREIGN KEY (idTipoUsuario) REFERENCES TipoUsuario (idTipoUsuario)
);
GO