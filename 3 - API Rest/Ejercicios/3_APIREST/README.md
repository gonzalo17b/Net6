Diseñe y escriba los endpoints que serán utilizados en una API que tendrá estos requisitos.

Una empresa de autobuses quiere que sus clientes puedan acceder a la información de sus viajes.

## Clientes

* Se podrá acceder a una lista de clientes. Esta lista será paginada. Los clientes se podrán editar, borrar y consultar.
* Para poder registrarse, el cliente debe proporcionar:
    * nombre
    * DNI 
    * foto de carnét
    * Teléfono
    * Dirección de email
* Cada cliente solo podrá gestionar sus datos. Un administrador podrá gestionar los datos de cualquier cliente. Reflexionar sobre los códigos de respuesta apropiados en caso de que un cliente intente acceder a los datos de otros clientes.

## Rutas

* Se podrá acceder a un listado de rutas. Cada ruta ofrecerá los siguientes datos:
    * Identificador (L123A)
    * Origen (Pamplona)
    * Destino (Madrid)
* Para cada ruta, se podrán consultar los posibles viajes. Se podrá filtrar por rango de fechas. Estos viajes ofrecerán los siguientes datos:
    * Identificador (4325)
    * Fecha-hora de salida (2022-09-20T10:00:00)
    * Fecha-hora de llegada (2022-09-20T16:30:00)
* Dentro de un viaje, podremos consultar el listado de asientos. Se podrá filtrar por disponibles. Estos asientos, tendrán los siguientes datos:
    * Identificador (15A)
    * Disponibilidad
    * Situación (Pasillo / Ventana / Otro)
    * Espacio amplio para piernas o no

 ## Reservas

 * Se podrá acceder a un listado de reservas para cada cliente, opcionalmente filtrando por fecha
 * La reserva contendrá los datos necesarios para asociar un asiento con un cliente, además de un localizador.
 * Las reservas podrán crearse, borrarse, consultarse y modificarse. Reflexionar sobre qué información deberíamos permitir modificar en una reserva, y cuales serían los códigos de respuesta apropiados.
 * Cada cliente solo podrá gestionar sus reservas. Un administrador podrá gestionar las reservas de cualquier cliente. Reflexionar sobre los códigos de respuesta apropiados en caso de que un cliente intente acceder a las reservas de otros clientes.

## Pasajeros

* Los conductores de autobús y los adiministradores tendrán acceso al listado de pasajeros de un viaje
* Cada pasajero contendrá los datos necesarios para asociar un asiento con un cliente, además del localizador de la reserva
* Los clientes no podrán acceder al listado de pasajeros. Reflexionar sobre el código de respuesta apropiado para este caso.