# 🛒 MyStore

Aplicación web desarrollada con **ASP.NET Core MVC** como proyecto práctico para aprender y consolidar conceptos de desarrollo web con **.NET**, **Razor**, **Entity Framework Core** y **SQLite**.

---

## ✨ Funcionalidades actuales

### 📁 Módulo Categorías
- Listado de categorías
- Alta de nuevas categorías
- Edición de categorías existentes
- Eliminación de categorías
- Confirmación visual de borrado con **SweetAlert2**
- Validación de campos obligatorios

### 📦 Módulo Productos
- Listado de productos
- Alta de nuevos productos
- Edición de productos existentes
- Eliminación de productos
- Asociación de productos a una categoría
- Subida de imágenes
- Visualización de imágenes en el listado
- Confirmación visual de borrado con **SweetAlert2**

---

## 🛠️ Tecnologías utilizadas

- **ASP.NET Core MVC**
- **C#**
- **Razor Views**
- **Entity Framework Core**
- **SQLite**
- **Bootstrap**
- **Font Awesome**
- **SweetAlert2**

---

## 🧱 Arquitectura del proyecto

El proyecto está organizado en capas para mantener una estructura clara y escalable:

- **Controllers** → reciben las solicitudes y controlan el flujo de la aplicación
- **Servicios** → contienen la lógica de negocio
- **Repositorios** → acceso a datos mediante repositorio genérico
- **Entidades** → modelos de base de datos
- **Models** → ViewModels utilizados en las vistas
- **Contexto** → configuración del `DbContext`
- **Views** → interfaz construida con Razor
- **wwwroot** → recursos estáticos e imágenes

---

## 🚀 Funcionalidades implementadas

Actualmente el sistema permite trabajar con:

### Categorías
- Crear categorías
- Editar categorías
- Eliminar categorías
- Mostrar mensajes de confirmación

### Productos
- Crear productos
- Editar productos
- Eliminar productos
- Asociar productos a una categoría
- Subir imagen del producto
- Mostrar imagen en el listado
- Confirmar eliminación antes de borrar

---

## 🗄️ Base de datos

La aplicación utiliza **SQLite** junto con **Entity Framework Core** para la persistencia de datos.

La cadena de conexión se configura en:

```json
appsettings.json
