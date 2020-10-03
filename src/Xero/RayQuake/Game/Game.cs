using System.Numerics;
using Raylib_cs;

using static Raylib_cs.Raylib;
using static Raylib_cs.CameraType;
using static Raylib_cs.CameraMode;
using static Raylib_cs.Color;

namespace Xero.RayQuake
{
    internal partial class Game
    {
        public int Run()
        {
            InitWindow(Settings.Screen.Width, Settings.Screen.Height, Settings.WindowTitle);

            // Define the camera to look into our 3d world
            var cam = new Camera3D();

            cam.position = new Vector3(10.0f, 10.0f, 10.0f);
            cam.target = new Vector3(0.0f, 0.0f, 0.0f);
            cam.up = new Vector3(0.0f, 1.0f, 0.0f);
            cam.fovy = 45.0f;
            cam.type = (int)CAMERA_PERSPECTIVE;

            Vector3 cubePosition = new Vector3(0.0f, 0.0f, 0.0f);

            Vector2 cubeScreenPosition;

            SetCameraMode(cam, CAMERA_FREE); // Set a free camera mode

            SetTargetFPS(60);                   // Set our game to run at 60 frames-per-second
                                                //--------------------------------------------------------------------------------------

            // Main game loop
            while (!WindowShouldClose())        // Detect window close button or ESC key
            {
                // Update
                //----------------------------------------------------------------------------------
                UpdateCamera(ref cam);          // Update camera

                // Calculate cube screen space position (with a little offset to be in top)
                cubeScreenPosition = GetWorldToScreen(new Vector3(cubePosition.X, cubePosition.Y + 2.5f, cubePosition.Z), cam);
                //----------------------------------------------------------------------------------

                // Draw
                //----------------------------------------------------------------------------------
                BeginDrawing();

                ClearBackground(RAYWHITE);

                BeginMode3D(cam);

                DrawCube(cubePosition, 2.0f, 2.0f, 2.0f, RED);
                DrawCubeWires(cubePosition, 2.0f, 2.0f, 2.0f, MAROON);

                DrawGrid(10, 1.0f);

                EndMode3D();

                DrawText("Enemy: 100 / 100", (int)cubeScreenPosition.X - MeasureText("Enemy: 100 / 100", 20) / 2, (int)cubeScreenPosition.Y, 20, BLACK);
                DrawText("Text is always on top of the cube", (Settings.Screen.Width - MeasureText("Text is always on top of the cube", 20)) / 2, 25, 20, GRAY);

                EndDrawing();
                //----------------------------------------------------------------------------------
            }

            // De-Initialization
            //--------------------------------------------------------------------------------------
            CloseWindow();        // Close window and OpenGL context
            //--------------------------------------------------------------------------------------

            return 0;
        }
    }
}