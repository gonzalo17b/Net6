Usa el proyecto OrderApp que se encuentra en esta sección. Puedes encontrarte algún error que tengas que corregir en la clase ```Product```.

Estos son los requisitos de Producto:

* El nombre debe tener al menos 12 caracteres.
* El precio debe ser 0 o mayor que 0.
* El precio es un entero.
* Un Producto que está fuera de catalogo no podrá ser modificado ni eliminado.

1. Crea un proyecto de TestUnitarios, dentro de una nueva carpeta /test/UnitTests. El proyecto debe ser de tipo XUnit.
2. Realiza los test unitarios de la clase ```Product```. Procura poner todos los casos
3. Ejecuta el comando ```dotnet test -l:html -r htmlresults``` dentro de la carpeta de los tests. ¿Has visto el html de resumen que genera?