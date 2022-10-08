using Godot;
using System;

public class monstru : Area2D
{
    [Export]
    private NodePath TintaPath;
    KinematicBody2D Tinta;
    private float Speed = .5f;
    private float Time = 0f;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready() {
        Tinta = GetNode<KinematicBody2D>(TintaPath);
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta) {
        Time += delta;
        Speed += 0.003f;
        this.GlobalPosition = this.GlobalPosition.LinearInterpolate(new Vector2(Tinta.GlobalPosition.x,Tinta.GlobalPosition.y-(GetSine()*50)-100),Speed*delta);
    }

    float GetSine() {
        return Mathf.Sin(Time * 3) * 1;
    }


    public void _on_Area2D_body_entered(Area2D area) {
        GD.Print("lets");
    }
}
