using Godot;
using System;

public class Peg : StaticBody2D
{
    private enum Colors {orange, blue, green};
    [Export] private Colors Color = Colors.blue;

    public Sprite[] peg_sprites;
    private Globals globals;

    public override void _Ready()
    {
        globals = GetNode("/root/Globals") as Globals;
        peg_sprites = Util.GetChildrenOfType<Sprite>(this);
        this.SetColor(Color);
    }
    public override void _ExitTree()
    {
        if (this.Color == Colors.green)
        {
            Globals.FireBallNextShot = true;
            Util.GetNode<FBNext>("/root/Main/FBNext", this).DisplayTimed();
        } else if (this.Color == Colors.orange)
        {
            Util.GetNode<Main>("/root/Main", this).RegisterOrangePegExited();
        }
        
        globals.UpdateScore();
    }

    public override void _EnterTree()
    {
        if (this.Color == Colors.orange)
            Util.GetNode<Main>("/root/Main", this).RegisterOrangePegEntered();
    }

    private Sprite GetSpriteOfColor(Colors color)
    {
        switch (color)
        {
            case Colors.blue:
                return this.GetNode("peg_blue") as Sprite;
            case Colors.orange:
                AddToGroup("orange_peg");
                return this.GetNode("peg_orange") as Sprite;
            case Colors.green:
                return this.GetNode("peg_green") as Sprite;
        }
        throw new SystemException();
    }
    private Sprite GetSpriteHightlightOfColor(Colors color)
    {
        switch (color)
        {
            case Colors.blue:
                return this.GetNode("peg_blue_hl") as Sprite;
            case Colors.orange:
                return this.GetNode("peg_orange_hl") as Sprite;
            case Colors.green:
                return this.GetNode("peg_green_hl") as Sprite;
        }
        throw new SystemException();
    }

    private void SetColor(Colors color)
    {
        this.SetAllPegsNotVisible();
        this.GetSpriteOfColor(color).Visible = true;
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
        GetSpriteHightlightOfColor(this.Color).Visible = true;
    }

    private void _OnDestroyTimeout(){
        this.QueueFree();
    }
}