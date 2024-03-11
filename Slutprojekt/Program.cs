using System.Linq.Expressions;
using System.Numerics;
using Raylib_cs;

Raylib.InitWindow(800, 600, "Slutprojekt");
Raylib.SetTargetFPS(200);

string scene = "hair";


/*--<][Main Loop][>--------------------------------------------------------------------------------------------------------------------------------------------------------------- 
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- */


while (!Raylib.WindowShouldClose())
{
  
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.White);

  if (scene == "hair")
  {
    
    Vector2 mousePosV = new Vector2(Raylib.GetMouseX(), Raylib.GetMouseY());
    Vector2 boxPressedV = new Vector2();

    Boxmaker(3,5);

    // Sparar vilken box du har klickat på
    if (Raylib.IsMouseButtonPressed(MouseButton.Left))
    {
      for (int x = 0; x < resultat.X; x++)
      {
        for (int y = 0; y < boxes.GetLength(1); y++)
        {
          if (Raylib.CheckCollisionPointRec(mousePosV, boxes[x, y]))
          {
            boxPressedV.X = x;
            boxPressedV.Y = y;
          }
        }
      }
    }
  }
  Raylib.EndDrawing();
}

Vector2 Boxmaker(int a, int b)
{
      Rectangle[,] boxes = new Rectangle[a, b];

    for (int x = 0; x < boxes.GetLength(0); x++)
    {
      for (int y = 0; y < boxes.GetLength(1); y++)
      {
        Raylib.DrawRectangleRec(boxes[x, y], Color.Brown);
      }
    }

    for (int x = 0; x < boxes.GetLength(0); x++)
    {
      for (int y = 0; y < boxes.GetLength(1); y++)
      {
        Rectangle rect = new(x * 120 + 50, y * 90 + 30, 100, 50);
        boxes[x, y] = rect;
      }

    }
  Vector2 resultat = new Vector2(a,b);
  return resultat;
}