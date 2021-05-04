USE Senai_Hroads_Manha;

-- Listar em qual valor está o AUTO_INCREMENT da tabela.
SELECT IDENT_CURRENT('Habilidade');

-- Redefinir coluna de identidade com novo id.
declare @max int
select @max=ISNULL(MAX(dbo.Habilidade.idHabilidade), 0) from dbo.Habilidade;
DBCC CHECKIDENT('dbo.Habilidade', RESEED, @max);

-----------------------------------------------

-- Atualizar o nome do personagem Fer8 para Fer7.
UPDATE dbo.Personagem
SET nome = 'Fer7'
WHERE dbo.Personagem.idPersonagem = 3;

-- Atualizar o nome da classe de Necromante para Necromancer.
UPDATE dbo.Classe
SET nome = 'Necromancer'
WHERE dbo.Classe.idClasse = 5;

-- Selecionar todos os personagens.
SELECT *
FROM dbo.Personagem;

-- Selecionar todas as classes.
SELECT *
FROM dbo.Classe;

-- Selecionar somente o nome das classes.
SELECT dbo.Classe.nome AS [Classe]
FROM dbo.Classe;

-- Selecionar todas as habilidades.
SELECT *
FROM dbo.Habilidade;

-- Realizar contagem de quantas habilidades estão cadastradas.
SELECT COUNT(dbo.Habilidade.idHabilidade) AS [Qtd. d/ Habilidades]
FROM dbo.Habilidade;

-- Selecionar somente os id's das habilidades classificando-os por ordem crescente.
SELECT *
FROM dbo.Habilidade
ORDER BY dbo.Habilidade.idHabilidade ASC;

-- Selecionar todos os tipos de habilidades.
SELECT *
FROM dbo.TipoHabilidade;

-- Selecionar todas as habilidades e a quais tipos de habilidades elas fazem parte.
SELECT H.idHabilidade, H.nome AS [Habilidade], TH.tipo AS [Tipo]
FROM dbo.Habilidade AS H
INNER JOIN dbo.TipoHabilidade AS TH
ON H.idTipoHabilidade = TH.idTipoHabilidade;

-- Selecionar todos os personagem e suas respectivas classes.
SELECT P.idPersonagem, P.nome AS [Personagem], C.nome AS [Classe], P.vida AS [Vida], P.mana AS [Mana], P.dtAtualizacao AS [Dt. Atualização], P.dtCricao AS [Dt. Criação]
FROM dbo.Personagem AS P
INNER JOIN dbo.Classe AS C
ON P.idClasse = C.idClasse;

-- Selecionar todos os personagens e as classes (mesmo que elas não tenham correspondência).
SELECT P.idPersonagem, P.nome AS [Personagem], C.nome AS [Classe], P.vida AS [Vida], P.mana AS [Mana], P.dtAtualizacao AS [Dt. Atualização], P.dtCricao AS [Dt. Criação]
FROM dbo.Personagem AS P
LEFT JOIN dbo.Classe AS C
ON P.idClasse = C.idClasse;

-- Selecionar todas as classes e suas respectivas habilidades.
SELECT *
FROM dbo.Classe_Habilidade;

-- Selecionar todas as habilidades e suas classes (somente as que possuem correspondência).
SELECT C.nome AS [Classe], H.nome AS [Habilidade]
FROM dbo.Classe_Habilidade AS CH
INNER JOIN dbo.Classe AS C
ON CH.idClasse = C.idClasse
INNER JOIN dbo.Habilidade AS H
ON CH.idHabilidade = H.idHabilidade;

-- Selecionar todas as habilidades e suas classes (mesmo que elas não tenham correspondência).
SELECT C.nome AS [Classe], H.nome AS [Habilidade]
FROM dbo.Classe_Habilidade AS CH
RIGHT JOIN dbo.Classe AS C
ON CH.idClasse = C.idClasse
LEFT JOIN dbo.Habilidade AS H
ON CH.idHabilidade = H.idHabilidade;