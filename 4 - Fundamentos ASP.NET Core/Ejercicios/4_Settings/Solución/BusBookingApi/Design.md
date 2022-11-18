## Cliente
Cliente: { nombre: string, dni: string, foto: string (base64), email: string, telefono: string }
GET /clientes?page=2&pageSize=10
    200 => [Cliente] Cabeceras: Paging = { page: 2, pageSize: 10, total: 100, totalPages: 10 }
    403 => Si no tiene permisos
GET /clientes/dni
    200 => Cliente
    404 => Si no existe el cliente con el dni
    404 => Si no tienes permisos, para no informar de que el recurso existe
POST /clientes/dni Cliente
    201 => Si se crea correctamente
    400 => { errors: { DNI: "La letra no coincide con el numero" }}
PUT /clientes/dni Cliente
    204 => Si se modifica correctamente
    404 => Si no existe el dni
    400 => Si hay errores de formato en los datos
    400/422 => Si algún dato relacionado no existe
DELETE /clientes/dni
    204 => Si se borra correctamente
    422 => Si hay entidades relacionadas que impidan el borrado
    404 => Si no existe el dni
## Ruta
Ruta: { identificador: string, origen: string, destino: string }
Viaje: { identificador: number, salida: string (ISO), llegada: string (ISO) }
Asiento: { identificador: string, disponibilidad: booleano, situacion: string (Pasillo, Venta, Otro), espacio: string (Normal, Amplio) }
GET /rutas
    200 => [Ruta]
GET /rutas/L123/viajes?salidaDesde=2022-09-27T10:00:00&salidaHasta=2022-09-27T17:00:00Z
    200 => [Viaje]
GET /rutas/L123/viajes/1234/asientos?disponible=true
    200 => [Asiento]
## Reservas
Reserva: { localizador: string, identificadorRuta: string, identificadorViaje: number, identificadorAsiento: string, dniCliente: string }
GET /clientes/dni/reservas?salidaDesde=2022-09-27T10:00:00&salidaHasta=2022-09-27T17:00:00Z&identificadorRuta=L123
    200 => [Reserva]
    404 => Si no existe dni, o si es un cliente accediendo a otro
GET /clientes/dni/reservas/localizador
    200 => Reserva
    404 => Si no existe dni o el localidor, o si es un cliente accediendo a otro
## Pasajeros
Pasajero: { dniCliente: string, identificadorAsiento: string, localizadorReserva: string }
GET /rutas/L123/viajes/1234/pasajeros
    200 => [Pasajero]