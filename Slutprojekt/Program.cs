
using System.Linq.Expressions;
using System.Numerics;
using Raylib_cs;

Raylib.InitWindow(800, 600, "Slutprojekt");
Raylib.SetTargetFPS(200);

string scene = "start";
bool clicked = false;

bool ultraHardMode = false;
bool extremeHardcoreMode = false;


int clickedBoxX = 0;
int clickedBoxY = 0;

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
    Raylib.DrawText("Pick a box", 310, 40, 30, Color.Black);

    Raylib.DrawText("Use the mouse and click on a box to pick it", 80, 90, 30, Color.Black);


    Raylib.DrawText("If the box turns green you chose correctly", 40, 150, 30, Color.Black);
    Raylib.DrawText("If not then you chose wrong", 170, 185, 30, Color.Black);

    Raylib.DrawText("Press R to Reset and ENTER to begin", 100, 250, 30, Color.Black);
    if (Raylib.IsKeyPressed(KeyboardKey.Enter))
    {
      scene = "game";
    }
  }
  /*--<][Base game][>--------------------------------------------------------------------------------------------------------------------------------------------------------------- 
  ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- */


  if (scene == "game")
  {

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

        Raylib.DrawText("Congrats! You chose correctly!", 170, 250, 30, Color.Green);
        Raylib.DrawText("You have unlocked", 260, 370, 30, Color.Black);
        Raylib.DrawText("ULTRA HARD MODE!!!", 200, 410, 40, Color.Purple);

        Raylib.DrawText("Press H to start ULTRA HARD MODE", 120, 450, 30, Color.Black);

        ultraHardMode = true;
      }
      else
      //Om man clickat fel
      {
        Raylib.DrawRectangleRec(boxes[clickedBoxX, clickedBoxY], Color.Red);

        Raylib.DrawText("Wrong.", 170, 250, 30, Color.Red);
        Raylib.DrawText("Press R to retry", 100, 290, 30, Color.Red);
      }
    }

  }

  /*--<][ULTRA HARD MODE][>--------------------------------------------------------------------------------------------------------------------------------------------------------------- 
  ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- */


  if (scene == "ultra")
  {

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

        Raylib.DrawText("Congrats! You chose correctly!", 170, 260, 30, Color.Green);
        Raylib.DrawText("You can leave now", 260, 360, 30, Color.Black);
        Raylib.DrawText("Unless you want to try the new", 160, 410, 30, Color.Black);
        Raylib.DrawText("EXTREME HARDCORE MODE!!!", 120, 470, 40, Color.Maroon);

        Raylib.DrawText("Press E to start EXTREME HARDCORE MODE", 70, 530, 30, Color.Black);


        extremeHardcoreMode = true;
      }
      else
      //Om man clickat fel
      {
        Raylib.DrawRectangleRec(boxes[clickedBoxX, clickedBoxY], Color.Red);

        Raylib.DrawText("Wrong.", 170, 250, 30, Color.Red);
        Raylib.DrawText("Press R to retry", 100, 290, 30, Color.Red);
      }
    }

  }

  /*--<][EXTREME HARDCORE MODE][>--------------------------------------------------------------------------------------------------------------------------------------------------------------- 
  ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- */

  if (scene == "extreme")
  {
  }
  // movement();






  //Saker som händer när man clickar--------------------------------------------------------------------------------------------------

  if (Raylib.IsKeyPressed(KeyboardKey.R))
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
    scene = "extrme";
    extremeHardcoreMode = false;
    clicked = false;
  }
  Raylib.EndDrawing();
}


