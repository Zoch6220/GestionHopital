use hopital;
go
CREATE TABLE [User] (
    UserId INT PRIMARY KEY IDENTITY(1,1),
    Login VARCHAR(50) NOT NULL,
    Password VARCHAR(50) NOT NULL,
    Nom VARCHAR(50) NOT NULL,
    Prenom VARCHAR(50) NOT NULL,
    Role VARCHAR(20) NOT NULL CHECK (Role IN ('admin', 'medecin', 'prepose')),
    ID_Medecin INT NULL,
    FOREIGN KEY (ID_Medecin) REFERENCES Medecin(ID_Medecin)
);