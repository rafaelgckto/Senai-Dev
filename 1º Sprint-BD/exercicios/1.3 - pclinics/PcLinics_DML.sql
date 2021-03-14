USE PcLinics;

INSERT INTO TipoPets (nome) VALUES (
	'Cachorro'
), (
	'Gato'
);
GO

INSERT INTO Raca (idTipoPets, nome) VALUES (
	1, 'Poodle'
), (
	1, 'Labrador'
), (
	1, 'SRD'
), (
	2, 'Siamês'
);
GO

INSERT INTO Dono (nome) VALUES (
	'Paulo'
), (
	'Odirlei'
);
GO

INSERT INTO Pets (idRaca, idDono, nome, dtNasc) VALUES (
	1, 1, 'Junior', '10/10/2018'
), (
	4, 1, 'Loli', '18/05/2017'
), (
	1, 2, 'Sammy', '16/06/2016'
);
GO

INSERT INTO Clinica (razaoSocial, cnpj, endereco) VALUES (
	'Meu Pimpão', '99999999999999', 'Av. Barão de Limeira, 539'
);
GO

INSERT INTO Veterinarios (idClinica, nome, crmv) VALUES (
	1, 'Saulo', '432551'
), (
	1, 'Caique', '653655'
);
GO

INSERT INTO Atendimento (idVeterinarios, idPets, descricao, dtAtendimento) VALUES (
	1, 2, 'Restam 10 dias de vida', '21/01/2020'
), (
	2, 2, 'O paciente está ok', '22/01/2020'
), (
	2, 1, 'O paciente está ok', '23/01/2020'
);
GO