USE Peoples;

INSERT INTO Funcionario (nome, sobrenome)
VALUES (
	'Catarina', 'Strada'
), (
	'Tadeu', 'Vitelli'
);

UPDATE Funcionario SET dtNasc = '11/08/1990' WHERE idFuncionario = 1;
UPDATE Funcionario SET dtNasc = '08/03/1991' WHERE idFuncionario = 2;