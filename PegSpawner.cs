using Godot;
using System;

public class PegSpawner : Node2D
{
    [Export] private int Rows = 10;
    [Export] private int Columns = 10;
    [Export] private int RowDistance = 100;
    [Export] private int ColumnDistance = 100;
    [Export] private int OrangePegs;

    private PackedScene _pegScene;


    public override void _Ready()
    {
        (this.GetNode("spawner_sprite") as Sprite).Visible = false;
        _pegScene = GD.Load("Peg.tscn") as PackedScene;
        Random randy = new Random();
        int greenCol = randy.Next(Columns);
        int greenRow = randy.Next(Rows);
        for (int i = 0; i < Columns; i++)
        {
            for (int j = 0; j < Rows; j++)
            {
                Peg peg = _pegScene.Instance() as Peg;
                peg.Position = new Vector2(i * RowDistance, j * ColumnDistance);
                this.AddChild(peg);
            }
        }
    }
}