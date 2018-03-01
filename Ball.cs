using Godot;
using System;

public class Ball : RigidBody2D
{
    private int KILLZ = 1000;
    public bool IsFireBall = false;


    public override void _Ready()
    {
        Util.GetNode<Main>("/root/Main", this).RegisterBallEntered();
        Globals.BallInPlay = true;
        if (Globals.FireBallNextShot)
        {
            Util.GetNode<Node>("collision_shape", this).QueueFree();
            this.IsFireBall = true;
            Util.GetNode<Sprite>("fire_ball", this).Visible = true;
        }
    }

    private void InitilizeFireBall()
    {
        Util.GetNode<Node>("collision_shape", this).QueueFree();
        this.IsFireBall = true;
        Util.GetNode<Sprite>("fire_ball", this).Visible = true;
    }


    public override void _Process(float delta){
        if (this.Position.y >= KILLZ)
        {
            Util.GetNode<Main>("/root/Main", this).LoseIfLost();
            Globals.BallDead();
            if (this.IsFireBall)
                Globals.FireBallNextShot = false;
            this.QueueFree();
        }
    }

    public void BallWasCaught()
    {
        Util.GetNode<Main>("/root/Main", this).BallsLeft++;
        Util.GetNode<BallsLeft>("/root/Main/BallsLeft", this).UpdateLabelText();
        Globals.BallDead();
        if (this.IsFireBall)
            Globals.FireBallNextShot = false;
        this.QueueFree();
    }

    private void _on_BallBody_body_entered(Godot.Object otherBody)
    {
        Node2D ob = otherBody as Node2D;
        if (ob.GetName().Contains("Peg"))
        {
            ((Peg)ob).Collided();
        }
    }
    public void _OnAreaEntered(Godot.Object otherArea)
    {
        if (this.IsFireBall)
        {
            Node2D ob = otherArea as Node2D;
            if (ob.GetParent().GetName().Contains("Peg"))
            {
                ((Peg)ob.GetParent()).Collided();
            }
        }
    }
}
