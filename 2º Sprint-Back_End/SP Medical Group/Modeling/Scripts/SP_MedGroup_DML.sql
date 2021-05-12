USE SP_MedicalGroup;

INSERT INTO dbo.Endereco (logradouro, numero, bairro, cidade, estado, cep)
VALUES (
	'Avenida Bar�o Limeira', '532', 'Santa Cec�lia', 'S�o Paulo', 'SP', ''
), (
	'Rua Vit�ria', '120', 'Vila S�o Jorge', 'Barueri', 'SP', '06402030'
), (
	'Rua Vereador Geraldo de Camargo', '66', 'Santa Luzia', 'Ribeir�o Pires', 'SP', '09405380'
);

INSERT INTO dbo.Paciente (telefone, dtNasc, rg, cpf, idEndereco)
VALUES (
	'11936586987', '06/08/1999', '369478125', '12345678974', 2
), (
	'11945878596', '07/04/1998', '256789482', '45678925896', 3
);

INSERT INTO dbo.Clinica (horaFuncionamento, cnpj, nomeFantasia, razaoSocial, idEndereco)
VALUES (
	'07:00-20:00', '86400902000130', 'Cl�nica Possarle', 'SP Medical Group', 1
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
	'Cirurgia da M�o'
), ( 
	'Cirurgia do Aparelho Digestivo'
), ( 
	'Cirurgia Geral'
), ( 
	'Cirurgia Pedi�trica'
), ( 
	'Cirurgia Tor�cica'
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

INSERT INTO dbo.Medico (crm, idEspecialidade, idClinica)
VALUES (
	'54369SP', 2, 1
), (
	'53789SP', 16, 1
), (
	'68741SP', 15, 1
);

INSERT INTO dbo.Situacao (tipo)
VALUES (
	'Agendada'
), (
	'Cancelada'
), (
	'Realizada'
);

INSERT INTO dbo.Consulta (dtAgendamento, descricao, idSituacao, idMedico, idPaciente)
VALUES (
	'06/09/2021  07:00', 'Texto...', 1, 2, 1
), (
	'10/03/2021 08:00', 'Texto...', 3, 1, 2
), (
	'25/05/2021 10:30', 'Texto...', 2, 3, 1
);

INSERT INTO dbo.TipoUsuario (perfil)
VALUES (
	'Administrador'
), (
	'M�dico'
), (
	'Paciente'
);

INSERT INTO dbo.Usuario (nome, email, senha, idTipoUsuario, idPaciente, idMedico)
VALUES (
	'Rafael Silva', 'rafael.silva@spmedicalgroup.com.br', '123456', 2, NULL, 1
), (
	'Fernando', 'fernando@gmail.com', '789456', 3, 1, NULL
), (
	'AdminMG', 'admin.mg@spmedicalgroup.com.br', '123789', 1, NULL, NULL
), (
	'Ricardo Souza', 'ricardo.souza@spmedicalgroup.com.br', '741852', 2, NULL, 2
), (
	'Jo�o', 'joao@gmail.com', '963852', 3, 2, NULL
), (
	'Roberto Texeira', 'roberto.texeira@spmedicalgroup.com.br', '159753', 2, NULL, 3
);