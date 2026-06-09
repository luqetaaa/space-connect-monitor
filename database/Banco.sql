CREATE DATABASE SpaceConnectMonitorDb;
GO

USE SpaceConnectMonitorDb;
GO

DROP TABLE IF EXISTS dbo.EventosEspaciais;
GO

CREATE TABLE dbo.EventosEspaciais (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    NomeEvento NVARCHAR(150) NOT NULL,
    TipoEvento NVARCHAR(100) NOT NULL,
    Regiao NVARCHAR(150) NOT NULL,
    Latitude DECIMAL(9,6) NOT NULL,
    Longitude DECIMAL(9,6) NOT NULL,
    DataDeteccao DATE NOT NULL,
    Intensidade INT NOT NULL,
    NivelRisco INT NOT NULL,
    Classificacao NVARCHAR(50) NOT NULL,
    SensorNome NVARCHAR(100) NOT NULL,
    SensorTipo NVARCHAR(50) NOT NULL,
    ConfiabilidadeSensor DECIMAL(5,2) NOT NULL,
    Status NVARCHAR(100) NOT NULL
);
GO

INSERT INTO dbo.EventosEspaciais
(NomeEvento, TipoEvento, Regiao, Latitude, Longitude, DataDeteccao, Intensidade, NivelRisco, Classificacao, SensorNome, SensorTipo, ConfiabilidadeSensor, Status)
VALUES
('Foco de calor detectado', 'Queimada', 'Amazônia Legal', -3.465300, -62.215900, DATEADD(day,-1,GETDATE()), 86, 100, 'Crítico', 'Aqua-1', 'Satélite', 97.80, 'Ação imediata'),
('Anomalia hídrica', 'Enchente', 'Vale do Itajaí', -26.918700, -49.066100, DATEADD(day,-2,GETDATE()), 78, 93, 'Crítico', 'Sentinel-BR', 'Satélite', 96.50, 'Ação imediata'),
('Baixa umidade extrema', 'Seca', 'Semiárido Nordestino', -8.047600, -39.017100, DATEADD(day,-8,GETDATE()), 70, 75, 'Moderado', 'Aqua-1', 'Satélite', 95.00, 'Monitorar'),
('Desmatamento progressivo', 'Desmatamento', 'Cerrado', -15.780100, -47.929200, DATEADD(day,-4,GETDATE()), 74, 89, 'Crítico', 'Orbital-X', 'Satélite', 94.80, 'Ação imediata'),
('Tempestade severa', 'Clima', 'Região Sul', -30.034600, -51.217700, DATEADD(day,-1,GETDATE()), 68, 83, 'Crítico', 'Sentinel-BR', 'Satélite', 96.10, 'Ação imediata'),
('Movimento de massa', 'Deslizamento', 'Serra do Mar', -23.550500, -46.633300, DATEADD(day,-3,GETDATE()), 62, 77, 'Moderado', 'Rover Terra-2', 'Rover', 91.00, 'Monitorar'),
('Ilha de calor urbana', 'Clima Urbano', 'São Paulo', -23.550500, -46.633300, DATEADD(day,-12,GETDATE()), 54, 59, 'Moderado', 'Orbital-X', 'Satélite', 93.20, 'Monitorar'),
('Baixo risco pluviométrico', 'Clima', 'Centro-Oeste', -16.686900, -49.264800, DATEADD(day,-15,GETDATE()), 32, 37, 'Baixo', 'Aqua-1', 'Satélite', 92.80, 'Observação');
GO
