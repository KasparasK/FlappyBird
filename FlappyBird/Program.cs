using System;

class Program
{
    static void Main(string[] args)
    {
        Program program = new Program();

        program.RunProgram();

        Console.Clear();
        Console.WriteLine("You Lost! :(");

    }

    void RunProgram()
    {
        Map map = new Map();
        Renderer renderer = new Renderer();
        Movement movement = new Movement();

        bool runProgram = true;

        while (runProgram)
        {
            Console.Clear();
            renderer.Render(map);
            bool allowMovement = movement.WaitForKeyPress();

            if (allowMovement)
            {
                if (movement.CheckForColision(map) == true)
                {
                    runProgram = false;
                }
                else
                {
                    movement.MovePlayer(map);
                    map.MoveMap();
                }
            }
        }
    }

}

