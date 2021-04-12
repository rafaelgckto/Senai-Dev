USE Peoples;

SELECT * 
FROM Funcionario;

SELECT nome, sobrenome
FROM Funcionario
WHERE nome = 'Catarina';

SELECT CONCAT(nome, ' ', sobrenome) AS [Nome Completo]
FROM Funcionario;

SELECT nome, sobrenome
FROM Funcionario
ORDER BY nome ASC;--ASC OU DESC