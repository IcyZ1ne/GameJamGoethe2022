using Godot;
using System;

public class Nivel15 : Node2D
{
    ColorRect intuneric;
    Tween tween;
    Label label;
    Timer timer;
    int prog = 0;
    AudioStreamPlayer muzica;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        label = (Label)GetNode("Label");
        intuneric = (ColorRect)GetNode("ColorRect2");
        tween = (Tween)GetNode("Tween");
        timer = (Timer)GetNode("Timer");
        muzica = (AudioStreamPlayer)GetNode("AudioStreamPlayer");
        muzica.Play();
        intuneric.Visible = true;
        tween.InterpolateProperty(intuneric,"color",new Color(0,0,0,1),new Color(0,0,0,0),1,Tween.TransitionType.Linear,Tween.EaseType.InOut,1);
        tween.Start();
        timer.Start();
        //GetTree().ChangeScene("res://scene/Nivel2.tscn");
    }

    public override void _Process(float delta) {
        if (timer.TimeLeft == 0 && prog == 0) {
            prog++;
            Sprite a = (Sprite)GetNode("Bula");
            a.Visible = false;
            Sprite b = (Sprite)GetNode("Bula2");
            b.Visible = true;
            Label c = (Label)GetNode("Label");
            c.Visible = false;
            Label d = (Label)GetNode("Label2");
            d.Visible = true;

            WaitTween();
        }
    }

    async void WaitTween() {
        tween.InterpolateProperty(intuneric,"color",new Color(0,0,0,0),new Color(0,0,0,1),1,Tween.TransitionType.Linear,Tween.EaseType.InOut,6);
        tween.Start();
        await ToSignal(tween,"tween_all_completed");
        GetTree().ChangeScene("res://scene/Nivel2.tscn");
    }
}
