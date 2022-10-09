using Godot;
using System;

public class Nivel1 : Node2D
{
    Area2D Monstru;
    ColorRect intuneric;
    KinematicBody2D Caracter3;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Monstru = (Area2D)GetNode("Golem2");
        intuneric = (ColorRect)GetNode("ColorRect2");
        Caracter3 = (KinematicBody2D)GetNode("Caracter3");
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        
    }

    public void _on_Area2D_body_entered(Area2D area) {
        if (area.Name == "Caracter3") {
            Monstru.Set("Finish",true);
            Monstru.Set("Speed",20);
        }
    }
}
