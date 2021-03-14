USE Locadora;
GO

SELECT * FROM Aluguel;
SELECT * FROM Cliente;
SELECT * FROM Empresa;
SELECT * FROM Marca;
SELECT * FROM Modelo;
SELECT * FROM Veiculo;

SELECT C.nome AS [CLIENTE], Mo.nome AS [MODELO], A.dtInicio AS [INICIO], A.dtFim AS [FIM]
FROM Aluguel AS A
INNER JOIN Veiculo AS V
ON A.idVeiculo = V.idVeiculo
INNER JOIN Cliente AS C
ON A.idCliente = C.idCliente
INNER JOIN Modelo AS Mo
ON V.idModelo = Mo.idModelo;

SELECT C.nome AS [CLIENTE], Mo.nome AS [MODELO], A.dtInicio AS [INICIO], A.dtFim AS [FIM]
FROM Aluguel AS A
INNER JOIN Veiculo AS V
ON A.idVeiculo = V.idVeiculo
INNER JOIN Cliente AS C
ON A.idCliente = C.idCliente
INNER JOIN Modelo AS Mo
ON V.idModelo = Mo.idModelo
WHERE C.nome LIKE 'Saulo';