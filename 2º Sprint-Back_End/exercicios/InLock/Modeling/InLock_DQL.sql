USE InLock_Games;

-- Listar todos os usuários.
SELECT *
FROM Usuario;

-- Listar todos os estúdios.
SELECT *
FROM Estudios;

-- Listar todos os jogos.
SELECT *
FROM Jogos;

-- Listar todos os jogos e seus respectivos estúdios.
SELECT *
FROM Jogos AS J
INNER JOIN Estudios AS E 
ON J.idEstudio = E.idEstudio;

-- Buscar e trazer na lista todos os estúdios com os respectivos jogos.
-- Obs.: Listar todos os estúdios mesmo que eles não contenham nenhum jogo de referência;
SELECT *
FROM Jogos AS J
RIGHT JOIN Estudios AS E 
ON J.idEstudio = E.idEstudio;

-- Buscar um usuário por e-mail e senha (login).
DECLARE @email VARCHAR(50) = 'admin@admin.com',
		@senha VARCHAR(255) = 'admin';

SELECT U.email, U.senha, TU.titulo
FROM Usuario AS U
INNER JOIN TipoUsuario AS TU
ON U.idTipoUsuario = TU.idTipoUsuario
WHERE email = @email AND senha = @senha;

-- Buscar um jogo por idJogo.
SELECT *
FROM Jogos
WHERE idJogo = 1;

-- Buscar um estúdio por idEstudio.
SELECT *
FROM Estudios
WHERE idEstudio = 1;