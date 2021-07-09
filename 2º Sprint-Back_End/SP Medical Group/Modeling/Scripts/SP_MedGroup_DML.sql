USE SP_MedicalGroup;

INSERT INTO dbo.Endereco (logradouro, numero, bairro, cidade, estado, cep)
VALUES (
	'Avenida Barão Limeira', '532', 'Santa Cecília', 'São Paulo', 'SP', ''
), (
	'Rua Vitória', '120', 'Vila São Jorge', 'Barueri', 'SP', '06402030'
), (
	'Rua Vereador Geraldo de Camargo', '66', 'Santa Luzia', 'Ribeirão Pires', 'SP', '09405380'
);

INSERT INTO dbo.Clinica (horaFuncionamento, cnpj, nomeFantasia, razaoSocial, idEndereco)
VALUES (
	'07:00-20:00', '86400902000130', 'Clínica Possarle', 'SP Medical Group', 1
);

INSERT INTO dbo.Especialidade (nome)
VALUES ( 
	'Acupuntura'
), ( 
	'Anestesiologia'
), ( 
	'Angiologia'
), ( 
	'Cardiologia'
), ( 
	'Cirurgia Cardiovascular'
), ( 
	'Cirurgia da Mão'
), ( 
	'Cirurgia do Aparelho Digestivo'
), ( 
	'Cirurgia Geral'
), ( 
	'Cirurgia Pediátrica'
), ( 
	'Cirurgia Torácica'
), ( 
	'Cirugia Vascular'
), ( 
	'Dermatologia'
), ( 
	'Radioterapia'
), ( 
	'Urologia'
), ( 
	'Pediatria'
), ( 
	'Psiquiatria'
);

INSERT INTO dbo.Situacao (tipo)
VALUES (
	'Agendada'
), (
	'Cancelada'
), (
	'Realizada'
);

INSERT INTO dbo.TipoUsuario (perfil)
VALUES (
	'Administrador'
), (
	'Médico'
), (
	'Paciente'
);

INSERT INTO dbo.Usuario (email, senha, idTipoUsuario)
VALUES (
	'rafael.silva@spmedicalgroup.com.br', '123456', 2
), (
	'fernando@gmail.com', '789456', 3
), (
	'admin.mg@spmedicalgroup.com.br', '123789', 1
), (
	'ricardo.souza@spmedicalgroup.com.br', '741852', 2
), (
	'joao@gmail.com', '963852', 3
), (
	'roberto.texeira@spmedicalgroup.com.br', '159753', 2
);

INSERT INTO dbo.Paciente (nome, telefone, dtNasc, rg, cpf, idUsuario, idEndereco)
VALUES (
	'Fernando', '11936586987', '06/08/1999', '369478125', '12345678974', 2, 2
), (
	'João', '11945878596', '07/04/1998', '256789482', '45678925896', 5, 3
);

INSERT INTO dbo.Medico (nome, crm, idUsuario, idEspecialidade, idClinica)
VALUES (
	'Rafael Silva', '54369SP', 1, 2, 1
), (
	'Ricardo Souza', '53789SP', 4, 16, 1
), (
	'Roberto Texeira', '68741SP', 6, 15, 1
);

INSERT INTO dbo.Consulta (dtAgendamento, descricao, idSituacao, idMedico, idPaciente)
VALUES (
	'06/09/2021  07:00', 'Texto...', 1, 2, 1
), (
	'10/03/2021 08:00', 'Texto...', 3, 1, 2
), (
	'25/05/2021 10:30', 'Texto...', 2, 3, 1
);
