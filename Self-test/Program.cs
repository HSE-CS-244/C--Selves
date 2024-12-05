// Disable `Unnecessary using directive` and
// `Global using appeared previously` warnings
#pragma warning disable 8019, 8933
using System;
using System.IO;
#pragma warning restore 8019, 8933
using System.Globalization;


public class Program
{
    static void Main(string[] args)
    {
        // Projectwise Culture Locale
        CultureInfo.CurrentCulture = new CultureInfo("ru-RU");

        Console.WriteLine("Hello from Self-test");
    }
}
