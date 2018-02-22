using Godot;
using System;

public class Peg : StaticBody2D
{
    // [Export] private string PegColor = "blue";
    [Export] private bool Orange = false;

    // public string PegColor {
    //     get {
    //         return _pegColor;
    //     }
    //     set {
    //         _pegColor = value;
    //     }
    // }
    public override void _Ready()
    {
        if (this.Orange)
        {
        ((Sprite)this.GetNode("peg_orange")).Visible = true;
        }
    }
	
	private void _OnPegBodyEntered(Godot.Object body)
	{
		GD.Print("Hello");
	}

}