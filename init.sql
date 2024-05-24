CREATE TABLE IF NOT EXISTS Facility (
    Id SERIAL PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    City VARCHAR(100) NOT NULL
);

CREATE TABLE IF NOT EXISTS Patient (
    Id SERIAL PRIMARY KEY,
    First_Name VARCHAR(100) NOT NULL,
    Last_Name VARCHAR(100) NOT NULL,
    Age INTEGER NOT NULL CHECK (age >= 0)
);

CREATE TABLE IF NOT EXISTS Payer (
    Id SERIAL PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    City VARCHAR(100) NOT NULL
);

CREATE TABLE IF NOT EXISTS Encounter (
    Id SERIAL PRIMARY KEY,
    Patient_Id INTEGER NOT NULL,
    Facility_Id INTEGER NOT NULL,
    Payer_Id INTEGER NOT NULL,
    FOREIGN KEY (Patient_Id) REFERENCES Patient(Id),
    FOREIGN KEY (Facility_Id) REFERENCES Facility(Id),
    FOREIGN KEY (Payer_Id) REFERENCES Payer(Id)
);

INSERT INTO Facility (Name, City) VALUES
('Mayo Clinic', 'Rochester'),
('John Hopkins', 'Baltimore'),
('New York-Presbyterian Hospital', 'New York City'),
('UCLA Medical Center', 'Los Ángeles');

INSERT INTO Patient (First_Name, Last_Name, Age) VALUES
('Thomas', 'Harvey', 30),
('Jane', 'Smith', 25),
('Milana', 'Bruce', 12),
('Michael', 'Brown', 50),
('Bruce', 'Davis', 20),
('David', 'Wilson', 60),
('Laura', 'Moore', 35),
('Robert', 'Taylor', 45),
('Linda', 'Anderson', 55),
('James', 'Thomas', 15),
('John', 'Wick', 30);

INSERT INTO Payer (name, city) VALUES
('CHUBB', 'New Jersey'),
('MetLife', 'New York City'),
('AIG', 'New York City'),
('CHUBB 2', 'Rochester'),
('MetLife 2', 'Los Ángeles'),
('AIG 2', 'Baltimore');
('CHUBB 3', 'Rochester'),
('MetLife 4', 'Los Ángeles'),
('AIG 5', 'Baltimore');

INSERT INTO Payer (Name, City) VALUES
('CHUBB', 'New Jersey'),
('MetLife', 'New York City'),
('AIG', 'New York City'),
('CHUBB 2', 'Rochester'),
('MetLife 2', 'Los Ángeles'),
('AIG 2', 'Baltimore'),
('CHUBB 3', 'Rochester'),
('MetLife 4', 'Los Ángeles'),
('AIG 5', 'Baltimore');
	
INSERT INTO Encounter (Patient_Id, Facility_Id, Payer_Id) VALUES
(1, 1, 7),
(1, 1, 7),
(1, 1, 7),
(1, 1, 5),
(1, 1, 5),
(1, 1, 1),
(1, 2, 1),
(1, 3, 1),
(2, 2, 2),
(3, 4, 1),
(3, 4, 2),
(3, 3, 4),
(3, 4, 7),
(3, 3, 6),
(10, 3, 1),
(10, 3, 2),
(10, 3, 4),
(10, 3, 7),
(4, 4, 1),
(5, 2, 2),
(6, 3, 3),
(7, 4, 1),
(8, 2, 2),
(9, 3, 3),
(10, 1, 1),
(1, 1, 1),
(1, 2, 2),
(3, 3, 3),
(4, 1, 1),
(5, 2, 2),
(6, 3, 3),
(7, 4, 1),
(11, 2, 2),
(9, 3, 3),
(11, 1, 1)
(1, 2, 1),
(2, 1, 2),
(3, 1, 3),
(4, 4, 1),
(5, 1, 2),
(6, 3, 3),
(7, 4, 1),
(8, 2, 2),
(9, 3, 3),
(10, 1, 1),
(1, 1, 1),
(1, 2, 2),
(3, 3, 3),
(4, 1, 1),
(5, 2, 2),
(6, 3, 3),
(7, 4, 1),
(11, 2, 2),
(9, 3, 3),
(11, 1, 1)	;
