using System.Numerics;
using Raylib_cs;

Raylib.InitWindow(800, 600, "Slutprojekt");
Raylib.SetTargetFPS(200);

Rectangle[,] boxes = new Rectangle[3, 5];




/*--<][Main Loop][>--------------------------------------------------------------------------------------------------------------------------------------------------------------- 
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- */

for (int x = 0; x < boxes.GetLength(0); x++)
{
  for (int y = 0; y < boxes.GetLength(1); y++)
  {
    Rectangle rect = new(x * 120 + 50, y * 90 + 30, 100, 50);
    boxes[x, y] = rect;
  }

}

while (!Raylib.WindowShouldClose())
{

Vector2 mousePosVect = new Vector2(Raylib.GetMouseX(), Raylib.GetMouseY());


  Raylib.BeginDrawing();
  Raylib.ClearBackground(Color.White);

  for (int x = 0; x < boxes.GetLength(0); x++)
  {
    for (int y = 0; y < boxes.GetLength(1); y++)
    {
      Raylib.DrawRectangleRec(boxes[x, y], Color.Brown);
      if (Raylib.IsMouseButtonPressed(MouseButton.Left) && Raylib.CheckCollisionPointRec(mousePosVect, boxes[x, y]))
      {
        
      }
    }

  } 
  Raylib.EndDrawing();
}