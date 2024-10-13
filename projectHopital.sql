-- Create the Assurance table first (parent table for Patient and Admission)
CREATE TABLE Assurance (
    ID_Assurance INT PRIMARY KEY,
    nom_compagnie VARCHAR(100) NOT NULL
);

-- Create the Departement table (parent table for Lit)
CREATE TABLE Departement (
    ID_Departement INT PRIMARY KEY,
    nom_departement VARCHAR(100) NOT NULL
);

-- Create the Type_Lit table (parent table for Lit)
CREATE TABLE Type_Lit (
    ID_Type INT PRIMARY KEY,
    description VARCHAR(100) NOT NULL
);

-- Create the Medecin table (parent table for Admission)
CREATE TABLE Medecin (
    ID_Medecin INT PRIMARY KEY,
    nom VARCHAR(50) NOT NULL,
    prenom VARCHAR(50) NOT NULL
);

-- Create the Patient table (references Assurance)
CREATE TABLE Patient (
    NSS CHAR(12) PRIMARY KEY,
    date_naissance DATE NOT NULL,
    nom VARCHAR(50) NOT NULL,
    prenom VARCHAR(50) NOT NULL,
    adresse VARCHAR(100),
    ville VARCHAR(50),
    province VARCHAR(50),
    code_postal CHAR(6),
    telephone VARCHAR(15),
    IDAssurance INT,
    FOREIGN KEY (IDAssurance) REFERENCES Assurance(ID_Assurance)
);

-- Create the Lit table (references Type_Lit and Departement)
CREATE TABLE Lit (
    Numero_Lit INT PRIMARY KEY,
    occupe BIT NOT NULL,
    ID_Type INT,
    ID_Departement INT,
    FOREIGN KEY (ID_Type) REFERENCES Type_Lit(ID_Type),
    FOREIGN KEY (ID_Departement) REFERENCES Departement(ID_Departement)
);

-- Create the Admission table (references Patient, Lit, and Medecin)
CREATE TABLE Admission (
    ID_Admission INT PRIMARY KEY,
    chirurgie_programme BIT,
    date_admission DATE NOT NULL,
    date_chirurgie DATE,
    date_du_conge DATE,
    televiseur BIT,
    telephone BIT,
    NSS CHAR(12),
    Numero_Lit INT,
    ID_Medecin INT,
    FOREIGN KEY (NSS) REFERENCES Patient(NSS),
    FOREIGN KEY (Numero_Lit) REFERENCES Lit(Numero_Lit),
    FOREIGN KEY (ID_Medecin) REFERENCES Medecin(ID_Medecin)
);
