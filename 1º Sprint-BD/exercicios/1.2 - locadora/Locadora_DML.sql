USE Locadora;
GO

INSERT INTO Marca (nome) VALUES (
	'Ford'
), (
	'GM'
), (
	'Fiat'
);
GO

INSERT INTO Modelo (idMarca, nome) VALUES (
	1, 'Fiesta'
), (
	2, 'Onix'
), (
	3, 'Argo'
);
GO

INSERT INTO Empresa (nome) VALUES (
	'Unidas'
), (
	'Localiza'
);
GO

INSERT INTO Veiculo (idEmpresa, idModelo, placa) VALUES (
	1, 1, 'HEL1805'
), (
	1, 2, 'FER1010'
), (
	2, 3, 'POR1978'
), (
	2, 1, 'LEM9876'
);
GO

INSERT INTO Cliente (nome, cpf) VALUES (
	'Saulo', '99999999999'
), (
	'Caique', '88888888888'
);
GO

INSERT INTO Aluguel (idVeiculo, idCliente, dtInicio, dtFim) VALUES (
	1, 1, '19/01/2019', '20/01/2019'
), (
	2, 1, '20/01/2019', '21/01/2019'
), (
	3, 2, '21/01/2019', '21/01/2019'
), (
	2, 2, '22/01/2019', '22/01/2019'
);
GO