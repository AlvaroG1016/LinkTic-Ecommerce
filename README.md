#LinkTic Ecommerce
* En el archivo adjunto se encuentra un archivo con extension .sql de nombre Query Creacion Tablas. Este archivo corresponde a la creacion de las tablas necesarias para el correcto funcionamiento del sistema
* Ejecutar el query en SQLServer
* Modificar la cadena de conexión a BD en appsettings.json
  
La aplicación tiene documentación en Swagger, por lo que se podrá acceder a los endpoints de manera más sencilla por dicho medio.
Los endpoints estan protegidos con un Token JWT, a excepcion del servicio de Login y CreateUsuarioAsync.
Utilizar el endpoint CreateUsuarioAsync para crear el primer usuario, posterior a ello realizar el login para obtener el token y poder utilizar el resto de servicios.


