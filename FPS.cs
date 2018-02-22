using Godot;
using System;

public class FPS : RichTextLabel
{
    // Member variables here, example:
    // private int a = 2;
    // private string b = "textvar";

    public override void _Ready()
    {
        this.Text = "FPS: ";
        // Called every time the node is added to the scene.
        // Initialization here
        
    }

   public override void _Process(float delta)
   {
       this.Text = "FPS: " + Godot.Engine.GetFramesPerSecond();
   }
}
