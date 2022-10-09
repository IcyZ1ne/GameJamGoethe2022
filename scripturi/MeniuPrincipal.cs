using Godot;
using System;

public class MeniuPrincipal : Node2D
{
    Tween tween;
    ColorRect intuneric;
    Label scris;
    Timer timer;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        tween = (Tween)GetNode("Tween");
        intuneric = (ColorRect)GetNode("ColorRect3");
        scris = (Label)GetNode("Label3");
        timer = (Timer)GetNode("Timer");
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }

    public void _on_Button_pressed() {
        intuneric.Visible = true;
        scris.Visible = true;
        WaitTween();
    } 

    async void WaitTween() {
        tween.InterpolateProperty(intuneric,"color",new Color(0,0,0,0),new Color(0,0,0,1),1,Tween.TransitionType.Linear,Tween.EaseType.InOut);
        tween.Start();
        await ToSignal(tween,"tween_all_completed");
        tween.InterpolateProperty(scris,"custom_colors/font_color",new Color(1,1,1,0),new Color(1,1,1,1),1,Tween.TransitionType.Linear,Tween.EaseType.InOut);
        tween.Start();
        await ToSignal(tween,"tween_all_completed");
        timer.Start();
        //GetTree().ChangeScene("res://scene/Nivel1.tscn");
    }

    public void _on_Timer_timeout() {
        GetTree().ChangeScene("res://scene/Nivel1.tscn");
    }
}
