DELETE FROM Admission;
DELETE FROM Patient;
DBCC CHECKIDENT ('Admission', RESEED, 1);




-- Delete all data from the Medecin table
DELETE FROM Medecin;

-- Reseed the identity column to start from 1
DBCC CHECKIDENT ('Medecin', RESEED, 1);
