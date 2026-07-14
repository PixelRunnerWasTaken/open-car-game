using Raylib_cs;

namespace HelloWorld;

internal static class Program
{
    // STAThread is required if you deploy using NativeAOT on Windows
    // See https://github.com/raylib-cs/raylib-cs/issues/301
    [System.STAThread]
    public static void Main()
    {
        Raylib.InitWindow(800, 480, "Open Car Game (WORKING TITLE)");

        // menu screen handled through basic switch statement. May be changed later
        int menuScreenIdx = 0;

        while (!Raylib.WindowShouldClose())
        {
            // click to switch menus
            if (Raylib.IsMouseButtonPressed(MouseButton.Left))
            {
                menuScreenIdx++;
            }

            // menu switch
            switch (menuScreenIdx)
            {
                case 0:
                    Raylib.BeginDrawing();
                    Raylib.ClearBackground(Color.Black);

                    Raylib.DrawText("Main menu", 12, 12, 20, Color.Red);

                    Raylib.EndDrawing();
                    break;
                case 1:
                    // very temporary. See, this would normally include some kind of gameplay
                    // involving a car that exists on screen and stuff, but that isn't here yet.
                    Raylib.BeginDrawing();
                    Raylib.ClearBackground(Color.Black);

                    Raylib.DrawText("Game screen", 12, 12, 20, Color.Blue);

                    Raylib.EndDrawing();
                    break;
                default:
                    menuScreenIdx = -1;
                    break;
            }
            
        }

        Raylib.CloseWindow();
    }
}