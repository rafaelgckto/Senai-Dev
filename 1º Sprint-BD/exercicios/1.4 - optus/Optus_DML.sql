USE Optus;

--Usuario.permissao (0 - Administrador : 1 - Comum)
INSERT INTO Usuario (nome, email, senha, permissao) VALUES (
	'Saulo', 's.santos@email.com', '123456', 0
), (
	'Caique', 'c.zaneti@email.com', '123456', 1
);
GO

INSERT INTO Artista (nome) VALUES (
	'Angra'
), (
	'Madonna'
), (
	'Shaman'
);
GO

INSERT INTO Album (idArtista, titulo, dtLancamento, localizacao, qtdMinutos, ativo) VALUES (
	1, 'Holy Land', '1996', 'Brasil','57', 1
), (
	2, 'MDNA', '2012', 'EUA', '75', 0
);
GO

INSERT INTO Estilo (nome) VALUES (
	'Rock'	
), (
	'Pop'
), (
	'Metal'
);
GO

INSERT INTO Album_Estilo (idAlbum, idEstilo) VALUES (
	1, 1
), (
	1, 3
), (
	2, 1
);
GO