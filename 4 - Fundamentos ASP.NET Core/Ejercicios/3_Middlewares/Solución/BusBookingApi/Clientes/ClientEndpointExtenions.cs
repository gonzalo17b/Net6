
namespace BusBookingApi.Clientes
{
    public static class ClientEndpointExtenions
    {
        public static WebApplication MapClientEndpoints(this WebApplication app)
        {
            var clientes = new Dictionary<string, Cliente>();
            app.MapGet("/Clientes", () =>
            {
                //200 => [Cliente] Cabeceras: Paging = { page: 2, pageSize: 10, total: 100, totalPages: 10 }
                //403 => Si no tiene permisos
                return clientes.Values;
            });

            app.MapPost("/Clientes/{dni}", (string dni, Cliente cliente) =>
            {
                // 201 => Si se crea correctamente
                // 400 => { errors: { DNI: "La letra no coincide con el numero" } }

                if (cliente.Dni != dni)
                {
                    return Results.BadRequest("El dni no coincide");
                }

                clientes.Add(dni, cliente);
                return Results.Created($"/Clientes/{dni}", cliente);
            });

            app.MapGet("/Clientes/{dni}", (string dni) =>
            {
                //200 => Cliente
                //404 => Si no existe el cliente con el dni
                //404 => Si no tienes permisos, para no informar de que el recurso existe <- esto nada
                Cliente? cliente = null;
                if (!clientes.TryGetValue(dni, out cliente))
                {
                    return Results.NotFound("No existe un cliente con ese DNI");
                }

                return Results.Ok(cliente);
            });


            app.MapPut("/Clientes/{dni}", (string dni, Cliente cliente) =>
            {
                //204 => Si se modifica correctamente
                //404 => Si no existe el dni
                //400 => Si hay errores de formato en los datos
                //400 / 422 => Si algún dato relacionado no existe
                if (cliente.Dni != dni)
                {
                    return Results.BadRequest("El dni no coincide");
                }

                Cliente? oldCliente = null;
                if (!clientes.TryGetValue(dni, out oldCliente))
                {
                    return Results.NotFound("No existe un cliente con ese DNI");
                }

                clientes[dni] = cliente;

                return Results.NoContent();
            });

            app.MapDelete("/Clientes/{dni}", (string dni) =>
            {
                //204 => Si se borra correctamente
                //422 => Si hay entidades relacionadas que impidan el borrado
                //404 => Si no existe el dni
                if (!clientes.ContainsKey(dni))
                {
                    return Results.NotFound("No existe un cliente con ese DNI");
                }

                clientes.Remove(dni);

                return Results.NoContent();
            });

            return app;
        }
    }
}
