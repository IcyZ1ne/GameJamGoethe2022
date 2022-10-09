using Godot;
using System;

public class Thoughts : Node2D
{
    Tween tween;
    ColorRect colorrect;
    AudioStreamPlayer muzica;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        tween = (Tween)GetNode("Tween");
        colorrect = (ColorRect)GetNode("ColorRect2");
        muzica = (AudioStreamPlayer)GetNode("AudioStreamPlayer");
        muzica.Play();
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        
    }

    public void _on_Area2D_body_entered(Area2D area) {
        tween.InterpolateProperty(colorrect,"color",colorrect.Color,new Color(0,0,0,1),1.0f);
        tween.Start();
        GetTree().ChangeScene("res://scene/Nivel5.tscn");
    }

}
