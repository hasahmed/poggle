using Godot;
using System;
using System.Collections.Generic;

public class Globals : Node
{

    private static int SCORE_INC = 100;

    public static bool BallInPlay = false;
    public static int BallsPlayed = 0;
    private static int Score = 0;
    public static bool FireBallNextShot = false;
    public static bool GameDone = false;


    public override void _Ready() {
    }

//    public override void _Process(float delta)
//    {
//        // Called every frame. Delta is time since last frame.
//        // Update game logic here.
//        
//    }

    public static void BallDead()
    {
        Globals.BallInPlay = false;
        Globals.BallsPlayed++;
    }

    public static void Reset(){
        BallInPlay = false;
        BallsPlayed = 0;
        Score = 0;
        FireBallNextShot = false;
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