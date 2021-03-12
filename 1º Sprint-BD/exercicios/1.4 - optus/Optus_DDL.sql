CREATE DATABASE Optus;
GO

USE Optus;

CREATE TABLE Usuario (
	idUsuario INT IDENTITY,
	nome VARCHAR(50) NOT NULL,
	email VARCHAR(35) NOT NULL,
	senha VARCHAR(50) NOT NULL,
	permissao BIT DEFAULT(0) NOT NULL,
	CONSTRAINT PK_idUsuario PRIMARY KEY (idUsuario)
);
GO

CREATE TABLE Artista (
	idArtista INT IDENTITY,
	nome VARCHAR(50) NOT NULL,
	CONSTRAINT PK_idArtista PRIMARY KEY (idArtista)
);
GO

CREATE TABLE Album (
	idAlbum INT IDENTITY,
	idArtista INT NOT NULL,
	titulo VARCHAR(50) NOT NULL,
	dtLancamento DATE NOT NULL,
	localizacao VARCHAR(50) NOT NULL,
	qtdMinutos VARCHAR(35) NOT NULL,
	ativo BIT NOT NULL,
	CONSTRAINT PK_idAlbum PRIMARY KEY (idAlbum),
	CONSTRAINT FK_idArtista FOREIGN KEY (idArtista) REFERENCES Artista (idArtista)
);
GO

CREATE TABLE Estilo (
	idEstilo INT IDENTITY,
	nome VARCHAR(50) NOT NULL,
	CONSTRAINT PK_idEstilo PRIMARY KEY (idEstilo)
);
GO

CREATE TABLE Album_Estilo (
	idAlbumEstilo INT IDENTITY,
	idAlbum INT NOT NULL,
	idEstilo INT NOT NULL,
	CONSTRAINT PK_idAlbumEstilo PRIMARY KEY (idAlbumEstilo),
	CONSTRAINT FK_idAlbum FOREIGN KEY (idAlbum) REFERENCES Album (idAlbum),
	CONSTRAINT FK_idEstilo FOREIGN KEY (idEstilo) REFERENCES Estilo (idEstilo) 
);
GO