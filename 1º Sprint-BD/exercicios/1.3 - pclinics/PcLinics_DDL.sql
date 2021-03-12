CREATE DATABASE PcLinics;
GO

USE PcLinics;

CREATE TABLE TipoPets (
	idTipoPets INT IDENTITY,
	nome VARCHAR(35) NOT NULL,
	CONSTRAINT PK_idTipoPets PRIMARY KEY (idTipoPets)
);
GO

CREATE TABLE Raca (
	idRaca INT IDENTITY,
	idTipoPets INT NOT NULL,
	nome VARCHAR(35) NOT NULL,
	CONSTRAINT PK_idRaca PRIMARY KEY (idRaca),
	CONSTRAINT FK_idTipoPets FOREIGN KEY (idTipoPets) REFERENCES TipoPets (idTipoPets)
);
GO

CREATE TABLE Dono (
	idDono INT IDENTITY,
	nome VARCHAR(35) NOT NULL,
	CONSTRAINT PK_idDone PRIMARY KEY (idDono)
);
GO

CREATE TABLE Pets (
	idPets INT IDENTITY,
	idRaca INT NOT NULL,
	idDono INT NOT NULL,
	nome VARCHAR(35) NOT NULL,
	dtNasc DATE NOT NULL,
	CONSTRAINT PK_idPets PRIMARY KEY (idPets),
	CONSTRAINT FK_idRaca FOREIGN KEY (idRaca) REFERENCES Raca (idRaca),
	CONSTRAINT FK_idDono FOREIGN KEY (idDono) REFERENCES Dono (idDono)
);
GO

CREATE TABLE Clinica (
	idClinica INT IDENTITY,
	razaoSocial VARCHAR(50) NOT NULL,
	cnpj CHAR(14) NOT NULL,
	endereco VARCHAR(100) NOT NULL,
	CONSTRAINT PK_idClinica PRIMARY KEY (idClinica)
);
GO

CREATE TABLE Veterinarios (
	idVeterinarios INT IDENTITY,
	idClinica INT NOT NULL,
	nome VARCHAR(50) NOT NULL,
	crmv VARCHAR(10) NOT NULL,
	CONSTRAINT PK_idVeterinarios PRIMARY KEY (idVeterinarios),
	CONSTRAINT FK_idClinica FOREIGN KEY (idClinica) REFERENCES Clinica (idClinica)
);
GO

CREATE TABLE Atendimento (
	idAtendimento INT IDENTITY,
	idVeterinarios INT NOT NULL,
	idPets INT NOT NULL,
	descricao VARCHAR(100) NOT NULL,
	dtAtendimento DATE NOT NULL,
	CONSTRAINT PK_idAtendimento PRIMARY KEY (idAtendimento),
	CONSTRAINT FK_idVeterinarios FOREIGN KEY (idVeterinarios) REFERENCES Veterinarios (idVeterinarios),
	CONSTRAINT FK_idPets FOREIGN KEY (idPets) REFERENCES Pets (idPets)
);
GO