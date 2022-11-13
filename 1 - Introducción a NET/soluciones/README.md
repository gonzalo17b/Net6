# SOLUCIONES

## Ejercicio 1

```
dotnet new console -n MyConsole
```

## Ejercicio 2

```
dotnet ejercicio2/DotNetCliEx2.dll

=> "Well Done!"
```

## Ejercicio 3

```
dotnet build ejercicio3/ejercicio3.csproj
```

## Ejercicio 4

```
dotnet clean ejercicio3/ejercicio3.csproj
```

## Ejercicio5

```
dotnet new sln -n ejercicio5
dotnet new console -n ejercicio5.console
dotnet sln ejercicio5.sln add ejercicio5.console/ejercicio5.console.csproj
dotnet build ejercicio5.sln -o dist
dotnet ejercicio5.console/bin/Debug/netcoreapp2.2/ejercicio5.console.dll
```

## Ejercicio 6

El problema de la solución del ejercicio6 es que tiene añadido un proyecto que no existe. Esto lo podemos ver con el comando:

```bash
dotnet sln ejercicio6.sln list
```

Ahí podemos ver que el proyecto añadido que tiene se llama ejercicio6temp.csproj. Para dejarlo todo funcionando correctamente podemos eliminar este proyecto y añadir el proyecto ejercicio6.csproj

```bash
dotnet sln ejercicio6.sln remove ejercicio6temp/ejercicio6temp.csproj
dotnet sln ejercicio6.sln add ejercicio6/ejercicio6.csproj
```

## Ejercicio 7

```bash
dotnet new sln -n ejercicio7.sln
dotnet new classlib -n Net6
dotnet new classlib -f net5 -n Net5
dotnet sln ejercicio7.sln add Net6/Net6.csproj
dotnet sln ejercicio7.sln add Net5/Net5.csproj
dotnet new console -n console
dotnet sln ejercicio7.sln add console/console.csproj
dotnet sln ejercicio7.sln list
```

## Ejercicio 8

```bash
dotnet add console/console.csproj reference netstandardlib/netstandardlib.csproj
```

## Ejercicio 9

```
dotnet new sln -n MiProyecto
dotnet new console -n MiConsola
dotnet new classlib -n MiLibreria
dotnet sln MiProyecto.sln add MiConsola/MiConsole.csproj
dotnet sln MiProyecto.sln add MiLibreria/MiLibreria.csproj
dotnet add MiConsola/MiConsola.csproj reference MiLibreria/MiLibreria.csproj
dotnet list MiConsola/MiConsola.csproj reference
```

## Ejercicio 10

```
dotnet publish MiConsola/MiConsole.csproj -o dist
```

## Ejercicio 11

10. Arregla el sln de la carpeta ejercicio10.

El problema de la solución del ejercicio 10 es que hay una dependencia circular. Si listamos los proyectos nos sale:

```bash
dotnet sln ejercicio10.sln list
Proyectos
---------
console\console.csproj
MiLibreria1\MiLibreria1.csproj
MiLibreria2\MiLibreria2.csproj
```

Si vamos a ver las referencias de los demás proyectos veremos que:

```bash
$ dotnet list console/console.csproj reference
Referencias de proyecto
-----------------------
..\MiLibreria1\MiLibreria1.csproj
..\MiLibreria2\MiLibreria2.csproj

$ dotnet list MiLibreria1/MiLibreria1.csproj reference
Referencias de proyecto
-----------------------
No hay referencias

$ dotnet list MiLibreria2/MiLibreria2.csproj reference
Referencias de proyecto
-----------------------
..\console\console.csproj
```

Por tanto, la librería MiLibreria2 referencia al proyecto de consola y viceversa. Si borramos la dependencia de console en MiLibreria2 quedaría todo solucionado:

```bash
$ dotnet remove MiLibreria2/MiLibreria2.csproj reference ..\console\console.csproj
$ dotnet build ejercicio10.sln
```
