using Godot;
using System;

public class BambooCannon : Sprite
{
    [Export] private int _speed = 200;
    private PackedScene _ballScn;

    public override void _Ready()
    {
        _ballScn = GD.Load("res://Ball.tscn") as PackedScene;
    }


    public override void _Input(InputEvent input)
    {
        // GD.Print("an event");
        if (input.IsActionPressed("drop_ball") && (!Globals.BallInPlay || true) && !Globals.GameDone)
        {
            // GD.Print("A registerd click");
            Ball ball = _ballScn.Instance() as Ball;
            ball.Position = (this.GetNode("_ball_spawner") as Node2D).GlobalPosition;
            var distanceFromMouse = GetGlobalMousePosition() - this.Position;
            var directionVector = distanceFromMouse.Normalized();
            ball.LinearVelocity = directionVector * _speed;
            this.GetNode("/root/Main").CallDeferred("add_child", ball);
        }
    }

    public override void _Process(float delta)
    {
       this.LookAt(this.GetGlobalMousePosition());
    }
}