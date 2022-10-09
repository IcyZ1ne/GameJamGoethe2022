using Godot;
using System;

public class Nivel15 : Node2D
{
    ColorRect intuneric;
    Tween tween;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        intuneric = (ColorRect)GetNode("ColorRect2");
        tween = (Tween)GetNode("Tween");
        intuneric.Visible = true;
        tween.InterpolateProperty(intuneric,"color",new Color(0,0,0,1),new Color(0,0,0,0),1,Tween.TransitionType.Linear,Tween.EaseType.InOut,1);
        tween.Start();
        //blabla
        GetTree().ChangeScene("res://scene/Nivel2.tscn");
    }

    // public override void _Process(float delta)
    // {

    // }
}
