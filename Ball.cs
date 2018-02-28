using Godot;
using System;

public class Ball : RigidBody2D
{
    // Member variables here, example:
    // private int a = 2;
    // private string b = "textvar";

    public override void _Ready()
    {
        // Called every time the node is added to the scene.
        // Initialization here
        
    }
    private void _on_BallBody_body_entered(Godot.Object otherBody)
    {
        Node2D ob = otherBody as Node2D;
        if (ob.GetName().Contains("Peg"))
        {
            ((Peg)ob).Collided();
        }
    }

//    public override void _Process(float delta)
//    {
//        // Called every frame. Delta is time since last frame.
//        // Update game logic here.
//        
//    }
}
