namespace Novedades.csharp8;

using System;
using System.Threading.Tasks;

public class AsynchronousDisposable
{
    public static async Task DoDisposableStuff()
    {
        await using (var resource = new DisposableResource())
        {
            Console.WriteLine("Doing Stuff");
            resource.DoStuff();
            Console.WriteLine("Finished doing Stuff");
        }
    }

    private class DisposableResource : IAsyncDisposable
    {
        public void DoStuff()
        {
            // Use some disposable resources
        }

        public async ValueTask DisposeAsync()
        {
            Console.WriteLine("Disposing...");
            // Dispose something asynchronously
            await Task.Delay(1000);
            Console.WriteLine("Disposed!");
        }
    }
}
