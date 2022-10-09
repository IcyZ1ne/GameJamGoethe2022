using Godot;
using System;

public class Nivel1 : Node2D
{
    Area2D Monstru;
    ColorRect intuneric;
    KinematicBody2D Caracter3;
    AudioStreamPlayer muzica;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Monstru = (Area2D)GetNode("Golem2");
        intuneric = (ColorRect)GetNode("ColorRect2");
        Caracter3 = (KinematicBody2D)GetNode("Caracter3");
        muzica = (AudioStreamPlayer)GetNode("AudioStreamPlayer");
        muzica.Play();
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        intuneric.Color = new Color(0,0,0,map(Caracter3.GlobalPosition.x,-1803.0f,3103.0f,0.0f,1.0f));
    }

    float map(float x, float in_min, float in_max, float out_min, float out_max) {
        return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
    }

    public void _on_Area2D_body_entered(Area2D area) {
        if (area.Name == "Caracter3") {
            Monstru.Set("Finish",true);
            Monstru.Set("Speed",20);
        }
    }
}
