using Godot;
using System;
using System.Collections.Generic;

public class Globals : Node
{

    private static int SCORE_INC = 100;

    public static bool BallInPlay = false;
    private static int Score = 0;
    public static bool FireBallNextShot = false;
    public static bool GameDone = false;


    public override void _Ready() {
        Reset();
    }


    public static void BallDead()
    {
        Globals.BallInPlay = false;
    }

    public static void Reset(){
        BallInPlay = false;
        Score = 0;
        FireBallNextShot = false;
        GameDone = false;
    }

    private static void ScoreIncrement(){
        Score += SCORE_INC;
    }
    public void UpdateScore(){
        Globals.ScoreIncrement();
        Util.GetNode<ScoreLabel>("/root/Main/ScoreLabel", this).UpdateScore(Globals.Score);
    }

    // public T GetNode<T>(String pathToNode) where T : Node
    // {
    //     return GetNode(pathToNode) as T;
    // }
}