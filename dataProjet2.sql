-- Insert 3 types of beds
INSERT INTO TypeLit (Description)
VALUES
('Standard'),
('Semi-Privé'),
('Privé');

-- Insert beds for Pédiatrie (ID_Departement = 1)
INSERT INTO Lit (Occupe, ID_Type, ID_Departement)
VALUES
(0, 1, 1),  -- Standard
(0, 1, 1),  -- Standard
(0, 2, 1),  -- Semi-Privé
(0, 2, 1),  -- Semi-Privé
(0, 3, 1);  -- Privé

-- Insert beds for Cardiologie (ID_Departement = 2)
INSERT INTO Lit (Occupe, ID_Type, ID_Departement)
VALUES
(0, 1, 2),  -- Standard
(0, 1, 2),  -- Standard
(0, 2, 2),  -- Semi-Privé
(0, 2, 2),  -- Semi-Privé
(0, 3, 2);  -- Privé

-- Insert beds for Chirurgie (ID_Departement = 3)
INSERT INTO Lit (Occupe, ID_Type, ID_Departement)
VALUES
(0, 1, 3),  -- Standard
(0, 1, 3),  -- Standard
(0, 2, 3),  -- Semi-Privé
(0, 2, 3),  -- Semi-Privé
(0, 3, 3);  -- Privé

-- Insert beds for Neurologie (ID_Departement = 4)
INSERT INTO Lit (Occupe, ID_Type, ID_Departement)
VALUES
(0, 1, 4),  -- Standard
(0, 1, 4),  -- Standard
(0, 2, 4),  -- Semi-Privé
(0, 2, 4),  -- Semi-Privé
(0, 3, 4);  -- Privé

-- Insert beds for Oncologie (ID_Departement = 5)
INSERT INTO Lit (Occupe, ID_Type, ID_Departement)
VALUES
(0, 1, 5),  -- Standard
(0, 1, 5),  -- Standard
(0, 2, 5),  -- Semi-Privé
(0, 2, 5),  -- Semi-Privé
(0, 3, 5);  -- Privé

-- Insert 4 doctors into the Medecin table
INSERT INTO Medecin (Nom, Prenom)
VALUES
('Lefebvre', 'Marc'),   -- Doctor 1
('Dubois', 'Sophie'),   -- Doctor 2
('Roy', 'Jean-Claude'), -- Doctor 3
('Gagnon', 'Isabelle'); -- Doctor 4
