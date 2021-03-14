USE PcLinics;

SELECT * FROM TipoPets;
SELECT * FROM Raca;
SELECT * FROM Dono;
SELECT * FROM Pets;
SELECT * FROM Clinica;
SELECT * FROM Veterinarios;
SELECT * FROM Atendimento;

SELECT C.razaoSocial AS [RAZÃO SOCIAL], V.nome AS [VETERINÁRIO], V.crmv AS [CRMV]
FROM Veterinarios AS V
INNER JOIN Clinica AS C
ON V.idClinica = C.idClinica;

SELECT nome AS [RAÇAS]
FROM Raca
WHERE nome LIKE 'S%';

SELECT nome AS [TIPOS DE PET]
FROM TipoPets
WHERE nome LIKE '%O';

SELECT R.nome AS [RAÇA], D.nome AS [DONO], P.nome AS [NOME DO PET]
FROM Pets AS P
LEFT JOIN Dono AS D
ON P.idDono = D.idDono
LEFT JOIN Raca AS R
ON P.idRaca = R.idRaca;

SELECT V.nome AS [VETERINÁRIO], P.nome AS [NOME DO PET], R.nome AS [RAÇA], TP.nome AS [TIPO DE RAÇA], D.nome AS [DONO], C.razaoSocial AS [Clinica]
FROM Atendimento AS A
INNER JOIN Veterinarios AS V ON A.idVeterinarios = V.idVeterinarios
INNER JOIN Clinica AS C ON V.idClinica = C.idClinica
INNER JOIN Pets AS P ON A.idPets = P.idPets
INNER JOIN Raca AS R ON P.idRaca = R.idRaca
INNER JOIN TipoPets AS TP ON R.idTipoPets = TP.idTipoPets
INNER JOIN Dono AS D ON P.idDono = D.idDono;