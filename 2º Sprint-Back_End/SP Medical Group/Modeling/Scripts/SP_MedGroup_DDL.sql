IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'SP_MedicalGroup')
BEGIN
	CREATE DATABASE SP_MedicalGroup; -- Criação do banco de dados (database).
END

GO

USE SP_MedicalGroup;
GO

--Você precisa checar se a tabela existe
IF NOT EXISTS(SELECT * FROM sys.objects WHERE name = 'Endereco' AND type = 'U')
BEGIN
	CREATE TABLE dbo.Endereco(
		idEndereco	INT IDENTITY(1, 1),
		logradouro	VARCHAR(50) NOT NULL,
		numero		VARCHAR(4) NOT NULL,
		bairro		VARCHAR(30) NOT NULL,
		cidade		VARCHAR(35) NOT NULL,
		estado		VARCHAR(30) NOT NULL,
		cep			CHAR(8) NOT NULL,
		CONSTRAINT PK_Endereco PRIMARY KEY (idEndereco)
	);
END

GO


IF NOT EXISTS( SELECT * FROM sys.objects WHERE name = 'Paciente' AND type = 'U' )
BEGIN
	CREATE TABLE dbo.Paciente(
		idPaciente	INT IDENTITY(1, 1),
		telefone	VARCHAR(11) NOT NULL,
		dtNasc		DATE NOT NULL,
		rg			VARCHAR(9) NOT NULL,
		cpf			VARCHAR(11) NOT NULL,
		idEndereco	INT NOT NULL,
		CONSTRAINT PK_Paciente PRIMARY KEY (idPaciente),
		CONSTRAINT FK_Endereco_Paciente FOREIGN KEY (idEndereco) REFERENCES Endereco (idEndereco),
		CONSTRAINT UQ_Paciente UNIQUE (telefone, rg, cpf)
	);
END

GO

--Adicionar Tabela 'HoraFuncionamento' com atributos "abertura" e "fechamento". Relação 1:1 chave FK vai na tabela Clinica.
/*CREATE TABLE HoraFuncionamento(
	idHF		INT IDENTITY(1, 1),
	abertura	VARCHAR(5) NOT NULL,
	fechamento	VARCHAR(5) NOT NULL,
	CONSTRAINT PK_HoraFuncionamento PRIMARY KEY (idHF),
	CONSTRAINT UQ_HoraFuncionamento UNIQUE (abertura, fechamento)
);
GO*/

IF NOT EXISTS( SELECT * FROM sys.objects WHERE name = 'Clinica' AND type = 'U' )
BEGIN
	CREATE TABLE dbo.Clinica(
		idClinica			INT IDENTITY(1, 1),
		horaFuncionamento	VARCHAR(11) NOT NULL,
		cnpj				CHAR(14) NOT NULL,
		nomeFantasia		VARCHAR(50) NOT NULL,
		razaoSocial			VARCHAR(35) NOT NULL,
		idEndereco			INT NOT NULL,
		CONSTRAINT PK_Clinica PRIMARY KEY (idClinica),
		CONSTRAINT FK_Endereco_Clinica FOREIGN KEY (idEndereco) REFERENCES Endereco (idEndereco),
		CONSTRAINT UQ_Clinica UNIQUE (cnpj)
	);
END

GO

IF NOT EXISTS( SELECT * FROM sys.objects WHERE name = 'Especialidade' AND type = 'U' )
BEGIN
	CREATE TABLE dbo.Especialidade(
		idEspecialidade	INT IDENTITY(1, 1),
		nome			VARCHAR(50) NOT NULL,
		CONSTRAINT PK_Especialidade PRIMARY KEY (idEspecialidade),
		CONSTRAINT UQ_Especialidade UNIQUE (nome)
	);
END

GO

IF NOT EXISTS( SELECT * FROM sys.objects WHERE name = 'Medico' AND type = 'U' )
BEGIN
	CREATE TABLE dbo.Medico(
		idMedico		INT IDENTITY(1, 1),
		crm				CHAR(8) NOT NULL,
		idEspecialidade	INT NOT NULL,
		idClinica		INT NOT NULL,
		CONSTRAINT PK_Medico PRIMARY KEY (idMedico),
		CONSTRAINT FK_Especialidade_Medico FOREIGN KEY (idEspecialidade) REFERENCES Especialidade (idEspecialidade),
		CONSTRAINT FK_Clinica_Medico FOREIGN KEY (idClinica) REFERENCES Clinica (idClinica),
		CONSTRAINT UQ_Medico UNIQUE (crm)
	);
END

GO

IF NOT EXISTS( SELECT * FROM sys.objects WHERE name = 'Situacao' AND type = 'U' )
BEGIN
	CREATE TABLE dbo.Situacao(
		idSituacao	INT IDENTITY(1, 1),
		tipo		VARCHAR(30) NOT NULL,
		CONSTRAINT PK_Situacao PRIMARY KEY (idSituacao),
		CONSTRAINT UQ_Situacao UNIQUE (tipo)
	);
END

GO

IF NOT EXISTS( SELECT * FROM sys.objects WHERE name = 'Consulta' AND type = 'U' )
BEGIN
	CREATE TABLE dbo.Consulta(
		idConsulta		INT IDENTITY(1, 1),
		dtAgendamento	DATETIME NOT NULL,
		descricao		VARCHAR(100) NOT NULL,
		idSituacao		INT NOT NULL,
		idMedico		INT NOT NULL,
		idPaciente		INT NOT NULL,
		CONSTRAINT PK_Consulta PRIMARY KEY (idConsulta),
		CONSTRAINT FK_Situacao_Consulta FOREIGN KEY (idSituacao) REFERENCES Situacao (idSituacao),
		CONSTRAINT FK_Medico_Consulta FOREIGN KEY (idMedico) REFERENCES Medico (idMedico),
		CONSTRAINT FK_Paciente_Consulta FOREIGN KEY (idPaciente) REFERENCES Paciente (idPaciente)
	);
END

GO


IF NOT EXISTS( SELECT * FROM sys.objects WHERE name = 'TipoUsuario' AND type = 'U' )
BEGIN
	CREATE TABLE dbo.TipoUsuario(
		idTipoUsuario	INT IDENTITY(1, 1),
		perfil			VARCHAR(14) NOT NULL,
		CONSTRAINT PK_TipoUsuario PRIMARY KEY (idTipoUsuario),
		CONSTRAINT UQ_TipoUsuario UNIQUE (perfil)
	);
END

GO

IF NOT EXISTS( SELECT * FROM sys.objects WHERE name = 'Usuario' AND type = 'U' )
BEGIN
	CREATE TABLE dbo.Usuario(
		idUsuario		INT IDENTITY(1, 1),
		nome			VARCHAR(35) NOT NULL,
		email			VARCHAR(50) NOT NULL,
		senha			VARCHAR(255) NOT NULL,
		idTipoUsuario	INT NOT NULL,
		idPaciente		INT,
		idMedico		INT,
		CONSTRAINT PK_Usuario PRIMARY KEY (idUsuario),
		CONSTRAINT FK_TipoUsuario_Usuario FOREIGN KEY (idTipoUsuario) REFERENCES TipoUsuario (idTipoUsuario),
		CONSTRAINT FK_Paciente_Usuario FOREIGN KEY (idPaciente) REFERENCES Paciente (idPaciente),
		CONSTRAINT FK_Medico_Usuario FOREIGN KEY (idMedico) REFERENCES Medico (idMedico),
		CONSTRAINT UQ_Usuario UNIQUE (email, idPaciente, idMedico)
	);
END

GO