-- Insert 3 types of beds
INSERT INTO TypeLit (Description)
VALUES
('Standard'),
('Semi-Priv�'),
('Priv�');

-- Insert beds for P�diatrie (ID_Departement = 1)
INSERT INTO Lit (Occupe, ID_Type, ID_Departement)
VALUES
(0, 1, 1),  -- Standard
(0, 1, 1),  -- Standard
(0, 2, 1),  -- Semi-Priv�
(0, 2, 1),  -- Semi-Priv�
(0, 3, 1);  -- Priv�

-- Insert beds for Cardiologie (ID_Departement = 2)
INSERT INTO Lit (Occupe, ID_Type, ID_Departement)
VALUES
(0, 1, 2),  -- Standard
(0, 1, 2),  -- Standard
(0, 2, 2),  -- Semi-Priv�
(0, 2, 2),  -- Semi-Priv�
(0, 3, 2);  -- Priv�

-- Insert beds for Chirurgie (ID_Departement = 3)
INSERT INTO Lit (Occupe, ID_Type, ID_Departement)
VALUES
(0, 1, 3),  -- Standard
(0, 1, 3),  -- Standard
(0, 2, 3),  -- Semi-Priv�
(0, 2, 3),  -- Semi-Priv�
(0, 3, 3);  -- Priv�

-- Insert beds for Neurologie (ID_Departement = 4)
INSERT INTO Lit (Occupe, ID_Type, ID_Departement)
VALUES
(0, 1, 4),  -- Standard
(0, 1, 4),  -- Standard
(0, 2, 4),  -- Semi-Priv�
(0, 2, 4),  -- Semi-Priv�
(0, 3, 4);  -- Priv�

-- Insert beds for Oncologie (ID_Departement = 5)
INSERT INTO Lit (Occupe, ID_Type, ID_Departement)
VALUES
(0, 1, 5),  -- Standard
(0, 1, 5),  -- Standard
(0, 2, 5),  -- Semi-Priv�
(0, 2, 5),  -- Semi-Priv�
(0, 3, 5);  -- Priv�

-- Insert 4 doctors into the Medecin table
INSERT INTO Medecin (Nom, Prenom)
VALUES
('Lefebvre', 'Marc'),   -- Doctor 1
('Dubois', 'Sophie'),   -- Doctor 2
('Roy', 'Jean-Claude'), -- Doctor 3
('Gagnon', 'Isabelle'); -- Doctor 4
