namespace Novedades.csharp8;

using System;

public class UsingDeclarations
{
    public static void DoDisposableStuff()
    {
        using var resource = new DisposableResource();
        resource.DoStuff();
    }

    private class DisposableResource : IDisposable
    {
        public void DoStuff()
        {
            // Use some disposable resources
        }

        public void Dispose()
        {
            // Dispose something
        }
    }
}
