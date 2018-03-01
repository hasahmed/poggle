using Godot;
using System;

public class Main : Node2D
{
    private int OrangePegsLeft = -1;
    [Export] public int BallsLeft = 5;



    public override void _Input(InputEvent input)
    {
        if (input.IsActionPressed("reset"))
        {
            GetTree().ReloadCurrentScene();
            Globals.Reset();
            Globals.GameDone = false;
        }
    }


    public void RegisterOrangePegEntered()
    {
        if (OrangePegsLeft == -1)
        {
            OrangePegsLeft = 1;
        } else
        {
            OrangePegsLeft++;
        }
    }
    public void RegisterOrangePegExited()
    {
        OrangePegsLeft--;
        if (CheckHasWon())
            WinProcedure();
    }

    public void WinProcedure()
    {
        if (!Globals.GameDone)
        {
            Util.GetNode<Sprite>("you_win", this).Visible = true;
            Globals.GameDone = true;
        }
    }

    public bool CheckHasWon()
    {
        if (OrangePegsLeft == 0)
            return true;
        return false;
    }



    public void RegisterBallEntered()
    {
        BallsLeft--;
        Util.GetNode<BallsLeft>("BallsLeft", this).UpdateLabelText();
    }

    public void LoseIfLost()
    {
        if (CheckHasLost())
            LoseProcedure();
    }

    public void LoseProcedure()
    {
        if (!Globals.GameDone)
        {
            Util.GetNode<Sprite>("you_lose", this).Visible = true;
            Globals.GameDone = true;
        }
    }

    public bool CheckHasLost()
    {
        if (BallsLeft <= 0)
            return true;
        return false;
    }



//     }

// //    public override void _Process(float delta)
// //    {
// //        // Called every frame. Delta is time since last frame.
// //        // Update game logic here.
// //        
// //    }
}
