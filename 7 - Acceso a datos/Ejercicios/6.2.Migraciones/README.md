1. En el proyecto BusBookingApi de los módulos anteriores, separa el modelo de datos del recurso Cliente que expone el API del modelo de negocio que emplearemos para almacenar los clientes en la BBDD.
2. Haz que el servicio emplee el modelo de datos (de momento, no hace falta que accedas a la base de datos, basta con emplear ese modelo y almacenarlo en memoria).
3. Añade la configuración de la tabla de clientes, y haz que se aplique sobre el DbContext.
4. Añade el DbSet de clientes al DbContext.
5. Genera una migración que cree la tabla de clientes.
6. Aplica la migración sobre la base de datos empleando el CLI.