using Godot;
using System;

public class Peg : StaticBody2D
{
    // [Export] private string PegColor = "blue";
    [Export] private bool Orange = false;
    private enum Colors {orange, blue, green};
    [Export] private Colors Color = Colors.blue;

    //dirty dirty dirty
    public Sprite peg_blue;
    public Sprite peg_blue_hl;
    public Sprite peg_orange;
    public Sprite peg_orange_hl;
    public Sprite peg_green;
    public Sprite peg_green_hl;
    public Sprite[] peg_sprites;
    public override void _Ready()
    {
        peg_sprites = Globals.GetChildrenOfType<Sprite>(this);
        peg_orange = this.GetNode("peg_orange") as Sprite;
        peg_orange_hl = this.GetNode("peg_orange_hl") as Sprite;
        peg_blue = this.GetNode("peg_blue") as Sprite;
        peg_blue_hl = this.GetNode("peg_blue_hl") as Sprite;
        peg_green = this.GetNode("peg_green") as Sprite;
        peg_green_hl = this.GetNode("peg_green_hl") as Sprite;

        if (this.Orange)
        {
            peg_orange.Visible = true;
        }
    }
    public void SetAllPegsNotVisible(){
        for(int i = 0; i < peg_sprites.Length; i++)
        {
            peg_sprites[i].Visible = false;
        }
    }
    public void Collided()
    {
        this.SetHighlight();
        (this.GetNode("destroy_timer") as Timer).Start();
    }
    public void SetHighlight()
    {
        SetAllPegsNotVisible();
        if (Orange)
        {
            peg_orange_hl.Visible = true;
        } else //then blue
        {
            peg_blue_hl.Visible = true;
        }
    }
    private void _OnDestroyTimeout(){
        this.QueueFree();
    }
}