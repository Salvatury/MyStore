# MyStore

MyStore es una aplicación web desarrollada con **ASP.NET Core MVC**, orientada a la práctica de conceptos como:

- Arquitectura en capas
- CRUD
- Entity Framework Core
- SQL Server
- Razor Views
- Repositorio genérico
- Servicios

## Tecnologías utilizadas

- ASP.NET Core MVC
- C#
- Entity Framework Core
- SQL Server
- Razor
- Bootstrap
- Font Awesome

## Estructura del proyecto

El proyecto está organizado en varias capas:

- **Controllers**: manejan las solicitudes HTTP
- **Servicios**: contienen la lógica de negocio
- **Repositorios**: acceso a datos mediante repositorio genérico
- **Entidades**: modelos de base de datos
- **Models**: ViewModels usados en las vistas
- **Views**: vistas Razor para la interfaz
- **Contexto**: configuración del `DbContext`

## Funcionalidades actuales

### Categorías
- Listado de categorías
- Alta de nuevas categorías
- Validación de campos obligatorios

## Base de datos

La aplicación utiliza **SQL Server** con **Entity Framework Core**.

