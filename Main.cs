using Godot;
using System;

public class Main : Node2D
{
//     private PackedScene _ballScn;

//     public override void _Ready()
//     {
//         _ballScn = GD.Load("res://Ball.tscn") as PackedScene;
//     }


    public override void _Input(InputEvent input)
    {
        if (input.IsActionPressed("reset"))
        {
            GetTree().ChangeScene("res://Main.tscn");
        }
    }



//     }

// //    public override void _Process(float delta)
// //    {
// //        // Called every frame. Delta is time since last frame.
// //        // Update game logic here.
// //        
// //    }
}
