namespace BusBookingApi.Clientes
{
    using Microsoft.AspNetCore.Mvc;

    public static class ClientEndpointExtenions
    {
        public static WebApplication MapClientEndpoints(this WebApplication app)
        {
            var clientes = new Dictionary<string, Cliente>();
            app.MapGet("/Clientes", (IClientsService service) =>
            {
                //200 => [Cliente] Cabeceras: Paging = { page: 2, pageSize: 10, total: 100, totalPages: 10 }
                //403 => Si no tiene permisos
                return service.GetClientes();
            }).Produces<IEnumerable<Cliente>>(StatusCodes.Status200OK)
            .WithTags("Clientes");

            app.MapGet("/Clientes/{dni}", (string dni, IClientsService service) =>
            {
                //200 => Cliente
                //404 => Si no existe el cliente con el dni
                //404 => Si no tienes permisos, para no informar de que el recurso existe <- esto nada
                Cliente? cliente = service.GetCliente(dni);
                if (cliente is null)
                {
                    return Results.NotFound("No existe un cliente con ese DNI");
                }

                return Results.Ok(cliente);
            }).Produces<Cliente>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithTags("Clientes");

            app.MapPost("/Clientes/{dni}", (string dni, Cliente cliente, IClientsService service) =>
            {
                // 201 => Si se crea correctamente
                // 400 => { errors: { DNI: "La letra no coincide con el numero" } }

                if (cliente.Dni != dni)
                {
                    return Results.BadRequest("El dni no coincide");
                }

                service.CreateCliente(cliente);

                return Results.Created($"/Clientes/{dni}", cliente);
            }).Produces(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithTags("Clientes");

            app.MapPut("/Clientes/{dni}", (string dni, Cliente cliente, IClientsService service) =>
            {
                //204 => Si se modifica correctamente
                //404 => Si no existe el dni
                //400 => Si hay errores de formato en los datos
                //400 / 422 => Si algún dato relacionado no existe
                if (cliente.Dni != dni)
                {
                    return Results.BadRequest("El dni no coincide");
                }

                service.UpdateCliente(cliente);


                return Results.NoContent();
            }).Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status400BadRequest)
            .WithTags("Clientes");

            app.MapDelete("/Clientes/{dni}", (string dni, IClientsService service) =>
            {
                //204 => Si se borra correctamente
                //422 => Si hay entidades relacionadas que impidan el borrado
                //404 => Si no existe el dni

                service.DeleteCliente(dni);

                return Results.NoContent();
            }).Produces(StatusCodes.Status404NotFound)
                .Produces(StatusCodes.Status204NoContent)
                .WithTags("Clientes");

            return app;
        }
    }
}
