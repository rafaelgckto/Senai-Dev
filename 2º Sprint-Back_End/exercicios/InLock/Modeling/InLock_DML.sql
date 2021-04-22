USE InLock_Games;

INSERT INTO Estudios(nome)
VALUES( 'Blizzard' ), ( 'Rockstar Studios' ), ( 'Square Enix' );

INSERT INTO Jogos(nome, descricao, dtLancamento, valor, idEstudio)
VALUES( 
	'Diablo 3', '� um jogo que cont�m bastante a��o e � viciante, seja voc� um novato ou f�.', '15/05/2012', 99.00, 1
), (
	'Red Dead Redemption II', 'Jogo eletr�nico de a��o-aventura western', '26/10/2018', 120.00, 2
);

INSERT INTO TipoUsuario(titulo)
VALUES( 'Administrador' ), ( 'Cliente' );

INSERT INTO Usuario(email, senha, idTipoUsuario)
VALUES(
	'admin@admin.com', 'admin', 1
), (
	'cliente@cliente.com', 'cliente', 2
);