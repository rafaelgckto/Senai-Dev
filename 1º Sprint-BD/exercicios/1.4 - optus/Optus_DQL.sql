USE Optus;

SELECT * FROM Usuario;
SELECT * FROM Artista;
SELECT * FROM Album;
SELECT * FROM Estilo;
SELECT * FROM Album_Estilo;

SELECT U.nome AS [Usuário], U.email AS [E-mail], U.senha AS [Senha] 
FROM Usuario AS U
WHERE permissao = 0; 

SELECT *
FROM Album
WHERE dtLancamento = '2012';

SELECT nome, email
FROM Usuario
WHERE email = 's.santos@email.com' AND senha = '123456';

SELECT AR.nome AS [Artista], E.nome AS [Estilo]
FROM Album_Estilo AS AE
INNER JOIN Album AS AL ON AE.idAlbum = AL.idAlbum
INNER JOIN Artista AS AR ON AL.idArtista = AR.idArtista
INNER JOIN Estilo AS E ON AE.idEstilo = E.idEstilo
WHERE AL.ativo = 1;