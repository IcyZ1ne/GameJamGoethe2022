using Godot;
using System;

public class Nivel5 : Node2D
{

    AudioStreamPlayer muzica;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        muzica = (AudioStreamPlayer)GetNode("AudioStreamPlayer");
        muzica.Play();
    }

    // // Called every frame. 'delta' is the elapsed time since the previous frame.
    // public override void _Process(float delta)
    // {
        
    // }
}
