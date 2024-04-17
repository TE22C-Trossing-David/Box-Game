
using System.Linq.Expressions;
using System.Numerics;
using Raylib_cs;

Raylib.InitWindow(800, 600, "Slutprojekt");
Raylib.SetTargetFPS(200);

string scene = "start";

bool clicked = false;
bool ClickatRätt = false;

int clickedBoxX = 0;
int clickedBoxY = 0;

Vector2 sizePlayer = new Vector2(70, 70);

Vector2 posPlayer = new Vector2(20, 20);
int posPlayerX = 0;
int posPlayerY = 0;

bool BeginExtreme = false;

//-------------------------- TRUE För Testing-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

bool ultraHardMode = true;
bool extremeHardcoreMode = true;
/*--<][Main Loop][>--------------------------------------------------------------------------------------------------------------------------------------------------------------- 
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- */

while (!Raylib.WindowShouldClose())
{
  Raylib.BeginDrawing();
  Raylib.ClearBackground(Color.White);
  /*--<][Start Screen][>--------------------------------------------------------------------------------------------------------------------------------------------------------------- 
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- */

  if (scene == "start")
  {
    //Ritar upp Starttexten
    StartText();

    //Startar Spelet
    if (Raylib.IsKeyPressed(KeyboardKey.Enter))
    {
      scene = "game";
    }
  }
  /*--<][Base game][>--------------------------------------------------------------------------------------------------------------------------------------------------------------- 
  ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- */

  if (scene == "game")
  {
    
    ClickatRätt = false;
    //Sparar muspositionen som en vector2
    Vector2 mousePosV = new Vector2(Raylib.GetMouseX(), Raylib.GetMouseY());

    //Skapar 2d Array eftersom att jag alltid vill ha samma storlek
    Rectangle[,] boxes = new Rectangle[3, 2];

    //Lägger till Boxes i en 2d Array
    for (int x = 0; x < boxes.GetLength(0); x++)
    {
      for (int y = 0; y < boxes.GetLength(1); y++)
      {
        Rectangle rect = new(x * 120 + 50, y * 90 + 30, 100, 50);
        boxes[x, y] = rect;
      }
    }

    //Ritar Boxes
    if (!clicked)
    {
      for (int x = 0; x < boxes.GetLength(0); x++)
      {
        for (int y = 0; y < boxes.GetLength(1); y++)
        {
          Raylib.DrawRectangleRec(boxes[x, y], Color.Brown);
        }
      }
    }

    // Sparar vilken box du har klickat på
    if (Raylib.IsMouseButtonPressed(MouseButton.Left) && !clicked)
    {
      for (int x = 0; x < boxes.GetLength(0); x++)
      {
        for (int y = 0; y < boxes.GetLength(1); y++)
        {
          if (Raylib.CheckCollisionPointRec(mousePosV, boxes[x, y]))
          {
            clickedBoxX = x;
            clickedBoxY = y;
            clicked = true;
          }
        }
      }
    }

    //Efter man clickat
    if (clicked)
    {
      //Om man clickade rätt
      if (clickedBoxX == 2 && clickedBoxY == 1)
      {
        Raylib.DrawRectangleRec(boxes[clickedBoxX, clickedBoxY], Color.Green);
        UltraUnlock();
        ClickatRätt = true;
        ultraHardMode = true;
      }
      else
      //Om man clickat fel
      {
        Raylib.DrawRectangleRec(boxes[clickedBoxX, clickedBoxY], Color.Red);
        FelBox();
      }
    }
  }
  /*--<][ULTRA HARD MODE][>--------------------------------------------------------------------------------------------------------------------------------------------------------------- 
  ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- */

  if (scene == "ultra")
  {
    ClickatRätt = false;
    //Sparar muspositionen som en vector2
    Vector2 mousePosV = new Vector2(Raylib.GetMouseX(), Raylib.GetMouseY());

    //Skapar 2d Array eftersom att jag alltid vill ha den lika stor
    Rectangle[,] boxes = new Rectangle[6, 6];

    //Ritar Boxes
    for (int x = 0; x < boxes.GetLength(0); x++)
    {
      for (int y = 0; y < boxes.GetLength(1); y++)
      {
        Rectangle rect = new(x * 120 + 50, y * 90 + 30, 100, 50);
        boxes[x, y] = rect;
      }
    }

    //Spawnar Boxes i en 2d Array
    if (!clicked)
    {
      for (int x = 0; x < boxes.GetLength(0); x++)
      {
        for (int y = 0; y < boxes.GetLength(1); y++)
        {
          Raylib.DrawRectangleRec(boxes[x, y], Color.Brown);
        }
      }
    }

    // Sparar vilken box du har klickat på
    if (Raylib.IsMouseButtonPressed(MouseButton.Left) && !clicked)
    {
      for (int x = 0; x < boxes.GetLength(0); x++)
      {
        for (int y = 0; y < boxes.GetLength(1); y++)
        {
          if (Raylib.CheckCollisionPointRec(mousePosV, boxes[x, y]))
          {
            clickedBoxX = x;
            clickedBoxY = y;
            clicked = true;
          }
        }
      }
    }

    //Efter man clickat
    if (clicked)
    {
      //Om man clickade rätt
      if (clickedBoxX == 4 && clickedBoxY == 2)
      {
        Raylib.DrawRectangleRec(boxes[clickedBoxX, clickedBoxY], Color.Green);
        ExtremeUnlock();
        ClickatRätt = true;
        extremeHardcoreMode = true;
      }
      else
      //Om man clickat fel
      {
        Raylib.DrawRectangleRec(boxes[clickedBoxX, clickedBoxY], Color.Red);
        FelBox();
      }
    }
  }
  /*--<][EXTREME HARDCORE MODE][>--------------------------------------------------------------------------------------------------------------------------------------------------------------- 
  ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- */

  if (scene == "extreme")
  {
    if (!BeginExtreme)
    {
      ExplainExtreme();
      if (Raylib.IsKeyPressed(KeyboardKey.Enter))
      {
        BeginExtreme = true;
      }
    }
    else
    {
      Raylib.ClearBackground(Color.SkyBlue);
      Vector2 move = Movement();
      posPlayerX = (int)move.X + posPlayerX;
      posPlayerY = (int)move.Y + posPlayerY;
      Vector2 vPosPlayer = new Vector2(posPlayerX, posPlayerY);
      Raylib.DrawRectangleV(vPosPlayer, sizePlayer, Color.Red);
    }
  }
  //Saker som händer när man clickar--------------------------------------------------------------------------------------------------

  if (Raylib.IsKeyPressed(KeyboardKey.R) && !ClickatRätt)
  {
    clicked = false;
  }

  if (Raylib.IsKeyPressed(KeyboardKey.H) && ultraHardMode)
  {
    scene = "ultra";
    ultraHardMode = false;
    clicked = false;
  }

  if (Raylib.IsKeyPressed(KeyboardKey.E) && extremeHardcoreMode)
  {
    scene = "extreme";
    extremeHardcoreMode = false;
    clicked = false;
  }


  static Vector2 Movement()
  {
    int intPosX = 0;
    int intPosY = 0;

    int playerSpeed = 2;

    if (Raylib.IsKeyDown(KeyboardKey.Up) || Raylib.IsKeyDown(KeyboardKey.W))
    {
      intPosY -= playerSpeed;
    }

    if (Raylib.IsKeyDown(KeyboardKey.Down) || Raylib.IsKeyDown(KeyboardKey.S))
    {
      intPosY += playerSpeed;
    }

    if (Raylib.IsKeyDown(KeyboardKey.Left) || Raylib.IsKeyDown(KeyboardKey.A))
    {
      intPosX -= playerSpeed;
    }

    if (Raylib.IsKeyDown(KeyboardKey.Right) || Raylib.IsKeyDown(KeyboardKey.D))
    {
      intPosX += playerSpeed;
    }

    Vector2 returnVector = new Vector2(intPosX, intPosY);
    return returnVector;
  }
  Raylib.EndDrawing();
}

static void StartText()
{
  Raylib.DrawText("Pick a box", 310, 100, 30, Color.Black);
  Raylib.DrawText("Use the mouse and click on a box to pick it", 80, 190, 30, Color.Black);
  Raylib.DrawText("If the box turns green you chose correctly", 40, 280, 30, Color.Green);
  Raylib.DrawText("If not then you chose wrong", 170, 320, 30, Color.Red);
  Raylib.DrawText("Press R to Reset and ENTER to begin", 100, 400, 30, Color.Black);
}

static void FelBox()
{
  Raylib.DrawText("Wrong.", 170, 250, 30, Color.Red);
  Raylib.DrawText("Press R to retry", 100, 290, 30, Color.Red);
}

static void UltraUnlock()
{
  Raylib.DrawText("Congrats! You chose correctly!", 170, 250, 30, Color.Green);
  Raylib.DrawText("You have unlocked", 260, 370, 30, Color.Black);
  Raylib.DrawText("ULTRA HARD MODE!!!", 200, 410, 40, Color.Purple);
  Raylib.DrawText("Press H to start ULTRA HARD MODE", 120, 450, 30, Color.Black);
}

static void ExtremeUnlock()
{
  Raylib.DrawText("Congrats! You chose correctly!", 170, 260, 30, Color.Green);
  Raylib.DrawText("You can leave now", 260, 360, 30, Color.Black);
  Raylib.DrawText("Unless you want to try the new", 160, 410, 30, Color.Black);
  Raylib.DrawText("EXTREME HARDCORE MODE!!!", 120, 470, 40, Color.Maroon);
  Raylib.DrawText("Press E to start EXTREME HARDCORE MODE", 70, 530, 30, Color.Black);
}

static void ExplainExtreme()
{
  Raylib.DrawText("You press E and get launched into the sky!!!", 30, 100, 30, Color.SkyBlue);
  Raylib.DrawText("Use WASD or the arrow keys to move", 80, 190, 30, Color.Black);
  Raylib.DrawText("You can freely move around in the sky", 60, 280, 30, Color.Black);
  Raylib.DrawText("Feel free to move around for as long as you like", 20, 320, 30, Color.Black);
  Raylib.DrawText("Press ENTER to start the game", 100, 400, 30, Color.Black);
  Raylib.DrawText("Press ESC to hit the groumd", 100, 440, 30, Color.Black);
}
