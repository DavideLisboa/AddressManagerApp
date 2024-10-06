-- Create Usuarios table
CREATE TABLE Usuarios (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nome NVARCHAR(100),
    Usuario NVARCHAR(50),
    Senha NVARCHAR(255)
);

-- Create Enderecos table
CREATE TABLE Enderecos (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Cep NVARCHAR(9),
    Logradouro NVARCHAR(255),
    Complemento NVARCHAR(255) NULL,
    Bairro NVARCHAR(255),
    Cidade NVARCHAR(255),
    Uf NVARCHAR(2),
    Numero NVARCHAR(10),
    UsuarioId INT FOREIGN KEY REFERENCES Usuarios(Id)
);