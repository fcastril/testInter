# testInter
Prueba Técnica para Intergrupo

**Autor:** Fabián Mauricio Castrillón Franco
**Fecha:** 17/03/2021

## Definición de la Prueba Técnica

Se requiere tener un sistema de administración de empleados en el cual se cuente con las siguientes funcionalidades:

**Autenticación de Usuarios.**
Visualización de empleados (Id Empleado, Nombre Empleado, Apellido Empleado, Documento de Identidad y Cargo)
Creación de empleados con Nombre Empleado, Apellido Empleado, Documento de Identidad y Cargo.
Edición de empleados solo se podrá editar Nombre Empleado, Apellido Empleado y Cargo.

**Elementos a tener en cuenta**

El desarrollo debe ser realizado en Angular para el FrontEnd, .Net Core para el desarrollo de la API y SQL Server para la base de datos.
Se evaluara los siguientes temas:
Seguridad
Arquitectura
Comunicación entre componentes
Mediador de comunicación entre FrontEnd y BackEnd.
Patrones Implementados.
Pruebas Unitarias.
Clean Code.

## Solución de la Prueba 

La **Arquitectura** utilizada es ONION, para el BACKEND. Se implementó Swagger para la documentación así como manejo de JWT para la generación de seguridad de acceso al servicio WEB- API Restful.

Para el manejo de base de datos, se utilizo first code, se hace necesario correr el comando **update-database** en **Package Manager Console** este procedimiento crea la base de datos y como usuario por defecto.

La Base de datos es LOCAL -  Necesario tener instalado SQL Server Express.

Email: admon@correo.com
Password: 1234

Estos datos se hacen necesarios para la autenticación, los datos de la tabla **usuarios** de igual forma se encuentran codificados para dificultar el acceso a dicha información.

Para el **FrontEnd** se realizón en angular, para organizar el direccionamiento de la WEBAPI se debe ingresar en el servicio **COMMON** y cambiar allí la ruta de la API.

