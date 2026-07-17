using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;

internal static class Program
{
    // STAThread is required if you deploy using NativeAOT on Windows
    // See https://github.com/raylib-cs/raylib-cs/issues/301
    [System.STAThread]
    public static void Main()
    {
        InitWindow(800, 480, "Open Car Game (WORKING TITLE)");

        // menu screen handled through basic switch statement. May be changed later
        int menuScreenIdx = 0;

        Camera3D camera = new();
        camera.Position = new Vector3(0.0f, 2.5f, 10.0f);
        camera.Target = new Vector3(0.0f, 0.0f, 0.0f);
        camera.Up = new Vector3(0.0f, 1.0f, 0.0f);
        camera.FovY = 45.0f;
        camera.Projection = CameraProjection.Perspective;

        Vector3 cubePosition = new(0.0f, 0.0f, 0.0f);

        SetTargetFPS(60);

        int car = 0;

        while (!WindowShouldClose())
        {
            

            // menu switch
            switch (menuScreenIdx)
            {
                case 0:
                    // click to switch to game screen
                    if (IsMouseButtonPressed(MouseButton.Left))
                    {
                        menuScreenIdx++;
                    }

                    BeginDrawing();
                    ClearBackground(Color.Black);

                    DrawText("Main menu. Click to play", 12, 12, 20, Color.Red);

                    EndDrawing();
                    break;
                case 1:
                    // q to switch to menu screen
                    if (IsKeyDown(KeyboardKey.Q))
                    {
                        menuScreenIdx = 0;
                    }

                    // e to change cars 
                    if (IsKeyPressed(KeyboardKey.E))
                    {
                        car++;
                        if (car > 3)
                        {
                            car = 0;
                        }
                    }

                    // very temporary. See, this would normally include some kind of gameplay
                    // involving a car and stuff, but that isn't here yet.
                    BeginDrawing();
                    ClearBackground(Color.Black);

                    BeginMode3D(camera);

                    // Switch between "cars," represented by color due to lack of models
                    switch(car)
                    {
                        case 0:
                            DrawCube(cubePosition, 2.0f, 1.5f, 3.5f, Color.Red); // eg civic
                            break;
                        case 1:
                            DrawCube(cubePosition, 2.0f, 1.5f, 3.5f, Color.Yellow); // 280zx
                            break;
                        case 2:
                            DrawCube(cubePosition, 2.0f, 1.5f, 3.5f, Color.Green); // gtr
                            break;
                        case 3:
                            DrawCube(cubePosition, 2.0f, 1.5f, 3.5f, Color.Blue); // nsx
                            break;
                    }
                    DrawCubeWires(cubePosition, 2.0f, 1.5f, 3.5f, Color.Black);

                    DrawGrid(10, 1.0f);

                    EndMode3D();

                    DrawText("Game screen. Q to quit to main menu, E to change car", 12, 12, 20, Color.Blue);

                    EndDrawing();
                    
                    break;
                default:
                    menuScreenIdx = -1;
                    break;
            }
            
        }

        CloseWindow();
    }
}