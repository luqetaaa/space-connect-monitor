# SpaceConnect Monitor

## Global Solution 2026 – C# Software Development

### Integrantes

* Lucas Rodrigues de Queiroz
* Felipe Paes de Barros Muller Carioba
* Djalma Moreira de Andrade Filho
* Victor Hugo de Paula
* Matheus Gushi Morioka

---

# 1. Sobre o Projeto

O SpaceConnect Monitor é uma aplicação desenvolvida em C# com ASP.NET Core MVC para simular o monitoramento de eventos ambientais detectados por sensores espaciais.

O sistema registra eventos como queimadas, enchentes, secas e outros fenômenos ambientais, utilizando dados simulados de satélites e sensores terrestres.

A solução demonstra como tecnologias ligadas à indústria espacial podem auxiliar no monitoramento ambiental, prevenção de desastres naturais e suporte à tomada de decisão.

---

# 2. Objetivo da Solução

O projeto tem como objetivo demonstrar a utilização de conceitos de Engenharia de Software e Programação Orientada a Objetos para desenvolver uma plataforma capaz de:

* Registrar eventos ambientais.
* Classificar automaticamente o nível de risco.
* Gerar alertas prioritários.
* Exibir indicadores em dashboard.
* Armazenar dados em banco SQL Server.

---

# 3. Tecnologias Utilizadas

## Backend

* C#
* ASP.NET Core MVC
* ASP.NET Core Web API
* Entity Architecture baseada em Repository Pattern
* Injeção de Dependência

## Banco de Dados

* SQL Server Express
* SQL Server Management Studio (SSMS)

## Frontend

* Razor Views
* HTML5
* CSS3
* JavaScript

## Ferramentas

* Visual Studio 2022/2026
* Swagger/OpenAPI

---

# 4. Conceitos de POO Aplicados

O projeto utiliza diversos conceitos de Programação Orientada a Objetos:

## Encapsulamento

Implementado através das propriedades das entidades.

## Herança

Classe base:

* SensorEspacial

Classes derivadas:

* SateliteSensor
* RoverSensor

## Polimorfismo

Implementado através da sobrescrita dos métodos:

* CalcularConfiabilidade()
* DescreverOrigem()

## Abstração

Utilização da classe abstrata SensorEspacial.

## Interfaces

* IEventoRepository
* ISqlConnectionFactory
* IClassificadorRiscoService
* IAlertaService
* IDashboardService

---

# 5. Estrutura do Projeto

SpaceConnectMonitor

* Controllers
* Data
* Exceptions
* Models
* Services
* ViewModels
* Views
* wwwroot
* Program.cs
* appsettings.json

---

# 6. Banco de Dados

Nome do banco:

SpaceConnectMonitorDb

Tabela principal:

EventosEspaciais

O banco armazena:

* Nome do Evento
* Tipo do Evento
* Região
* Latitude
* Longitude
* Data de Detecção
* Intensidade
* Sensor
* Nível de Risco
* Classificação
* Status

---

# 7. Como Executar o Projeto

## Passo 1 – Clonar ou Extrair

Extrair o arquivo ZIP do projeto.

---

## Passo 2 – Criar o Banco

Abrir o SQL Server Management Studio.

Conectar em:

localhost\SQLEXPRESS

Abrir o arquivo:

database/Banco.sql

Executar utilizando F5.

Verificar se o banco:

SpaceConnectMonitorDb

foi criado com sucesso.

---

## Passo 3 – Abrir o Projeto

Abrir o arquivo:

SpaceConnectMonitor.sln

no Visual Studio.

---

## Passo 4 – Verificar Connection String

Arquivo:

appsettings.json

Connection String:

Server=localhost\SQLEXPRESS;Database=SpaceConnectMonitorDb;Trusted_Connection=True;TrustServerCertificate=True;

---

## Passo 5 – Compilar

Menu:

Compilação → Recompilar Solução

ou

Ctrl + Shift + B

---

## Passo 6 – Executar

Pressionar:

F5

ou

Executar

---

# 8. Funcionalidades

## Dashboard

Apresenta:

* Total de eventos
* Eventos críticos
* Eventos moderados
* Risco médio
* Região mais afetada

## Cadastro de Eventos

Permite registrar:

* Nome do Evento
* Tipo
* Região
* Coordenadas
* Data
* Intensidade
* Sensor

## Classificação de Risco

O sistema classifica automaticamente os eventos em:

* Crítico
* Moderado
* Baixo

## Alertas

Geração automática de alertas prioritários.

---

# 9. API

Swagger disponível em:

/swagger

Endpoints principais:

GET /api/eventos

GET /api/eventos/{id}

POST /api/eventos

GET /api/dashboard/resumo

GET /api/alertas

---

# 10. Tratamento de Exceções

O projeto utiliza exceções customizadas.

Exemplo:

EventoInvalidoException

Validações implementadas:

* Nome obrigatório
* Tipo obrigatório
* Intensidade entre 0 e 100
* Data válida
* Dados obrigatórios do sensor

---

# 11. Limitações Conhecidas

* Utiliza dados simulados.
* Não possui autenticação.
* Não consome APIs espaciais reais.
* Não possui integração com satélites reais.

---

# 12. Trabalhos Futuros

* Integração com APIs da NASA.
* Integração com APIs meteorológicas.
* Uso de Machine Learning para previsão de riscos.
* Sistema de autenticação de usuários.
* Dashboard com gráficos avançados.

---

# 13. Referências

INPE – Instituto Nacional de Pesquisas Espaciais.

https://www.gov.br/inpe

NASA Earth Data.

https://earthdata.nasa.gov

European Space Agency.

https://www.esa.int

FIAP Global Solution 2026 – Space Connect.

Material disponibilizado pela disciplina.

---

# 14. Evidências de Funcionamento

Adicionar:

* Print do Dashboard
* Print do Cadastro
* Print dos Alertas
* Print da API Swagger
* Print do Banco de Dados
