using Godot;
using System;

public class BallCatcher : Sprite
{
    // Member variables here, example:
    // private int a = 2;
    // private string b = "textvar";

    public override void _Ready()
    {
        // Called every time the node is added to the scene.
        // Initialization here
        
    }

    public void _OnAreaEntered(Godot.Object otherArea)
    {
        ((Ball)((Node)otherArea).GetParent()).BallWasCaught();
    }

//    public override void _Process(float delta)
//    {
//        // Called every frame. Delta is time since last frame.
//        // Update game logic here.
//        
//    }
}
