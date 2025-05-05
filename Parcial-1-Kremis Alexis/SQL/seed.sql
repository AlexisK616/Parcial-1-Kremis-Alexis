-- Crear tabla Aerolineas
CREATE TABLE Aerolineas (
    id INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL
);

-- Crear tabla AvionModelos
CREATE TABLE AvionModelos (
    id INT IDENTITY(1,1) PRIMARY KEY,
    detalle VARCHAR(50) NOT NULL
);

-- Crear tabla Vuelos
CREATE TABLE Vuelos (
    id INT IDENTITY(1,1) PRIMARY KEY,
    numeroVuelo INT NOT NULL,
    idAerolinea INT NOT NULL,
    idAvionModelo INT NOT NULL,
    FOREIGN KEY (idAerolinea) REFERENCES Aerolineas(id),
    FOREIGN KEY (idAvionModelo) REFERENCES AvionModelos(id)
);


-- Poblar Aerolineas
SET IDENTITY_INSERT Aerolineas ON;
INSERT INTO Aerolineas (id, nombre) VALUES 
(1, 'Aerolíneas Argentinas'),
(2, 'LATAM'),
(3, 'Sky Airline'),
(4, 'Flybondi'),
(5, 'JetSMART');
SET IDENTITY_INSERT Aerolineas OFF;

-- Poblar AvionModelos
SET IDENTITY_INSERT AvionModelos ON;
INSERT INTO AvionModelos (id, detalle) VALUES
(1, 'Boeing 737'),
(2, 'Airbus A320'),
(3, 'Embraer 190'),
(4, 'Boeing 787'),
(5, 'Airbus A330');
SET IDENTITY_INSERT AvionModelos OFF;

-- Poblar Vuelos (IDs de aerolínea y modelo válidos)
INSERT INTO Vuelos (numeroVuelo, idAerolinea, idAvionModelo) VALUES
(1001, 1, 1),
(1002, 2, 2),
(1003, 3, 3),
(1004, 4, 4),
(1005, 5, 5),
(1006, 1, 2),
(1007, 2, 1),
(1008, 3, 4),
(1009, 4, 3),
(1010, 5, 1);
