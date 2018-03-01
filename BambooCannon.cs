using Godot;
using System;

public class BambooCannon : Sprite
{
    [Export] private int _speed = 200;
    private PackedScene _ballScn;
    [Export] private bool debugShooting = false;

    public override void _Ready()
    {
        _ballScn = GD.Load("res://Ball.tscn") as PackedScene;
    }

    int i = 0;

    public override void _Input(InputEvent input)
    {
        if (input.IsActionPressed("drop_ball") && (!Globals.BallInPlay || debugShooting) && !Globals.GameDone)
        {
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