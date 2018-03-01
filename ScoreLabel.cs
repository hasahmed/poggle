using Godot;
using System;

public class ScoreLabel : RichTextLabel
{

    private string ScoreString = "SCORE: ";

    public override void _Ready()
    {
        UpdateScore(0);
    }

    public void UpdateScore(int score){
        this.Text = ScoreString + score.ToString();
    }


//    public override void _Process(float delta)
//    {
//        // Called every frame. Delta is time since last frame.
//        // Update game logic here.
//        
//    }
}
