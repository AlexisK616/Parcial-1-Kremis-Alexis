-- Crear la base de datos (opcional)
-- CREATE DATABASE MiBaseDeDatos;
-- USE MiBaseDeDatos;

-- Crear la tabla EmpleadoSectores
CREATE TABLE EmpleadoSectores (
    id INT PRIMARY KEY IDENTITY(1,1),
    nombre VARCHAR(50) NOT NULL
);

-- Crear la tabla Empleados
CREATE TABLE Empleados (
    id INT PRIMARY KEY IDENTITY(1,1),
    apellido VARCHAR(50) NOT NULL,
    nombre VARCHAR(50) NOT NULL,
    id_sector INT NOT NULL,
    FOREIGN KEY (id_sector) REFERENCES EmpleadoSectores(id)
);

-- Insertar datos en la tabla EmpleadoSectores
INSERT INTO EmpleadoSectores (nombre)
VALUES 
('Recursos Humanos'),  -- id = 1
('Finanzas'),          -- id = 2
('Tecnología'),        -- id = 3
('Marketing'),         -- id = 4
('Ventas'),            -- id = 5
('Atención al Cliente'),-- id = 6
('Logística'),         -- id = 7
('Investigación y Desarrollo'), -- id = 8
('Producción'),        -- id = 9
('Calidad');          -- id = 10

-- Insertar datos en la tabla Empleados
INSERT INTO Empleados (apellido, nombre, id_sector)
VALUES 
('Pérez', 'Juan', 1),          -- Juan Pérez en Recursos Humanos
('López', 'María', 2),         -- María López en Finanzas
('González', 'Carlos', 3),     -- Carlos González en Tecnología
('Rodríguez', 'Ana', 4),       -- Ana Rodríguez en Marketing
('Sánchez', 'Laura', 5),       -- Laura Sánchez en Ventas
('Martínez', 'José', 6),       -- José Martínez en Atención al Cliente
('Hernández', 'Pedro', 7),     -- Pedro Hernández en Logística
('Fernández', 'Lucía', 8),     -- Lucía Fernández en I+D
('Díaz', 'Francisco', 9),      -- Francisco Díaz en Producción
('Ramírez', 'Clara', 10),       -- Clara Ramírez en Calidad
('Torres', 'Javier', 1),        -- Javier Torres en Recursos Humanos
('Morales', 'Mónica', 3),       -- Mónica Morales en Tecnología
('Castillo', 'Andrés', 2);      -- Andrés Castillo en Finanzas
