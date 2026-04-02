# MyStore

MyStore es una aplicación web desarrollada con **ASP.NET Core MVC** como práctica para aprender y afianzar conceptos de desarrollo web con .NET, Razor, Entity Framework Core y SQL Server.

## Funcionalidades actuales

### Módulo Categorías
- Listado de categorías
- Alta de nuevas categorías
- Edición de categorías existentes
- Eliminación de categorías
- Confirmación visual de borrado con **SweetAlert2**
- Validación de campos obligatorios

## Tecnologías utilizadas

- ASP.NET Core MVC
- C#
- Razor Views
- Entity Framework Core
- SQL Server
- Bootstrap
- Font Awesome
- SweetAlert2

## Arquitectura del proyecto

El proyecto está organizado en capas para mantener una mejor separación de responsabilidades:

- **Controllers**: reciben las solicitudes y controlan el flujo de la aplicación
- **Servicios**: contienen la lógica de negocio
- **Repositorios**: acceso a datos mediante repositorio genérico
- **Entidades**: modelos de base de datos
- **Models**: ViewModels utilizados en las vistas
- **Contexto**: configuración del `DbContext`
- **Views**: interfaz construida con Razor

## Funcionalidad implementada hasta el momento

Actualmente el proyecto permite trabajar con categorías mediante una pantalla que incluye:

- botón para crear nuevas categorías
- formulario reutilizable para agregar y editar
- botón para editar registros existentes
- botón para eliminar con confirmación previa
- mensajes de confirmación para operaciones realizadas correctamente

## Base de datos

La aplicación utiliza **SQL Server** junto con **Entity Framework Core** para la persistencia de datos.
