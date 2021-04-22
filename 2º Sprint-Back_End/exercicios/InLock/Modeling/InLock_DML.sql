USE InLock_Games;

INSERT INTO Estudios(nome)
VALUES( 'Blizzard' ), ( 'Rockstar Studios' ), ( 'Square Enix' );

INSERT INTO Jogos(nome, descricao, dtLancamento, valor, idEstudio)
VALUES( 
	'Diablo 3', 'É um jogo que contém bastante ação e é viciante, seja você um novato ou fã.', '15/05/2012', 99.00, 1
), (
	'Red Dead Redemption II', 'Jogo eletrônico de ação-aventura western', '26/10/2018', 120.00, 2
);

INSERT INTO TipoUsuario(titulo)
VALUES( 'Administrador' ), ( 'Cliente' );

INSERT INTO Usuario(email, senha, idTipoUsuario)
VALUES(
	'admin@admin.com', 'admin', 1
), (
	'cliente@cliente.com', 'cliente', 2
);