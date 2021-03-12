CREATE DATABASE Locadora;
GO

USE Locadora;

CREATE TABLE Marca (
	idMarca INT IDENTITY NOT NULL,
	nome VARCHAR(50) NOT NULL,
	CONSTRAINT PK_idMarca PRIMARY KEY (idMarca)
);
GO

CREATE TABLE Modelo (
	idModelo INT IDENTITY NOT NULL,
	idMarca INT NOT NULL,
	nome VARCHAR(50) NOT NULL,
	CONSTRAINT PK_idModelo PRIMARY KEY (idModelo),
	CONSTRAINT FK_idMarca FOREIGN KEY (idMarca) REFERENCES Marca (idMarca)
);
GO

CREATE TABLE Empresa (
	idEmpresa INT IDENTITY NOT NULL,
	nome VARCHAR(50),
	CONSTRAINT PK_idEmpresa PRIMARY KEY (idEmpresa)
);
GO

CREATE TABLE Veiculo (
	idVeiculo INT IDENTITY NOT NULL,
	idEmpresa INT NOT NULL,
	idModelo INT NOT NULL,
	placa CHAR(7) NOT NULL,
	CONSTRAINT PK_idVeiculo PRIMARY KEY (idVeiculo),
	CONSTRAINT FK_idEmpresa FOREIGN KEY (idEmpresa) REFERENCES Empresa (idEmpresa),
	CONSTRAINT FK_idModelo FOREIGN KEY (idModelo) REFERENCES Modelo (idModelo)
);
GO

CREATE TABLE Cliente (
	idCliente INT IDENTITY NOT NULL,
	nome VARCHAR(40) NOT NULL,
	cpf CHAR(11),
	CONSTRAINT PK_idCliente PRIMARY KEY (idCliente)
);
GO

CREATE TABLE Aluguel (
	idAluguel INT IDENTITY NOT NULL,
	idVeiculo INT NOT NULL,
	idCliente INT NOT NULL,
	dtInicio DATE NOT NULL,
	dtFim DATE NOT NULL,
	CONSTRAINT PK_idAluguel PRIMARY KEY (idAluguel),
	CONSTRAINT FK_idVeiculo FOREIGN KEY (idVeiculo) REFERENCES Veiculo (idVeiculo),
	CONSTRAINT FK_idCliente FOREIGN KEY (idCliente) REFERENCES Cliente (idCliente),
);
GO