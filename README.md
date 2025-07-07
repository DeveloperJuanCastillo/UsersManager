# 👤 UserManagement

Aplicación web para la gestión de usuarios, construida con arquitectura en capas utilizando .NET y Razor Pages. Permite crear, consultar, actualizar y eliminar usuarios (CRUD), conectada a una base de datos SQL Server.

---

## 🎯 Objetivo

El objetivo de este proyecto es demostrar el uso de buenas prácticas de desarrollo en .NET Core, aplicando una arquitectura por capas, separación de responsabilidades, consumo de servicios REST y uso de Entity Framework o procedimientos almacenados para el acceso a datos.

---

## 🧰 Tecnologías utilizadas

- 🔹 ASP.NET Core 8 con Razor Pages (Frontend)
- 🔹 ASP.NET Core Web API (Capa intermedia)
- 🔹 SQL Server (Base de datos relacional)
- 🔹 Procedimientos almacenados (CRUD)
- 🔹 Bootstrap 5 + Bootstrap Icons (Estilo)
- 🔹 C# y Entity Framework Core (opcional, si lo usaste)
- 🔹 Inyección de dependencias (DI)
- 🔹 Git y GitHub (control de versiones)

---

## 🖼️ Funcionalidades

- ✔ Crear usuario con validaciones
- ✔ Listar usuarios en una tabla con acciones
- ✔ Editar información de usuario
- ✔ Eliminar usuario con confirmación
- ✔ Conexión a base de datos local o en Azure
- ✔ Diseño limpio y profesional

---

## 🚀 Cómo ejecutar el proyecto localmente

### 📦 Requisitos previos

- [.NET SDK 8.0](https://dotnet.microsoft.com/download)
- SQL Server (LocalDB, Express o completo)
- Visual Studio 2022+ o VS Code

🧱 Configuración de la base de datos
Asegúrate de tener SQL Server LocalDB o SQL Server Express instalado.

Abre SQL Server Management Studio (SSMS) o Azure Data Studio.

Ejecuta el script ubicado en:
👉 Database/init.sql

Verifica que se haya creado la base de datos y la tabla Users.
---
