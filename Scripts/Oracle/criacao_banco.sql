CREATE TABLE Segurado(
	Id number NOT NULL,
	Nome varchar(100) NOT NULL,
	CPF varchar(11) NOT NULL,
	Idade number NULL,   
    PRIMARY KEY (Id)
)

CREATE TABLE Veiculo (
	Id number NOT NULL,
	Marca varchar(80) NOT NULL,
	Modelo varchar(80) NOT NULL,
	Valor number(16, 2) NOT NULL,
    PRIMARY KEY (Id)
)

CREATE TABLE Seguro (
	Id number NOT NULL,
	IdSegurado number NOT NULL, 
	IdVeiculo number NOT NULL, 
	ValorSeguro number(16, 2) NOT NULL,
	DataCalculo date NOT NULL,
    PRIMARY KEY (Id),
    FOREIGN KEY (IdSegurado) REFERENCES Segurado(Id),
    FOREIGN KEY (IdVeiculo) REFERENCES Veiculo(Id)
)