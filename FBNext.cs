using Godot;
using System;

public class FBNext : RichTextLabel
{
    // Member variables here, example:
    // private int a = 2;
    // private string b = "textvar";

    public override void _Ready()
    {
        // Called every time the node is added to the scene.
        // Initialization here
        
    }
    public void DisplayTimed(){
        Util.GetNode<Timer>("FBNextTimer", this).Start();
        this.Visible = true;
    }

    public void _OnTimeout(){
        this.Visible = false;
    }

//    public override void _Process(float delta)
//    {
//        // Called every frame. Delta is time since last frame.
//        // Update game logic here.
//        
//    }
}
