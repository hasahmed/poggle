using Godot;
using System;

public class BallsLeft : RichTextLabel
{
    // Member variables here, example:
    // private int a = 2;
    // private string b = "textvar";
    private Main main;
    private string labelText = "Balls Left: ";

    public override void _Ready()
    {
        main = Util.GetNode<Main>("/root/Main", this);
        this.Text = labelText + main.BallsLeft;
    }

    public void UpdateLabelText()
    {
        this.Text = labelText + main.BallsLeft;
    }

//    public override void _Process(float delta)
//    {
//        // Called every frame. Delta is time since last frame.
//        // Update game logic here.
//        
//    }
}
