USE Senai_Hroads_Manha;

INSERT INTO dbo.TipoHabilidade(tipo)
VALUES	('Ataque'), 
		('Defesa'), 
		('Cura'), 
		('Magia');

INSERT INTO dbo.Habilidade(nome, idTipoHabilidade)
VALUES	('Lança Mortal', 1), 
		('Escudo Supremo', 2), 
		('Recuperar Vida', 3);

INSERT INTO dbo.Classe(nome)
VALUES	('Bárbaro'), 
		('Cruzado'), 
		('Caçadora de Demônios'), 
		('Monge'), 
		('Necromante'), 
		('Feiticeiro'), 
		('Arcantista');

INSERT INTO dbo.Classe_Habilidade(idClasse, idHabilidade)
VALUES	(1, 1), 
		(1, 2), 
		(2, 2), 
		(3, 1), 
		(4, 3), 
		(4, 2), 
		(6, 3);

INSERT INTO dbo.Personagem(nome, idClasse, vida, mana, dtAtualizacao, dtCricao)
VALUES	('DeuBug', 1, 100, 80, '26/04/2021', '18/01/2019'), 
		('BitBug', 4, 70, 100, '26/04/2021', '17/03/2016'), 
		('Fer8', 7, 75, 60, '26/04/2021', '18/03/2018');