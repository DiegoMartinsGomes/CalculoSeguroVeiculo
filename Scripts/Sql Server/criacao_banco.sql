CREATE TABLE Segurado(
	Id int IDENTITY(1,1) NOT NULL,
	Nome varchar(100) NOT NULL,
	CPF varchar(11) NOT NULL,
	Idade int NULL,   
    PRIMARY KEY (Id)
)

CREATE TABLE Veiculo (
	Id int IDENTITY(1,1) NOT NULL,
	Marca varchar(80) NOT NULL,
	Modelo varchar(80) NOT NULL,
	Valor decimal(16, 2) NOT NULL,
    PRIMARY KEY (Id)
)

CREATE TABLE Seguro (
	Id int IDENTITY(1,1) NOT NULL,
	IdSegurado int NOT NULL, 
	IdVeiculo int NOT NULL, 
	ValorSeguro decimal(16, 2) NOT NULL,
	DataCalculo datetime NOT NULL,
    PRIMARY KEY (Id),
    FOREIGN KEY (IdSegurado) REFERENCES Segurado(Id),
    FOREIGN KEY (IdVeiculo) REFERENCES Veiculo(Id)
)

