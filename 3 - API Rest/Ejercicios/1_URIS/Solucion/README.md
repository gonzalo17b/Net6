## Clientes:

Cliente: { id: string, name: string, phoneNumber: string, emailAddress: string, image: string (base64) }

* GET /customers?page={page}&pageSize={pageSize} => 
    * 200 [Cliente] Cabecera paging: { page: number, pageSize: number, total: number, totalPages: number } }
    * 403 (Si no es administrador)
* GET /customers/{id} 
    * 200 Cliente
    * 404 (Si no existe, o es un usuario accediendo a un cliente distinto)
* POST /customers Cliente => 
    * 201 (Si se ha creado correctamente)
    * 400 (Si hay error en los datos)
* PUT /customers/{id} Cliente =>
    * 204 (Si se ha modificado correctamente)
    * 400 (Si hay error en los datos)
    * 404 (Si no existe, o es un usuario accediendo a un cliente distinto)
* DELETE /customers/{id} => 
    * 204 (Si se ha eliminado correctamente)
    * 404 (Si no existe, o es un usuario accediendo a un cliente distinto)

## Rutas:

Ruta: { id: string, origin: string, destination: string }
Viaje: { id: number, departure: string (fecha formato ISO), arrival: string (fecha formato ISO) }
Asiento: { id: string, available: boolean, placement: string (window, isle, other), legroom: string (regular, big) }

* GET /routes => 
    * 200 [Ruta]
* GET /routes/{id}/trips?dateFrom={fecha}&dateTo={fecha} => 
    * 200 [Viaje]
    * 404 (Si la ruta no existe)
* GET /routes/{id}/trips/{id}/seats?available={available} =>
    * 200 [Asiento]
    * 404 (Si la ruta o el viaje no existen)

## Reservas:

Reserva: { id: string, routeId: string, tripId: number, seatId: string, customerId: string }

* GET /customers/{id}/bookings?dateFrom={fecha}&dateTo={fecha} =>
    * 200 [Reserva]
    * 404 (Si el cliente no existe, o es un usuario accediendo a un cliente distinto)
* GET /customers/{id}/bookings/{id}
    * 200 Reserva
    * 404 (Si el cliente o la reserva no existen, o es un usuario accediendo a un cliente distinto)
* POST /customer/{id}/bookings Reserva =>
    * 201 (Si se ha creado correctamente)
    * 400 (Si hay error en los datos, incluso si alguno de los datos referenciados no existen)
    * 404 (Si el cliente no existe, o es un usuario accediendo a un cliente distinto)
* PUT /customers/{id}/bookings/{id} Reserva =>
    * 204 (Si se ha modificado correctamente)
    * 400 (Si hay error en los datos, como haber modificado cualquier cosa que no sea el asiento, o haber elegdo un asiento inexistente)
    * 404 (Si el cliente o la reserva no existen, o es un usuario accediendo a un cliente distinto)
* DELETE /customers/{id}/bookings/{id} => 
    * 204 (Si se ha eliminado correctamente)
    * 404 (Si el cliente o la reserva no existen, o es un usuario accediendo a un cliente distinto)

## Pasajeros

Pasajero: { seatId: string, customerId: string, bookingId: string }

* GET /routes/{id}/trips/{id}/passengers =>
    * 200 [Pasajero]
    * 403 (Si es un cliente intentando acceder al listado de pasajeros)
    * 404 (Si la ruta o el viaje no existen)