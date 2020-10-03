using System;
using Xero.RayQuake.Core;

namespace Xero.RayQuake
{
    class Program
    {
        static void Main(string[] args)
        {
            Debug.LogMethod(nameof(Program), nameof(Main));

            new Game().Run();
        }
    }
}
