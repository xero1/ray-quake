using System;
using System.Collections.Generic;
using System.Text;

namespace Xero.RayQuake
{
    internal partial class Game
    {
        public static class Settings
        {
            public static string WindowTitle { get; } = nameof(RayQuake);

            public static class Screen
            {
                public static int Width { get; } = 800;
                public static int Height { get; } = 450;
            }
        }
    }
}
